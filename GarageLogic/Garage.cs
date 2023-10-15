namespace GarageLogic
{
    using System;
    using System.Collections.Generic;

    using GarageLogic;

    public class Garage
    {
        private Dictionary<Vehicle, Customer> m_VehiclesInGarage;

        public Garage()
        {
            this.m_VehiclesInGarage = new Dictionary<Vehicle, Customer>();
        }

        public Dictionary<Vehicle, Customer> VehiclesInGarage
        {
            get { return m_VehiclesInGarage; }
            set { m_VehiclesInGarage = value; }
        }

        public void AddVehicleToGarage(Vehicle i_Vehicle, Customer i_Customer)
        {
            VehiclesInGarage.Add(i_Vehicle, i_Customer);
        }

        public void SetVehicleState(Vehicle i_VehicleToChangeState, VehicleEnum.eVehicleState i_NewState)
        {
            VehiclesInGarage[i_VehicleToChangeState].VehicleState = i_NewState;
        }

        public void TiresInflate(Vehicle i_VehicleToInflate)
        {
            for(int i = 0; i < i_VehicleToInflate.Tires.Count; i++)
            {
                i_VehicleToInflate.Tires[i].Inflate();
            }
        }

        public void IncreaseEnergy(Vehicle i_Vehicle, string i_EnergyToAdd)
        {
            i_Vehicle.IncreaseEnergy(i_EnergyToAdd);
        }

        public void CheckTypeOfFuel(Vehicle i_Vehicle, string i_TypeOfFuel)
        {
            if(!i_Vehicle.EnergyType.Equals(i_TypeOfFuel))
            {
                throw new ArgumentException();
            }
        }

        public bool IsCarInGarage(string i_LicenseNumber)
        {
            bool isInGarage = !true;
            
            foreach (KeyValuePair<Vehicle, Customer> vehicleInGarage in m_VehiclesInGarage)
            {
                if (vehicleInGarage.Key.LicenseNumber.Equals(i_LicenseNumber))
                {
                    isInGarage = !isInGarage;
                }
            }

            return isInGarage;
        }
        // $G$ CSS-028 (-3) A method should not include more than one return statement.
        // $G$ CSS-028 (-3) Return should be at the end of the function
        public Vehicle GetCarInGarage(string i_VehicleLicenseNumber)
        {
            foreach (KeyValuePair<Vehicle, Customer> vehicleInGarage in VehiclesInGarage)
            {
                if (vehicleInGarage.Key.LicenseNumber.Equals(i_VehicleLicenseNumber))
                {
                    return vehicleInGarage.Key;
                }
            }

            return null;
        }
    }
}