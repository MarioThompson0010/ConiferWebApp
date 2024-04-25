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
            this.States = this.FileOpenStates();// new List<MyState>();
        }

        public async Task<List<MyState>> GetStates()
        {
            return this.States;
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

        private List<MyState> FileOpenStates()
        {
            var json = File.ReadAllText("Components/Pages/states.json");
            List<MyState> states = JsonConvert.DeserializeObject<List<MyState>>(json);

            return states;
        }

    }
}
