using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using vehicle;
using AutonomousIntersectionManager;
using Spawn_Vehicles;

namespace Main
{
    public partial class MainFrame : Form
    {
        // test running
        bool test_running = false;

        // Init time parameters
        double Time_Global = 0;
        double Real_Time_Global = 0;
        double accumulatedTime, totalAccumulatedTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
        double realdt;
        double dt = 0.01;
        double time_test = 0;

        // origin cordinates
        int o_x = 400;
        int o_y = 400;

        // bounds
        int simulation_bound = 400;
        public static int reservationRadius = 350;//300;
        int criticalRadius = 0;// Convert.ToInt16(Math.Sqrt(2));

        // lists containing vehicles
        public static List<Vehicle> vehicles = new List<Vehicle>();
        public static List<Vehicle> vehicles_ghost = new List<Vehicle>();

        // statistical vehicle paramters
        public static int test_vehicles_passed = 0;
        int test_vehicles_spawned = 0;
        string test_data_time = "";
        string test_data_spawned = "";
        string test_data_passed = "";
        string test_data_incomingVehicles = "";
        string test_data_dIn = "";
        string test_data_dOut = "";

        // margin parameters (AIM)
        public static double speed_limit; // vehicle upp speed limit
        public static double distMargin = 20;

        // trajectory-intersection model
        public static int[,] trajectory_model = new int[,] {
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

        public static double[,] d0f = new double[12, 12];
        public static double[,] d0l = new double[12, 12];

        // visual parameters
        bool show_ghost = false; // show ghost vehicles toggle
        bool showZones = false;
        bool zoom = false; // show zoom
        double zoomFactor = 1; // zoom factor
        int zoomValue;
        int laneWidth = 8; // lane width, meters

        // graphics
        float[] dashValues = { 4, 6 };
        Pen p = new Pen(Color.Black, 1);
        Pen p_dashed = new Pen(Color.White, 1);
        Pen p_thin = new Pen(Color.White, 1);
        Pen p_roads = new Pen(Color.LightGray, 16);
        Pen p_road = new Pen(Color.Black, 1);
        Pen p_red = new Pen(Color.Red, 1);
        Pen p_car = new Pen(Color.Red, 3);
        Pen p_car_g = new Pen(Color.Gray, 3);
        Pen p_bus = new Pen(Color.Red, 5);
        Pen p_bus_g = new Pen(Color.Gray, 5);
        Graphics g;
        Graphics gProj;
        Bitmap bm = new Bitmap(1000, 1000);
        Bitmap bmProj = new Bitmap(400, 500);
        string drawString;
        Font drawFont;
        SolidBrush drawBrush;
        PointF drawPoint;


        //controller
        double delay_AIM;



        public MainFrame()
        {
            InitializeComponent();
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            // initialize parameters
            zoomValue = Convert.ToInt16(nudZoom.Value);
            speed_limit = Convert.ToDouble(nudSpeedLimit.Value);
            Spawn.spawn_speed = Convert.ToDouble(nudSpawnSpeed.Value);
            distMargin = Convert.ToDouble(nudDistMargin.Value);
            delay_AIM = Convert.ToDouble(nudDelayAIM.Value);

            // distance-to-collison (vehicle j)
            d0f = new double[,] {
                                { 0,0,0,0,Math.PI,0,0,0,Math.PI,0,0,0 },
                                { 0,0,0,0,laneWidth/2,laneWidth,0,0,laneWidth/2,2 * laneWidth,2 * laneWidth,2 * laneWidth},
                                { 0,0,0,0,0,Math.PI*3,Math.PI*6 + 2,Math.PI*6 + 2,Math.PI*6 + 2,0,Math.PI*3,Math.PI*3},
                                { 0,0,0,0,0,0,0,Math.PI,0,0,0,Math.PI },
                                { 2*laneWidth,2*laneWidth,2*laneWidth,0,0,0,0,laneWidth/2,laneWidth,0,0,0},
                                { 0,Math.PI*3,Math.PI*3,0,0,0,0,0,Math.PI*3,Math.PI*6 + 2,Math.PI*6 + 2,Math.PI*6 + 2},
                                { 0,0,Math.PI,0,0,0,0,0,0,0,Math.PI,0},
                                { 0,0,laneWidth/2,2*laneWidth,2*laneWidth,2*laneWidth,0,0,0,0,laneWidth/2,laneWidth},
                                { Math.PI*6 + 2,Math.PI*6 + 2,Math.PI*6 + 2,0,Math.PI*3,Math.PI*3,0,0,0,0,laneWidth/2,Math.PI*3},
                                { 0,Math.PI,0,0,0,Math.PI,0,0,0,0,0,0},
                                { 0,laneWidth/2,laneWidth,0,0,laneWidth/2,2*laneWidth,2*laneWidth,2*laneWidth,0,0,0},
                                { 0,laneWidth/2,Math.PI*3,Math.PI*6 + 2,Math.PI*6 + 2,Math.PI*6 + 2,0,Math.PI*3,Math.PI*3,0,0,0},
                                };
            // distance-to-collison (vehicle i)
            d0l = new double[,] {
                                { 0,0,0,0,Math.PI,0,0,0,Math.PI,0,0,0 },
                                { 0,0,0,0,0,laneWidth,0,0,0,2 * laneWidth,2 * laneWidth,2 * laneWidth},
                                { 0,0,0,0,0,Math.PI*3,Math.PI*6,Math.PI*6,0,0,Math.PI*3,Math.PI*3},
                                { 0,0,0,0,0,0,0,Math.PI,0,0,0,Math.PI },
                                { 2* laneWidth,2* laneWidth,2* laneWidth,0,0,0,0,0,laneWidth,0,0,0},
                                { 0,Math.PI*3,Math.PI*3,0,0,0,0,0,Math.PI*3,Math.PI*6,Math.PI*6,0},
                                { 0,0,Math.PI,0,0,0,0,0,0,0,Math.PI,0},
                                { 0,0,0,2*laneWidth,2*laneWidth,2*laneWidth,0,0,0,0,0,laneWidth},
                                { Math.PI*6,Math.PI*6,0,0,Math.PI*3,Math.PI*3,0,0,0,0,0,Math.PI*3},
                                { 0,Math.PI,0,0,0,Math.PI,0,0,0,0,0,0},
                                { 0,0,laneWidth,0,0,0,2*laneWidth,2*laneWidth,2*laneWidth,0,0,0},
                                { 0,0,Math.PI*3,Math.PI*6,Math.PI*6,0,0,Math.PI*3,Math.PI*3,0,0,0},
                                        };
        }

        public void start_timers()
        {
            timer_simulation.Start();
            timer_print.Start();
        }
        private void timer_simulation_Tick(object sender, EventArgs e)
        {
            update_timers();

            if (test_running == true)
                test_action();

            // Apply AIM controller, with the specified delay. 
            if (Time_Global % delay_AIM < dt)
            {
                AIM.apply_trafficmanager(vehicles);
                AIM.controller_distance_topbottom();
            }

            // remove vehicles out of bounds
            remove_vehicles();

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
                if (show_ghost)
                    draw_vehicle(vehicle);
            }

            // update image
            pbSimulation.Image = bm;
            pbProjection.Image = bmProj;

            accumulatedTime = 0;
        }

