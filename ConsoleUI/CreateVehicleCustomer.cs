using System;

namespace Garage.ConsoleUI
{
    
    using System.Collections.Generic;
    using System.Text;

    using GarageLogic;

    internal class CreateVehicleCustomer
    {
        
        internal static Customer GetCustomerInfo()
        {
            Customer newCustomer = new Customer();
            bool validInput = !true;
            
            Console.WriteLine("Please enter your name:");
            string customerName = Console.ReadLine();
            
            while (!validInput)
            {
                try
                {
                    Customer.CheckValidCustomerName(customerName);
                    newCustomer.Name = customerName;
                    validInput = !validInput;
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid name. Please enter your name:");
                    customerName = Console.ReadLine();
                }
            }

            validInput = !true;

            Console.WriteLine();
            Console.WriteLine("Please enter your phone number (5 digits number):");
            
            string customerPhoneNum = Console.ReadLine();
            
            while (!validInput)
            {
                try
                {
                    Customer.CheckValidPhoneNumber(customerPhoneNum);
                    newCustomer.PhoneNum = customerName;
                    validInput = !validInput;
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid phone number. Please enter your phone number:");
                    customerPhoneNum = Console.ReadLine();
                }
            }

            return newCustomer;
        }


        // $G$ DSN-007 (-7) This method is too long, should be divided into several methods.
        internal static Vehicle GetVehicleInfo(Garage i_GarageLogic)
        {
            VehicleFactory vehicleFactory = new VehicleFactory();
            StringBuilder menuSupportedVehicle = new StringBuilder();

            foreach (KeyValuePair<int, string> supportedVehicle in vehicleFactory.SupportedByGarage)
            {
                menuSupportedVehicle.AppendFormat(
                    @"{0} : {1}
", 
                    supportedVehicle.Value, 
                    supportedVehicle.Key);
            }

            Console.WriteLine(
                "What kind of vehicle do you want to repair? Please enter the digit that represents your answer:");
            Console.WriteLine(menuSupportedVehicle);
            string typeOfVehicleMenu = Console.ReadLine();
            
            GarageUI.ValidMenuSelection(typeOfVehicleMenu, vehicleFactory.SupportedByGarage.Count, out int typeOfVehicle);

            vehicleFactory.SupportedByGarage.TryGetValue(typeOfVehicle, out string typeOfVehicleStr);

            Vehicle vehicleToAdd = null;
            bool validInput = !true;

            Console.Clear();
            Console.WriteLine("Please enter the {0} license number:", typeOfVehicleStr);
            string licenseNumber = Console.ReadLine();

            while (!validInput)
            {
                try
                {
                    Vehicle.CheckValidLicenseNumber(licenseNumber);
                    
                    if (i_GarageLogic.IsCarInGarage(licenseNumber))
                    {
                        return i_GarageLogic.GetCarInGarage(licenseNumber);
                    }
                    else
                    {
                        vehicleToAdd = vehicleFactory.BuildVehicle(typeOfVehicle);
                        vehicleToAdd.LicenseNumber = licenseNumber;
                        validInput = !validInput;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid license number. Please try again:");
                    licenseNumber = Console.ReadLine();
                }
            }

            foreach (string feature in vehicleToAdd.Features)
            {
                Console.Clear();
                Console.WriteLine("Please enter the {0} of the {1}:", feature, typeOfVehicleStr);
                
                string userInput = null;
                validInput = !true;
                
                while (!validInput)
                {
                    try
                    {
                        string[] featureOptions = VehicleEnum.GetEnumValues(feature);
                        
                        if (featureOptions != null)
                        {
                            StringBuilder featureOptionsMenuSB = new StringBuilder();
                            
                            for (int i = 0; i < featureOptions.Length; i++)
                            {
                                featureOptionsMenuSB.AppendFormat("{0} : {1}      ", i + 1, featureOptions[i]);
                            }

                            Console.WriteLine(featureOptionsMenuSB);
                            userInput = Console.ReadLine();
                            
                            GarageUI.ValidMenuSelection(userInput, featureOptions.Length, out int menuSelection);
                            userInput = featureOptions[menuSelection - 1];
                        }
                        else
                        {
                            userInput = Console.ReadLine();
                        }
                        
                        vehicleToAdd.SetFeatures(feature, userInput);
                        validInput = !validInput;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid format input for feature {0}. Please try again:", feature);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid logic input for feature {0}. Please try again:", feature);
                    }
                    catch (ValueOutOfRangeException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine("{0}. Please try again:", e.Message);
                    }
                }
            }

            return vehicleToAdd;
        }
    }
}
