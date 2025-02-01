using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly ApplicationDbContext _context;

        public WorkerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Worker>> AllWorkers()
        {
            return await _context.Workers
                .Include(worker => worker.Operations)
                .ToListAsync();
        }

        public async Task<Worker> Get(int id)
        {
            return await _context.Workers
                .Include(worker => worker.Operations)
                .Where(worker => worker.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Save(Worker worker)
        {
            if (worker.Id == 0)
            {
                _context.Workers.Add(worker);
            }
            else
            {
                _context.Workers.Update(worker);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _context.Workers
                .Where(worker => worker.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
