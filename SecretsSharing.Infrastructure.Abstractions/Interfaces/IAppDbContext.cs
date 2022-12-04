using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecretsSharing.Domain.StorageDataEntities;
using SecretsSharing.Domain.Users;

namespace SecretsSharing.Infrastructure.Abstractions.Interfaces
{
    /// <summary>
    /// Application database context.
    /// </summary>
    public interface IAppDbContext
    {
        /// <summary>
        /// Users.
        /// </summary>
        DbSet<User> Users { get; }
        
        /// <summary>
        /// Messages.
        /// </summary>
        public DbSet<Message> Messages { get; }
        
        /// <summary>
        /// Files.
        /// </summary>
        public DbSet<File> Files { get; }

        /// <summary>
        /// Save changes.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}