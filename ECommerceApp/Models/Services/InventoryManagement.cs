using ECommerceApp.Data;
using ECommerceApp.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Services
{
    public class InventoryManagement : IInventory
    {
        //gain access to table properties
        private StoreDbContext _context { get; }

        //constructor
        public InventoryManagement(StoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a physical therapy service
        /// </summary>
        /// <param name="physicalTherapy">object</param>
        /// <returns></returns>
        public async Task CreatePhysicalTherapy(PhysicalTherapy physicalTherapy)
        {
            _context.Add(physicalTherapy);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all physical therapies
        /// </summary>
        /// <returns>list of physical therapy objects</returns>
        public async Task<List<PhysicalTherapy>> GetAllPhysicalTherapy() => await _context.PhysicalTherapies.ToListAsync();

        /// <summary>
        /// Get a single physical therapy service by ID
        /// </summary>
        /// <param name="physicalTherapyID">object</param>
        /// <returns>single physical therapy object</returns>
        public async Task<PhysicalTherapy> GetPhysicalTherapyByID(int physicalTherapyID) => await _context.PhysicalTherapies.FindAsync(physicalTherapyID);

        /// <summary>
        /// Remove a single physical therapy service based on ID
        /// </summary>
        /// <param name="physicalTherapyID">object</param>
        /// <returns></returns>
        public async Task RemovePhysicalTherapy(int physicalTherapyID)
        {
            PhysicalTherapy PT = await _context.PhysicalTherapies.FindAsync(physicalTherapyID);
            _context.PhysicalTherapies.Remove(PT);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update a single physical therapy
        /// </summary>
        /// <param name="physicalTherapyID">int</param>
        /// <param name="physicalTherapy">object</param>
        /// <returns></returns>
        public async Task UpdatePhysicalTherapy(int physicalTherapyID, PhysicalTherapy physicalTherapy)
        {
            _context.Entry(physicalTherapy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
