using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Services
{
    public interface IOperationService
    {
        Task<List<Operation>> AllOperations(OperationsSearch search = null);
        Task<List<Car>> GetCars();
        Task<List<Status>> GetStatuses();
        Task<List<Worker>> GetWorkers();
        Task<Operation> GetWithIncludes(int id);
        Task Save(Operation operation);
        Task Delete(int id);
    }
}
