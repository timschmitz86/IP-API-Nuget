using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IP_API
{
    /// <summary>
    /// Static service to Call IP API
    /// </summary>
    public static class IPAPIService
    {
        private const string ENDPOINT = "http://ip-api.com/";
        private const string METHOD_SINGLE ="json/";  
        private const string METHOD_BULK = "bulk/";

        /// <summary>
        /// Translates a single IPv4 or IPv6 into IPAPI structure
        /// </summary>
        /// <param name="ip">IPv4 or IPv6 as string</param>
        /// <returns>returns the filled IPAPI structure on sucess</returns>
        public static async Task<IPAPI> GetLanguageIPAPI(string ip)
        {
            try
            {
                string api = ENDPOINT+METHOD_SINGLE;
                HttpClient client = new ();
                var payload = await client.GetStreamAsync(api + ip);

                return await JsonSerializer.DeserializeAsync<IPAPI>(payload);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;

            }
        }

        /// <summary>
        /// Translates a list of IPv4 or IPv6 into IPAPI structures
        /// </summary>
        /// <param name="ip">list of IPv4 or IPv6 strings</param>
        /// <returns>returns a list of filled IPAPI structures on success</returns>
        public static async Task<IEnumerable<IPAPI>> GetLanguageIPAPIBatch(List<string> ip)
        {
            return await GetLanguageIPAPIBatch(ip.ToArray());
        }

        /// <summary>
        /// Translates a array of IPv4 or IPv6 into IPAPI structures
        /// </summary>
        /// <param name="ip">array of IPv4 or IPv6 strings</param>
        /// <returns>returns a list of filled IPAPI structures on success</returns>
        public static async Task<IEnumerable<IPAPI>> GetLanguageIPAPIBatch(string[] ip)
        {
            try
            {
                string api = ENDPOINT+METHOD_BULK;

                var json = JsonSerializer.Serialize(ip);
                HttpClient client = new ();
                StringContent content = new (json);
                var payload = await client.PostAsync(api, content);


                return await JsonSerializer.DeserializeAsync<IPAPI[]>(await payload.Content.ReadAsStreamAsync());
                // return result.Select(p => p.countryCode);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;

            }
        }
    }
}
