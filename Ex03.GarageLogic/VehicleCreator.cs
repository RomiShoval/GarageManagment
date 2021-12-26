using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public static Vehicle GasMotorcycle(
            string i_Model,
            string i_LicenseNumber,
            eMotorcycleLicense i_LicenseType,
            int i_EngineCapacity,
            string i_WheelManufacturer)
        {
            return new GasMotorcycle(i_Model, i_LicenseNumber, i_LicenseType, i_EngineCapacity, i_WheelManufacturer);
        }
        public static Vehicle ElectricMotorcycle(
            string i_Model,
            string i_LicenseNumber,
            eMotorcycleLicense i_LicenseType,
            int i_EngineCapacity,
            string i_WheelManufacturer)
        {
            return new ElectricMotorcycle(i_Model, i_LicenseNumber, i_LicenseType, i_EngineCapacity, i_WheelManufacturer);
        }
        public static Vehicle GasCar(
            string i_Model,
            string i_LicenseNumber,
            eColor i_Color,
            int i_NumberOfDoors,
            string i_WheelManufacturer)
        {
            return new GasCar(i_Model, i_LicenseNumber, i_Color, i_NumberOfDoors, i_WheelManufacturer);
        }
        public static Vehicle ElectricCar(
            string i_Model,
            string i_LicenseNumber,
            eColor i_Color,
            int i_NumberOfDoors,
            string i_WheelManufacturer)
        {
            return new ElectricCar(i_Model, i_LicenseNumber, i_Color, i_NumberOfDoors, i_WheelManufacturer);
        }
        public static Vehicle Truck(
            String i_Model,
            String i_LicenseNumber,
            bool i_IsTransportHazardMaterials,
            float i_MaxCargoWeight,
            string i_WheelManufacturer)
        {
            return new Truck(i_Model, i_LicenseNumber, i_IsTransportHazardMaterials, i_MaxCargoWeight, i_WheelManufacturer);
        }
    }
}
