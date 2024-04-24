using Microsoft.AspNetCore.Http.HttpResults;
using ModelsProject;

namespace ConiferWebApp.Services
{
    public class Region : IRegion
    {
        private readonly HttpClient _httpClient;

        public Region(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<MyRegion>> GetRegions()
        {
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
            return null;
        }
    }
}
