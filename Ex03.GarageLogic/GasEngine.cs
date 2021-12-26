using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eFuel
    {
        Soler = 1,
        Octan95,
        Octan96,
        Octan98
    }

    class GasEngine : Engine
    {
        private readonly eFuel r_Fuel;
        private const eEngineType k_EngineType = eEngineType.Gas;

        public GasEngine(eFuel i_Fuel, float i_MaxFuelCapacity) : base(i_MaxFuelCapacity, k_EngineType)
        {
            r_Fuel = i_Fuel;
        }

        public override void ChargeOrFuel(float i_FuelAmount = 0, eFuel i_Fuel = eFuel.Soler, int i_Hours = 0)
        {
            if(m_EnergyLeft + i_FuelAmount > r_MaxEnergyCapacity) throw new ValueOutOfRangeException(0, r_MaxEnergyCapacity - m_EnergyLeft);
            if (i_Fuel != r_Fuel) throw new ArgumentException($"Fuel type {i_Fuel} cant be added to {r_Fuel}");
            m_EnergyLeft += i_FuelAmount;
        }

        public override string GetEngineDetails()
        {
            return $"Gas Engine, Fuel type: {r_Fuel}";
        }
    }
}
