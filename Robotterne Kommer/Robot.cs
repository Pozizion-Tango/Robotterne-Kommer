using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotterne_Kommer
{
    internal class Robot
    {
        Random rnd = new Random();//a random to be used a lot to make randomized assignements to the robots.
        private string serialnumber;
        private string size;
        private bool wifichip;
        private string color;
        private int battery;
        private string job;
        private double soap;
        private int wheels;

        public string Serialnumber
        {
            get { return serialnumber; }
            set { serialnumber = value; }
        }
        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        public bool Wifichip
        {
            get { return wifichip; }
            set { wifichip = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public int Battery
        {
            get { return battery; }
            set { battery = value; }
        }
        public string Job
        {
            get { return job; }
            set { job = value; }
        }
        public double Soap
        {
            get { return soap; }
            set { soap = value; }
        }
        public int Wheels
        {
            get { return wheels; }
            set { wheels = value; }
        }
        public void MakeRobot()
        {
            this.Serialnumber = SerialNumber();//finds a serial number for the robot using a 50/50 chance to select what chip
            Console.WriteLine(serialnumber);
            this.Size = SizeRandom();// gives the robot a random size, that later will be used to choose how many wheels it has. From none to 3
            Console.WriteLine(size);
            this.Color = SelectColor();//gives only a few of the robots a yellow paint
            if (this.Color == "color: Yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(color);
                Console.ResetColor();
            }    
            else
                Console.WriteLine(color);
            this.Battery = BatteryCapacity();//will give all white robots a battery, while the yellow once have none
            if (this.Battery == 0)
                Console.WriteLine("Battery: None");
            else
                Console.WriteLine("Battery: "+battery+"%");
            this.Wifichip = WifiChip();//a 50/50 chance to either have or not have a Wifichip
            Console.WriteLine("Wifichip: "+wifichip);
            this.Job = JobFinder();//selects a job for the robot, from 1 of 3 jobs.
            Console.WriteLine(job);
            this.Soap = SoapCapacity();//checks if the robot is a cleaning robot or not, if not it's soap will be set to none
            if (this.soap == 0)
                Console.WriteLine("Soap Capacity: None");
            else
            Console.WriteLine("Soap Capacity: "+soap);
            this.Wheels = WheelAmount();// it will check if it got any wheels, size matters in this. Small robots got no wheels. Medium 2, large 3.
            if (this.Wheels == 0)
                Console.WriteLine("Wheels: None\r\n");
            else
            Console.WriteLine("Wheels: "+wheels+"\r\n");
          
        }
        public string SerialNumber()
        {
            string serialnumber = "";
            int fiftyfifty = rnd.Next(1, 3);// a 50/50 chance
            if (fiftyfifty == 1)
                serialnumber = "Chip: RX54667";
            else
                serialnumber = "Chip: QT8339";
            return serialnumber;
        }
        public string SizeRandom()
        {
            double size = rnd.NextDouble() * (2.0 - 0.5) + 0.5;//using a Double to randomize, a size will be picked randomly.
            string finishsize = "";
            if (size < 1)
                return (finishsize = "small: " + size.ToString("0.0"));
            else if (size < 1.5)
                return (finishsize = "medium: : " + size.ToString("0.0"));
            else
                return (finishsize = "large: " + size.ToString("0.0"));
        }
        public bool WifiChip()// 50/50 chance on it having wifi or not
        {
            int fiftyfifty = rnd.Next(1, 3);
            if (fiftyfifty == 1)
                return true;
            else
                return false;
        }
        public string SelectColor()// 1/5 chance on a yellow robot to be choosen
        {
            string color = "color: ";
            int oneinfive = rnd.Next(1, 6);
            if (oneinfive == 1)
                return color = color + "Yellow";
            else
                return color = color + "White";
        }
        public int BatteryCapacity()//if the robot is yellow, it sets the Battery to 0, aka None. but sets it to 255 if white
        {
            int BatteryCapacity = 0;
            if (this.color == "color: Yellow")
                return BatteryCapacity;
            else
                return BatteryCapacity = 255;
        }
        public string JobFinder()//selects a job out of 3 options.
        {
            int jobfindersmall = rnd.Next(1, 4);
            if (jobfindersmall == 1)
                return "Job: Floor Cleaner";
            else if (jobfindersmall == 2)
                return "Job: Window Cleaner";
            else
                return "Job: Tire Switcher";
        }
        public double SoapCapacity()//if the jobs is a Tire Switcher, only job that contains a T. It will have 0 soap, aka None
        {
            if (this.Job.Contains("T"))
                return 0;
            else
                return 2.3;
        }
        public int WheelAmount()//using different the starting chars, we will know the size and how many wheels it needs.
        {
            string size = this.Size;
            bool small = size.Contains("small");//small
            bool medium = size.Contains("medium");//medium
            if (small)
                return 0;
            else if (medium)
                return 2;
            else
                return 3;
        }
    }
}
