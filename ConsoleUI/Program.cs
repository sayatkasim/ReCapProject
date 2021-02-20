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
            //RentalManagerTest();
            //GetAllTest(carManager);
            //UserAdded();
            //CarDTOTest();
            //CarRental();
            //CustomerAdded();


        }

        private static void CustomerAdded()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer {CompanyName = "Musteri1" , UserId = 1004};
            customerManager.Add(customer);
        }
        private static void CarRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CarManager carManager = new CarManager(new EfCarDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var car = carManager.Get(3);
            var customer = customerManager.Get(1);

            if (car.Data == null)
            {
                Console.WriteLine("Araç sistemde bulunamadı.");
            }
            else if (customer.Data == null)
            {
                Console.WriteLine("Müşteri sistemde bulunamadı.");
            }
            else
            {
                var result = rentalManager.Add(new Rental
                {
                    CarId = car.Data.CarId,
                    CustomerId = customer.Data.CustomerId,
                    RentDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))
                });
                if (result.Success)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }
        }
        private static void CarDTOTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car {ModelYear = 2021, BrandId = 2, ColorId = 1, DailyPrice = 800, Description = "A180 AMG"};
            var result = carManager.Add(car);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message + " " + car.Description);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
        private static void UserAdded()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { FirstName = "Musteri1", LastName = "musteri", Password = "password2", Email = "musteri@mail.com", Username = "musteri"};
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
