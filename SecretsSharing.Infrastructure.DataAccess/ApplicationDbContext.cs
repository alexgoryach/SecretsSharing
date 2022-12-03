using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecretsSharing.Domain.StorageDataEntities;
using SecretsSharing.Domain.Users;
using SecretsSharing.Infrastructure.Abstractions.Interfaces;

namespace SecretsSharing.Infrastructure.DataAccess
{
    /// <summary>
    /// Application database context.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<User>, IAppDbContext
    {
        /// <inheritdoc cref=""/>
        public DbSet<Message> Messages { get; private set; }
    
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        /// <inheritdoc/>
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await base.SaveChangesAsync(cancellationToken);
        }
    }
}