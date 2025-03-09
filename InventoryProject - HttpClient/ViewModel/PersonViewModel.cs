using ClientHttp.Model;
using InventoryProject___HttpClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientHttp.ViewModel
{
    public class PersonViewModel
    {
        private static HttpClient httpClient = new HttpClient();

        public static async Task<List<Person>> getPerson()
        {
            try
            {
                StringContent content = new StringContent("getPerson");
                using var request = new HttpRequestMessage(HttpMethod.Get, "http://127.0.0.1:8888/connection/");
                request.Headers.Add("table", "person");
                request.Content = content;
                using HttpResponseMessage response = await httpClient.SendAsync(request);
                string responseText = await response.Content.ReadAsStringAsync();
                List<Person> clients = JsonSerializer.Deserialize<List<Person>>(responseText)!;
                return clients;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ошибка HTTP-запроса: {ex.Message}");
                return new List<Person>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Ошибка десериализации JSON: {ex.Message}");
                return new List<Person>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
                return new List<Person>();
            }
        }
        public static async Task SendClient(Person person)
        {
            try
            {
                JsonContent content = JsonContent.Create(person);
                var request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8888/connection/");
                request.Content = content;
                request.Headers.Add("table", "person");
                using var response = await httpClient.SendAsync(request);
                string responseText = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseText);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ошибка HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static async Task DelClient(int clientId)
        {
            try
            {
                JsonContent content = JsonContent.Create(clientId);
                var request = new HttpRequestMessage(HttpMethod.Delete, "http://127.0.0.1:8888/connection/");
                request.Content = content;
                request.Headers.Add("table", "person");
                using var response = await httpClient.SendAsync(request);
                string responseText = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseText);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ошибка HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static async Task PutClient(Person person)
        {
            try
            {
                JsonContent content = JsonContent.Create(person);
                var request = new HttpRequestMessage(HttpMethod.Put, "http://127.0.0.1:8888/connection/");
                request.Content = content;
                request.Headers.Add("table", "person");
                using var response = await httpClient.SendAsync(request);
                string responseText = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseText);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ошибка HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public static async Task<bool> VerifyPassword(string username, string password)
        {
            JsonUser requestData = new JsonUser()
            {
                UserName = username,
                Password = password
            };
            JsonContent content = JsonContent.Create(requestData);
            var request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8888/connection/");
            request.Content = content;
            request.Headers.Add("table", "verifyPasswordPerson");
            using var response = await httpClient.SendAsync(request);
            string responseText = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseText);
            var result = JsonSerializer.Deserialize<PasswordVerificationResult>(responseText);
            return result!.IsValid;
        }
    }
    public class PasswordVerificationResult
    {
        public bool IsValid { get; set; }
    }
}
