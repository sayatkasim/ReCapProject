using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("----- Get All -----");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear);
            }
            
            Console.WriteLine("----- Get All Car Details-----");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName+ " " + car.Description+ " " + car.ColorName);
            }
        }
    }
}
