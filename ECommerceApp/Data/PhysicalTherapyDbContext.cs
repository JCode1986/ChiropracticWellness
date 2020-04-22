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
    }
}
