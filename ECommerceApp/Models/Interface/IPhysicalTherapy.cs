using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Interface
{
    interface IPhysicalTherapy
    {
        //Create
        Task CreatePhysicalTherapy(PhysicalTherapy physicalTherapy);

        //Read specific patient with resources
        Task<PhysicalTherapy> GetPhysicalTherapyByID(int physicalTherapyID);

        //Read All
        Task<List<PhysicalTherapy>> GetAllPhysicalTherapy();

        //Update
        Task UpdatePhysicalTherapy(int physicalTherapyID, PhysicalTherapy physicalTherapy);

        //Delete
        Task RemovePhysicalTherapy(int ID);
    }
}
