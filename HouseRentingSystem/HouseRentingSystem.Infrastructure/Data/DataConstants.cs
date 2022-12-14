namespace HouseRentingSystem.Infrastructure.Data
{
    public class DataConstants
    {
        public class Category
        {
            public const int MinCategoryName = 2;
            public const int MaxCategoryName = 50;
        }

        public class House
        {
            public const int MinHouseTitle = 10;
            public const int MaxHouseTitle = 50;

            public const int MinHouseAddress = 30;
            public const int MaxHouseAddress = 150;

            public const int MinHouseDescription = 50;
            public const int MaxHouseDescription = 500;

            public const string MinPricePerMonth = "0.0";
            public const string MaxPricePerMonth = "20000.0";
        }

        public class Agent
        {
            public const int MinUserName = 1;
            public const int MaxUserName = 20;

            public const int MinAgentPhoneNumber = 7;
            public const int MaxAgentPhoneNumber = 15;
        }
    }
}
