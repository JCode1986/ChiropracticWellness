using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    public class Inventory
    {
        public int ID { get; set; }

        public ServiceType ServiceType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
        public string Image { get; set; }
    }

    public enum ServiceType
    {
        initialConsultation,
        followUpConsultation,
        neckAdjustment,
        lowerBackAdjustment,
        upperBackAdjustment,
        thirtyMinuteMassage,
        sixtyMinuteMassage,
        packOfNeckAdjustments,
        packOfLowerBackAdjustments,
        packOfUpperBackAdjustments,
    }
}
