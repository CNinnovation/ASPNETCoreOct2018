using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPIClient.Models;

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
            var response = await _httpClient.GetAsync("/api/Books");
            response.EnsureSuccessStatusCode();

            // string length??? - use ReadAsStreamAsync with large strings!
            string json = await response.Content.ReadAsStringAsync();
            IEnumerable<Book> books = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
            return books;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            string json = JsonConvert.SerializeObject(book);
            HttpContent booksContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Books", booksContent);
            response.EnsureSuccessStatusCode();

            string jsonResult = await response.Content.ReadAsStringAsync();
            Book returnedBook = JsonConvert.DeserializeObject<Book>(jsonResult);
            return returnedBook;

        }
    }
}
