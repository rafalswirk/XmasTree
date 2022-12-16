using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XmasTreeApp.ServiceConnection.Dto;
using static Android.Content.ClipData;

namespace XmasTreeApp.ServiceConnection.RestAPI
{
    public class ApiClient
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public ApiClient(string url)
        {
            _client = new HttpClient();
            _baseUrl = url;
        }

        public async Task<IEnumerable<LightModeDto>> GetLigthingModes()
        {
            Uri uri = new Uri($"{_baseUrl}/xmastree");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var items = JsonSerializer.Deserialize<List<string>>(content);
                    return items.Select(i => new LightModeDto { Id = i}).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return null;
            }
            return null;
        }

        public async Task<bool> SetLigthingMode(LightModeDto dto)
        {
            Uri uri = new Uri($"{_baseUrl}/xmastree/setlightingmode");
            try
            {
                string json = JsonSerializer.Serialize<LightModeDto>(dto);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


                HttpResponseMessage response = await _client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return false;
            }
            return false;
        }
    }
}
