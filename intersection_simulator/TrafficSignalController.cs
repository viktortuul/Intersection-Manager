using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using vehicle;

namespace trafficLight
{
    class TrafficSignalController
    {
        public static List<Vehicle> vehicles_N = new List<Vehicle>();
        public static List<Vehicle> vehicles_E = new List<Vehicle>();
        public static List<Vehicle> vehicles_S = new List<Vehicle>();
        public static List<Vehicle> vehicles_W = new List<Vehicle>();

        public static void apply_signal(List<Vehicle> vehicles)
        {
            vehicles_N.Clear();
            vehicles_E.Clear();
            vehicles_S.Clear();
            vehicles_W.Clear();

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.spawn == "North")
                {
                    if (vehicle.dist_to_inter > 0) vehicles_N.Add(vehicle);
                }
                else if (vehicle.spawn == "East")
                {
                    if (vehicle.dist_to_inter > 0) vehicles_E.Add(vehicle);
                }
                else if (vehicle.spawn == "South")
                {
                    if (vehicle.dist_to_inter > 0) vehicles_S.Add(vehicle);
                }
                else if (vehicle.spawn == "West")
                {
                    if (vehicle.dist_to_inter > 0) vehicles_W.Add(vehicle);
                }
            }

            vehicles_N = vehicles_N.OrderBy(vehicle => vehicle.dist_to_inter).ToList();
            vehicles_E = vehicles_E.OrderBy(vehicle => vehicle.dist_to_inter).ToList();
            vehicles_S = vehicles_S.OrderBy(vehicle => vehicle.dist_to_inter).ToList();
            vehicles_W = vehicles_W.OrderBy(vehicle => vehicle.dist_to_inter).ToList();

            controller_trafficlight(vehicles_N);
            controller_trafficlight(vehicles_E);
            controller_trafficlight(vehicles_S);
            controller_trafficlight(vehicles_W);

        }

        public static void controller_trafficlight(List<Vehicle> vehicles_lane)
        {
            if (vehicles_lane.Count() >= 1)
            {
                if (MainFrame.green_light == vehicles_lane[0].spawn && MainFrame.yellow_light == false)
                    vehicles_lane[0].speed_request = MainFrame.speed_limit;
                else
                {
                    if (vehicles_lane[0].dist_to_inter > 100)
                        vehicles_lane[0].speed_request += 0.1;

                    else if (vehicles_lane[0].dist_to_inter < 50)
                    {
                        //vehicles_lane[0].speed_request -= 0.1;
                        if (vehicles_lane[0].dist_to_inter < 5)
                            vehicles_lane[0].speed = 0;
                    }
                }
            }
            if (vehicles_lane.Count() >= 2)
                for (int i = 1; i <= vehicles_lane.Count() - 1; i++)
                {
                    double Kp = 1;
                    //double Kd = 0.2;
                    double dist_ref = vehicles_lane[i - 1].dist_to_inter + 15;

                    if (MainFrame.green_light == vehicles_lane[0].spawn && MainFrame.yellow_light == false)
                    {
                        if (vehicles_lane[i].speed > vehicles_lane[i - 1].speed)
                        {
                            vehicles_lane[i].speed = Kp * (vehicles_lane[i].dist_to_inter - dist_ref);
                        }
                        else
                        {
                            vehicles_lane[i].speed_request = vehicles_lane[i - 1].speed;
                        }
                        //vehicles_lane[i].speed_request = Kp * (vehicles_lane[i].dist_to_inter - dist_ref) - Kd * (vehicles_lane[i].speed - vehicles_lane[i - 1].speed);
                    }
                    else
                    {
                        vehicles_lane[i].speed = Kp * (vehicles_lane[i].dist_to_inter - dist_ref);
                    }


                }

        }
    }
}
