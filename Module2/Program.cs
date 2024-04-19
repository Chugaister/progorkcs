using System;
using System.Collections.Generic;

// VARIANT 1

namespace modul2
{
    public class ModuleException : Exception
    {
        public ModuleException() : base() { }
        public ModuleException(string message) : base(message) { }
        public ModuleException(string message, Exception innerException) : base(message, innerException) { }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public Product()
        {
            Name = "default_product_name";
            Price = 0.0;
        }
    }

    class FoodProduct: Product
    {
        public int Weight { get; set; }
        public FoodProduct(string name, double price, int weight): base(name, price)
        {
            Weight = weight;
        }
    }

    class ElectronicProduct: Product
    {
        public int Ram { get; set; }
        public ElectronicProduct(string name, double price, int ram): base(name, price)
        {
            Ram = ram;
        }
    }

    interface IOrder
    {
        void add(Product p);
        void del(Product p);
        double getPrice();
    }

    class Order: IOrder
    {
        List<Product> products;


        public delegate void OrderChangedDelegate(object sender, EventArgs e);
        public event OrderChangedDelegate OrderChanged;


        public Order()
        {
            products = new List<Product>();
        }

        public void add(Product p)
        {
            if (p.Name.Contains("Z"))
            {
                throw new ModuleException("Z shit is forbidden here");
            }
            products.Add(p);
            if (OrderChanged != null)
            {
                EventArgs ea = new EventArgs();
                OrderChanged(this, ea);
            }
        }

        public void del(Product p)
        {
            products.Remove(p);
            if (OrderChanged != null)
            {
                EventArgs ea = new EventArgs();
                OrderChanged(this, ea);
            }
        }

        public double getPrice()
        {
            double price = 0;
            foreach (Product p in products)
            {
                price += p.Price;
            }
            return price;
        }
    }
    class Program
    {
        static void eee(object sender, EventArgs e) {
            Order o = (Order)sender;
            Console.WriteLine($"Order changed! Total price: {o.getPrice()}");
        }
        static void Main(string[] args)
        {
            /// There is no need in generilization of Order class. There are two reasons why:
            /// At first any derived class from Product can be passed to Order mothods, so flexibility provided enough
            /// Other reason is that I don't know how to use intefraces with generic stuff together

            Order o = new Order();
            o.OrderChanged += eee;
            Product p1 = new Product("Dudka", 400.0);
            FoodProduct p2 = new FoodProduct("Kovbasa", 5.0, 200);
            ElectronicProduct p3 = new ElectronicProduct("Magnitolla", 500.0, 128);

            o.add(p1);
            o.del(p1);
            o.add(p2);
            o.add(p3);
            Console.Read();
        }
    }
}
