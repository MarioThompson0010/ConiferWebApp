using Microsoft.AspNetCore.Http.HttpResults;
using ModelsProject;
using Newtonsoft.Json;

namespace ConiferWebApp.Services
{
    public class Region : IRegion
    {
        private readonly HttpClient _httpClient;
        public List<MyRegion> Regions { get; set; }
        public Region(HttpClient httpClient)
        {
            this._httpClient = httpClient;

            var response =  _httpClient.GetFromJsonAsync<MyRegion[]>($"api/Region").Result;

            this.Regions = response.ToList();


            //this.Regions = FileOpenRegions();
        }

        public async Task<List<MyRegion>> GetRegions()
        {
             return this.Regions;
            
        }

        private List<MyRegion> FileOpenRegions()
        {
            var json = File.ReadAllText("Components/Pages/regions.json");
            List<MyRegion> regions = JsonConvert.DeserializeObject<List<MyRegion>>(json);



            return regions;
        }

    }
}
