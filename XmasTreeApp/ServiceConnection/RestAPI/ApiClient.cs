using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XmasTreeApp.ServiceConnection.Dto;

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

        public async Task<IEnumerable<LightModeDto>> GetData()
        {
            //Uri uri = new Uri("http://192.168.0.161:5000/xmastree");
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
    }
}