        private void update_timers()
        {
            // update time passed dt
            realdt = DateTime.Now.TimeOfDay.TotalMilliseconds - totalAccumulatedTime;
            totalAccumulatedTime += realdt;
            accumulatedTime += realdt;

            // update global timer
            label8.Text = "Real time: " + Convert.ToString(Real_Time_Global.ToString("0.0"));
            Real_Time_Global += realdt / 1000;

            // update global timer
            label6.Text = "Simulation Time: " + Convert.ToString(Time_Global.ToString("0.0"));
            Time_Global += dt;
        }

        private void test_action()
        {
            if (time_test % Convert.ToDouble(nudDelay.Value) < 0.01)
            {
                Spawn.Random();
                test_vehicles_spawned += 1;
            }

            if (time_test >= Convert.ToDouble(nudTestLength.Value))
            {
                test_running = false;
                time_test = 0;
                labelDuration.Text = "Test Done ";

                test_data_time = test_data_time.Replace(",", ".");
                test_data_dIn = test_data_dIn.Replace(",", ".");
                test_data_dOut = test_data_dOut.Replace(",", ".");

                TextWriter tw = File.CreateText(Application.StartupPath + "_vs" + Spawn.spawn_speed + "_vl" + speed_limit + "_dm" + distMargin + "_int" + nudDelay.Value + "_len" + nudTestLength.Value + ".txt");
                tw.WriteLine(test_data_time + Environment.NewLine +
                    test_data_spawned + Environment.NewLine +
                    test_data_passed + Environment.NewLine +
                    test_data_incomingVehicles + Environment.NewLine +
                    test_data_dIn + Environment.NewLine +
                    test_data_dOut);
                tw.Close();
            }
            else
            {
                time_test += dt;
                labelDuration.Text = "Duration: " + Convert.ToString(Math.Round(time_test, 1));

                if (time_test % 1 < 0.01) // Fånga data varje 1000 millisekund bara. % är modulo
                {
                    test_data_time += time_test + " ";
                    test_data_spawned += test_vehicles_spawned + " ";
                    test_data_passed += test_vehicles_passed + " ";
                    test_data_incomingVehicles += AIM.vehicles_approaching.Count + " ";
                    test_data_dIn += test_vehicles_spawned / time_test + " ";
                    test_data_dOut += test_vehicles_passed / time_test + " "; ;
                }
            }
        }

