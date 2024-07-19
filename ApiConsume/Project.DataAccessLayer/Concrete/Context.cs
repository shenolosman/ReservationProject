﻿using Microsoft.EntityFrameworkCore;
using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;initial catalog=ReservationProjectAPI:integrated security=true");
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services{ get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<MailSubscribe> MailSubscribes { get; set; }
        public DbSet<Testimonial> Testimonial { get; set; }
    }
}
