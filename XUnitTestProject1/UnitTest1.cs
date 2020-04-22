using ECommerceApp.Models;
using System;
using Xunit;


namespace XUnitTestProject1
{
    public class UnitTest1
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
    
    }
}
