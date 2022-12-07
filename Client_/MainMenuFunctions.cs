using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Client_
{
    internal class MainMenuFunctions
    {

        
        public async void ShowAllRecords(HttpClient httpClient)
        {
            var response = await httpClient.GetAsync("/Persons");
            response.EnsureSuccessStatusCode();
            var persons = await response.Content.ReadFromJsonAsync<PersonDto[]>();
            Console.WriteLine("All records");
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
        public void ShowOneRecord()
        {
            Console.WriteLine("Enter the ID");
        }
        public string AddRecord()
        {
            Console.WriteLine("Enter the Name of the new record.");
            string newRecordName = Console.ReadLine();
            Console.WriteLine("Enter the City of the new record.");
            string newRecordCity = Console.ReadLine();

            var newEntry = 
                "{" +
                "Name = " + newRecordName + ", " +
                "City = " + newRecordCity + 
                "}";

            return newEntry;
        }
        public void UpdateRecord()
        {
            Console.WriteLine("Update Record.");
        }
        public void RemoveRecord()
        {
            Console.WriteLine("Remove Record.");
        }
    }
}
