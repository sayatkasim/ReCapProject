using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;
        
        public CarManager (ICarDal carDal)
        {
            _CarDal = carDal;
        }
        public void Add(Car car)
        {
            _CarDal.Add(car);
        }

        public void Delete(Car car)
        {
            _CarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
           return _CarDal.GetAll();
        }

        public Car GetById(Car car)
        {
            return _CarDal.GetById(car);
        }


        public void Update(Car car)
        {
            _CarDal.Update(car);
        }
    }
}
