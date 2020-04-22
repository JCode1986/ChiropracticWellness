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
        /// Create a chiropractic service
        /// </summary>
        /// <param name="chiropracticService">object</param>
        /// <returns></returns>
        public async Task CreateChiropracticService(Inventory chiropracticService)
        {
            _context.Add(chiropracticService);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all chiropractic services
        /// </summary>
        /// <returns>list of physical therapy objects</returns>
        public async Task<List<Inventory>> GetAllChiropracticService() => await _context.Inventories.ToListAsync();

        /// <summary>
        /// Get a single chiropractic service by ID
        /// </summary>
        /// <param name="chiropracticServiceID">object</param>
        /// <returns>single physical therapy object</returns>
        public async Task<Inventory> GetChiropracticServiceByID(int chiropracticServiceID) => await _context.Inventories.FindAsync(chiropracticServiceID);

        /// <summary>
        /// Remove a single chiropractic service based on ID
        /// </summary>
        /// <param name="chiropracticServiceID">object</param>
        /// <returns></returns>
        public async Task RemoveChiropracticService(int chiropracticServiceID)
        {
            Inventory PT = await _context.Inventories.FindAsync(chiropracticServiceID);
            _context.Inventories.Remove(PT);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update a chiropractic service
        /// </summary>
        /// <param name="chiropracticServiceID">int</param>
        /// <param name="chiropracticService">object</param>
        /// <returns></returns>
        public async Task UpdateChiropracticService(int chiropracticServiceID, Inventory chiropracticService)
        {
            _context.Entry(chiropracticService).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
