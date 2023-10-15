namespace GarageLogic
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Vehicle
    {
        private string m_Model;
        private string m_LicenseNumber;
        private float m_Energy;
        private List<Tire> m_Tires;
        private bool m_IsFueled;



        // $G$ DSN-999 (-5) This class should have been abstract. - fuel engine and electric engine inherit from abstract engine
        private string m_EnergyType;




        private List<string> m_Features;

        protected Vehicle(float i_CarMaxAirPressure, int i_NumberOfTires)
        {
            this.m_Model = "model";
            this.m_LicenseNumber = "000";
            this.m_Energy = 0;
            this.m_IsFueled = true;
            this.m_EnergyType = "energy";
            this.m_Tires = new List<Tire>();

            for(int i = 0; i < i_NumberOfTires; i++)
            {
                this.m_Tires.Add(new Vehicle.Tire("Manufacturer", 0f, i_CarMaxAirPressure));
            }
            
            this.m_Features = new List<string>();
            this.m_Features.Add("model");
            this.m_Features.Add("tires' manufacturer");
            this.m_Features.Add("tires' current air pressure");
        }

        public static void CheckValidLicenseNumber(string i_LicenseNumber)
        {
            if(string.IsNullOrEmpty(i_LicenseNumber))
            {
                throw new FormatException();
            }
        }

        public string Model
        {
            get { return this.m_Model; }
            private set { this.m_Model = value; }
        }

        public string LicenseNumber
        {
            get { return this.m_LicenseNumber; }
            set { this.m_LicenseNumber = value; }
        }

        public float Energy
        {
            get { return this.m_Energy; }
            protected set { this.m_Energy = value; }
        }

        public List<Tire> Tires
        {
            get { return this.m_Tires; }
            private set { this.m_Tires = value; }
        }

        public List<string> Features
        {
            get { return this.m_Features; }
            protected set { this.m_Features = value; }
        }

        public bool IsFueled
        {
            get { return this.m_IsFueled; }
            protected set { this.m_IsFueled = value; }
        }

        public string EnergyType
        {
            get { return this.m_EnergyType; }
            protected set { this.m_EnergyType = value; }
        }

        protected void SetFeatureValue(string i_Key, string i_Value)
        {
            switch (i_Key)
            {
                case "model":
                    Model = i_Value;
                    break;
                case "tires' manufacturer":
                    for(int i = 0; i < Tires.Count; i++)
                    {
                        Tires[i].Manufacturer = i_Value;
                    }
                    break;
                case "tires' current air pressure":
                    for(int i = 0; i < Tires.Count; i++)
                    {
                        Tires[i].CurrentAirPressure = Tires[i].CheckValidCurrentAirPressure(i_Value);
                    }
                    break;
                default:
                    break;
            }
        }

        internal StringBuilder VehicleInfo()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.AppendFormat(
                @"Model: {0}
", 
                Model);
            vehicleInfo.AppendFormat(
                @"License number: {0}
", 
                LicenseNumber);
            vehicleInfo.AppendFormat(
                @"Energy: {0}%
", 
                Energy);
            vehicleInfo.AppendFormat(
                @"Tires' Manufacturer: {0}
", 
                Tires[0].Manufacturer);
            vehicleInfo.AppendFormat(
                @"Tires' Current air pressure: {0}
", 
                Tires[0].CurrentAirPressure);

            return vehicleInfo;
        }

        public abstract void SetFeatures(string i_Key, string i_Value);

        internal abstract void IncreaseEnergy(string i_EnergyToAddStr);

        public abstract StringBuilder ToString();

        public class Tire
        {
            private string m_Manufacturer;
            private float m_CurrentAirPressure;


            // $G$ DSN-999 (-4) The "maximum air pressure" field should be readonly member of class wheel.
            private float m_MaxAirPressure;
            
            public Tire(string i_Manufacturer = "Manufacturer", float i_CurrentAirPressure = 0, float i_CarMaxAirPressure = 0)
            {
                this.m_Manufacturer = i_Manufacturer;
                this.m_CurrentAirPressure = i_CurrentAirPressure;
                this.m_MaxAirPressure = i_CarMaxAirPressure;
            }

            public string Manufacturer
            {
                get { return this.m_Manufacturer; }
                internal set { this.m_Manufacturer = value; }
            }

            public float CurrentAirPressure
            {
                get { return m_CurrentAirPressure; }
                internal set { m_CurrentAirPressure = value; }
            }

            public float MaxAirPressure
            {
                get { return m_MaxAirPressure; }
            }

            public float CheckValidCurrentAirPressure(string i_CurrentAirPressure)
            {
                if (!float.TryParse(i_CurrentAirPressure, out float currentAirPressure))
                {
                    throw new FormatException();
                }

                if(currentAirPressure < 0 || currentAirPressure > this.MaxAirPressure)
                {
                    throw new ValueOutOfRangeException(0, this.MaxAirPressure);
                }

                return currentAirPressure;
            }

            internal void Inflate()
            {
                CurrentAirPressure = MaxAirPressure;
            }
        }
    }
}

