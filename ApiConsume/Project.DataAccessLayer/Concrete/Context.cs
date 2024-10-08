﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;initial catalog=ReservationProjectAPI:integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.WorkLocations)
                .WithMany(w => w.AppUsers)
                .HasForeignKey(a => a.WorkLocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<MailSubscribe> MailSubscribes { get; set; }
        public DbSet<Testimonial> Testimonial { get; set; }
        public DbSet<AboutUs> HomePageAboutUs { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests{ get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }
        public DbSet<ContactMessageCategory> ContactMessageCategories { get; set; }
        public DbSet<WorkLocation> WorkLocations { get; set; }

    }
}
