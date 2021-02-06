using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 429, ModelYear = 2018, Description = "Megane Icon" },
                new Car { CarId = 2, BrandId = 1, ColorId = 4, DailyPrice = 700, ModelYear = 2019, Description = "Focus Titanium" },
                new Car { CarId = 3, BrandId = 2, ColorId = 1, DailyPrice = 300, ModelYear = 2018, Description = "Clio Icon" },
                new Car { CarId = 4, BrandId = 3, ColorId = 5, DailyPrice = 4299, ModelYear = 2021, Description = "530i XDrive" },
                new Car { CarId = 5, BrandId = 4, ColorId = 1, DailyPrice = 7999, ModelYear = 2021, Description = "G63 AMG" },
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;

            carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public Car GetById(Car car)
        {
            return _car.SingleOrDefault(c => c.CarId == car.CarId);
        }

        public void Update(Car car)
        {
            Car carUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carUpdate.CarId = car.CarId;
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;
        }
    }
}
