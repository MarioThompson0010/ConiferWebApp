using Microsoft.AspNetCore.Http.HttpResults;
using ModelsProject;

namespace ConiferWebApp.Services
{
    public class Zone : IZone
    {
        private readonly HttpClient _httpClient;
        public List<MyZone> Zones { get; set; }

        public Zone(HttpClient httpClient, List<MyZone> zones)
        {
            this._httpClient = httpClient;
            if (zones.Count < 1)
            {
                var response =  _httpClient.GetFromJsonAsync<MyZone[]>($"api/Zone").Result;

                this.Zones = response.ToList();
                zones.AddRange(this.Zones);
            }
            else
            {
                this.Zones = zones;
            }
        }

        public async Task<IEnumerable<MyZone>> GetZones()
        {
            // Actually call the server on click event

            var response = await _httpClient.GetFromJsonAsync<MyZone[]>($"api/Zone");
            
            this.Zones = response.ToList();

            return response;
        }

        public async Task<List<MyZone>> GetZonesAlreadyInjected()
        {
            return this.Zones;
            
        }
    }
}
