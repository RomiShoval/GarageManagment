using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Motorcycle
    {
        private const float k_WheelMaxAirPressure = 30f;
        private const float k_MaxBatteryTime = 1.8f;

        public ElectricMotorcycle(
            string i_Model,
            string i_LicenseNumber,
            eMotorcycleLicense i_LicenseType,
            int i_EngineCapacity,
            string i_WheelManufacturer)
            : base(i_Model, i_LicenseNumber, i_LicenseType, i_EngineCapacity, i_WheelManufacturer, k_WheelMaxAirPressure, new ElectricEngine(k_MaxBatteryTime))
        {
        }
    }
}
