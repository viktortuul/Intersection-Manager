using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main;
using vehicle;

namespace Spawn_Vehicles
{
    class Spawn
    {
        // vehicle spawn parameters
        public static double spawn_speed; // spawn speed
        public static int spawn_ID = 0; // vehicle spawn ID
        public static int last_ID = 0; // last ID (for the ghost vehicle)
        public static string last_spawn = "North"; // last spawn position
        public static string last_target = ""; // last spawn target
        public static bool random_target = true; // toggle random target

        // random operator 
        static Random rnd = new Random();


        public static void All()
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
                MainFrame.vehicles.Add(bil1);
                MainFrame.vehicles.Add(bil2);
                MainFrame.vehicles.Add(bil3);
                MainFrame.vehicles.Add(bil4);
                MainFrame.vehicles_ghost.Add(bil01);
                MainFrame.vehicles_ghost.Add(bil02);
                MainFrame.vehicles_ghost.Add(bil03);
                MainFrame.vehicles_ghost.Add(bil04);
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
                MainFrame.vehicles.Add(bil1);
                MainFrame.vehicles.Add(bil2);
                MainFrame.vehicles.Add(bil3);
                MainFrame.vehicles.Add(bil4);
                MainFrame.vehicles_ghost.Add(bil01);
                MainFrame.vehicles_ghost.Add(bil02);
                MainFrame.vehicles_ghost.Add(bil03);
                MainFrame.vehicles_ghost.Add(bil04);
            }

 

        }
        public static void Random()
        {
            Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, get_random_spawn(), get_random_target(), true);
            Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, last_spawn, last_target, false);
            MainFrame.vehicles.Add(bil1);
            MainFrame.vehicles_ghost.Add(bil01);
        }

        public static void North()
        {
            if (random_target == true)
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "North", get_random_target(), true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "North", last_target, false);
                MainFrame.vehicles.Add(bil1);
                MainFrame.vehicles_ghost.Add(bil01);
            }
            else
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "North", "South", true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "North", "South", false);
                MainFrame.vehicles.Add(bil1);
                MainFrame.vehicles_ghost.Add(bil01);
            }
            last_spawn = "North";
        }

        public static void East()
        {
            if (random_target == true)
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "East", get_random_target(), true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "East", last_target, false);
                MainFrame.vehicles.Add(bil1);
                MainFrame.vehicles_ghost.Add(bil01);
            }
            else
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "East", "West", true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "East", "West", false);
                MainFrame.vehicles.Add(bil1);
                MainFrame.vehicles_ghost.Add(bil01);
            }
            last_spawn = "East";
        }

        public static void South()
        {
            if (random_target == true)
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "South", get_random_target(), true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "South", last_target, false);
                MainFrame.vehicles.Add(bil1);
                MainFrame.vehicles_ghost.Add(bil01);
            }
            else
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "South", "North", true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "South", "North", false);
                MainFrame.vehicles.Add(bil1);
                MainFrame.vehicles_ghost.Add(bil01);
            }
            last_spawn = "South";
        }

        public static void West()
        {
            if (random_target == true)
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "West", get_random_target(), true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "West", last_target, false);
                MainFrame.vehicles.Add(bil1);
                MainFrame.vehicles_ghost.Add(bil01);
            }
            else
            {
                Vehicle bil1 = new Vehicle(spawnID_next(), "Car", spawn_speed, "West", "East", true);
                Vehicle bil01 = new Vehicle(last_ID, "Car", spawn_speed, "West", "East", false);
                MainFrame.vehicles.Add(bil1);
                MainFrame.vehicles_ghost.Add(bil01);
            }
            last_spawn = "West";
        }


        private static int spawnID_next()
        {
            spawn_ID += 1;
            last_ID = spawn_ID;
            return spawn_ID;
        }

        private static int spawnID_keep()
        {
            return spawn_ID;
        }

        private static string get_random_spawn()
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

        private static string get_random_target()
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
    }
}
