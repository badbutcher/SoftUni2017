namespace Store
{
    class Program
    {
        static void Main()
        {
            StoreContext context = new StoreContext();

            //Product p1 = new Product
            //{
            //    Name = "Apple",
            //    DistributorName = "BGTrade",
            //    Description = "It's an apple",
            //    Price = 0.99f
            //};

            //Product p2 = new Product
            //{
            //    Name = "Banana",
            //    DistributorName = "BGTrade",
            //    Description = "It's an banana",
            //    Price = 1.49f
            //};

            //Product p3 = new Product
            //{
            //    Name = "Orange",
            //    DistributorName = "UKTrade",
            //    Description = "It's an orange",
            //    Price = 1.99f
            //};

            //Product p4 = new Product
            //{
            //    Name = "Watermelon",
            //    DistributorName = "TradeGO",
            //    Description = "Tova e golqm fasul",
            //    Price = 0.39f,
            //    Weight = 3,
            //    Quantity = 1
            //};

            //context.Products.Add(p1);
            //context.Products.Add(p2);
            //context.Products.Add(p3);
            //context.Products.Add(p4);

            context.Products.Remove(context.Products.Find(1));

            context.SaveChanges();
        }
    }
}