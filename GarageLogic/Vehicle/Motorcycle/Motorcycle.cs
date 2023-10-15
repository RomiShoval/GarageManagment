namespace GarageLogic
{
    using System;
    using System.Text;

    using GarageLogic;

    public abstract class Motorcycle : Vehicle
    {
        private const float k_MotorcycleMaxAirPressure = 30;
        private const int k_NumberOfTires = 2;
        private const float k_MaxEngineCapacity = 2400; // A value we determined according to our knowledge (no specific requirements in the exercise 
        private VehicleEnum.eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        protected Motorcycle()
            : base(k_MotorcycleMaxAirPressure, k_NumberOfTires)
        {
            Features.Add("license type");
            Features.Add("engine capacity");
        }

        internal float MotorcycleMaxAirPressure
        {
            get { return k_MotorcycleMaxAirPressure; }
        }

        internal VehicleEnum.eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            private set { m_LicenseType = value; }
        }

        internal int EngineCapacity
        {
            get { return m_EngineCapacity; }
            private set { m_EngineCapacity = value; }
        }

        internal float MaxEngineCapacity
        {
            get { return k_MaxEngineCapacity; }
        }

        internal StringBuilder VehicleInfo()
        {
            StringBuilder vehicleInfo = base.VehicleInfo();

            vehicleInfo.AppendFormat(
                @"License type: {0}
",
                LicenseType);
            vehicleInfo.AppendFormat(
                @"Engine capacity: {0}
",
                EngineCapacity);

            return vehicleInfo;
        }

        protected void SetFeatureValue(string i_Key, string i_Value)
        {
            switch (i_Key)
            {
                case "license type":
                    LicenseType = checkValidLicenseType(i_Value);
                    break;
                case "engine capacity":
                    EngineCapacity = checkValidEngineCapacity(i_Value);
                    break;
                default:
                    base.SetFeatureValue(i_Key, i_Value);
                    break;
            }
        }

        private VehicleEnum.eLicenseType checkValidLicenseType(string i_LicenseTypeValue)
        {
            if(!Enum.TryParse(i_LicenseTypeValue, out VehicleEnum.eLicenseType checkLicenseType))
            { 
                throw new ArgumentException();
            }

            return checkLicenseType;
        }

        private int checkValidEngineCapacity(string i_EngineCapacityValue)
        {
            if (!int.TryParse(i_EngineCapacityValue, out int checkEngineCapacity))
            {
                throw new ArgumentException();
            }

            if (checkEngineCapacity < 0 || checkEngineCapacity > MaxEngineCapacity)
            {
                throw new ValueOutOfRangeException(0, MaxEngineCapacity);
            }

            return checkEngineCapacity;
        }

        public abstract override void SetFeatures(string i_Key, string i_Value);

        public abstract override StringBuilder ToString();
    }
}
