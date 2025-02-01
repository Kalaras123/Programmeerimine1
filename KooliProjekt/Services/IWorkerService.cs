using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IWorkerService
    {
        Task<List<Worker>> AllWorkers();
        Task<Worker> Get(int id);
        Task Save(Worker worker);
        Task Delete(int id);
    }
}
