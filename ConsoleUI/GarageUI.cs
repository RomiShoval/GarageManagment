using Garage.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text;

namespace Garage.ConsoleUI
{
    using System.Linq;
    using System.Threading;

    public class GarageUI
    {

        // $G$ NTT-999 (-3) This kind of field should be readonly.
        private Garage m_GarageLogic;
        private List<string> m_MainMenuOptions;
        private List<string> m_VehicleMenuOptions;

        public GarageUI()
        {
            this.m_GarageLogic = new Garage();
            
            this.m_MainMenuOptions = new List<string>();

            this.m_MainMenuOptions.Add("Add vehicle to garage");
            this.m_MainMenuOptions.Add("Print all vehicles in garage");
            this.m_MainMenuOptions.Add("Preform actions on vehicle in garage");
            this.m_MainMenuOptions.Add("Exit garage");

            this.m_VehicleMenuOptions = new List<string>();

            this.m_VehicleMenuOptions.Add("Set state of a vehicle in garage");
            this.m_VehicleMenuOptions.Add("Inflate vehicle's tires");
            this.m_VehicleMenuOptions.Add("Increase the energy of the vehicle");
            this.m_VehicleMenuOptions.Add("Print vehicle's information");
            this.m_VehicleMenuOptions.Add("Go back to the main menu");
        }

        private Garage GarageLogic
        {
            get { return m_GarageLogic; }
        }

        private List<string> MainMenuOptions
        {
            get { return m_MainMenuOptions; }
        }

        private List<string> VehicleMenuOptions
        {
            get { return this.m_VehicleMenuOptions; }
        }


        public void RunApp()
        {
            Console.WriteLine("Hello, welcome to the garage!");
            Console.WriteLine();

            this.mainMenuSelection();
        }

        private void mainMenuSelection()
        {
            Console.WriteLine("Please enter your choice from the menu bar");
            Console.WriteLine();

            int menuChoice = selectionMenu(MainMenuOptions, false);

            Console.Clear();

            switch (menuChoice)
            {
                // $G$ CSS-018 (-3) You should have used enumerations here.
                case 1:
                    Console.Clear();
                    
                    Vehicle newVehicle = CreateVehicleCustomer.GetVehicleInfo(this.m_GarageLogic);
                    
                    if (GarageLogic.IsCarInGarage(newVehicle.LicenseNumber))
                    {
                        GarageLogic.SetVehicleState(newVehicle, VehicleEnum.eVehicleState.InRepair);
                        
                        Console.WriteLine();
                        Console.WriteLine("This vehicle is already in the garage.");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.Clear();
                        
                        Customer newCustomer = CreateVehicleCustomer.GetCustomerInfo();
                        addVehicleToGarage(newVehicle, newCustomer);
                    }
                    
                    this.vehicleMenuSelection(newVehicle);
                    break;
                case 2:
                    Console.WriteLine("Do you want to use a filter to print the vehicles in the garage?");
                    
                    List<string> filterPrint = new List<string>() {"yes", "no"};
                    int userChoice = selectionMenu(filterPrint, false);
                    
                    if(userChoice == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter the vehicles' state that you want to print:");
                        
                        userChoice = selectionMenu("vehicle state", true);
                        string[] stateOptions = VehicleEnum.GetEnumValues("vehicle state");
                        
                        Console.WriteLine();
                        this.printVehiclesInGarage((VehicleEnum.eVehicleState)Enum.Parse(typeof(VehicleEnum.eVehicleState), stateOptions[userChoice - 1]));
                    }
                    else
                    {
                        Console.WriteLine();
                        this.printVehiclesInGarage();
                    }

                    Console.WriteLine();
                    this.mainMenuSelection();
                    break;
                case 3:
                    Console.WriteLine("Please enter the vehicle's license number:");
                    string vehicleLicenseNumber = Console.ReadLine();
                    
                    bool validInput = !true;
                    
                    while(!validInput)
                    {
                        try
                        {
                            Vehicle.CheckValidLicenseNumber(vehicleLicenseNumber);
                            validInput = !validInput;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid license number. Please try again:");
                            vehicleLicenseNumber = Console.ReadLine();
                        }
                    }
                    if(GarageLogic.IsCarInGarage(vehicleLicenseNumber))
                    {
                        vehicleMenuSelection(GarageLogic.GetCarInGarage(vehicleLicenseNumber));
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No vehicle in garage with this license number.");
                        Console.WriteLine();
                        
                        this.mainMenuSelection();
                    }
                    break;
                default:
                    Console.WriteLine("BYE BYE!");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
            }
        }

        private void vehicleMenuSelection(Vehicle i_Vehicle)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter your choice from the menu bar");
            Console.WriteLine();

            string userInput;
            int userChoice = selectionMenu(VehicleMenuOptions, false);

            Console.Clear();

            // $G$ CSS-018 (-3) You should have used enumerations here.
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("Please enter the new state of the vehicle from the menu:");
                    
                    userChoice = selectionMenu("vehicle state", true);
                    string[] stateOptions = VehicleEnum.GetEnumValues("vehicle state");
                    
                    setVehicleState(i_Vehicle, (VehicleEnum.eVehicleState)Enum.Parse(typeof(VehicleEnum.eVehicleState), stateOptions[userChoice - 1]));
                    
                    break;
                case 2:
                    tiresInflate(i_Vehicle);

