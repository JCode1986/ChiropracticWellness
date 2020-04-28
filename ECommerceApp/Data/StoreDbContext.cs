using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(

                new Service
                {
                    ID = 1,
                    ServiceType = "Initial Consultation",
                    Description = "Initial Evaluation where the Chiropractor will spend time with you to learn about your condition, your previous level of function, and how your condition is affecting your life. He will then perform an examination and perform a treatment.",
                    Price = 250.00M,
                    Duration = "1 hour",
                    Image = "/Styles/Assets/InitialEvaluation.jpg"
                },
                new Service
                {
                    ID = 2,
                    ServiceType = "Follow-up Consultation",
                    Description = "A Follow-up Evaluation where the Chiropractor will spend time with you to see how you are doing and how you are meeting your functional goals. He will then perform an mini-examination and perform a treatment. Note: This service is only available after you have had a full initial consultation",
                    Price = 150.00M,
                    Duration = "45-60 minutes",
                    Image = "/Styles/Assets/FollowUpConsultation.jpg"
                },
                new Service
                {
                    ID = 3,
                    ServiceType = "Lower Back Adjustment",
                    Description = "A follow up visit for targetted adjustment of the lower back.",
                    Price = 75.00M,
                    Duration = "30 minutes",
                    Image = "/Styles/Assets/LowBack1.jpg"
                },
                new Service
                {
                    ID = 4,
                    ServiceType = "Neck Adjustment",
                    Description = "A follow up visit for targetted adjustment of the neck.",
                    Price = 85.00M,
                    Duration = "30 minutes",
                    Image = "/Styles/Assets/NeckAdjustment1.jpg"
                },
                new Service
                {
                    ID = 5,
                    ServiceType = "Upper Back Adjustment",
                    Description = "A follow up visit for targetted adjustment of the upper back/thoracic region.",
                    Price = 75.00M,
                    Duration = "30 minutes",
                    Image = "/Styles/Assets/UpperBack1.jpg"
                },
                new Service
                {
                    ID = 6,
                    ServiceType = "5-Pack of Lower Back Adjustments",
                    Description = "Reguar adjustments are sometimes necessary to maintain pain free postural alignment. This service allows you to purchase 5 low back adjustments at a discounted rate that may be used within the next 6 months.",
                    Price = 300.00M,
                    Duration = "30 minutes each",
                    Image = "/Styles/Assets/LowBack2.jpg"
                },
                new Service
                {
                    ID = 7,
                    ServiceType = "5-Pack of Neck Adjustments",
                    Description = "Reguar adjustments are sometimes necessary to maintain pain free postural alignment. This service allows you to purchase 5 neck adjustments at a discounted rate that may be used within the next 6 months.",
                    Price = 325.00M,
                    Duration = "30 minutes each",
                    Image = "/Styles/Assets/NeckAdjustment2.jpg"
                },
                new Service
                {
                    ID = 8,
                    ServiceType = "5-Pack of Upper Back Adjustments",
                    Description = "Reguar adjustments are sometimes necessary to maintain pain free postural alignment. This service allows you to purchase 5 upper back/thoracic region adjustments at a discounted rate that may be used within the next 6 months.",
                    Price = 300.00M,
                    Duration = "30 minutes each",
                    Image = "/Styles/Assets/UpperBack2.jpg"
                },
                new Service
                {
                    ID = 9,
                    ServiceType = "60 Minute Massage",
                    Description = "A 60-minute Orthopedic massage allowing for deep tissue therapy of problem areas. The massage may incorporate Shiatzu, Swedish or trigger point techniques.",
                    Price = 80.00M,
                    Duration = "60 minutes",
                    Image = "/Styles/Assets/Massage1.jpg"
                },
                new Service
                {
                    ID = 10,
                    ServiceType = "30 Minute Massage",
                    Description = "A 30-minute Orthopedic massage providing an overall massage. The massage may incorporate Shiatzu or Swedish techniques. This massage is best suited before a Chiropractic adjustment. If you are seeking deep tissue or have a specific problem area, consider a 60-minute massage instead.",
                    Price = 45.00M,
                    Duration = "30 minutes",
                    Image = "/Styles/Assets/Massage2.jpg"
                }
            );
        }

        //refer to each table created
        public DbSet<Service> Inventories { get; set; }
    }
}
