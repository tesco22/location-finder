using LocationFinder.DAL.Repository.Interfaces;
using LocationFinder.Domain.GoogleResponses;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            try
            {
                string requestUri = $"maps/api/place/nearbysearch/json?location={location}&radius={radius}&keyword={keyword}&key={_apiKey}";
                var result = await _client.GetAsync(requestUri);

                var data = await result.Content.ReadAsStringAsync();

                //parse out the response since I only care about the name of the place
                var response = GetResponse(data);

                return response;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        private string GetResponse(string data)
        {
            var locationNames = new List<string>();
            var jResponse = JsonConvert.DeserializeObject<GooglePlaceResult>(data);

            var resultList = jResponse.Results;

            foreach(var item in resultList)
            {
                locationNames.Add(item.GetValue("name").ToString());
            }

            return JsonConvert.SerializeObject(locationNames).ToString();


        }
    }
}
