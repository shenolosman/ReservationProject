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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly Context context;
        public EfBookingDal(Context context) : base(context)
        {
            this.context = context;
        }    

        public void BookingStatusChangeApprovedWithId(int id)
        {
            var values = context.Bookings.Find(id);
            values.Status = "Approved";
            context.SaveChanges();
        }

        public void BookingStatusChangeDeclineWithId(int id)
        {
            var values = context.Bookings.Find(id);
            values.Status = "Declined";
            context.SaveChanges();
        }

        public void BookingStatusChangeWaitWithId(int id)
        {
            var values = context.Bookings.Find(id);
            values.Status = "Waiting";
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
          return context.Bookings.Count();
        }

        public List<Booking> Last6Booking()
        {
           return context.Bookings.OrderByDescending(x => x.BookingId).Take(6).ToList();
        }
    }
}
