using CC.Scheduling.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager.Persistance.Data
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Client> Client { get; set; }


        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            const string schema = "SchedulingDB";

            var schedule = builder.Entity<Schedule>();
            schedule.ToTable(nameof(Schedule), schema);
            schedule.HasKey(x => x.ScheduleId);
            schedule.Property(x => x.Name).HasColumnType("VARCHAR(100)");
            schedule.Property(x => x.FromTime);
            schedule.Property(x => x.ToTime);
            schedule.HasOne(x => x.Client);

            var client = builder.Entity<Client>();
            client.ToTable(nameof(Client), schema);
            client.HasKey(x => x.ClientId);
            client.Property(x => x.FirstName).HasColumnType("VARCHAR(100)");
            client.Property(x => x.LastName).HasColumnType("VARCHAR(100)");
            client.Property(x => x.Email).HasColumnType("VARCHAR(100)");
            client.Property(x => x.PhoneNumber).HasColumnType("VARCHAR(10)");

        }
    }
}