        private void draw_vehicle(Vehicle vehicle)
        {
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
                o_x + Convert.ToInt64(vehicle.x - vehicle.length / 2 * Math.Cos(vehicle.angle) - 0 * Math.Sin(vehicle.angle)),
                o_y + Convert.ToInt64(vehicle.y - vehicle.length / 2 * Math.Sin(vehicle.angle) + 0 * Math.Cos(vehicle.angle)),
                o_x + Convert.ToInt64(vehicle.x + vehicle.length / 2 * Math.Cos(vehicle.angle) - 0 * Math.Sin(vehicle.angle)),
                o_y + Convert.ToInt64(vehicle.y + vehicle.length / 2 * Math.Sin(vehicle.angle) + 0 * Math.Cos(vehicle.angle)));

            gProj.DrawLine(p_road, Convert.ToInt64(395 - vehicle.dist_to_inter), 490, 395, Convert.ToInt64(490 - 20 * vehicle.dist_to_inter / vehicle.speed));
            gProj.DrawLine(p_red, 395, 0, 395, 500);
            gProj.DrawLine(p_red, 395 - simulation_bound, 0, 395 - simulation_bound, 500);
            gProj.DrawLine(p_red, 395 - reservationRadius, 0, 395 - reservationRadius, 500);

            drawString = Convert.ToString(vehicle.ID);
            drawFont = new Font("Arial", 6);
            drawBrush = new SolidBrush(Color.Black);
            drawPoint = new PointF(
                            Convert.ToInt64(392 - vehicle.dist_to_inter),
                            Convert.ToInt64(492));
            gProj.DrawString(drawString, drawFont, drawBrush, drawPoint);

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
                drawString = Convert.ToString(vehicle.ID);
                // Create font and brush.
                drawFont = new Font("Arial", 7);
                drawBrush = new SolidBrush(Color.Black);

                // Create point for upper-left corner of drawing.
                int align_x = 6;
                int align_y = 5;

                if (Spawn.spawn_ID >= 100) align_x = 10; // avoid text on road
                drawPoint = new PointF(
                Convert.ToInt64(o_x + vehicle.x - 20 * Math.Sin(vehicle.angle) - align_x),
                Convert.ToInt64(o_y + vehicle.y + 17 * Math.Cos(vehicle.angle) - align_y));

