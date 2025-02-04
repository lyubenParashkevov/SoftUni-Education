using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {

        private Repository<IUser> userRepository;
        private Repository<IVehicle> vehicleRepository;
        private Repository<IRoute> routeRepository;
        public Controller()
        {
            userRepository = new UserRepository();
            vehicleRepository = new VehicleRepository();
            routeRepository = new RouteRepository();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (userRepository.FindById(drivingLicenseNumber) != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);

            }

            IUser user = new User(firstName, lastName, drivingLicenseNumber);

            userRepository.AddModel(user);

            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
            //return string.Format("{0} {1} is registered successfully with DLN-{2}", firstName, lastName, drivingLicenseNumber);
        }
        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber) //?
        {

            if (vehicleType != nameof(PassengerCar) && vehicleType != nameof(CargoVan))
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            IVehicle vehicle = vehicleRepository.FindById(licensePlateNumber);

            if (vehicle != null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            if (vehicleType == nameof(CargoVan))
            {
                IVehicle cargovan = new CargoVan(brand, model, licensePlateNumber);
                vehicleRepository.AddModel(cargovan);
                return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
            }
            else
            {
                IVehicle passengerCar = new PassengerCar(brand, model, licensePlateNumber);
                vehicleRepository.AddModel(passengerCar);
                return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
            }

        }

        public string AllowRoute(string startPoint, string endPoint, double length) ////////////////////?
        {
            int routeId = routeRepository.GetAll().Count + 1;


            IRoute route = new Route(startPoint, endPoint, length, routeId);

            if (routeRepository.GetAll().Where(r => r.StartPoint == startPoint).Where(r => r.EndPoint == endPoint)
                .Where(r => r.Length == length).Any())
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);

            }

            if (routeRepository.GetAll().Where(r => r.StartPoint == startPoint).Where(r => r.EndPoint == endPoint)
                .Where(r => r.Length < length).Any())
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }



            routeRepository.AddModel(route);

            IRoute routeToLock = routeRepository.GetAll().Where(r => r.StartPoint == startPoint).Where(r => r.EndPoint == endPoint)
               .Where(r => r.Length > length).FirstOrDefault();
            {
                if (routeToLock != null)
                {
                    routeToLock.LockRoute();
                }
            }

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }
        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {

            IVehicle vehicletoDrive = vehicleRepository.GetAll().First(v => v.LicensePlateNumber == licensePlateNumber); //////?
            IRoute routeToDrive = routeRepository.GetAll().First(r => r.RouteId == int.Parse(routeId));
            IUser userToDrive = userRepository.GetAll().First(u => u.DrivingLicenseNumber == drivingLicenseNumber);

            if (userToDrive.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);

            }

            if (vehicletoDrive.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);

            }

            if (routeToDrive.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);

            }

            vehicletoDrive.Drive(routeToDrive.Length);

            if (isAccidentHappened == true)
            {
                vehicletoDrive.ChangeStatus();
                userToDrive.DecreaseRating();
            }
            else
            {
                userToDrive.IncreaseRating();
            }


            return vehicletoDrive.ToString();


        }
        public string RepairVehicles(int count)                            ///?
        {
            List<IVehicle> vehiclesToRepair = vehicleRepository.GetAll().Where(v => v.IsDamaged == true)
                .OrderBy(v => v.Brand).ThenBy(v => v.Model).ToList();

            if (vehiclesToRepair.Count < count)
            {
                int repaired = 0;
                for (int i = 0; i < vehiclesToRepair.Count; i++)
                {
                    vehiclesToRepair[i].ChangeStatus();
                    vehiclesToRepair[i].Recharge();
                    repaired++;
                    count = repaired;
                }
                return string.Format(OutputMessages.RepairedVehicles, count);
            }

            for (int i = 0; i < count; i++)
            {
                vehiclesToRepair[i].ChangeStatus();
                vehiclesToRepair[i].Recharge();
            }
            return string.Format(OutputMessages.RepairedVehicles, count);
        }


        public string UsersReport()
        {
            IUser[] usersToPrint = userRepository.GetAll().OrderByDescending(u => u.Rating).ThenBy(u => u.LastName)
                .ThenBy(u => u.FirstName).ToArray();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** E-Drive-Rent ***");

            foreach (var user in usersToPrint)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
