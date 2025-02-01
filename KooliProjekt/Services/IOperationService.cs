using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IOperationService
    {
        Task<List<Operation>> AllOperations();
        Task<List<Car>> GetCars();
        Task<List<Status>> GetStatuses();
        Task<List<Worker>> GetWorkers();
        Task<Operation> GetWithIncludes(int id);
        Task Save(Operation operation);
        Task Delete(int id);
    }
}
