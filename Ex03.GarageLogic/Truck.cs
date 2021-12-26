using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 16;
        private const float k_WheelMaxAirPressure = 26f;
        private const eFuel k_FuelType = eFuel.Soler;
        private const float k_MaxFuelCapacity = 120f;
        private readonly bool r_IsTransportHazardMaterials;
        private readonly float r_MaxCargoWeight;

        public Truck(
            String i_Model,
            String i_LicenseNumber,
            bool i_IsTransportHazardMaterials,
            float i_MaxCargoWeight,
            string i_WheelManufacturer)
            : base(i_Model, i_LicenseNumber, k_NumberOfWheels, i_WheelManufacturer, k_WheelMaxAirPressure,new GasEngine(k_FuelType,k_MaxFuelCapacity))
        {
            r_IsTransportHazardMaterials = i_IsTransportHazardMaterials;
            r_MaxCargoWeight = i_MaxCargoWeight;
        }
    }
}
