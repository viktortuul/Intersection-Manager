using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using vehicle;

namespace AutonomousIntersectionManager
{
    class AIM
    {
        public static List<Vehicle> vehicles_approaching = new List<Vehicle>();


        public static void apply_trafficmanager(List<Vehicle> vehicles)
        {
            vehicles_approaching.Clear();
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.dist < MainFrame.reservationRadius)
                {
                    if (vehicle.dist_to_inter > 0) vehicles_approaching.Add(vehicle);
                }
            }
            vehicles_approaching = vehicles_approaching.OrderBy(vehicle => vehicle.dist_to_inter).ToList(); // add relevant vehicles (sorted)
 
        }

        public static void controller_distance_topbottom()
        {
            for (int i = 0; i <= vehicles_approaching.Count() - 1; i++)
            {
                vehicles_approaching[i].speed_request = MainFrame.speed_limit;

                if (vehicles_approaching.Count() >= 2)
                {
                    List<double> speed_requests = new List<double>();
                    bool foundRisk = false;

                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (collision_risk(vehicles_approaching[i], vehicles_approaching[j]) == true)
                        {
                            double d_0f = get_df(vehicles_approaching[j], vehicles_approaching[i]);
                            double d_0l = get_dl(vehicles_approaching[i], vehicles_approaching[j]);
                            double d_m = MainFrame.distMargin + vehicles_approaching[i].length / 2 + vehicles_approaching[j].length / 2;
                            double di = vehicles_approaching[i].dist_to_inter;
                            double Tj = vehicles_approaching[j].dist_to_inter / vehicles_approaching[j].speed_request;
                            double T0j = d_0f / vehicles_approaching[j].speed_request;

                            double speed_request = (di + d_0l - d_m) / (Tj + T0j);

                            speed_requests.Add(speed_request);
                            if (speed_requests.Count() >= 6)
                                break;
                            foundRisk = true;
                        }
                    }
                    if (foundRisk == true)
                    {
                        vehicles_approaching[i].speed_request = speed_requests.Min();
                        if (vehicles_approaching[i].speed_request > MainFrame.speed_limit) vehicles_approaching[i].speed_request = MainFrame.speed_limit;

                    }
                }
            }
        }


        private static bool collision_risk(Vehicle vehicle1, Vehicle vehicle2)
        {
            bool result;
            int i = get_tajectory_index(vehicle1);
            int j = get_tajectory_index(vehicle2);
            if (MainFrame.trajectory_model[i, j] == 1) result = true;
            else result = false;
            return result;
        }

        private static double get_df(Vehicle vehicle1, Vehicle vehicle2)
        {
            double result;
            int a = get_tajectory_index(vehicle1);
            int b = get_tajectory_index(vehicle2);
            result = MainFrame.d0f[a, b];
            return result;
        }
        private static double get_dl(Vehicle vehicle1, Vehicle vehicle2)
        {
            double result;
            int a = get_tajectory_index(vehicle1);
            int b = get_tajectory_index(vehicle2);
            result = MainFrame.d0l[a, b] / 2;
            return result;
        }

        private static int get_tajectory_index(Vehicle vehicle)
        {
            int index = 0;
            String[] route = { "NW", "NS", "NE", "EN", "EW", "ES", "SE", "SN", "SW", "WS", "WE", "WN" };
            for (int i = 0; i < route.Count(); i++)
                if (vehicle.route == route[i]) index = i;
            return index;
        }
    }
}
