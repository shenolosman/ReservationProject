﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DataAccessLayer.Abstract;
using Project.DataAccessLayer.Concrete;
using Project.DataAccessLayer.Repositories;
using Project.EntityLayer.Concrete;

namespace Project.DataAccessLayer.EntityFramework
{
    public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EfTestimonialDal(Context context) : base(context)
        {
        }
    }
}