                g.DrawString(drawString, drawFont, drawBrush, drawPoint);
            }
        }


        private void draw_road()
        {
            if (zoom)
                zoomFactor = zoomValue;
            else
                zoomFactor = 1;

            // origin cordinates
            o_x = Convert.ToInt16(400 / zoomFactor);
            o_y = Convert.ToInt16(400 / zoomFactor);

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

            // Draw outer circle
            g.DrawEllipse(p_road, Convert.ToInt32(o_x - simulation_bound), Convert.ToInt32(o_y - simulation_bound), 2 * simulation_bound, 2 * simulation_bound);

            // Draw intersection zones
            if (showZones)
            {
                SolidBrush semiTransBrushGreen = new SolidBrush(Color.FromArgb(40, 0, 255, 0));
                Pen greenPen = new Pen(Color.Green, 1);
                g.DrawEllipse(greenPen, Convert.ToInt32(o_x - reservationRadius), Convert.ToInt32(o_y - reservationRadius), 2 * reservationRadius, 2 * reservationRadius);
                g.FillEllipse(semiTransBrushGreen, Convert.ToInt32(o_x - reservationRadius), Convert.ToInt32(o_y - reservationRadius), 2 * reservationRadius, 2 * reservationRadius);

                Pen redPen = new Pen(Color.Red, 1);
                SolidBrush semiTransBrushRed = new SolidBrush(Color.FromArgb(150, 255, 0, 0));
                g.DrawEllipse(redPen, Convert.ToInt32(o_x - criticalRadius), Convert.ToInt32(o_y - criticalRadius), Convert.ToInt32(2 * criticalRadius), Convert.ToInt32(2 * criticalRadius));
                g.FillEllipse(semiTransBrushRed, Convert.ToInt32(o_x - criticalRadius), Convert.ToInt32(o_y - criticalRadius), Convert.ToInt32(2 * criticalRadius), Convert.ToInt32(2 * criticalRadius));
            }

            // Draw double white lines
            g.DrawLine(p_thin, 0, o_y - 1, o_x - laneWidth, o_y - 1);
            g.DrawLine(p_thin, o_x + laneWidth, o_y - 1, 1000, o_y - 1);
            g.DrawLine(p_thin, 0, o_y + 1, o_x - laneWidth, o_y + 1);
            g.DrawLine(p_thin, o_x + laneWidth, o_y + 1, 1000, o_y + 1);
            g.DrawLine(p_thin, o_x - 1, 0, o_x - 1, o_y - laneWidth);
            g.DrawLine(p_thin, o_x - 1, o_y + laneWidth, o_x - 1, 1000);
            g.DrawLine(p_thin, o_x + 1, 0, o_x + 1, o_y - laneWidth);
            g.DrawLine(p_thin, o_x + 1, o_y + laneWidth, o_x + 1, 1000);
        }

        private void clear_graphics()
        {
            g = Graphics.FromImage(bm);
            gProj = Graphics.FromImage(bmProj);

            // Zoom 
            g.ScaleTransform(Convert.ToInt16(zoomFactor), Convert.ToInt16(zoomFactor));
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //SmoothingMode.AntiAlias;

            g.Clear(Color.White);
            gProj.Clear(Color.White);
        }

        private void remove_vehicles()
        {
            for (int i = 0; i < vehicles.Count; i++)
                if (vehicles[i].dist > simulation_bound) vehicles.RemoveAt(i);

            for (int i = 0; i < vehicles_ghost.Count; i++)
                if (vehicles_ghost[i].dist > simulation_bound) vehicles_ghost.RemoveAt(i);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Spawn.All();
            start_timers();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Spawn.Random();
            start_timers();
        }

        private void buttonN_Click(object sender, EventArgs e)
        {
            Spawn.North();
            start_timers();
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            Spawn.East();
            start_timers();
        }


        private void buttonS_Click(object sender, EventArgs e)
        {
            Spawn.South();
            start_timers();
        }

        private void buttonW_Click(object sender, EventArgs e)
        {
            Spawn.West();
            start_timers();
        }


        double DegToRad(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cBRun.Checked == false)
            {
                timer_simulation.Stop();
            }
            else
            {
                start_timers();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (cBShowGhost.Checked == false)
                show_ghost = false;
            else show_ghost = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (cBTarget.Checked == false)
                Spawn.random_target = false;
            else Spawn.random_target = true;
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cBZoom.Checked)
                zoom = true;
            else zoom = false;
        }

        private void numericUpDownDistMargin_ValueChanged(object sender, EventArgs e)
        {
            distMargin = Convert.ToDouble(nudDistMargin.Value);
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            if (nudZoom.Value < 1)
                nudZoom.Value = 1;
            else if (nudZoom.Value > 30)
                nudZoom.Value = 30;
            zoomValue = Convert.ToInt16(nudZoom.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            speed_limit = Convert.ToDouble(nudSpeedLimit.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Spawn.spawn_speed = Convert.ToDouble(nudSpawnSpeed.Value);
        }

        private void timer_print_Tick(object sender, EventArgs e)
        {
            string present_vehicles = "";

            /*
            foreach (Vehicle vehicle in vehicles)
            {
                present_vehicles += Convert.ToString("ID: " + vehicle.ID + "\tdist: " + Math.Round(vehicle.dist, MidpointRounding.AwayFromZero) + "\tspeed: " + Math.Round(vehicle.speed, MidpointRounding.AwayFromZero) + "\tT: " + Math.Round(vehicle.T, 1) + "\tPassed: " + Convert.ToString(vehicle.passed) + Environment.NewLine);
            }
            */

            present_vehicles = "";
            foreach (Vehicle vehicle in AIM.vehicles_approaching)
            {
                present_vehicles += Convert.ToString("ID: " + vehicle.ID + "\tdi: " + Math.Round(vehicle.dist_to_inter) + "\tv: " + Math.Round(vehicle.speed, MidpointRounding.AwayFromZero) + " (" + Math.Round(vehicle.speed_request, MidpointRounding.AwayFromZero) + ")\t\tacc: " + Math.Round(vehicle.acceleration, 1) + "\ttraj: " + vehicle.route + "\tT: " + Math.Round(vehicle.T, 1) + Environment.NewLine);
            }
            tBApproachingVehicles.Text = present_vehicles;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (cBShowZones.Checked)
                showZones = true;
            else
                showZones = false;
        }

        private void numericUpDownDelayAIM_ValueChanged(object sender, EventArgs e)
        {
            delay_AIM = Convert.ToDouble(nudDelayAIM.Value);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // refresh all test-data
            test_running = true;
            time_test = 0;
            test_vehicles_passed = 0;
            test_vehicles_spawned = 0;
            test_data_time = "";
            test_data_spawned = "";
            test_data_passed = "";
            test_data_incomingVehicles = "";
            test_data_dIn = "";
            test_data_dOut = "";
            timer_simulation.Start();
            timer_print.Start();
        }
    }
}
