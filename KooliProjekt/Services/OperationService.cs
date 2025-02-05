using KooliProjekt.Data;
using KooliProjekt.Search;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class OperationService : IOperationService
    {
        private readonly ApplicationDbContext _context;

        public OperationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Operation>> AllOperations(OperationsSearch search = null)
        {
            var query = _context.Operations
                .AsQueryable();

            if (search != null) 
            {
                if(!string.IsNullOrWhiteSpace(search.Keyword))
                {
                    search.Keyword = search.Keyword.Trim();
                    query = query.Where(o => 
                    o.Action.Contains(search.Keyword) ||
                    o.Worker.WorkerName.Contains(search.Keyword)
                    );
                }

                if (!string.IsNullOrEmpty(search.IsStatus))
                {
                    query = query.Where(o =>
                    o.Status.StatusType.Equals(search.IsStatus)
                    );
                }
            }

            return await query
                .Include(o => o.Car)
                .Include(o => o.Status)
                .Include(o => o.Worker)
                .ToListAsync();
        }

        public async Task<List<Car>> GetCars()
        {
            return await _context.Cars
                .ToListAsync();
        }

        public async Task<List<Status>> GetStatuses()
        {
            return await _context.Statuses
                .ToListAsync();
        }

        public async Task<List<Worker>> GetWorkers()
        {
            return await _context.Workers
                .ToListAsync();
        }

        public async Task<Operation> GetWithIncludes(int id)
        {
            return await _context.Operations
                .Include(o => o.Car)
                .Include(o => o.Status)
                .Include(o => o.Worker)
                .Where(operation => operation.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Save(Operation operation)
        {
            if (operation.Id == 0)
            {
                _context.Operations.Add(operation);
            }
            else
            {
                _context.Operations.Update(operation);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _context.Operations
                .Where(operation => operation.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
