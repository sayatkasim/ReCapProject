using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals is null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cus in context.Customers
                             on r.CustomerId equals cus.CustomerId
                             join u in context.Users
                             on cus.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 CarId = c.CarId,
                                 CustomerName= cus.CompanyName,
                                 Description= c.Description,
                                 RentalId=r.RentalId,
                                 RentDate= r.RentDate,
                                 ReturnDate= r.ReturnDate,
                                 UserName= u.Username
                             };

                return result.ToList();
            }
        }
    }
}
