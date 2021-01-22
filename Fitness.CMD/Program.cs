using Fitness.BL.Controller;
using System;


namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, It's FITNESSapp");

            Console.WriteLine("Enter your name");
            var name = Console.ReadLine();

            Console.WriteLine("Enter your gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter your Birhday");
            var birthdata = DateTime.Parse(Console.ReadLine()); // must be try parse

            Console.WriteLine("Enter your weight");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter your height");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdata, weight, height);

            userController.Save();

        }
    }
}
