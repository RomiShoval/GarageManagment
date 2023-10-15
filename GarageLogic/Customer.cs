namespace GarageLogic
{
    using System;

    using GarageLogic;

    public class Customer
    {
        private string m_Name;
        private string m_PhoneNum;
        private VehicleEnum.eVehicleState m_VehicleState;

        public Customer(string i_Name = "Customer Name", string i_PhoneNum = "0000000000")
        {
            this.m_Name = i_Name;
            this.m_PhoneNum = i_PhoneNum;
            this.m_VehicleState = VehicleEnum.eVehicleState.InRepair;
        }

        public string Name
        {
            get { return this.m_Name; }
            set { this.m_Name = value; }
        }

        public string PhoneNum
        {
            get { return this.m_PhoneNum; }
            set { this.m_PhoneNum = value; }
        }

        public VehicleEnum.eVehicleState VehicleState
        {
            get { return this.m_VehicleState; }
            internal set { this.m_VehicleState = value; }
        }

        public static void CheckValidCustomerName(string i_CustomerName)
        {
            if (string.IsNullOrEmpty(i_CustomerName))
            {
                throw new FormatException();
            }
        }

        public static void CheckValidPhoneNumber(string i_CustomerPhoneNum)
        {
            if (i_CustomerPhoneNum.Length != 5 || !int.TryParse(i_CustomerPhoneNum, out int phoneNum))
            {
                throw new FormatException();
            }
        }
    }
}
