namespace GarageLogic
{
    using System;
    using System.Text;

    using GarageLogic;

    internal class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryTime = 1.2f;
        private float m_CurrentBattery;

        internal ElectricMotorcycle()
            : base()
        {
            IsFueled = false;
            EnergyType = "Battery";
            Features.Add("current battery amount");
        }

        internal float CurrentBattery
        {
            get { return m_CurrentBattery; }
            private set { m_CurrentBattery = value; }
        }

        internal float MaxBatteryTime
        {
            get { return k_MaxBatteryTime; }
        }

        public override void SetFeatures(string i_Key, string i_Value)
        {
            setFeatureValue(i_Key, i_Value);
        }

        private void setFeatureValue(string i_Key, string i_Value)
        {
            if (string.IsNullOrEmpty(i_Value))
            {
                throw new FormatException();
            }

            switch (i_Key)
            {
                case "current battery amount":
                    CurrentBattery = this.validCurrentBatteryAmount(i_Value);
                    this.Energy = (CurrentBattery / MaxBatteryTime) * 100;
                    break;
                default:
                    base.SetFeatureValue(i_Key, i_Value);
                    break;
            }
        }

        private float validCurrentBatteryAmount(string i_CurrentBatteryAmountInput)
        {
            if (!float.TryParse(i_CurrentBatteryAmountInput, out float valueToCheck))
            {
                throw new FormatException();
            }

            if (valueToCheck < 0 || valueToCheck > MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(0, MaxBatteryTime);
            }

            return valueToCheck;
        }

        internal override void IncreaseEnergy(string i_HoursToAdd)
        {
            if (!float.TryParse(i_HoursToAdd, out float hoursToAdd))
            {
                throw new FormatException();
            }

            float updatedBatteryTime = CurrentBattery + hoursToAdd;

            if (hoursToAdd < 0 || updatedBatteryTime > MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(0, MaxBatteryTime - CurrentBattery);
            }
            else
            {
                CurrentBattery = updatedBatteryTime;
                Energy = (CurrentBattery / MaxBatteryTime) * 100;
            }
        }

        public override StringBuilder ToString()
        {
            return this.VehicleInfo();
        }

        internal StringBuilder VehicleInfo()
        {
            StringBuilder vehicleInfo = base.VehicleInfo();

            vehicleInfo.AppendFormat(
                @"Current energy in battery: {0}
",
                CurrentBattery);

            return vehicleInfo;
        }
    }
}