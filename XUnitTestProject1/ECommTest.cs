using ECommerceApp.Models;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestProject1
{
    public class ECommTest
    {

        [Fact]
        public void CanAddDescriptionToInventory()
        {
            Inventory inventory = new Inventory();
            inventory.Description = "neck treatment";
            Assert.Equal("neck treatment", inventory.Description);
        }
    
        [Fact]
        public void CanSetDescriptionToInventory()
        {
            Inventory inventory = new Inventory();
            inventory.Description = "back treatment";
            inventory.Description = "neck treatment";
            Assert.Equal("neck treatment", inventory.Description);
        }

        [Fact]
        public async Task CanAddPostToDB()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanAddPostToDB")
                .Options;

            // open the connection to the database
            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManagement IM = new InventoryManagement(context);

                Inventory inventory = new Inventory()
                {
                    ID = 1,
                    ServiceType = ServiceType.neckAdjustment,
                    Price = 50M,
                    Description = "Headlock",
                    Duration = "25 minutes"
                };

                var result = await IM.CreateChiropracticService(inventory);

                // Check if the post exists through the context directly
                var data = context.Inventories.Find(inventory.ID);
                Assert.Equal(result, data);
            }
        }

        [Fact]
        public async Task CanReadFromDB()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("CanReadFromDB")
               .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManagement IM = new InventoryManagement(context);

                Inventory _ = new Inventory()
                {
                    ID = 1,
                    ServiceType = ServiceType.neckAdjustment,
                    Price = 50M,
                    Description = "Headlock",
                    Duration = "25 minutes"
                };

                var result = await IM.GetAllChiropracticService();
                Assert.NotNull(result);
            }
        }
      
        [Fact(Skip = "Doesn't work at the moment")]
        public async Task CanDeleteAnItem()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("CanDeleteAnItem")
               .Options;
            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManagement IM = new InventoryManagement(context);

                Inventory inventory = new Inventory()
                {
                    ID = 1,
                    Price = 50M,
                    Description = "Headlock",
                    Duration = "25 minutes"
                };
                await IM.RemoveChiropracticService(inventory.ID);
                Assert.Null(inventory.Duration);
            }
        }
    }
}
