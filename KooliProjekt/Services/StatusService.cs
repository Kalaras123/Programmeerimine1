using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class StatusService : IStatusService
    {
        private readonly ApplicationDbContext _context;

        public StatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Status>> AllStatuses()
        {
            return await _context.Statuses
                .ToListAsync();
        }

        public async Task<Status> Get(int id)
        {
            return await _context.Statuses
                .FirstOrDefaultAsync();
        }

        public async Task Save(Status status)
        {
            if (status.Id == 0)
            {
                _context.Statuses.Add(status);
            }
            else
            {
                _context.Statuses.Update(status);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _context.Statuses
                .Where(status => status.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
