using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_simulation
{
    public partial class MainFrame : Form
    {

        // Init time parameters
        double Time_Global = 0;
        double accumulatedTime, totalAccumulatedTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
        double realdt;
        double dt = 0.01;

        // origin cordinates
        int o_x = 400;
        int o_y = 400;

        // bounds
        int simulation_bound = 400;

        // lists containing vehicles
        List<Vehicle> vehicles = new List<Vehicle>();
        List<Vehicle> vehicles_relevant = new List<Vehicle>();
        List<Vehicle> vehicles_ghost = new List<Vehicle>();

        // vehicle spawn parameters
        double spawn_speed = 10; // spawn speed
        int spawn_ID = 0; // vehicle spawn ID
        int last_ID = 0; // last ID (for the ghost vehicle)
        string last_spawn = ""; // last spawn position
        string last_target = ""; // last spawn target
        bool random_target = true; // toggle random target

        // statistical vehicle paramters
        double speed_total; // total vehicle speed
        double speed_average; // average vehicle speed
        int n_vehicles; // number of cars driving towards the intersection

        // margin parameters (AIM)
        double speed_limit = 20; // vehicle upp speed limit
        double T_margin = 2;
        double distMargin = 20;

        // trajectory-intersection model
        int[,] trajectory_model = new int[,] {
                { 1,1,1,0,1,0,0,0,1,0,0,0 },
                { 1,1,1,0,1,1,0,0,1,1,1,1 },
                { 1,1,1,0,1,1,1,1,1,0,1,1 },
                { 0,0,0,1,1,1,0,1,0,0,0,1 },
                { 1,1,1,1,1,1,0,1,1,0,0,1 },
                { 0,1,1,1,1,1,0,1,1,1,1,1 },
                { 0,0,1,0,0,0,1,1,1,0,1,0 },
                { 0,0,1,1,1,1,1,1,1,0,1,1 },
                { 1,1,1,0,1,1,1,1,1,0,1,1 },
                { 0,1,0,0,0,1,0,0,0,1,1,1 },
                { 0,1,1,0,0,1,1,1,1,1,1,1 },
                { 0,1,1,1,1,1,0,1,1,1,1,1 },
            };

        // visual parameters
        bool show_ghost = false; // show ghost vehicles toggle
        bool zoom = false; // show zoom
        int zoomFactor = 1; // zoom factor
        int zoomValue = 10;
        int laneWidth = 8; // lane width, meters

        // graphics

        float[] dashValues = { 4, 6 };
        Pen p_dashed = new Pen(Color.White, 1);
        Pen p_thin = new Pen(Color.White, 1);
        Pen p_roads = new Pen(Color.LightGray, 16);
        Pen p_road = new Pen(Color.Black, 1);
        Pen p_car = new Pen(Color.Red, 4);
        Pen p_car_g = new Pen(Color.Gray, 4);
        Pen p_bus = new Pen(Color.Red, 5);
        Pen p_bus_g = new Pen(Color.Gray, 5);
        Graphics g;
        bool init = false;

        
        Bitmap bm = new Bitmap(1000, 1000);

    
        // random operator 
        Random rnd = new Random();

        public MainFrame()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            // update time passed dt
            realdt = DateTime.Now.TimeOfDay.TotalMilliseconds - totalAccumulatedTime;
            totalAccumulatedTime += realdt;
            accumulatedTime += realdt;

            

            // Console.Write("accumulatedTime : " + totalAccumulatedTime / 1000);
            if (true)//accumulatedTime > 500)
            {
                if (zoom)
                    zoomFactor = zoomValue;
                else
                    zoomFactor = 1;

                // origin cordinates
                o_x = 400 / zoomFactor;
                o_y = 400 / zoomFactor;


                // add the vehicles to the list that will be get speed requests
                apply_trafficmanager();

                // perform actions on each car (choose a controller)
                controller_distance();

                // remove vehicles out of bounds
                remove_vehicles();

                accumulatedTime = 0;

            }
                // update global timer
                label6.Text = "Time: " + Convert.ToString(Time_Global.ToString("0.0"));
                Time_Global += realdt / 1000;

            // clear graphics
            clear_graphics();
            
            // draw the environment
            draw_road();

            // update vehicle states
            foreach (Vehicle vehicle in vehicles)
            {
                // update vehicle state
                vehicle.update_state();

                // draw vehicle
                draw_vehicle(vehicle);
            }

            // update vehicle states (ghost vehicles)
            foreach (Vehicle vehicle in vehicles_ghost)
            {
                vehicle.update_state();
                if (show_ghost) draw_vehicle(vehicle);
            }

         
            // update image
            pictureBox1.Image = bm;


        }

        private void apply_trafficmanager()
        {
            vehicles_relevant.Clear();
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.passed == false) // 
                {
                    vehicles_relevant.Add(vehicle);
                    //speed_total += vehicle.speed;
                }
            }

            vehicles_relevant = vehicles_relevant.OrderBy(vehicle => vehicle.dist).ToList(); // add relevant vehicles (sorted)

            n_vehicles = vehicles_relevant.Count();
            speed_average = speed_total / n_vehicles;
        }

        private void controller_time_only()
        {
            for (int i = 0; i < vehicles_relevant.Count - 1; i++)
            {
                double T_diff = vehicles_relevant[i + 1].T - vehicles_relevant[i].T;

                if (T_diff <= T_margin) // time limit
                {
                    if (vehicles_relevant[i + 1].speed_request >= 0.3) vehicles_relevant[i + 1].speed_request -= 0.2;
                    if (vehicles_relevant[i].speed_request < 40) vehicles_relevant[i].speed_request += 0.1;
                }
                else
                {
                    if (vehicles_relevant[i + 1].speed_request < 40) vehicles_relevant[i].speed_request += 0.2;
                }
            }
            if (vehicles_relevant.Count == 1 && vehicles_relevant[0].speed_request < 40) vehicles_relevant[0].speed_request += 0.3;

        }

        private void controller_distance()
        {
            for (int i = vehicles_relevant.Count - 1; i >= 0; i--)
            {
                // set speed request to the speed limit
                vehicles_relevant[i].speed_request = speed_limit;
                if (vehicles_relevant.Count() >= 2)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        // if collision risk with vehicle, adjust speed (probes through all vehicles with distance in descending order)
                        if (vehicles_relevant[j].passed == false && collision_risk(vehicles_relevant[i], vehicles_relevant[j]) == true)
                        {
                            double Tj = vehicles_relevant[j].dist / vehicles_relevant[j].speed_request;
                            if (vehicles_relevant[i].dist - distMargin >= 0)
                            {
                                vehicles_relevant[i].speed_request = (vehicles_relevant[i].dist - distMargin) / Tj;
                            }
                            if (vehicles_relevant[i].speed_request > 40) vehicles_relevant[i].speed_request = 40;
                            break;
                        }
                    }

                }
            }

        }

        private bool collision_risk(Vehicle vehicle1, Vehicle vehicle2)
        {
            bool result;
            int i = get_tajectory_index(vehicle1);
            int j = get_tajectory_index(vehicle2);
            if (trajectory_model[i, j] == 1) result = true;
            else result = false;
            return result;
        }
        private int get_tajectory_index(Vehicle vehicle)
        {
            int index = 0;
            String[] route = {"NW", "NS", "NE", "EN", "EW", "ES", "SE", "SW", "WS", "WE", "WN"};
            for (int i = 0; i < route.Count(); i++)
                if (vehicle.route == "NW") index = i;
            return index;
            
        }

        private void draw_vehicle(Vehicle vehicle)
        {
            Pen p = new Pen(Color.Black, 1);
            if (vehicle.type == "Car")
            {
                if (vehicle.mode == true) p = p_car;
                else p = p_car_g;
            }
            if (vehicle.type == "Bus")
            {
                if (vehicle.mode == true) p = p_bus;
                else p = p_bus_g;
            }

            g.DrawLine(p,
                o_x + Convert.ToInt64(vehicle.x - vehicle.length / 2 * Math.Cos(vehicle.angle) - 4 * Math.Sin(vehicle.angle)),
                o_y + Convert.ToInt64(vehicle.y - vehicle.length / 2 * Math.Sin(vehicle.angle) + 4 * Math.Cos(vehicle.angle)),
                o_x + Convert.ToInt64(vehicle.x + vehicle.length / 2 * Math.Cos(vehicle.angle) - 4 * Math.Sin(vehicle.angle)),
                o_y + Convert.ToInt64(vehicle.y + vehicle.length / 2 * Math.Sin(vehicle.angle) + 4 * Math.Cos(vehicle.angle)));

            /*
            g.DrawEllipse(p_road,
                Convert.ToInt32(o_x + vehicle.x - 1), 
                Convert.ToInt32(o_x + vehicle.y - 1), 
                2, 2); // vehicle dot position
            */


            // Draw string to screen.
            if (zoomFactor < 5)
            {
                // Create string to draw.
                string drawString = Convert.ToString(vehicle.ID);
                // Create font and brush.
                Font drawFont = new Font("Arial", 8);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                // Create point for upper-left corner of drawing.
                int align_x = 6;
                int align_y = 5;
                if (spawn_ID >= 100) align_x = 10; // avoid text on road
                PointF drawPoint = new PointF(
                  Convert.ToInt64(o_x + vehicle.x - 20 * Math.Sin(vehicle.angle) - align_x),
                  Convert.ToInt64(o_y + vehicle.y + 17 * Math.Cos(vehicle.angle) - align_y));

                g.DrawString(drawString, drawFont, drawBrush, drawPoint);
            }
        }
        private void draw_road()
        {

            // Draw Road
            g.DrawLine(p_roads, 0, o_y, 1000, o_y);
            g.DrawLine(p_roads, o_x, 0, o_y, 1000);

            // Draw road outlines
            g.DrawLine(p_road, 0, o_y - laneWidth, o_x - laneWidth, o_y - laneWidth);
            g.DrawLine(p_road, o_x + laneWidth, o_y - laneWidth, 1000, o_y - laneWidth);
            g.DrawLine(p_road, 0, o_y + laneWidth, o_x - laneWidth, o_y + laneWidth);
            g.DrawLine(p_road, o_x + laneWidth, o_y + laneWidth, 1000, o_y + laneWidth);
            g.DrawLine(p_road, o_x - laneWidth, 0, o_x - laneWidth, o_y - laneWidth);
            g.DrawLine(p_road, o_x - laneWidth, o_y + laneWidth, o_x - laneWidth, 1000);
            g.DrawLine(p_road, o_x + laneWidth, 0, o_x + laneWidth, o_y - laneWidth);
            g.DrawLine(p_road, o_x + laneWidth, o_y + laneWidth, o_x + laneWidth, 1000);
            g.DrawEllipse(p_road, Convert.ToInt32(o_x - simulation_bound), Convert.ToInt32(o_y - simulation_bound), 2 * simulation_bound, 2 * simulation_bound);


            // Draw double white lines
            g.DrawLine(p_thin, 0, o_y - 1, o_x - laneWidth, o_y - 1);
            g.DrawLine(p_thin, o_x + laneWidth, o_y - 1, 1000, o_y - 1);
            g.DrawLine(p_thin, 0, o_y + 1, o_x - laneWidth, o_y + 1);
            g.DrawLine(p_thin, o_x + laneWidth, o_y + 1, 1000, o_y + 1);
            g.DrawLine(p_thin, o_x - 1, 0, o_x - 1, o_y - laneWidth);
            g.DrawLine(p_thin, o_x - 1, o_y + laneWidth, o_x - 1, 1000);
            g.DrawLine(p_thin, o_x + 1, 0, o_x + 1, o_y - laneWidth);
            g.DrawLine(p_thin, o_x + 1, o_y + laneWidth, o_x + 1, 1000);


            // Draw dashed white lines
            // p_dashed.DashPattern = dashValues;
            //g.DrawLine(p_dashed, 6, o_y, 995, o_y);
            // g.DrawLine(p_dashed, o_x, 6, o_y, 1000);
        }

        private void clear_graphics()
        {
            g = Graphics.FromImage(bm);

            // Zoom 
            g.ScaleTransform(zoomFactor, zoomFactor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//SmoothingMode.AntiAlias;

            g.Clear(Color.White);
           
        }

        private void remove_vehicles()
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].dist > simulation_bound) vehicles.RemoveAt(i);
            }
            for (int i = 0; i < vehicles_ghost.Count; i++)
            {
                if (vehicles_ghost[i].dist > simulation_bound) vehicles_ghost.RemoveAt(i);
            }
        }

        private int spawnID_next()
        {
            spawn_ID += 1;
            last_ID = spawn_ID;
            return spawn_ID;
        }

        private int spawnID_keep()
        {
            return spawn_ID;
        }

        private string get_random_spawn()
        {
            int num = rnd.Next(1, 5);
            string spawn = "";
            if (num == 1) spawn = "North";
            else if (num == 2) spawn = "East";
            else if (num == 3) spawn = "South";
            else if (num == 4) spawn = "West";
            last_spawn = spawn;
            return spawn;
        }

        private string get_random_target()
        {
            int num = rnd.Next(1, 5);
            string target = "";
            if (num == 1) target = "North";
            else if (num == 2) target = "East";
            else if (num == 3) target = "South";
            else if (num == 4) target = "West";
            last_target = target;
            return target;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (random_target == true)
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "North", get_random_target(), true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "North", last_target, false);
                Vehicle bil2 = new Vehicle(spawnID_next(), "Car", spawn_speed, "East", get_random_target(), true);
                Vehicle bil02 = new Vehicle(last_ID, "Car", spawn_speed, "East", last_target, false);
                Vehicle bil3 = new Vehicle(spawnID_next(), "Car", spawn_speed, "South", get_random_target(), true);
                Vehicle bil03 = new Vehicle(last_ID, "Car", spawn_speed, "South", last_target, false);
                Vehicle bil4 = new Vehicle(spawnID_next(), "Car", spawn_speed, "West", get_random_target(), true);
                Vehicle bil04 = new Vehicle(last_ID, "Car", spawn_speed, "West", last_target, false);
                vehicles.Add(bil1);
                vehicles.Add(bil2);
                vehicles.Add(bil3);
                vehicles.Add(bil4);
                vehicles_ghost.Add(bil01);
                vehicles_ghost.Add(bil02);
                vehicles_ghost.Add(bil03);
                vehicles_ghost.Add(bil04);
            }
            else
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "North", "South", true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "North", "South", false);
                Vehicle bil2 = new Vehicle(spawnID_next(), "Car", spawn_speed, "East", "West", true);
                Vehicle bil02 = new Vehicle(last_ID, "Car", spawn_speed, "East", "West", false);
                Vehicle bil3 = new Vehicle(spawnID_next(), "Car", spawn_speed, "West", "East", true);
                Vehicle bil03 = new Vehicle(last_ID, "Car", spawn_speed, "West", "East", false);
                Vehicle bil4 = new Vehicle(spawnID_next(), "Car", spawn_speed, "South", "North", true);
                Vehicle bil04 = new Vehicle(last_ID, "Car", spawn_speed, "South", "North", false);
                vehicles.Add(bil1);
                vehicles.Add(bil2);
                vehicles.Add(bil3);
                vehicles.Add(bil4);
                vehicles_ghost.Add(bil01);
                vehicles_ghost.Add(bil02);
                vehicles_ghost.Add(bil03);
                vehicles_ghost.Add(bil04);
            }

            timer_simulation.Start();
            timer_print.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, get_random_spawn(), get_random_target(), true);
            Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, last_spawn, last_target, false);
            vehicles.Add(bil1);
            vehicles_ghost.Add(bil01);
            timer_simulation.Start();
            timer_print.Start();
        }

        private void buttonN_Click(object sender, EventArgs e)
        {
            if (random_target == true)
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "North", get_random_target(), true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "North", last_target, false);
                vehicles.Add(bil1);
                vehicles_ghost.Add(bil01);
            }
            else
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "North", "South", true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "North", "South", false);
                vehicles.Add(bil1);
                vehicles_ghost.Add(bil01);
            }

            timer_simulation.Start();
            timer_print.Start();
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            if (random_target == true)
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "East", get_random_target(), true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "East", last_target, false);
                vehicles.Add(bil1);
                vehicles_ghost.Add(bil01);
            }
            else
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "East", "West", true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "East", "West", false);
                vehicles.Add(bil1);
                vehicles_ghost.Add(bil01);
            }

            timer_simulation.Start();
            timer_print.Start();
        }

        private void buttonW_Click(object sender, EventArgs e)
        {
            if (random_target == true)
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "West", get_random_target(), true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "West", last_target, false);
                vehicles.Add(bil1);
                vehicles_ghost.Add(bil01);
            }
            else
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "West", "East", true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "West", "East", false);
                vehicles.Add(bil1);
                vehicles_ghost.Add(bil01);
            }
            timer_simulation.Start();
            timer_print.Start();
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            if (random_target == true)
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "South", get_random_target(), true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "South", last_target, false);
                vehicles.Add(bil1);
                vehicles_ghost.Add(bil01);
            }
            else
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "South", "North", true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "South", "North", false);
                vehicles.Add(bil1);
                vehicles_ghost.Add(bil01);
            }
            timer_simulation.Start();
            timer_print.Start();
        }

        double DegToRad(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            T_margin = Convert.ToDouble(numericUpDown_margin.Value);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                timer_simulation.Stop();
                timer_print.Start();
            }
            else
            {
                timer_simulation.Start();
                timer_print.Start();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false) show_ghost = false;
            else show_ghost = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTarget.Checked == false) random_target = false;
            else random_target = true;
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked) zoom = true;
            else zoom = false;
        }

        private void numericUpDownDistMargin_ValueChanged(object sender, EventArgs e)
        {
            distMargin = Convert.ToDouble(numericUpDownDistMargin.Value);
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 1)
                numericUpDown1.Value = 1;
            else if (numericUpDown1.Value > 30)
                numericUpDown1.Value = 30;
            zoomValue = Convert.ToInt16(numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            speed_limit = Convert.ToDouble(numericUpDown2.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            spawn_speed = Convert.ToDouble(numericUpDown3.Value);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void timer_print_Tick(object sender, EventArgs e)
        {
            string present_vehicles = "";
            foreach (Vehicle vehicle in vehicles)
            {
                // present vehicle states
                present_vehicles += Convert.ToString("ID: " + vehicle.ID + "\tdist: " + Math.Round(vehicle.dist, MidpointRounding.AwayFromZero) + "\tspeed: " + Math.Round(vehicle.speed, MidpointRounding.AwayFromZero) + "\tT: " + Math.Round(vehicle.T, 1) + "\tPassed: " + Convert.ToString(vehicle.passed) + Environment.NewLine);
            }
            textBox1.Text = present_vehicles;

            present_vehicles = "";
            foreach (Vehicle vehicle in vehicles_relevant)
            {
                present_vehicles += Convert.ToString("ID: " + vehicle.ID + "\td: " + Math.Round(vehicle.dist) + "\tv: " + Math.Round(vehicle.speed, MidpointRounding.AwayFromZero) + " (" + Math.Round(vehicle.speed_request, MidpointRounding.AwayFromZero) + ")\t\tT: " + Math.Round(vehicle.T, 1) + "\ttraj: " + vehicle.route + Environment.NewLine);
            }
            textBox2.Text = present_vehicles;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Vehicle
    {
        public int ID; // vehicle ID
        public double x, y, vx, vy, angle, deltaAngle, targetAngle, speed, dist, T; // dynamic parameters
        public double speed_request; // speed recuest from intersection manager
        public string type; // car, bus etc.
        public double mass; // vehicle mass
        public string spawn, target, route; // route parameters
        public double length, width; // dimensions
        public bool passed = false; // passed intersection
        public bool mode; // real/ghost vehicle
        protected double turningTime; // parameters while turning
        protected double curvatureRadius = 8;
        protected bool enteredIntersection = false;
        public double dt = 0.01; // time step

        // regulator parameters
        public double speed_prev;
        public double error_prev;
        public double error_derivative;
        public double error_integral;

        public Vehicle(int inp_ID, string inp_vehicle_type, double inp_x, double inp_y, double inp_speed, double inp_angle, bool inp_mode)
        {
            // Spawn vehicle at custom coordinates, with specified angle
            ID = inp_ID;
            type = inp_vehicle_type;
            mode = inp_mode;
            x = inp_x;
            y = inp_y;
            speed = inp_speed;
            angle = inp_angle;

            if (type == "Car")
            {
                length = 6;
                width = 3;
            }
            else if (type == "Bus")
            {
                length = 10;
                width = 4;
            }
        }

        public Vehicle(int inp_ID, string inp_vehicle_type, double inp_speed, string inp_spawn, string inp_target, bool inp_mode)
        {
            // Spawn vehicle at determined points, with a target
            ID = inp_ID;
            type = inp_vehicle_type;
            mode = inp_mode;
            speed = inp_speed;
            speed_request = inp_speed;
            spawn = inp_spawn;
            target = inp_target;



            // set spawn position
            if (spawn == "North")
            {
                x = 0;
                y = -380;
                angle = DegToRad(90);
                if (target == "North") target = "South";
            }
            else if (spawn == "West")
            {
                x = -380;
                y = 0;
                angle = DegToRad(0);
                if (target == "West") target = "East";
            }
            else if (spawn == "East")
            {
                x = 380;
                y = 0;
                angle = DegToRad(-180);
                if (target == "East") target = "West";
            }
            else if (spawn == "South")
            {
                x = 0;
                y = 380;
                angle = DegToRad(-90);
                if (target == "South") target = "North";
            }

            // determine intersection route
            if (spawn == "North")
            {
                if (target == "East") route = "NE";
                if (target == "South") route = "NS";
                if (target == "West") route = "NW";
            }
            else if (spawn == "East")
            {
                if (target == "North") route = "EN";
                if (target == "South") route = "ES";
                if (target == "West") route = "EW";
            }
            else if (spawn == "South")
            {
                if (target == "North") route = "SN";
                if (target == "East") route = "SE";
                if (target == "West") route = "SW";
            }
            else if (spawn == "West")
            {
                if (target == "North") route = "WN";
                if (target == "East") route = "WE";
                if (target == "South") route = "WS";
            }

            // set vehicle dimensions
            if (type == "Car")
            {
                length = 6;
                width = 3;
                mass = 2000;
            }
            else if (type == "Bus")
            {
                length = 10;
                width = 4;
                mass = 7000;
            }
        }

        public Vehicle()
        {
            // empty vehicle
        }

        public void update_state()
        {
            speed_control();
            vx = speed * Math.Cos(angle);
            vy = speed * Math.Sin(angle);
            x += vx * dt;
            y += vy * dt;
            dist = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            T = dist / speed;
            turn_control();
        }

        public void get_state()
        {
            dist = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            T = dist / speed;
        }

        public void turn_control()
        {
            // int timePassed = timer_simulation.Interval;
            // This is a new awesome turn controller!!
            // make a turn

            if (dist <= 8)
            //passed == false)
            {
                deltaAngle = 0;
                if (spawn == "North")
                {
                    if (target == "East")
                    {
                        deltaAngle = -90;
                        targetAngle = 0;
                    }
                    else if (target == "West")
                    {
                        deltaAngle = 90;
                        targetAngle = 180;
                    }
                }
                else if (spawn == "East")
                {
                    if (target == "South")
                    {
                        deltaAngle = -90;
                        targetAngle = 90;
                    }
                    else if (target == "North")
                    {
                        deltaAngle = 90;
                        targetAngle = -90;
                    }
                }
                else if (spawn == "South")
                {
                    if (target == "East")
                    {
                        deltaAngle = 90;
                        targetAngle = 0;
                    }
                    else if (target == "West")
                    {
                        deltaAngle = -90;
                        targetAngle = 180;
                    }
                }
                else if (spawn == "West")
                {
                    if (target == "South")
                    {
                        deltaAngle = 90;
                        targetAngle = 90;
                    }
                    else if (target == "North")
                    {
                        deltaAngle = -90;
                        targetAngle = -90;
                    }
                }

                if (deltaAngle != 0)
                {
                    turningTime = (Math.Abs(DegToRad(deltaAngle)) * curvatureRadius) / speed;
                    angle += DegToRad(deltaAngle) * dt / turningTime;

                }
                enteredIntersection = true;
            }
            else if (enteredIntersection)
            {
                passed = true;
            }
        }

        public void speed_control()
        {
            // controller parameters
            double Kp = 2000;
            double Kd = 10;
            double Ki = 0.01;

            //drag parameters
            double c = 1.5;
            double density = 1.2;
            double A = 3; // vehicle front area



            // regulator error
            double error = speed_request - speed;

            // physical calculations
            double drag = c * density * A * Math.Pow(speed, 2) / 2;
            double Power = Kp * error + Kd * error_derivative + Ki * error_integral;
            double acceleration = (Power - drag) / mass;

            // update speed
            speed += acceleration * dt;

            // values for D and I - part
            error_derivative = error - error_prev;
            error_integral += error;

            // temporary values
            speed_prev = speed;
            error_prev = error;

        }

        double DegToRad(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
