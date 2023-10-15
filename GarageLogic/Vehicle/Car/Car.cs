namespace GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using GarageLogic;

    public abstract class Car : Vehicle
    {
        private const float k_CarMaxAirPressure = 32;
        private const int k_NumberOfTires = 4;
        private VehicleEnum.eColor m_Color;
        private VehicleEnum.eNumberOfDoors m_NumberOfDoors;

        protected Car()
        : base(k_CarMaxAirPressure, k_NumberOfTires)
        {
            Features.Add("color");
            Features.Add("number of doors");
        }

        internal float CarMaxAirPressure
        {
            get { return k_CarMaxAirPressure; }
        }

        internal VehicleEnum.eColor Color
        {
            get { return m_Color; }
            private set { m_Color = value; }
        }

        internal VehicleEnum.eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            private set { m_NumberOfDoors = value; }
        }

        internal int NumberOfTires
        {
            get { return k_NumberOfTires; }
        }

        protected void SetFeatureValue(string i_Key, string i_Value)
        {
            switch (i_Key)
            {
                case "color":
                    Color = checkValidColor(i_Value);
                    break;
                case "number of doors":
                    NumberOfDoors = checkValidNumOfDoors(i_Value);
                    break;
                default:
                    base.SetFeatureValue(i_Key, i_Value);
                    break;
            }
        }

        internal StringBuilder VehicleInfo()
        {
            StringBuilder vehicleInfo = base.VehicleInfo();

            vehicleInfo.AppendFormat(
                @"Color: {0}
", 
                Color);
            vehicleInfo.AppendFormat(
                @"Number of doors: {0}
", 
                NumberOfDoors);

            return vehicleInfo;
        }

        private VehicleEnum.eColor checkValidColor(string i_InputColor)
        {
            if(!Enum.TryParse(i_InputColor, out VehicleEnum.eColor checkColor))
            {
                throw new ArgumentException();
            }

            return checkColor;
        }

        private VehicleEnum.eNumberOfDoors checkValidNumOfDoors(string i_InputNumOfDoors)
        {
            if(!Enum.TryParse(i_InputNumOfDoors, out VehicleEnum.eNumberOfDoors checkNumOfDoors))
            {
                throw new ArgumentException();
            }

            return checkNumOfDoors;
        }

        public abstract override void SetFeatures(string i_Key, string i_Value);

        public abstract override StringBuilder ToString();
    }
}
