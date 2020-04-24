using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Interface
{
    public interface IInventory
    {
        //Create
        Task<Inventory> CreateChiropracticService(Inventory chiropracticService);

        //Read specific chiropractic service
        Task<Inventory> GetChiropracticServiceByID(int chiropracticServiceID);

        //Read All
        Task<List<Inventory>> GetAllChiropracticService();

        //Update
        Task<Inventory> UpdateChiropracticService(int chiropracticServiceID, Inventory chiropracticService);

        //Delete
        Task<Inventory> RemoveChiropracticService(int ID);
    }
}
