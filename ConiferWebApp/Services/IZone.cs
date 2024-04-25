using ModelsProject;

namespace ConiferWebApp.Services
{
    public interface IZone
    {
        Task<IEnumerable<MyZone>> GetZones();
        Task<List<MyZone>> GetZonesAlreadyInjected();
    }
}
