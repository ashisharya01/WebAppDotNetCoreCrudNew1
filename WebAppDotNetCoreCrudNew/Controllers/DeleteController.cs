
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program7
{
    static async Task Main()
    {
        int customerId = 1; // Replace with the desired customer ID
        string apiUrl = $"https://getinvoices.azurewebsites.net/api/Customer/{customerId}";

        // Send a DELETE request to remove the customer
        bool success = await DeleteCustomer(apiUrl);

        if (success)
        {
            Console.WriteLine($"Customer with ID {customerId} deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Error deleting customer with ID {customerId}.");
        }

        Console.ReadLine(); // Pause to keep the console window open
    }

    static async Task<bool> DeleteCustomer(string apiUrl)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(apiUrl);

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