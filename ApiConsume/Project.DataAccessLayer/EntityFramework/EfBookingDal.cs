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
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusChangeApproved(Booking model)
        {
            var context = new Context();
            var values = context.Bookings.Where(x => x.BookingId == model.BookingId).FirstOrDefault();
            values.Status = "Approved";
            context.SaveChanges();
        }

        public void BookingStatusChangeApprovedWithId(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Approved";
            context.SaveChanges();
        }
    }
}
