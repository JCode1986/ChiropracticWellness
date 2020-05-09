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
        private UserManager<ApplicationUser> _user;

        public ReceiptOrderService(StoreDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }

        public async Task<string> CreateReceipt(string userId)
        {
            Receipt receipt = new Receipt();
            receipt.UserID = userId;
            _context.Receipt.Add(receipt);
            await _context.SaveChangesAsync();
            return userId;
        }


        public async Task<ReceiptOrders> CreateAllReceiptInfo(ReceiptOrders receiptOrders)
        {
            _context.Add(receiptOrders);
            await _context.SaveChangesAsync();
            return receiptOrders;
        }

        public async Task<List<CartItems>> GetAllCartItems(string username)
        {
            var user = await _user.FindByNameAsync(username);
            var userReceipt = await _context.Receipt.FirstOrDefaultAsync(x => x.UserID == user.Id);

            //Get all serivces from specific user/receipt
            var receiptOrder = await _context.CartItems.Where(x => x.CartID == userReceipt.ID)
                                                    .Include(x => x.Services).ToListAsync();
            return receiptOrder;
        }

        public async Task<List<ReceiptOrders>> GetAllReceiptInfo() => await _context.ReceiptOrders.ToListAsync();

        public async Task<ReceiptOrders> GetReceiptByID(int ID) => await _context.ReceiptOrders.FindAsync(ID);

        public async Task<int> GetReceiptIdForUser(string username)
        {
            var user = await _user.FindByNameAsync(username);
            var receipt = await _context.Receipt.FirstOrDefaultAsync(x => x.UserID == user.Id);

            if (receipt != null)
            {
                return receipt.ID;
            }
            return 0;
        }
    }
}