                    break;
                case 3:
                    if(i_Vehicle.IsFueled)
                    {
                        Console.WriteLine("Please enter the type of fuel that you want to add");
                        
                        userChoice = selectionMenu("fuel type", true);
                        string[] fuelOptions = VehicleEnum.GetEnumValues("fuel type");
                        try
                        {
                            GarageLogic.CheckTypeOfFuel(i_Vehicle, fuelOptions[userChoice - 1]);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Fuel type does not match vehicle type.");
                            vehicleMenuSelection(i_Vehicle);
                        }

                        Console.WriteLine();
                        Console.WriteLine("Please enter the number of liters you want to add to the vehicle:");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter the number of hours you want to recharge the battery of the vehicle:");
                    }

                    userInput = Console.ReadLine();
                    this.increaseEnergy(i_Vehicle, userInput);
                    
                    break;
                case 4:
                    printVehicleInfo(i_Vehicle.LicenseNumber);
                    break;
                case 5:
                    Console.Clear();
                    this.mainMenuSelection();
                    break;
            }

            vehicleMenuSelection(i_Vehicle);
        }

        private int selectionMenu(object i_Menu, bool i_IsEnum)
        {
            StringBuilder optionsMenuSB = new StringBuilder();
            string[] options;
            
            if (i_IsEnum)
            {
                options = VehicleEnum.GetEnumValues(i_Menu as string);
            }
            else
            {
                options = (i_Menu as List<string>).ToArray();
            }

            for (int i = 0; i < options.Length; i++)
            {
                optionsMenuSB.AppendFormat(
                    @"{0} : {1}
", 
                    i + 1, 
                    options[i]);
            }

            Console.WriteLine(optionsMenuSB);
            string userInput = Console.ReadLine();
            
            ValidMenuSelection(userInput, options.Length, out int userChoice);
            return userChoice;
        }

        private void addVehicleToGarage(Vehicle i_VehicleToAdd, Customer i_CustomerToAdd)
        {
            GarageLogic.AddVehicleToGarage(i_VehicleToAdd, i_CustomerToAdd);
        }

        private void printVehiclesInGarage()
        {
            if(GarageLogic.VehiclesInGarage.Count == 0)
            {
                Console.WriteLine("There are no vehicles in the garage.");
                Console.WriteLine();
                return;
            }
            
            StringBuilder vehiclesInGarage = new StringBuilder();
            
            foreach (KeyValuePair<Vehicle, Customer> vehicle in GarageLogic.VehiclesInGarage)
            {
                vehiclesInGarage.AppendFormat(
                    @"- {0}
", 
                    vehicle.Key.LicenseNumber);
            }

            Console.WriteLine("The vehicles in the garage:");
            Console.WriteLine(vehiclesInGarage);
            Console.WriteLine();
        }

        private void printVehiclesInGarage(VehicleEnum.eVehicleState i_VehicleState)
        {
            if (GarageLogic.VehiclesInGarage.Count == 0)
            {
                Console.WriteLine("There are no vehicles in the garage.");
                Console.WriteLine();
                return;
            }

            StringBuilder vehiclesInGarage = new StringBuilder();
            int countVehiclesWithState = 0;

            foreach (KeyValuePair<Vehicle, Customer> vehicle in GarageLogic.VehiclesInGarage)
            {
                if (vehicle.Value.VehicleState.ToString().Equals(i_VehicleState.ToString()))
                {
                    vehiclesInGarage.AppendFormat(
                        @"- {0}
", 
                        vehicle.Key.LicenseNumber);
                    countVehiclesWithState++;
                }
            }

            if(countVehiclesWithState > 0)
            {
                Console.WriteLine("The vehicles in the garage in state {0}:", i_VehicleState);
                Console.WriteLine(vehiclesInGarage);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There are no vehicles in the garage with this state.");
                Console.WriteLine();
            }
        }

        private void setVehicleState(Vehicle i_VehicleToChangeState, VehicleEnum.eVehicleState i_NewState)
        {
            GarageLogic.SetVehicleState(i_VehicleToChangeState, i_NewState);
            Console.WriteLine("Vehicle's state change successful!");
        }

        private void tiresInflate(Vehicle i_VehicleToInflate)
        {
            GarageLogic.TiresInflate(i_VehicleToInflate);
            Console.WriteLine("Tires inflate successful!");
        }

        private void increaseEnergy(Vehicle i_VehicleToIncreaseEnergy, string i_LitersToAdd)
        {
            try
            {
                GarageLogic.IncreaseEnergy(i_VehicleToIncreaseEnergy, i_LitersToAdd);
                Console.WriteLine("Vehicle's energy increased successful!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format input.");
                Console.WriteLine();
            }
            catch (ValueOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }

        private void printVehicleInfo(string i_LicenseNumber)
        {
            StringBuilder vehicleInfo = new StringBuilder();
            Vehicle vehicle = GarageLogic.GetCarInGarage(i_LicenseNumber);
            
            vehicleInfo.AppendFormat(
                @"Owner's name: {0}
",
                GarageLogic.VehiclesInGarage[vehicle].Name);
            
            vehicleInfo.AppendFormat(
                    @"Vehicle's state: {0}
",
                    GarageLogic.VehiclesInGarage[vehicle].VehicleState);

            vehicleInfo.Append(vehicle.ToString());
            
            Console.WriteLine("The vehicle's information:");
            Console.WriteLine(vehicleInfo);
            Console.WriteLine();
        }

        internal static void ValidMenuSelection(string i_MenuSelectionStr, int i_MaxOption, out int i_MenuSelection)
        {
            while (!int.TryParse(i_MenuSelectionStr, out i_MenuSelection)
                   || i_MenuSelection < 1 
                   || i_MenuSelection > i_MaxOption)
            {
                Console.WriteLine();
                Console.WriteLine("Input entered is not a valid option from the menu. Please try again:");
                i_MenuSelectionStr = Console.ReadLine();
            }
        }
    }
}
