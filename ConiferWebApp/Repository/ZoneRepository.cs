using ConiferWebApp.Data;
using ModelsProject;
using Newtonsoft.Json;

namespace ConiferWebApp.Repository
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly ApplicationDbContext _context;

        public ZoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MyZone>> GetMyZones()
        {
            //string storedProc = $"exec GetClientSP " + $"@Email='{email.Email}'";
            List<MyZone> myZone = new List<MyZone>();

            try
            {

                var resultGood = await FileOpenZones();// _context.MyClientSp.FromSqlRaw(storedProc).ToListAsync();
                return resultGood;
            }
            catch (Exception)
            {
                return myZone;
                //throw;
            }
        }

        private async Task<List<MyZone>> FileOpenZones()
        {
            var json = File.ReadAllText("Components/Pages/cities_and_zones.json");
            List<MyZone> zones = JsonConvert.DeserializeObject<List<MyZone>>(json);



            return zones;
        }

    }
}
