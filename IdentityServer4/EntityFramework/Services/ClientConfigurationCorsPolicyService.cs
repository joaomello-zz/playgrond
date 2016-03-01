using IdentityServer4.Core.Services;
using Microsoft.Data.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.EntityFramework
{
    public class ClientConfigurationCorsPolicyService<T> : ICorsPolicyService where T : IClientConfigurationDbContext
    {
        private readonly T _context;

        public ClientConfigurationCorsPolicyService(T ctx)
        {
            _context = ctx;
        }

        public async Task<bool> IsOriginAllowedAsync(string origin)
        {
            var query =
                from client in _context.Clients
                from allowed in client.AllowedCorsOrigins
                select allowed.Origin;
            var urls = await query.ToArrayAsync();

            var origins = urls.Select(x => x.GetOrigin()).Where(x => x != null).Distinct();

            var result = origins.Contains(origin, StringComparer.OrdinalIgnoreCase);

            return result;
        }
    }
}
