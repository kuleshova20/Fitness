using Fitness.BL.Controller;
using System;


namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, It's FITNESSapp");

            Console.WriteLine("Enter your name:");
            var name = Console.ReadLine();

            //Console.WriteLine("Enter your gender");
            //var gender = Console.ReadLine();

            //Console.WriteLine("Enter your Birhday");
            //var birthdata = DateTime.Parse(Console.ReadLine()); // must be try parse

            //Console.WriteLine("Enter your weight");
            //var weight = double.Parse(Console.ReadLine());

            //Console.WriteLine("Enter your height");
            //var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name);
            if(userController.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter your birhday (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not true format date");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Not true format value");
                }
            }
        }

    }
}
