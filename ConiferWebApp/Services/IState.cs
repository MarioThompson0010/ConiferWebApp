using ModelsProject;

namespace ConiferWebApp.Services
{
    public interface IState
    {
        Task<List<MyState>> GetStates();
    }
}
