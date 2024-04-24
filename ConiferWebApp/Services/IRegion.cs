using ModelsProject;

namespace ConiferWebApp.Services
{
    public interface IRegion
    {
        Task<List<MyRegion>> GetRegions();
    }
}
