using MyFitnessProject.BL.Controller;
using System;

namespace MyFitnessProject.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет от MyFitnessProject");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }
    }
}
