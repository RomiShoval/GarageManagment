using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_Model;
        private readonly string r_LicenseNumber;
        protected float m_EnergyLeftPercent = 0;
        private readonly Wheel[] r_Wheels;
        protected readonly Engine r_Engine;

        protected Vehicle(
            string i_Model,
            string i_LicenseNumber,
            int i_NumberOfWheels,
            string i_WheelManufacturer,
            float i_WheelMaxAirPressure,
            Engine i_Engine)
        {
            r_Model = i_Model;
            r_LicenseNumber = i_LicenseNumber;
            r_Wheels = new Wheel[i_NumberOfWheels];
            CreateWheels(i_WheelManufacturer, i_WheelMaxAirPressure);
            r_Engine = i_Engine;
        }

        public void CreateWheels(string i_Manufacturer, float i_MaxAirPressure)
        {
            for(int i = 0; i < r_Wheels.Length; i++)
            {
                r_Wheels[i] = new Wheel(i_Manufacturer, i_MaxAirPressure);
            }
        }

        public string GetEnergyLeftPercentString()
        {
            return m_EnergyLeftPercent + "%";
        }

        public void Charge(int i_Minutes)
        {
            if (r_Engine.EngineType == eEngineType.Gas)
                throw new ArgumentException("Cant add fuel to Electric Engine");
            r_Engine.ChargeOrFuel(i_Hours: i_Minutes/60);
            updateEnergyLeftPercent();
        }

        public void AddFuel(float i_FuelAmount, eFuel i_Fuel)
        {
            if(r_Engine.EngineType == eEngineType.Electric)
                throw new ArgumentException("Cant add fuel to Electric Engine");
            r_Engine.ChargeOrFuel(i_FuelAmount, i_Fuel);
            updateEnergyLeftPercent();
        }

        private void updateEnergyLeftPercent()
        {
            m_EnergyLeftPercent = r_Engine.EnergyLeft / r_Engine.MaxEnergyCapacity;
        }

        public string Model => r_Model;

        public string LicenseNumber => r_LicenseNumber;

        public Wheel[] Wheels => r_Wheels;

        public string GetEngineDetails()
        {
            return r_Engine.GetEngineDetails();
        }

        public string GetWheelsDetails()
        {
            StringBuilder wheelsDetails = new StringBuilder();
            wheelsDetails.AppendLine();
            for (int i = 0; i < r_Wheels.Length; i++)
            {
                wheelsDetails.AppendLine($"\tWheel No.{i + 1} {r_Wheels[i]}");
            }

            return wheelsDetails.ToString();
        }
    }
}
