using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface ICarService
    {
        Task<List<Car>> AllCars();
        Task<Car> Get(int id);
        Task Save(Car car);
        Task Delete(int id);

    }
}
