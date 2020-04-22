using ECommerceApp.Data;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Mvc;
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
        /// Create a chiropractic service and returns object
        /// </summary>
        /// <param name="chiropracticService">object</param>
        /// <returns></returns>
        public async Task<Inventory> CreateChiropracticService(Inventory chiropracticService)
        {
            _context.Add(chiropracticService);
            await _context.SaveChangesAsync();
            return chiropracticService;
        }

        /// <summary>
        /// Get all chiropractic services
        /// </summary>
        /// <returns>list of physical therapy objects</returns>
        public async Task<List<Inventory>> GetAllChiropracticService() => await _context.Inventories.ToListAsync();

        /// <summary>
        /// Get a single chiropractic service by ID and return object
        /// </summary>
        /// <param name="chiropracticServiceID">object</param>
        /// <returns>single physical therapy object</returns>
        public async Task<Inventory> GetChiropracticServiceByID(int chiropracticServiceID) => await _context.Inventories.FindAsync(chiropracticServiceID);

        /// <summary>
        /// Remove a single chiropractic service based on ID and returns the object
        /// </summary>
        /// <param name="chiropracticServiceID">int</param>
        /// <returns>inventory object</returns>
        public async Task<Inventory> RemoveChiropracticService(int chiropracticServiceID)
        {
            Inventory PT = await _context.Inventories.FindAsync(chiropracticServiceID);
            _context.Inventories.Remove(PT);
            await _context.SaveChangesAsync();
            return PT;
        }

        /// <summary>
        /// Update a chiropractic service
        /// </summary>
        /// <param name="chiropracticServiceID">int</param>
        /// <param name="chiropracticService">object</param>
        /// <returns></returns>
        public async Task<Inventory> UpdateChiropracticService(int chiropracticServiceID, Inventory chiropracticService)
        {
            if (chiropracticServiceID != chiropracticService.ID)
            {
                return null;
            }
            _context.Entry(chiropracticService).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return chiropracticService;
        }
    }
}
