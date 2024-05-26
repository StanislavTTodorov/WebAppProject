namespace WebAppProject.Common
{
    public class ModelsValidationConstants
    {
        public static class Product
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 1;

            public const string PriceMax = "1000000";
            public const string PriceMin = "0";
        }
    }
}
