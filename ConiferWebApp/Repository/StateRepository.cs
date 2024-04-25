using ConiferWebApp.Data;
using ModelsProject;
using Newtonsoft.Json;

namespace ConiferWebApp.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDbContext _context;

        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MyState>> GetMyStates()
        {
            List<MyState> mystate = new List<MyState>();

            try
            {

                var resultGood = await FileOpenStates();
                return resultGood;
            }
            catch (Exception)
            {
                return mystate;
            }
        }

        private async Task<List<MyState>> FileOpenStates()
        {
            var json = File.ReadAllText("Components/Pages/states.json");
            List<MyState> states = JsonConvert.DeserializeObject<List<MyState>>(json);



            return states;
        }

    }
}
