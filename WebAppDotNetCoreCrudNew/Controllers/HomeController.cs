using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebAppDotNetCoreCrudNew;
using WebAppDotNetCoreCrudNew.Models;



namespace WebAppDotNetCoreCrudNew.Controllers
{
    public class HomeController : Controller
    {


        class Program
        {
            private static async Task Main()
            {
                string apiUrl = "https://getinvoices.azurewebsites.net/api/Customers";

                // Retrieve the list of customers
                List<Customer> customers = await GetCustomers(apiUrl);

                // Display the customer information
                DisplayCustomers(customers);

                Console.ReadLine(); // Pause to keep the console window open
            }

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

            static void DisplayCustomers(List<Customer> customers)
            {
                if (customers != null)
                {
                    Console.WriteLine("Customer List:");
                    foreach (var customer in customers)
                    {
                        Console.WriteLine($"ID: {customer.ID}, Name: {customer.Firstname} {customer.Lastname}, Email: {customer.Email}");
                    }
                }
            }
        }
    }

        class Customer
        {
            public int ID { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Email { get; set; }

        public static implicit operator Customer(Customer v)
        {
            throw new NotImplementedException();
        }
        // Add other properties as needed
    }
    }
