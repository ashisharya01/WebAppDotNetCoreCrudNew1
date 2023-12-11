using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main()
    {
        int customerId = 1; // Replace with the desired customer ID
        string apiUrl = $"https://getinvoices.azurewebsites.net/api/Customer/{customerId}";

        // Retrieve the existing customer by ID
        Customer existingCustomer = await GetCustomerById(apiUrl);

        if (existingCustomer != null)
        {
            // Update customer information
            existingCustomer.Firstname = "UpdatedFirstName";
            existingCustomer.Lastname = "UpdatedLastName";
            existingCustomer.Email = "updated.email@example.com";
            // Add other property updates as needed

            // Send a POST request to update the customer
            bool success = await UpdateCustomer(apiUrl, existingCustomer);

            if (success)
            {
                Console.WriteLine($"Customer with ID {customerId} updated successfully.");
            }
            else
            {
                Console.WriteLine($"Error updating customer with ID {customerId}.");
            }
        }
        else
        {
            Console.WriteLine($"Error retrieving customer with ID {customerId}.");
        }

        Console.ReadLine(); // Pause to keep the console window open
    }

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

    static async Task<bool> UpdateCustomer(string apiUrl, Customer updatedCustomer)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Serialize the updated customer object to JSON
                string jsonCustomer = JsonConvert.SerializeObject(updatedCustomer);
                StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

                // Send a POST request to update the customer
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


    class Customer
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        // Add other properties as needed
    }
}