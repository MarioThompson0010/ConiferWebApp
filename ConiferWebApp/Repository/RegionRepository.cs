using ConiferWebApp.Data;
using ModelsProject;
using Newtonsoft.Json;

namespace ConiferWebApp.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly ApplicationDbContext _context;

        public RegionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MyRegion>> GetMyRegions()
        {
            //string storedProc = $"exec GetClientSP " + $"@Email='{email.Email}'";
            List<MyRegion> myZone = new List<MyRegion>();

            try
            {

                var resultGood = await FileOpenRegions();// _context.MyClientSp.FromSqlRaw(storedProc).ToListAsync();
                return resultGood;
            }
            catch (Exception)
            {
                return myZone;
                //throw;
            }
        }

        private async Task<List<MyRegion>> FileOpenRegions()
        {
            var json = File.ReadAllText("Components/Pages/regions.json");
            List<MyRegion> regions = JsonConvert.DeserializeObject<List<MyRegion>>(json);



            return regions;
        }

    }
}
