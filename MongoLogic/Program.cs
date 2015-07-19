using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoRepository;

namespace MongoLogic
{
    class Program
    {
        private static readonly MongoRepository<Customer> CustomerRepository = new MongoRepository<Customer>();

        static void Main(string[] args)
        {
            var john = new Customer()
            {
                FirstName = "John",
                LastName = "Aratunde"
            };

            var jane = new Customer()
            {
                FirstName = "Jane",
                LastName = "Iringe-Koko"
            };

            var jerry = new Customer()
            {
                FirstName = "Jerry",
                LastName = "Ajibade"
            };

            CustomerRepository.Add(new[] {john, jane, jerry});

            DumpData();

            john.FirstName = "Jonny";
            CustomerRepository.Update(john);

            CustomerRepository.Delete(jerry.Id);

            jane.Products.AddRange(new[]
            {
                new Product() {Name = "Mouse", Price = 33.33M},
                new Product() {Name = "Laptop", Price = 9033.33M}
            });

            CustomerRepository.Update(jane);

            DumpData();

            Console.ReadKey();

        }

        private static void DumpData()
        {
            Console.WriteLine("Currently in our database");
            foreach (var customer in CustomerRepository)
            {
                Console.WriteLine("{0}\t{1}\t has {2} products", customer.FirstName,customer.LastName, customer.Products.Count);
                foreach (var product in customer.Products)
                {
                    Console.WriteLine("\t{0} priced ${1:N2}", product.Name, product.Price);
                }
                Console.WriteLine("\tTOTAL: ${0:N2}", customer.Products.Sum(x => x.Price));
            }
            Console.WriteLine(new string('=',50));
        }
    }
}
