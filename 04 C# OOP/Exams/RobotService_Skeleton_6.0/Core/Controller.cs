using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IRepository<IRobot> robots;
        private IRepository<ISupplement> supplements;

        public Controller()
        {
            robots = new RobotRepository();
            supplements = new SupplementRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }
            if (typeName == nameof(DomesticAssistant))
            {
                IRobot robot = new DomesticAssistant(model);
                robots.AddNew(robot);
            }
            else
            {
                IRobot robot = new IndustrialAssistant(model);
                robots.AddNew(robot);
            }
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(SpecializedArm) && typeName != nameof(LaserRadar))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            if (typeName == nameof(SpecializedArm))
            {
                ISupplement supplement = new SpecializedArm();
                supplements.AddNew(supplement);
            }
            else
            {
                ISupplement supplement = new LaserRadar();
                supplements.AddNew(supplement);
            }
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);


        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName);
            int currentInterFaceValue = supplement.InterfaceStandard;

            IRobot robot = robots.Models().FirstOrDefault(x => x.Model == model && !x.InterfaceStandards.Contains(currentInterFaceValue));

            if (robot == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            robot.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);


            //List<IRobot> robotsToUpgrade = new List<IRobot>();
            //foreach (var robot in robots.Models())
            //{
            //    if (!robot.InterfaceStandards.Contains(currentInterFaceValue))
            //    {
            //        robotsToUpgrade.Add(robot);
            //    }
            //}
            //robotsToUpgrade = robotsToUpgrade.Where(r => r.Model == model).ToList();
            //
            //if (robotsToUpgrade.Count == 0)
            //{
            //    return string.Format(OutputMessages.AllModelsUpgraded, model);
            //}
            //else
            //{
            //    IRobot robotToUpgrade = robotsToUpgrade.First();
            //    robotToUpgrade.InstallSupplement(supplement);
            //    supplements.RemoveByName(supplementTypeName);
            //    return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
            //}
        }
        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> robotsToPerformService = robots.Models()
                .Where(r => r.InterfaceStandards.Contains(intefaceStandard))
            .OrderByDescending(r => r.BatteryLevel).ToList();

            // List<IRobot> robotsToPerformService = new List<IRobot>();
            // foreach (var robot in robots.Models())
            // {
            //     if (robot.InterfaceStandards.Contains(intefaceStandard))
            //     {
            //         robotsToPerformService.Add(robot);
            //     }
            // }

            if (robotsToPerformService.Count == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int allRobotsPower = robotsToPerformService.Sum(r => r.BatteryLevel);

            //robotsToPerformService = robotsToPerformService.OrderByDescending(r => r.BatteryLevel).ToList();

            //int allRobotsPower = 0;
            //foreach (var robot in robotsToPerformService)  // robotsToPerformService.Sum(x => x.BatteryLevel)
            //{
            //    allRobotsPower += robot.BatteryLevel;
            //}

            if (allRobotsPower < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - allRobotsPower);
            }

            int robotCounter = 0;

            foreach(var robot in robotsToPerformService)
            {
                robotCounter++;

                if (robot.BatteryLevel >= totalPowerNeeded)  // = added
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }

                totalPowerNeeded -= robot.BatteryLevel;
                robot.ExecuteService(robot.BatteryLevel);  // ? not clear(was totalPowerNeeded
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotCounter);
        }
        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> robotsToFeed = new List<IRobot>();
            foreach (var robot in robots.Models().Where(r => r.Model == model && r.BatteryLevel < r.BatteryCapacity / 2))
            {
                
                robotsToFeed.Add(robot);
            }

            foreach (var robot in robotsToFeed)
            {
                
                robot.Eating(minutes);
            }

            return string.Format(OutputMessages.RobotsFed, robotsToFeed.Count);

        }
        public string Report()
        {
            List<IRobot> allRobotsToReport = robots.Models().OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var robot in allRobotsToReport) { sb.AppendLine(robot.ToString()); }

            return sb.ToString().TrimEnd();
        }
    }
}
