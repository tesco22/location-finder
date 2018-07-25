using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationFinder.Domain.GoogleResponses
{
    public class GooglePlaceResult
    {
        [JsonProperty("html_attributions")]
        public string [] HtmlAttributions { get; set; }
        [JsonProperty("next_page_token")]
        public string NextPageToken { get; set; }
        [JsonProperty("results")]
        public List<JObject> Results { get; set; }
    }
}
