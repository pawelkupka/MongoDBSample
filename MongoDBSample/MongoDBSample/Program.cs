using System;
using System.Linq;
using MongoDBSample.Models;

namespace MongoDBSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerRepository = new CustomerRepository();
            customerRepository.DeleteAll();
            customerRepository.Insert(new Customer { Id = 1, Name = "Name1" });
            customerRepository.Insert(new Customer { Id = 2, Name = "Name2" });
            customerRepository.Insert(new Customer { Id = 3, Name = "Name3" });
            customerRepository.Insert(new Customer { Id = 4, Name = "Name4" });
            customerRepository.Update(new Customer { Id = 2, Name = "Name22" });
            customerRepository.Delete(3);
            var allCustomers = customerRepository.GetAll();
            allCustomers.ToList().ForEach(c => Console.WriteLine(c.Name));
        }
    }
}
