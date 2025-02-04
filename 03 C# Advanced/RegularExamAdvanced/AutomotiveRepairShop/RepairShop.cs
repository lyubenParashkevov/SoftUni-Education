using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity) 
        { 
            this.Capacity = capacity;
            this.Vehicles = new List<Vehicle>();
        }
        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            foreach (Vehicle vehicle in Vehicles.Where(v => v.VIN == vin))
            {
                Vehicles.Remove(vehicle);
                return true;
            }
            return false;
        }

        public int GetCount()
        {
            return Vehicles.Count;
        }

        public Vehicle GetLowestMileage()
        {
            var ordered = Vehicles.OrderBy(v => v.Mileage).ToList();
            return ordered.FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");

            foreach (Vehicle vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
