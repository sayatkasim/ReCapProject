using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapContext>,ICarDal
    {
       public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context =new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto { BrandId = c.BrandId, BrandName=b.BrandName, CarId=c.CarId, 
                                                     ColorId=c.ColorId, DailyPrice=c.DailyPrice, Description=c.Description,
                                                     ModelYear=c.ModelYear};

                return result.ToList();
            }
        }
    }
}
