namespace Garage.ConsoleUI
{
    // $G$ SFN-999 (-10) The program does not give all the options in the main menu as requested

    // $G$ CSS-016 (-3) The main class should be called Program.
    public class App
    {
        public static void Main()
        {
            GarageUI garageManager = new GarageUI();
            garageManager.RunApp();
        }
    }
}
