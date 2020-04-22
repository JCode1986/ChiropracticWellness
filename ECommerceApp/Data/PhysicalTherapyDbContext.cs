using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Data
{
    public class PhysicalTherapyDbContext : DbContext
    {
        public PhysicalTherapyDbContext(DbContextOptions<PhysicalTherapyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhysicalTherapy>().HasData(

                new PhysicalTherapy
                {
                    ID = 1,
                    ServiceType = ServiceType.initialConsultation,
                    Description = "Initial Evaluation where physical therapist will spend time with you to learn about your condition, your previous level of function, and how your condition is affecting your life.",
                    Price = 100.00M,
                    Duration = "1 hour"
                },
                new PhysicalTherapy
                {
                    ID = 2,
                    ServiceType = ServiceType.followUpConsultation,
                    Description = "Follow up evaluation.",
                    Price = 50.00M,
                    Duration = "30 minutes"
                },
                new PhysicalTherapy
                {
                    ID = 3,
                    ServiceType = ServiceType.lowerBackAdjustment,
                    Description = "Lower back stuff here.",
                    Price = 75.00M,
                    Duration = "30 minutes"
                },
                new PhysicalTherapy
                {
                    ID = 4,
                    ServiceType = ServiceType.neckAdjustment,
                    Description = "Neck stuff here.",
                    Price = 100.00M,
                    Duration = "45 minutes"
                },
                new PhysicalTherapy
                {
                    ID = 5,
                    ServiceType = ServiceType.upperBackAdjustment,
                    Description = "Upper back stuff here.",
                    Price = 75.00M,
                    Duration = "30 minutes"
                },
                new PhysicalTherapy
                {
                    ID = 6,
                    ServiceType = ServiceType.packOfLowerBackAdjustments,
                    Description = "Package deal lower back stuff here.",
                    Price = 100.00M,
                    Duration = "1 hour 30 minutes"
                },
                new PhysicalTherapy
                {
                    ID = 7,
                    ServiceType = ServiceType.packOfNeckAdjustments,
                    Description = "Package deal neck stuff here.",
                    Price = 125.00M,
                    Duration = "1 hour 30 minutes"
                },
                new PhysicalTherapy
                {
                    ID = 8,
                    ServiceType = ServiceType.packOfUpperBackAdjustments,
                    Description = "Package deal lower back stuff here.",
                    Price = 100.00M,
                    Duration = "1 hour 30 minutes"
                },
                new PhysicalTherapy
                {
                    ID = 9,
                    ServiceType = ServiceType.sixtyMinuteMassage,
                    Description = "60 minute massage description here.",
                    Price = 80.00M,
                    Duration = "60 minutes"
                },
                new PhysicalTherapy
                {
                    ID = 10,
                    ServiceType = ServiceType.thirtyMinuteMassage,
                    Description = "60 minute massage description here.",
                    Price = 45.00M,
                    Duration = "30 minutes"
                }
            );
        }
        public DbSet<PhysicalTherapy> PhysicalTherapies { get; set; }
    }
}
