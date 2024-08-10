using crud.Context;
using crud.Models;

namespace crud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var product1 = new Product { Name = "Laptop", Price = 999.99M };
            var product2 = new Product { Name = "Smartphone", Price = 599.99M };
            var product3 = new Product { Name = "Tablet", Price = 299.99M };

            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);

            var order1 = new Order { Address = "123 Hebron" };
            var order2 = new Order { Address = "456 Ramalleh" };
            var order3 = new Order { Address = "789 Nblus" };

            context.Orders.Add(order1);
            context.Orders.Add(order2);
            context.Orders.Add(order3);

            context.SaveChanges();

            var products = context.Products.ToList();
            Console.WriteLine("get All Products");
            foreach (var product in products)
            {
                Console.WriteLine($"ProductId:{product.Id}...ProductName:{product.Name}...ProductPrice:{product.Price}");
            }
            Console.WriteLine("--------------------------------------------------------");
            var orders = context.Orders.ToList();
            Console.WriteLine("get All Orders");
            foreach (var order in orders)
            {
                Console.WriteLine($"OrderId:{order.Id}...Address:{order.Address}");

            }
            Console.WriteLine("--------------------------------------------------------");

            var pupdate = context.Products.FirstOrDefault(p => p.Id == 1);
            pupdate.Name = "Laptop Hp";
            context.SaveChanges();
            Console.WriteLine("Product name updated successfully.");

            var CreatATUpdate = context.Orders.FirstOrDefault(o => o.Id == 1);
            CreatATUpdate.CreatedAt = DateTime.Now;
            context.SaveChanges();
            Console.WriteLine("Order 'created_AT' updated successfully.");

            var removeProduct = context.Products.FirstOrDefault(p => p.Id == 2);
            context.Remove(removeProduct);
            context.SaveChanges();
            Console.WriteLine("Product id 2 remove successfully.");

            var removeOrder = context.Orders.FirstOrDefault(o => o.Id == 3);
            context.Remove(removeOrder);
            context.SaveChanges();
            Console.WriteLine("Order id 3 remove successfully.");


        }
    }
}
