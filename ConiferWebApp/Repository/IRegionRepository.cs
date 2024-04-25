using ModelsProject;

namespace ConiferWebApp.Repository
{
    public interface IRegionRepository
    {
        Task<IEnumerable<MyRegion>> GetMyRegions();
    }
}
