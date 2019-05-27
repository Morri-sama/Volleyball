using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string apiUrl = @"http://192.168.1.33:5000/";

            RegisterViewModel model = new RegisterViewModel();

            Console.ReadKey();

            Console.WriteLine("Никнейм");
            model.UserName = Console.ReadLine();
            Console.WriteLine("Имя");
            model.FirstName = Console.ReadLine();
            Console.WriteLine("Фамилия");
            model.MiddleName = Console.ReadLine();
            Console.WriteLine("Отчество");
            model.LastName = Console.ReadLine();
            Console.WriteLine("Пароль");
            model.Password = Console.ReadLine();




            HttpResponseMessage response = null;

            using (var httpClient = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync(new Uri(apiUrl + "api/account"), stringContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                    Console.WriteLine("Ok");
                }
            }
        }
    }
}
