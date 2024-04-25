using ModelsProject;

namespace ConiferWebApp.Repository
{
    public interface IZoneRepository
    {
        Task<IEnumerable<MyZone>> GetMyZones();
    }
}
