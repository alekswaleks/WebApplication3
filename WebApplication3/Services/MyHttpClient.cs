using System.Text.Json.Serialization;
using System.Text.Json;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class MyHttpClient(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<PersonWithGender>> GetPeopleAsync()
        {
            var options = new JsonSerializerOptions()
            {
                Converters = { new JsonStringEnumConverter() }
            };

            var items = await _httpClient.GetFromJsonAsync<List<PersonWithGender>>("/people/index", options);
            return items;
        }
    }
}
