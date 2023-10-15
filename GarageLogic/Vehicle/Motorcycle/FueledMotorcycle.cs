namespace GarageLogic
{
    using System;
    using System.Text;
    using GarageLogic;

    internal class FueledMotorcycle : Motorcycle
    {
        private const int k_MaxFuelCapacity = 7;
        private const VehicleEnum.eFuelType k_FuelType = VehicleEnum.eFuelType.Octan95;
        private float m_CurrentFuelAmount;

        internal FueledMotorcycle()
            : base()
        {
            IsFueled = true;
            EnergyType = k_FuelType.ToString();
            Features.Add("current fuel amount");
        }

        internal VehicleEnum.eFuelType FuelType
        {
            get { return k_FuelType; }
        }

        internal float CurrentFuelAmount
        {
            get { return m_CurrentFuelAmount; }
            private set { m_CurrentFuelAmount = value; }
        }

        internal float MaxFuelCapacity
        {
            get { return k_MaxFuelCapacity; }
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
                case "current fuel amount":
                    CurrentFuelAmount = validCurrentFuelAmount(i_Value);
                    this.Energy = (CurrentFuelAmount / MaxFuelCapacity) * 100;
                    break;
                default:
                    base.SetFeatureValue(i_Key, i_Value);
                    break;
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
                @"Fuel type: {0}
",
                FuelType);
            vehicleInfo.AppendFormat(
                @"Current fuel amount: {0}
",
                CurrentFuelAmount);

            return vehicleInfo;
        }

        private float validCurrentFuelAmount(string i_CurrentFuelAmountInput)
        {
            if (!float.TryParse(i_CurrentFuelAmountInput, out float valueToCheck))
            {
                throw new FormatException();
            }

            if (valueToCheck < 0 || valueToCheck > MaxFuelCapacity)
            {
                throw new ValueOutOfRangeException(0, MaxFuelCapacity);
            }

            return valueToCheck;
        }

        internal override void IncreaseEnergy(string i_FuelToAddStr)
        {
            if (!float.TryParse(i_FuelToAddStr, out float fuelToAdd))
            {
                throw new FormatException();
            }

            float updatedFuelAmount = CurrentFuelAmount + fuelToAdd;

            if (fuelToAdd < 0 || updatedFuelAmount > MaxFuelCapacity)
            {
                throw new ValueOutOfRangeException(0, MaxFuelCapacity - CurrentFuelAmount);
            }
            else
            {
                CurrentFuelAmount = updatedFuelAmount;
                Energy = (CurrentFuelAmount / MaxFuelCapacity) * 100;
            }
        }
    }
}