using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Train_project.Models;

namespace Train_project.Data
{
    public class TrainContext : DbContext
    {
        public TrainContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Class> Class { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }

    }
}
