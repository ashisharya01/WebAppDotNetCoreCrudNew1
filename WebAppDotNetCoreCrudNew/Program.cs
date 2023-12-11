using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebAppDotNetCoreCrudNew.Models;

namespace WebAppDotNetCoreCrudNew
{
    public class Program
    {
        string apiUrl = "https://getinvoices.azurewebsites.net/api/customers";
        private List<Client> customers;
      
 // Pause to keep the console window open
        // Retrieve data from the API


        private static Task<List<Client>> GetCustomer()
        {
            throw new NotImplementedException();
        }

        public List<Client> Customers { get => Customers1; set => Customers1 = value; }
        public List<Client> Customers1 { get => customers; set => customers = value; }

        private static Task<List<Client>> GetClient()
        {
            throw new NotImplementedException();
        }

        // Build and display the table
        static async Task<List<Customer>> GetCustomers(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                        return customers;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return null;
                }
            }
        }

        static void BuildTable(List<Customer> customers)
        {
            if (customers != null)
            {
                Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-25} {4,-15} {5,-10} {6,-10} {7,-10}",
                    "CustomerId", "Firstname", "Lastname", "Email", "Phone_Number", "Country_code", "Gender", "Balance");

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-25} {4,-15} {5,-10} {6,-10} {7,-10}",
                        customer.CustomerId, customer.Firstname, customer.Lastname, customer.Email,
                        customer.Phone_Number, customer.Country_code, customer.Gender, customer.Balance);
                }
            }
        }
        




    public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

}
    