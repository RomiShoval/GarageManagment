using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        Done = 1,
        Repair,
        Paid
    }

    public class CustomerTicket
    {
        private readonly string r_Name;
        private readonly string r_Phone;
        private readonly Vehicle r_Vehicle;
        private eVehicleStatus m_VehicleStatus;

        public CustomerTicket(string i_Name, string i_Phone, Vehicle i_Vehicle, eVehicleStatus i_Status)
        {
            r_Name = i_Name;
            r_Phone = i_Phone;
            r_Vehicle = i_Vehicle;
            m_VehicleStatus = i_Status;
        }

        public string Name => r_Name;
        public string Phone => r_Phone;
        public Vehicle Vehicle => r_Vehicle;
        public eVehicleStatus Status 
        {
            get => m_VehicleStatus;
            set => m_VehicleStatus = value;
        }
    }
}
