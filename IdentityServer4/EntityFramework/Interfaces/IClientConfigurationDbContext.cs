using IdentityServer.EntityFramework.Entities;
using Microsoft.Data.Entity;

namespace IdentityServer.EntityFramework
{
    public interface IClientConfigurationDbContext
    {
        DbSet<Client> Clients { get; set; }
    }
}
