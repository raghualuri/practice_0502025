// practice_0502025.Application.Interfaces/IUnitOfWork.cs

using System;
using System.Threading.Tasks;
using practice_0502025.Entities; // Assuming your entities are here

namespace practice_0502025.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // We will remove SaveChangesAsync from IGenericRepository
        // and centralize it here.
        Task<int> CommitAsync(); // Returns the number of state entries written to the database.

        // OPTIONAL: If you have many specific repositories, you can expose them here
        // For example:
        // IProductRepository Products { get; }
        // ICategoryRepository Categories { get; }
        // For now, we'll keep it simple with just CommitAsync(),
        // as your GenericRepository is already accessible.
    }
}