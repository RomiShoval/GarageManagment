using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricCar : Car
    {
        private const float k_WheelMaxAirPressure = 32f;
        private const float k_MaxBatteryTime = 3.2f;

        public ElectricCar(
            string i_Model,
            string i_LicenseNumber,
            eColor i_Color,
            int i_NumberOfDoors,
            string i_WheelManufacturer)
            : base(i_Model, i_LicenseNumber, i_Color, i_NumberOfDoors, i_WheelManufacturer, k_WheelMaxAirPressure, new ElectricEngine(k_MaxBatteryTime))
        {
        }
    }
}
