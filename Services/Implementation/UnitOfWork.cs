// practice_0502025.Infrastructure.Data/UnitOfWork.cs (Recommended location)
// Or practice_0502025.Services.Implementations/UnitOfWork.cs

using practice_0502025.Application; // For ApplicationDbContext
using practice_0502025.Application.Interfaces;
using System.Threading.Tasks;

namespace practice_0502025.Infrastructure.Data // Create this new folder if it doesn't exist
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
         }

        public void Dispose()
        {
            _context.Dispose();
            // Suppress finalization to prevent the garbage collector from calling Dispose twice.
            GC.SuppressFinalize(this);
        }
    }
}