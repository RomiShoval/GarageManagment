namespace GarageLogic
{
    public abstract class VehicleEnum
    {
        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B
        }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public enum eColor
        {
            Red,
            White,
            Black,
            Silver
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public enum eVehicleState
        {
            InRepair,

            Repaired,

            Paid
        }

        public static string[] GetEnumValues(string i_EnumType)
        {
            switch(i_EnumType)
            {
                case "license type":
                    return typeof(eLicenseType).GetEnumNames();
                case "fuel type":
                    return typeof(eFuelType).GetEnumNames();
                case "color":
                    return typeof(eColor).GetEnumNames();
                case "number of doors":
                    return typeof(eNumberOfDoors).GetEnumNames();
                case "vehicle state":
                    return typeof(eVehicleState).GetEnumNames();
                default:
                    return null;
            }
        }
    }
}