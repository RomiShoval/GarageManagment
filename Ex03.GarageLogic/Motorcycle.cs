using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eMotorcycleLicense
    {
        A = 1,
        B1,
        AA,
        BB
    }
    abstract class Motorcycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private readonly eMotorcycleLicense r_LicenseType;
        private readonly int r_EngineCapacity;

        protected Motorcycle(
            string i_Model,
            string i_LicenseNumber,
            eMotorcycleLicense i_LicenseType,
            int i_EngineCapacity,
            string i_WheelManufacturer,
            float i_WheelMaxAirPressure,
            Engine i_Engine)
            : base(i_Model, i_LicenseNumber, k_NumberOfWheels, i_WheelManufacturer, i_WheelMaxAirPressure, i_Engine)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }
    }
}
