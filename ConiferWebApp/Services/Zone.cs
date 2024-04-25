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
            this.Zones = new List<MyZone>();
        }

        public async Task<IEnumerable<MyZone>> GetZones()
        {
            // Actually call the server on click event

            //GetClientSp getClientSp = new GetClientSp() { Email = email };
            var response = await _httpClient.GetFromJsonAsync<MyZone[]>($"api/Zone");
            //MyClient myClient = new MyClient();
            //try
            //{
            //    var temp = await response.Content.ReadFromJsonAsync<List<MyClient>>();
            //    myClient = temp.FirstOrDefault();
            //}
            //catch (Exception ex)
            //{
            //    var temp = ex.Message;

            //}

            //return myClient;
            this.Zones = response.ToList();

            return response;
        }
    }
}
