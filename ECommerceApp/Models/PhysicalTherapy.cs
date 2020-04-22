using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    public class PhysicalTherapy
    {
        public int ID { get; set; }

        public Type Type { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
    }

    public enum Type
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
