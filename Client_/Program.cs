using ClassLibrary;
using Client_;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;


internal class Program
{
    static void Main(string[] args)
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:7189");
        var running = true;
        var mainMenuFunctions = new MainMenuFunctions();
        while (running)
        {
            Console.WriteLine("Type: ");
            Console.WriteLine("1. To see all record.");
            Console.WriteLine("2. To see a record.");
            Console.WriteLine("3. To add a record.");
            Console.WriteLine("4. To update a record.");
            Console.WriteLine("5. To remove a record.");
            Console.WriteLine("6. To Exit.");
            var selection = Console.ReadKey();
            switch (selection.KeyChar)
            {
                case '1':
                    var response = httpClient.GetAsync("Persons");
                    var diserializedResponse = response.Result.Content.ReadFromJsonAsync<PersonDto[]>();
                    
                    Console.WriteLine(diserializedResponse);
                    Console.ReadKey();
                    return;

                case '2':
                    mainMenuFunctions.ShowOneRecord();
                    return;

                case '3':
                    mainMenuFunctions.AddRecord();

                    return;
                case '4':
                    mainMenuFunctions.UpdateRecord();
                    return;
                case '5':
                    mainMenuFunctions.RemoveRecord();
                    return;
            }
            Console.ReadLine();

        }


    }
}
