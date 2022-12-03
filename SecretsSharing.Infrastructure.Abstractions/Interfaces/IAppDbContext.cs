using System.Threading;
using System.Threading.Tasks;

namespace SecretsSharing.Infrastructure.Abstractions.Interfaces
{
    /// <summary>
    /// Application database context.
    /// </summary>
    public interface IAppDbContext
    {
        /// <summary>
        /// Save changes.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}