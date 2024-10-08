﻿using Project.BusinessLayer.Abstract;
using Project.DataAccessLayer.Abstract;
using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TBookingStatusChangeApprovedWithId(int id)
        {
            _bookingDal.BookingStatusChangeApprovedWithId(id);
        }

        public void TBookingStatusChangeDeclineWithId(int id)
        {
            _bookingDal.BookingStatusChangeDeclineWithId(id);
        }

        public void TBookingStatusChangeWaitWithId(int id)
        {
            _bookingDal.BookingStatusChangeWaitWithId(id);
        }

        public void TDelete(Booking t)
        {
            _bookingDal.Delete(t);
        }

        public int TGetBookingCount()
        {
            return _bookingDal.GetBookingCount();
        }

        public Booking TGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public void TInsert(Booking t)
        {
            _bookingDal.Insert(t);
        }

        public List<Booking> TLast6Booking()
        {
            return _bookingDal.Last6Booking();
        }

        public void TUpdate(Booking t)
        {
            _bookingDal.Update(t);
        }
    }
}
