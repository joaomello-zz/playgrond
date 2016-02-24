using IndentityServer.EntityFramework.Entities;
using Microsoft.Data.Entity;

namespace IndentityServer.EntityFramework
{
    public interface IClientConfigurationDbContext
    {
        DbSet<Client> Clients { get; set; }
    }
}
