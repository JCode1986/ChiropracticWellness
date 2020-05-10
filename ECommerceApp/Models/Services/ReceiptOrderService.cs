using ECommerceApp.Data;
using ECommerceApp.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Services
{
    public class ReceiptOrderService : IReceiptOrders
    {
        private StoreDbContext _context;

        public ReceiptOrderService(StoreDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
        }
        
        /// <summary>
        /// Create receipt information
        /// </summary>
        /// <param name="receiptOrders">object</param>
        /// <returns>object</returns>
        public async Task<ReceiptOrders> CreateReceiptInfo(ReceiptOrders receiptOrders)
        {
            _context.Add(receiptOrders);
            await _context.SaveChangesAsync();
            return receiptOrders;
        }

        /// <summary>
        /// Get all receipt information
        /// </summary>
        /// <returns>object</returns>
        public async Task<List<ReceiptOrders>> GetAllReceiptInfo() => await _context.ReceiptOrders.ToListAsync();

        /// <summary>
        /// get specific receipt information
        /// </summary>
        /// <param name="ID">int</param>
        /// <returns>object</returns>
        public async Task<ReceiptOrders> GetReceiptByID(int ID) => await _context.ReceiptOrders.FindAsync(ID);
    }
}
