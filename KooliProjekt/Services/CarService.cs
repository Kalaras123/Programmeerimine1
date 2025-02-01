using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task <List<Car>> AllCars()
        {
            return await _context.Cars
                .Include(car => car.Operations)
                .ToListAsync();
        }
        
        public async Task<Car> Get(int id)
        {
            return await _context.Cars
                .Include(car => car.Operations)
                .Where(car => car.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Save(Car car)
        {
            if (car.Id == 0)
            {
                _context.Cars.Add(car);
            }
            else
            {
                _context.Cars.Update(car);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _context.Cars
                .Where(car => car.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
