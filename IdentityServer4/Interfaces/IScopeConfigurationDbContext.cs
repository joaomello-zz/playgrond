using IndentityServer.EntityFramework.Entities;
using Microsoft.Data.Entity;

namespace IndentityServer.EntityFramework
{
    public interface IScopeConfigurationDbContext
    {
        DbSet<Scope> Scopes { get; set; }
    }
}
