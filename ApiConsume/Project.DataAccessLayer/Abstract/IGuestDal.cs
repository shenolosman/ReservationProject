﻿using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Abstract
{
    public interface IGuestDal : IGenericDal<Guest>
    {
        int GuestCount();
    }
}
