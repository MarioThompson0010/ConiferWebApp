using ModelsProject;

namespace ConiferWebApp.Repository
{
    public interface IStateRepository
    {
        Task<IEnumerable<MyState>> GetMyStates();
    }
}
