namespace Inventory.Api.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = $"{Root}/{Version}";

        public static class Products
        {
            public const string AddProduct = $"{Base}/products/";
            public const string GetCounts = $"{Base}/products/counts";
            public const string GetProduct = Base + "/products/{productId:int}";
            public const string ChangeProductStatus = Base + "/products/{productId:int}";
            public const string SellProduct = Base + "/products/{productId:int}";
        }
    }
}
