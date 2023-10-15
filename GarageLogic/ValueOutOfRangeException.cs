using System;

namespace GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        private float MaxValue
        {
            get { return m_MaxValue; }
        }

        private float MinValue
        {
            get { return m_MinValue; }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format("Value out of range. The input range is {0} - {1}", i_MinValue, i_MaxValue))
        {
            this.m_MaxValue = i_MaxValue;
            this.m_MinValue = i_MinValue;
        }
    }
}