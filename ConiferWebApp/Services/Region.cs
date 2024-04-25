﻿using Microsoft.AspNetCore.Http.HttpResults;
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
            this.Regions = FileOpenRegions();// new List<MyRegion>();
        }

        public async Task<List<MyRegion>> GetRegions()
        {
             return this.Regions;
            //GetClientSp getClientSp = new GetClientSp() { Email = email };
            //var response = await _httpClient.PostAsJsonAsync<GetClientSp>($"api/GetClient", getClientSp);
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
            //return null;
        }

        private List<MyRegion> FileOpenRegions()
        {
            var json = File.ReadAllText("Components/Pages/regions.json");
            List<MyRegion> regions = JsonConvert.DeserializeObject<List<MyRegion>>(json);



            return regions;
        }

    }
}