﻿using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingStatusChangeApproved(Booking model);
        void BookingStatusChangeApprovedWithId(int id);
        int TGetBookingCount();
        List<Booking> TLast6Booking();

    }
}
