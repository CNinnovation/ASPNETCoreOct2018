using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPIClient.Models;
using WebAPIClient.Extensions;

namespace WebAPIClient
{
    public class BooksClientService
    {
        private readonly HttpClient _httpClient;

        public BooksClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            //var response = await _httpClient.GetAsync("/api/Books");
            //response.EnsureSuccessStatusCode();

            // v1: using strings
            // string length??? - use ReadAsStreamAsync with large strings!
            // string json = await response.Content.ReadAsStringAsync();

            // v2: using streams
            //Stream stream = await response.Content.ReadAsStreamAsync();
            //using (var reader = new StreamReader(stream))
            //using (var jsonReader = new JsonTextReader(reader))
            //{
            //    return new JsonSerializer().Deserialize<IEnumerable<Book>>(jsonReader);
            //}

            // v3: using extension helpers
            return await _httpClient.GetItemsAsync<Book>("/api/Books");
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            //string json = JsonConvert.SerializeObject(book);
            //HttpContent booksContent = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await _httpClient.PostAsync("/api/Books", booksContent);
            //response.EnsureSuccessStatusCode();

            //string jsonResult = await response.Content.ReadAsStringAsync();
            //Book returnedBook = JsonConvert.DeserializeObject<Book>(jsonResult);
            //return returnedBook;

            return await _httpClient.AddItemAsync("/api/Books", book);
        }
    }
}
