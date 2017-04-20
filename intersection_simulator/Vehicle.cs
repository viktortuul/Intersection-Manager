using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;

namespace vehicle
{
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

        public double dist_to_inter;
        public double trajectoryDist;
        public double dist_tot;
        // regulator parameters
        public double speed_prev;
        public double error_prev;
        public double error_derivative;
        public double error_integral;
        public double acceleration;

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
                length = 5;
                width = 3;
            }
            else if (type == "Bus")
            {
                length = 20;
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
                x = -4;
                y = -380;
                angle = DegToRad(90);
                if (target == "North") target = "South";
            }
            else if (spawn == "West")
            {
                x = -380;
                y = 4;
                angle = DegToRad(0);
                if (target == "West") target = "East";
            }
            else if (spawn == "East")
            {
                x = 380;
                y = -4;
                angle = DegToRad(-180);
                if (target == "East") target = "West";
            }
            else if (spawn == "South")
            {
                x = 4;
                y = 380;
                angle = DegToRad(-90);
                if (target == "South") target = "North";
            }

            // determine intersection route
            if (spawn == "North")
            {
                if (target == "East")
                {
                    route = "NE";
                    trajectoryDist = 6 * Math.PI * 8 / 8;
                }
                if (target == "South")
                {
                    route = "NS";
                    trajectoryDist = 2 * 8;
                }
                if (target == "West")
                {
                    route = "NW";
                    trajectoryDist = Math.PI * 8 / 16;
                }
            }
            else if (spawn == "East")
            {
                if (target == "North")
                {
                    route = "EN";
                    trajectoryDist = Math.PI * 8 / 16;
                }
                if (target == "South")
                {
                    route = "ES";
                    trajectoryDist = 6 * Math.PI * 8 / 8;
                }
                if (target == "West")
                {
                    route = "EW";
                    trajectoryDist = 2 * 8;
                }
            }
            else if (spawn == "South")
            {
                if (target == "North")
                {
                    route = "SN";
                    trajectoryDist = 2 * 8;
                }
                if (target == "East")
                {
                    route = "SE";
                    trajectoryDist = Math.PI * 8 / 16;
                }
                if (target == "West")
                {
                    route = "SW";
                    trajectoryDist = 6 * Math.PI * 8 / 8;
                }
            }
            else if (spawn == "West")
            {
                if (target == "North")
                {
                    route = "WN";
                    trajectoryDist = 6 * Math.PI * 8 / 8;
                }
                if (target == "East")
                {
                    route = "WE";
                    trajectoryDist = 2 * 8;
                }
                if (target == "South")
                {
                    route = "WS";
                    trajectoryDist = Math.PI * 8 / 16;
                }
            }

            trajectoryDist = trajectoryDist + length;
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
            if (spawn == "South") dist_to_inter = y - 8 - length / 2;
            if (spawn == "North") dist_to_inter = -y - 8 - length / 2;
            if (spawn == "East") dist_to_inter = x - 8 - length / 2;
            if (spawn == "West") dist_to_inter = -x - 8 - length / 2;
            dist_tot = dist_to_inter + trajectoryDist;
            T = dist / speed;
            turn_control();
        }

        public void get_state()
        {
            dist = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            dist_tot = dist_to_inter + trajectoryDist;
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
                    curvatureRadius = 8 - 4 * Math.Abs(deltaAngle) / deltaAngle;
                    //Console.Write("\n" + spawn + " " + Convert.ToString(target) + " " + Convert.ToString(deltaAngle) + " " + Convert.ToString(8 - 4*Math.Abs(deltaAngle)/deltaAngle));
                    turningTime = (Math.Abs(DegToRad(deltaAngle)) * curvatureRadius) / speed;
                    angle += DegToRad(deltaAngle) * dt / turningTime;

                }
                enteredIntersection = true;
            }
            else if (enteredIntersection)
            {
                if (deltaAngle != 0)
                    angle = DegToRad(targetAngle);
                if (passed == false && mode == true)
                {
                    MainFrame.test_vehicles_passed += 1;
                }
                passed = true;

            }
        }

        public void speed_control()
        {
            // controller parameters
            double Kp = 500;
            double Kd = 10;
            double Ki = 1;

            //drag parameters
            double c = 1.5;
            double density = 1.2;
            double A = 3; // vehicle front area

            // regulator error
            double error = speed_request - speed;

            // physical calculations
            double drag = c * density * A * Math.Pow(speed, 2) / 2;
            double Power = Kp * error + Kd * error_derivative + Ki * error_integral;
            if (Power > 6000)
                Power = 6000;
            acceleration = (Power - drag) / mass;

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
