using ModelsProject;
using Newtonsoft.Json;

namespace ConiferWebApp.Services
{
    public class State : IState
    {
        private readonly HttpClient _httpClient;

        public List<MyState> States { get; set; }
        public State(HttpClient httpClient)
        {
            this._httpClient = httpClient;


            var response = _httpClient.GetFromJsonAsync<MyState[]>($"api/State").Result;

            this.States = response.ToList();

        }

        public async Task<List<MyState>> GetStates()
        {
            return this.States;
            
        }

        

    }
}
