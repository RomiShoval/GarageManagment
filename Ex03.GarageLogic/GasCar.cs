using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class GasCar : Car
    {
        private const float k_WheelMaxAirPressure = 32f;
        private const eFuel k_FuelType = eFuel.Octan95;
        private const float k_MaxFuelCapacity = 45f;

        public GasCar(
            string i_Model,
            string i_LicenseNumber,
            eColor i_Color,
            int i_NumberOfDoors,
            string i_WheelManufacturer)
            : base(i_Model, i_LicenseNumber, i_Color, i_NumberOfDoors, i_WheelManufacturer, k_WheelMaxAirPressure, new GasEngine(k_FuelType, k_MaxFuelCapacity))
        {
        }
    }
}
