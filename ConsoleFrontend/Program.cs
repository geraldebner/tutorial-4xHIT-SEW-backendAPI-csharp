using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleFrontend;

class Program
{
    private static readonly HttpClient client = new HttpClient();
    private const string baseUrl = "http://127.0.0.1:5235";

    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("FastAPI Frontend Console App");
            Console.WriteLine("1. Get Greeting");
            Console.WriteLine("2. Store Text");
            Console.WriteLine("3. Get Stored Text");
            Console.WriteLine("q. Quit");
            Console.WriteLine("Choose an option (1-3):");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await GetGreeting();
                    break;  
                case "2":
                    await StoreText();
                    break;
                case "3":
                    await GetStoredText();
                    break;
                case "q":
                    Console.WriteLine("Quitting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("----------------------------");
        }
    }

    static async Task GetGreeting()
    {
        var response = await client.GetStringAsync($"{baseUrl}/");
        Console.WriteLine($"Response: {response}");
    }

    static async Task StoreText()
    {
        Console.Write("Enter text to store: ");
        var text = Console.ReadLine();

        var url = $"{baseUrl}/text?text={Uri.EscapeDataString(text)}";
        var response = await client.PutAsync(url, null);
        Console.WriteLine($"Status: {response.StatusCode}");
    }

    static async Task GetStoredText()
    {
        var response = await client.GetStringAsync($"{baseUrl}/text");
        Console.WriteLine($"Stored Text: {response}");
    }
}
