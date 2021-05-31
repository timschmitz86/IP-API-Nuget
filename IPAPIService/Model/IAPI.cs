using System.Text.Json.Serialization;

namespace IP_API
{
    /// <summary>
    /// default model of IP API structure
    /// </summary>
    public class IPAPI
    {
        public string query { get; set; }
        public string status { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string timezone { get; set; }
        public string isp { get; set; }
        public string org { get; set; }
        [JsonPropertyName("as")]
        public string _as { get; set; }
    }
}