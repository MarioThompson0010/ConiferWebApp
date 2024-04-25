using Microsoft.AspNetCore.Http.HttpResults;
using ModelsProject;

namespace ConiferWebApp.Services
{
    public class Zone : IZone
    {
        private readonly HttpClient _httpClient;
        public List<MyZone> Zones { get; set; }

        public Zone(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            if (this.Zones == null)
            {
                var response =  _httpClient.GetFromJsonAsync<MyZone[]>($"api/Zone").Result;

                this.Zones = response.ToList();//.ToList();
                //this.Zones = new List<MyZone>();
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
