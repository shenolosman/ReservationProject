using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusChangeApprovedWithId(int id);
        void BookingStatusChangeDeclineWithId(int id);
        void BookingStatusChangeWaitWithId(int id);
        int GetBookingCount();
        List<Booking> Last6Booking();
    }
}
