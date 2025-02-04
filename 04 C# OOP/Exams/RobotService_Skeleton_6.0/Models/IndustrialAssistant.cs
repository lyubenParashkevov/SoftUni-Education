﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        private const int IndustrialAssistantBatteryCapacity = 40_000;
        private const int IndustrialAssistantConversionCapacityIndex = 5_000;
        public IndustrialAssistant(string model) : base(model, IndustrialAssistantBatteryCapacity, IndustrialAssistantConversionCapacityIndex)
        {
        }
    }
}
