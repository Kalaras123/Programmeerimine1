using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IStatusService
    {
        Task<List<Status>> AllStatuses();
        Task<Status> Get(int id);
        Task Save(Status status);
        Task Delete(int id);
    }
}
