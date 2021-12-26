using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {
        private const eEngineType k_EngineType = eEngineType.Electric;
        public ElectricEngine(float i_MaxBatteryTime) : base(i_MaxBatteryTime, k_EngineType)
        {
        }

        public override void ChargeOrFuel(float i_FuelAmount = 0, eFuel i_Fuel = eFuel.Soler, int i_Hours = 0)
        { 
            if(m_EnergyLeft + i_FuelAmount > r_MaxEnergyCapacity) throw new ValueOutOfRangeException(0, r_MaxEnergyCapacity - m_EnergyLeft);
            m_EnergyLeft += i_Hours;
        }

        public override string GetEngineDetails()
        {
            return "Electric Engine";
        }
    }
}
