using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, CustomerTicket> r_CurrentCostumersDictionary = new Dictionary<string, CustomerTicket>();

        public void AddVehicle(CustomerTicket i_Costumer)
        {
            r_CurrentCostumersDictionary.Add(i_Costumer.Vehicle.LicenseNumber, i_Costumer);

        }
        public List<string> GetVehicleListByQuery(eVehicleStatus i_Status)
        {
            List<string> listByQuery = new List<string>();
            foreach(string licenseNumber in r_CurrentCostumersDictionary.Keys)
            {
                if(r_CurrentCostumersDictionary[licenseNumber].Status == i_Status)
                {
                    listByQuery.Add(licenseNumber);
                }

            }

            return listByQuery;
        }

        public void SetVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            r_CurrentCostumersDictionary[i_LicenseNumber].Status = i_NewStatus;
        }

        public void PumpMaxAirPressure(string i_LicenseNumber)
        {
            Wheel[] wheels = r_CurrentCostumersDictionary[i_LicenseNumber].Vehicle.Wheels;
            foreach(Wheel wheel in wheels)
            {
                wheel.PumpAir(wheel.MaxAirPressure - wheel.AirPressure);
            }
        }

        public void Fuel(string i_LicenseNumber, eFuel i_Fuel, float i_FuelAmount)
        {
            r_CurrentCostumersDictionary[i_LicenseNumber].Vehicle.AddFuel(i_FuelAmount, i_Fuel);
        }

        public void Charge(string i_LicenseNumber, int i_Minutes)
        {
            r_CurrentCostumersDictionary[i_LicenseNumber].Vehicle.Charge(i_Minutes);
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return r_CurrentCostumersDictionary.ContainsKey(i_LicenseNumber);
        }

        public Dictionary<string, string> GetVehicleDetails(string i_LicenseNumber)
        {
            Dictionary<string, string> vehicleDetails = new Dictionary<string, string>();
            CustomerTicket ticket = r_CurrentCostumersDictionary[i_LicenseNumber];
            vehicleDetails.Add("License Number", i_LicenseNumber);
            vehicleDetails.Add("Model",ticket.Vehicle.Model);
            vehicleDetails.Add("Name",ticket.Name);
            vehicleDetails.Add("Phone",ticket.Phone);
            vehicleDetails.Add("Status", ticket.Status.ToString());
            vehicleDetails.Add("Wheels", ticket.Vehicle.GetWheelsDetails());
            vehicleDetails.Add("Energy Type", ticket.Vehicle.GetEngineDetails());
            vehicleDetails.Add("Energy Left", ticket.Vehicle.GetEnergyLeftPercentString());
            return vehicleDetails;
        }
    }
}
