using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core
{
    public class Controller : IController
    {
        IRepository<IFormulaOneCar> cars = new FormulaOneCarRepository();
        IRepository<IPilot> pilots = new PilotRepository();
        IRepository<IRace> races = new RaceRepository();
        public string CreatePilot(string fullName)
        {
            IPilot pilot;

            if (pilots.Models.Any(p => p.FullName == fullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilot = new Pilot(fullName);
            pilots.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car;
            if (cars.Models.Any(c => c.Model == model))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            if (type == nameof(Ferrari))
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }

            else if (type == nameof(Williams))
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }

            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race;
            if (races.Models.Any(r => r.RaceName == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            race = new Race(raceName, numberOfLaps);
            races.Add(race);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IFormulaOneCar car = cars.FindByName(carModel);
            IPilot pilot = pilots.FindByName(pilotName);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (car == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            pilot.AddCar(car);
            cars.Remove(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = pilots.FindByName(pilotFullName);
            IRace race = races.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (pilot == null || !pilot.CanRace || race.Pilots.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace race = races.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }


            if (races.FindByName(raceName).TookPlace == true) //?
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }           
                     
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }


            List<IPilot> sortedPilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps))
                .ToList(); // race.Pilots?

            race.TookPlace = true;
            sortedPilots.First().WinRace();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Pilot {sortedPilots[0].FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {sortedPilots[1].FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {sortedPilots[2].FullName} is third in the {raceName} race.");

            return sb.ToString().TrimEnd();
        }


        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IRace race in races.Models.Where(r => r.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }


        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pilot in pilots.Models.OrderByDescending(p => p.NumberOfWins))
            {
                sb = sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }




    }
}
