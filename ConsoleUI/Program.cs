using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car { ModelYear = 2021, BrandId = 2, ColorId = 1, DailyPrice = 800, Description = "A180 AMG" };
            var result = carManager.Add(car);
            if (result.Success==true)
            {
                Console.WriteLine(result.Message +" "+ car.Description);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            

            Console.WriteLine("----- Get All Car Details-----");
            foreach (var carDetail in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(carDetail.BrandName + " " + carDetail.Description + " " + carDetail.ColorName);
            }
            Console.WriteLine("Araç kiralama test");

            //RentalManagerTest();
            //GetAllTest(carManager);
            //UserAdded();

        }
        private static void RentalManagerTest()
        {
            IRentalService _rentalManager = new RentalManager(new EfRentalDal());

            var result = _rentalManager.GetAll();

            if (result.Success == true)
            {
                foreach (var rental in _rentalManager.GetAll().Data)
                {
                    Console.WriteLine(rental.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void UserAdded()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { UserId = 1, FirstName = "Sayat", LastName = "Kasim", Password = "password1" };
            userManager.Add(user);
        }

        private static void GetAllTest(CarManager carManager)
        {
            Console.WriteLine("----- Get All -----");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.ModelYear);
            }

            Console.WriteLine("----- Get All Car Details-----");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.BrandName + " " + car.Description + " " + car.ColorName);
            }
        }
    }
}
