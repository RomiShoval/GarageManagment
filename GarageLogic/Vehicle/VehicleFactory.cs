namespace GarageLogic
{
    using System.Collections.Generic;

    using GarageLogic;

    public class VehicleFactory
    {
        private Dictionary<int,string> m_SupportedByGarage;

        public VehicleFactory()
        {
            this.m_SupportedByGarage = new Dictionary<int, string>();
            this.m_SupportedByGarage.Add(1, "Fueled Car");
            this.m_SupportedByGarage.Add(2, "Electric Car");
            this.m_SupportedByGarage.Add(3, "Fueled Motorcycle");
            this.m_SupportedByGarage.Add(4, "Electric Motorcycle");
            this.m_SupportedByGarage.Add(5, "Fueled Truck");
        }

        public Dictionary<int, string> SupportedByGarage
        {
            get { return m_SupportedByGarage; }
            private set { m_SupportedByGarage = value; }
        }


        public Vehicle BuildVehicle(int i_MotorTypeToBuild)
        {
            // $G$ CSS-018 (-3) You should have used enumerations here.
            switch (i_MotorTypeToBuild)
            {
                case 1:
                    return new FueledCar();
                case 2:
                    return new ElectricCar();
                case 3:
                    return new FueledMotorcycle();
                case 4:
                    return new ElectricMotorcycle();
                default:
                    return new FueledTruck();
            }
        }
    }
}