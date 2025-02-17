using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace auto.browser.Tests
{
    public class EventJsonData
    {
        [JsonPropertyName("Code")]
        public string Code { get; set; }
    }

    public class SmsRegResponse
    {
        [JsonPropertyName("eventJsonData")]
        public string EventJsonData { get; set; }
    }

    class GetResponse
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public static async Task<string> GetJsonResponseAsync(string url)
        {
            
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                SmsRegResponse[] regResponse = JsonSerializer.Deserialize<SmsRegResponse[]>(jsonResponse);
                SmsRegResponse responseItem = regResponse[0];
                EventJsonData eventData = JsonSerializer.Deserialize<EventJsonData>(responseItem.EventJsonData);
                return eventData.Code;

            }
        }
    }

}
