namespace GarageLogic
{
    using System;
    using System.Runtime.Remoting.Messaging;
    using System.Text;

    using GarageLogic;

    public abstract class Truck : Vehicle
    {
        private const float k_TruckMaxAirPressure = 28;
        private const int k_NumberOfTires = 16;
        private const float k_MaxCargoVolume = 100000; // A value we determined according to our knowledge (no specific requirements in the exercise 
        private bool m_IsTransportHazardMaterials;
        private float m_CargoVolume;

        protected Truck()
            : base(k_TruckMaxAirPressure, k_NumberOfTires)
        {
            Features.Add("state of hazardous materials (true/false)");
            Features.Add("cargo volume");
        }

        internal float TruckMaxAirPressure
        {
            get { return k_TruckMaxAirPressure; }
        }

        internal bool IsTransportHazardMaterials
        {
            get { return m_IsTransportHazardMaterials; }
            private set { m_IsTransportHazardMaterials = value; }
        }

        internal float CargoVolume
        {
            get { return m_CargoVolume; }
            private set { m_CargoVolume = value; }
        }

        internal float MaxCargoVolume
        {
            get { return k_MaxCargoVolume; }
        }

        protected void SetFeatureValue(string i_Key, string i_Value)
        {
            switch (i_Key)
            {
                case "state of hazardous materials (true/false)":
                    IsTransportHazardMaterials = this.checkValidTransportHazardMaterial(i_Value);
                    break;
                case "cargo volume":
                    CargoVolume = this.checkCargoVolume(i_Value);
                    break;
                default:
                    base.SetFeatureValue(i_Key, i_Value);
                    break;
            }
        }

        private bool checkValidTransportHazardMaterial(string i_InputTransportHazardMaterial)
        {
            if (!(i_InputTransportHazardMaterial.Equals("true") || i_InputTransportHazardMaterial.Equals("false")))
            {
                throw new FormatException();
            }

            return i_InputTransportHazardMaterial.Equals("true") ? true : false;
        }

        private float checkCargoVolume(string i_InputCargoVolume)
        {
            if(!int.TryParse(i_InputCargoVolume, out int checkCargoVolume))
            {
                throw new FormatException();
            }

            if(checkCargoVolume < 0 || checkCargoVolume > MaxCargoVolume)
            {
                throw new ValueOutOfRangeException(0, MaxCargoVolume);
            }

            return checkCargoVolume;
        }

        internal StringBuilder VehicleInfo()
        {
            StringBuilder vehicleInfo = base.VehicleInfo();

            vehicleInfo.AppendFormat(
                @"Transport Hazardous Materials: {0}
",
                IsTransportHazardMaterials);
            vehicleInfo.AppendFormat(
                @"Cargo volume: {0}
",
                CargoVolume);

            return vehicleInfo;
        }

        public abstract override void SetFeatures(string i_Key, string i_Value);

        public abstract override StringBuilder ToString();
    }
}
