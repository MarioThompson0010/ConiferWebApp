using ModelsProject;
using Newtonsoft.Json;

namespace ConiferWebApp.Services
{
    public class State : IState
    {
        private readonly HttpClient _httpClient;

        public List<MyState> States { get; set; }
        public State(HttpClient httpClient, List<MyState> states)
        {
            this._httpClient = httpClient;

            if (states.Count < 1)
            {
                var response = _httpClient.GetFromJsonAsync<MyState[]>($"api/State").Result;
                this.States = response.ToList();
                states.AddRange(this.States);
            }
            else
            {
                this.States = states;
            }


        }

        public async Task<List<MyState>> GetStates()
        {
            return this.States;
            
        }

        

    }
}
