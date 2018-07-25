using LocationFinder.DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LocationFinder.DAL.Repository
{
    public class LocationRepository : ILocationRepository
    {

        private HttpClient _client;
        private readonly string _apiKey;

        public LocationRepository(HttpClient client, IConfiguration config)
        {
            _client = client;
            _client.BaseAddress = new Uri($"https://maps.googleapis.com");
            _apiKey = config["GoogleAPIKey"];
        }

        public async Task<string> GetLocationData(string keyword, int radius, string location)
        {
            
            string requestUri = $"maps/api/place/nearbysearch/json?location={location}&radius={radius}&keyword={keyword}&key={_apiKey}";
            var result = await _client.GetAsync(requestUri);

            var response = await result.Content.ReadAsStringAsync();

            return response;
        }
    }
}
