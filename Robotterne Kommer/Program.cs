using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotterne_Kommer
{
    internal class Program
    {
        static void Main(string[] args)
        {//Title screen
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("___________");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Robo CO");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("___________\r\n");
            Console.ResetColor();
            
            int productionnumber = 100;//first robot number
            while (true)
            {
                Robot robot = new Robot();//creates the settings for the robots
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Number: " + productionnumber);//assigns the robot a number
                Console.ResetColor();
                robot.MakeRobot();//creates a robot with different propities
                productionnumber++;
                Console.ReadKey();
            }
        }
    }
}
