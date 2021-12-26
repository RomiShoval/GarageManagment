using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eEngineType
    {
        Gas = 1,
        Electric
    }

    public abstract class Engine
    {
        protected float m_EnergyLeft = 0;
        protected readonly float r_MaxEnergyCapacity;
        private readonly eEngineType r_EngineType;

        protected Engine(float i_MaxEnergyCapacity, eEngineType i_EngineType)
        {
            r_MaxEnergyCapacity = i_MaxEnergyCapacity;
            r_EngineType = i_EngineType;
        }

        public abstract string GetEngineDetails();
        public abstract void ChargeOrFuel(float i_FuelAmount = 0, eFuel i_Fuel = 0, int i_Hours = 0);
        public float EnergyLeft => m_EnergyLeft;
        public float MaxEnergyCapacity => r_MaxEnergyCapacity;
        public eEngineType EngineType => r_EngineType;
    } 
}
