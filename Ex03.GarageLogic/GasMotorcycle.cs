using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class GasMotorcycle : Motorcycle
    {
        private const float k_WheelMaxAirPressure = 30f;
        private const eFuel k_FuelType = eFuel.Octan98;
        private const float k_MaxFuelCapacity = 6f;

        public GasMotorcycle(
            string i_Model,
            string i_LicenseNumber,
            eMotorcycleLicense i_LicenseType,
            int i_EngineCapacity,
            string i_WheelManufacturer)
            : base(i_Model, i_LicenseNumber, i_LicenseType, i_EngineCapacity, i_WheelManufacturer, k_WheelMaxAirPressure, new GasEngine(k_FuelType, k_MaxFuelCapacity))
        {
        }
    }
}
