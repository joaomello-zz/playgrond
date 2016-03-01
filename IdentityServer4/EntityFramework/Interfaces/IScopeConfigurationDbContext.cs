using IdentityServer.EntityFramework.Entities;
using Microsoft.Data.Entity;

namespace IdentityServer.EntityFramework
{
    public interface IScopeConfigurationDbContext
    {
        DbSet<Scope> Scopes { get; set; }
    }
}
