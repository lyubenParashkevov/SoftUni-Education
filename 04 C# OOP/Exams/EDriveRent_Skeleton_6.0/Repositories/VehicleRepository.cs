using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : Repository<IVehicle>
    {
        private List<IVehicle> vehicles;

        public VehicleRepository() 
        {
            vehicles = new List<IVehicle>();
        }
        public void AddModel(IVehicle model)
        {
            vehicles.Add(model);
        }
        public bool RemoveById(string identifier)
        {
            return vehicles.Remove(FindById(identifier));   
        }

        public IVehicle FindById(string identifier)
        {
            return vehicles.FirstOrDefault(x => x.LicensePlateNumber == identifier); 
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
           return vehicles.AsReadOnly();    
        }

        
    }
}
