using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eColor
    {
        Red,
        Silver,
        Black,
        White
    }
    abstract class Car : Vehicle
    {
        private const int k_NumberOfWheels = 4;
        private readonly eColor r_Color;
        private readonly int r_NumberOfDoors;

        protected Car(
            string i_Model,
            string i_LicenseNumber,
            eColor i_Color,
            int i_NumberOfDoors,
            string i_WheelManufacturer,
            float i_WheelMaxAirPressure,
            Engine i_Engine)
            : base(i_Model, i_LicenseNumber, k_NumberOfWheels, i_WheelManufacturer, i_WheelMaxAirPressure, i_Engine)
        {
            r_Color = i_Color;
            r_NumberOfDoors = i_NumberOfDoors;
        }
    }
}
