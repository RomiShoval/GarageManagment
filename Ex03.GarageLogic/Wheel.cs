using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_Manufacturer;
        private float m_AirPressure = 0;
        private readonly float r_MaxAirPressure;

        public Wheel(string i_Manufacturer, float i_MaxAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string Manufacturer => r_Manufacturer;
        public float AirPressure => m_AirPressure;
        public float MaxAirPressure => r_MaxAirPressure;
        public void PumpAir(float i_AirToAdd)
        {
            if (m_AirPressure + i_AirToAdd > r_MaxAirPressure) throw new ValueOutOfRangeException(0, r_MaxAirPressure - m_AirPressure);
            m_AirPressure += i_AirToAdd;
        }

        public override string ToString()
        {
            return $"Air Pressure: {m_AirPressure} Manufacturer: {r_Manufacturer}";
        }
    }
}
