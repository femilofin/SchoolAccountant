using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoRepository;

namespace MongoLogic
{
    public class Customer : Entity
    {
        public Customer()
        {
            this.Products = new List<Product>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Product> Products { get; set; }

    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
