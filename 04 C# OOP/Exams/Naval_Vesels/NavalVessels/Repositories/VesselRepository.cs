using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> vesselsRepo = new List<IVessel>();
        public IReadOnlyCollection<IVessel> Models { get {  return vesselsRepo.AsReadOnly(); } }

        public void Add(IVessel model)
        {
            vesselsRepo.Add(model);
        }
        public bool Remove(IVessel model)
        {
            return vesselsRepo.Remove(model);
        }
        public IVessel FindByName(string name)
        {
            return vesselsRepo.FirstOrDefault(x => x.Name == name);
        }

        
    }
}
