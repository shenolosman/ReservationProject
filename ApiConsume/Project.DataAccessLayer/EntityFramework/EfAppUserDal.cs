using Microsoft.EntityFrameworkCore;
using Project.DataAccessLayer.Abstract;
using Project.DataAccessLayer.Concrete;
using Project.DataAccessLayer.Repositories;
using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        private readonly Context _context;
        public EfAppUserDal(Context context) : base(context)
        {
            _context = context;
        }

        public int AppUserCount()
        {
            return _context.Users.Count();
        }

        public IQueryable<AppUser> UserListWithWorkLocation()
        {
            var values = (from AspNetUsers in _context.Users
                          join _worklocation in _context.WorkLocations
                          on AspNetUsers.WorkLocationId equals _worklocation.WorkLocationId into listusers

                          from list in listusers.DefaultIfEmpty()

                          select new AppUser
                          {
                              Id = AspNetUsers.Id,
                              Name = AspNetUsers.Name,
                              Surname = AspNetUsers.Surname,
                              City = AspNetUsers.City,
                              ImageUrl = AspNetUsers.ImageUrl,
                              WorkDeparment = list.WorkLocationCityHotelName,                              
                              WorkLocationId = AspNetUsers.Id,
                          });

            return values.AsQueryable();
        }

    }
}
