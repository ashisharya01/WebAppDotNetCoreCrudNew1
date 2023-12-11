using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAppDotNetCoreCrudNew;

namespace WebAppDotNetCoreCrudNew.Controllers
{
    class Program
    {
        static async Task Main()
        {
            string deleteUrl = "https://getinvoices.azurewebsites.net/api/DeleteCustomerList";
            string createUrl = "https://getinvoices.azurewebsites.net/api/CreateCustomerList";

            // Delete the existing Customer List
            await DeleteCustomerList(deleteUrl);

            // Create a new Customer List
            await CreateCustomerList(createUrl);

            Console.WriteLine("Customer List deleted and a new one created.");

            Console.ReadLine(); // Pause to keep the console window open
        }

        private static Task CreateCustomerList(string createUrl)
        {
            throw new NotImplementedException();
        }

        static async Task DeleteCustomerList(string deleteUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Customer List deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Error deleting Customer List: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }

        class Program1
        {
            static async Task Main(int v)
            {
                string apiUrl = "https://getinvoices.azurewebsites.net/api/Customer";

                // Create a new customer
                Customer newCustomer = new Customer
                {
                    Firstname = v,
                    Lastname = "Doe",
                    Email = "john.doe@example.com",
                    // Add other properties as needed
                };

                // Send a POST request to create the new customer
                bool success = await CreateCustomer(apiUrl, newCustomer);

                if (success)
                {
                    Console.WriteLine("New customer created successfully.");
                }
                else
                {
                    Console.WriteLine("Error creating the new customer.");
                }

                Console.ReadLine(); // Pause to keep the console window open
            }

            static async Task<bool> CreateCustomer(string apiUrl, Customer newCustomer)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // Serialize the customer object to JSON
                        string jsonCustomer = JsonConvert.SerializeObject(newCustomer);
                        StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

                        // Send a POST request to create the new customer
                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                        return response.IsSuccessStatusCode;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }
    class main1
    {
        static async Task Main()
        {
            int customerId = 1; // Replace with the desired customer ID
            string apiUrl = $"https://getinvoices.azurewebsites.net/api/Customer/{customerId}";

            // Retrieve the customer by ID
            Customer customer = await GetCustomerById(apiUrl);

            if (customer != null)
            {
                Console.WriteLine($"Customer ID: {customer.ID}, Name: {customer.Firstname} {customer.Lastname}, Email: {customer.Email}");
            }
            else
            {
                Console.WriteLine($"Error retrieving customer with ID {customerId}.");
            }

            Console.ReadLine(); // Pause to keep the console window open
        }

        private static Task<Customer> GetCustomerById(string apiUrl)
        {
            throw new NotImplementedException();
        }

        class Prom
        {
            static async Task<Customer> GetCustomerById(string apiUrl)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            Customer customer = JsonConvert.DeserializeObject<Customer>(json);
                            return customer;
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



            record Customer5(int ID, string Firstname, string Lastname, string Email);
        }
    }
}
