using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

// This is using .NET 4.8 Framework, for later version it already different
// Here we added reference to System.Web.Extension assembly in this project

namespace JsonSerializationExample
{
    [Serializable]
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Age { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer()
            {
                CustomerId = 1,
                CustomerName = "Nancy",
                Age = 20,
            };

            // Create object of JavaScriptSerializer class
            var javaScriptSerializer = new JavaScriptSerializer();

            string filePath = @"c:\practice\customer.txt";
            using (var streamWriter = new StreamWriter(filePath))
            {
                // Serialize
                string json = javaScriptSerializer.Serialize(customer);
                streamWriter.Write(json);
                Console.WriteLine(json);
                Console.WriteLine("Serialize");
            }

            // Deserialize
            using (var streamReader = new StreamReader(filePath))
            {
                string json = streamReader.ReadToEnd(); 
                Customer customer_from_file = javaScriptSerializer.Deserialize<Customer>(json);
                Console.WriteLine("\nAfter serialization:");
                Console.WriteLine($"CustomerId : {customer_from_file.CustomerId}");
                Console.WriteLine($"CustomerName: {customer_from_file.CustomerName}");
                Console.WriteLine($"Age: {customer_from_file.Age}");
            }

            Console.ReadKey();
        }
    }
}
