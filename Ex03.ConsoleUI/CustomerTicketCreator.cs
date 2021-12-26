using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    enum eVehicleChoice
    {
        Motorcycle = 1,
        Car,
        Truck
    }

    enum eYesNoChoice
    {
        Yes = 1,
        No
    }
    class CustomerTicketCreator
    {
        public static CustomerTicket CreateTicket(string i_LicenseNumber)
        {
            string userName = TryAgainLoop(getName());
            string userPhone = getPhone();
            Vehicle vehicle = createVehicle(i_LicenseNumber);
            return new CustomerTicket(userName, userPhone, vehicle, eVehicleStatus.Repair);
        }

        private static Vehicle createVehicle(string i_LicenseNumber)
        {
            Vehicle vehicle = null;
            switch(getVehicleChoice())
            {
                case eVehicleChoice.Motorcycle:
                    vehicle = createMotorcycle(i_LicenseNumber);
                    break;
                case eVehicleChoice.Car:
                    vehicle = createCar(i_LicenseNumber);
                    break;
                case eVehicleChoice.Truck:
                    vehicle = createTruck(i_LicenseNumber);
                    break;
            }

            return vehicle;
        }

        private static Vehicle createMotorcycle(string i_LicenseNumber)
        {
            string inputModel = getModel();
            eMotorcycleLicense licenseType = getMotorcycleLicense();
            int engineCapacity = getEngineCapacity();
            string wheelManufacturer = getWheelManufacturer();
            Vehicle motorcycle = null;
            switch (getGasOrElectric())
            {
                case eEngineType.Gas:
                    motorcycle = VehicleCreator.GasMotorcycle(
                        inputModel,
                        i_LicenseNumber,
                        licenseType,
                        engineCapacity,
                        wheelManufacturer);
                    break;
                case eEngineType.Electric:
                    motorcycle = VehicleCreator.ElectricMotorcycle(
                        inputModel,
                        i_LicenseNumber,
                        licenseType,
                        engineCapacity,
                        wheelManufacturer);
                    break;
            }

            return motorcycle;
        }

        private static Vehicle createCar(string i_LicenseNumber)
        {
            string inputModel = getModel();
            eColor carColor = getCarColor();
            int numberOfDoors = getNumberOfDoors();
            string wheelManufacturer = getWheelManufacturer();
            Vehicle car = null;
            switch (getGasOrElectric())
            {
                case eEngineType.Gas:
                    car = VehicleCreator.GasCar(
                        inputModel,
                        i_LicenseNumber,
                        carColor,
                        numberOfDoors,
                        wheelManufacturer);
                    break;
                case eEngineType.Electric:
                    car = VehicleCreator.ElectricCar(
                        inputModel,
                        i_LicenseNumber,
                        carColor,
                        numberOfDoors,
                        wheelManufacturer);
                    break;
            }

            return car;
        }

        private static Vehicle createTruck(string i_LicenseNumber)
        {
            string inputModel = getModel();
            bool canTransport = getHazardTransportChoice();
            float maxCargoWeight = getMaxCargoWeight();
            string wheelManufacturer = getWheelManufacturer();
            Vehicle truck = VehicleCreator.Truck(
                inputModel,
                i_LicenseNumber,
                canTransport,
                maxCargoWeight,
                wheelManufacturer);
            return truck;
        }

        private static string getName()
        {
            Console.WriteLine("Please enter your name:");
            Console.WriteLine("-----------------------");
            string userName;
            userName = Console.ReadLine();
            ValidateInput.ValidateName(userName);
            Console.Clear();
            return userName;
        }

        private static string getPhone()
        {
            Console.WriteLine("Please enter your phone number:");
            Console.WriteLine("-------------------------------");
            string userPhone = Console.ReadLine();
            ValidateInput.ValidatePhone(userPhone);
            Console.Clear();
            return userPhone;
        }

        private static string getModel()
        {
            Console.WriteLine("Please enter vehicle model:");
            Console.WriteLine("-------------------------");
            string inputModel = Console.ReadLine();
            Console.Clear();
            return inputModel;
        }

        private static string getWheelManufacturer()
        {
            Console.WriteLine("Please enter wheel manufacturer:");
            Console.WriteLine("--------------------------------");
            string wheelManufacturer = Console.ReadLine();
            Console.Clear();
            return wheelManufacturer;
        }

        private static eEngineType getGasOrElectric()
        {
            int engineTypeOptions = Enum.GetNames(typeof(eEngineType)).Length;
            Console.WriteLine("Please choose gas or electric car:");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1. Gas");
            Console.WriteLine("2. Electric");
            string engineTypeChoice = Console.ReadLine();
            int choice;
            if(!int.TryParse(engineTypeChoice, out choice) || choice < 1 || choice > engineTypeOptions)
            {
                throw new FormatException(1, engineTypeOptions);
            }
            Console.Clear();
            return (eEngineType)choice;
        }

        private static eColor getCarColor()
        {
            int colorOptions = Enum.GetNames(typeof(eColor)).Length;
            Console.WriteLine("Please enter car color:");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Red");
            Console.WriteLine("2. Silver");
            Console.WriteLine("3. Black");
            Console.WriteLine("4. White");
            string inputCarColorChoice = Console.ReadLine();
            int choice;
            if (!int.TryParse(inputCarColorChoice, out choice) || choice < 1 || choice > colorOptions)
            {
                throw new FormatException(1, colorOptions);
            }
            Console.Clear();
            return (eColor)choice;
        }

        private static int getNumberOfDoors()
        {
            Console.WriteLine("Please enter number of doors (2, 3, 4, 5):");
            Console.WriteLine("------------------------------------------");
            string inputNumberOfDoors = Console.ReadLine();
            int numberOfDoors;
            if (!int.TryParse(inputNumberOfDoors, out numberOfDoors))
            {
                throw new FormatException(2,5);
            }
            Console.Clear();
            return numberOfDoors;
        }

        private static bool getHazardTransportChoice()
        {
            int yesOrNoOptions = Enum.GetNames(typeof(eYesNoChoice)).Length;
            Console.WriteLine("Please choose if tuck can transport hazard materials");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            string inputTransport = Console.ReadLine();
            bool canTransport = false;
            int choice;
            if (!int.TryParse(inputTransport, out choice) || choice < 1 || choice > yesOrNoOptions)
            {
                throw new FormatException(1, yesOrNoOptions);
            }
            switch ((eYesNoChoice)choice)
            {
                case eYesNoChoice.Yes:
                    canTransport = true;
                    break;
                case eYesNoChoice.No:
                    canTransport = false;
                    break;
            }
            Console.Clear();
            return canTransport;
        }

        private static float getMaxCargoWeight()
        {
            Console.WriteLine("Please max cargo weight:");
            Console.WriteLine("------------------------");
            string inputMaxCargoWeight = Console.ReadLine();
            float maxCargoWeight;
            if (!float.TryParse(inputMaxCargoWeight, out maxCargoWeight))
            {
                throw new FormatException("Must be an integer");
            }
            Console.Clear();
            return maxCargoWeight;
        }

        private static eMotorcycleLicense getMotorcycleLicense()
        {
            int licenseTypeOptions = Enum.GetNames(typeof(eMotorcycleLicense)).Length;
            Console.Clear();
            Console.WriteLine("Please enter license type:");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. A");
            Console.WriteLine("2. B1");
            Console.WriteLine("3. AA");
            Console.WriteLine("4. BB");
            string licenseTypeChoice = Console.ReadLine();
            int choice;
            if (!int.TryParse(licenseTypeChoice, out choice) || choice < 1 || choice > licenseTypeOptions)
            {
                throw new FormatException(1, licenseTypeOptions);
            }
            Console.Clear();
            return (eMotorcycleLicense)choice;
        }

        private static int getEngineCapacity()
        {
            Console.WriteLine("Please enter engine capacity:");
            Console.WriteLine("-----------------------------");
            string inputEngineCapacity = Console.ReadLine();
            int engineCapacity;
            if (!int.TryParse(inputEngineCapacity, out engineCapacity))
            {
                throw new FormatException("Must be an integer");
            }
            Console.Clear();
            return engineCapacity;
        }

        private static eVehicleChoice getVehicleChoice()
        {
            int vehicleChoices = Enum.GetNames(typeof(eVehicleChoice)).Length;
            Console.WriteLine("Please choose which vehicle:");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Motorcycle");
            Console.WriteLine("2. Car");
            Console.WriteLine("3. Truck");
            string vehicleChoice = Console.ReadLine();
            int choice;
            if (!int.TryParse(vehicleChoice, out choice) || choice < 1 || choice > vehicleChoices)
            {
                throw new FormatException(1, vehicleChoices);
            }
            Console.Clear();
            return (eVehicleChoice)choice;
        }

        public static void PrintTryAgain(Exception i_Exception)
        {
            Console.Clear();
            Console.WriteLine(i_Exception.Message);
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Please try again...");
            Thread.Sleep(1500);
            Console.Clear();
        }
        public void TryAgainLoop(Action i_anyMethod)
        {
            while (true)
            {
                try
                {
                    i_anyMethod();
                    break;
                }
                catch(Exception exception)
                {
                    PrintTryAgain(exception);
                }
            }
        }
    }
}
