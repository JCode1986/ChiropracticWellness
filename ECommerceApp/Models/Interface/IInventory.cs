using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Interface
{
    public interface IInventory
    {
        //Create
        Task<Service> CreateChiropracticService(Service chiropracticService);

        //Read specific chiropractic service
        Task<Service> GetChiropracticServiceByID(int chiropracticServiceID);

        //Read All
        Task<List<Service>> GetAllChiropracticService();

        //Update
        Task<Service> UpdateChiropracticService(int chiropracticServiceID, Service chiropracticService);

        //Delete
        Task<Service> RemoveChiropracticService(int ID);
    }
}
