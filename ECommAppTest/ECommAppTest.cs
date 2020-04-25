using ECommerceApp.Models;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommAppTest
{
    public class ECommAppTest
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
                    ServiceType = "Neck Adjustment",
                    Price = 50M,
                    Description = "Neck lock",
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

                Inventory inventory = new Inventory()
                {
                    ID = 1,
                    ServiceType = "Neck Adjustment",
                    Price = 50M,
                    Description = "Headlock",
                    Duration = "60 minutes"
                };
                await IM.CreateChiropracticService(inventory);
                var result = await IM.GetAllChiropracticService();
                Assert.Equal("60 minutes", result[0].Duration);
            }
        }

        [Fact]
        public async Task CanReadSpecificItemFromDB()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("CanReadSpecificItemFromDB")
               .Options;

            using (StoreDbContext context = new StoreDbContext(options))
            {
                InventoryManagement IM = new InventoryManagement(context);

                Inventory invOne = new Inventory()
                {
                    ID = 1,
                    ServiceType = "Neck Adjustment",
                    Price = 50M,
                    Description = "Headlock",
                    Duration = "60 minutes"
                };
                Inventory invTwo = new Inventory()
                {
                    ID = 2,
                    ServiceType = "Back Adjustment",
                    Price = 50M,
                    Description = "Back breaker",
                    Duration = "60 minutes"
                };

                await IM.CreateChiropracticService(invOne);
                await IM.CreateChiropracticService(invTwo);
                var result = await IM.GetChiropracticServiceByID(invOne.ID);
                Assert.Equal("Headlock", result.Description);
            }
        }

        [Fact]
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
                await IM.CreateChiropracticService(inventory);
                var result = await IM.RemoveChiropracticService(1);
                Assert.Equal("Headlock", result.Description);
            }
        }

        [Fact]
        public async Task CanUpdateAnItem()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("CanUpdateAnItem")
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

                await IM.CreateChiropracticService(inventory);
                inventory.Duration = "60 minutes";
                var result = await IM.UpdateChiropracticService(1, inventory);
                Assert.Equal("60 minutes", result.Duration);
            }
        }
    }
}
