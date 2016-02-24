using IdentityServer4.Core.Models;
using IdentityServer4.Core.Services;
using Microsoft.Data.Entity;
using System;
using System.Threading.Tasks;

namespace IndentityServer.EntityFramework
{
    public class ClientStore<T> : IClientStore where T : IClientConfigurationDbContext
    {
        private readonly T _context;
        public ClientStore(T context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _context = context;
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var client = await _context.Clients
                .Include(x => x.ClientSecrets)
                .Include(x => x.RedirectUris)
                .Include(x => x.PostLogoutRedirectUris)
                .Include(x => x.AllowedScopes)
                .Include(x => x.IdentityProviderRestrictions)
                .Include(x => x.Claims)
                .Include(x => x.AllowedCustomGrantTypes)
                .Include(x => x.AllowedCorsOrigins)
                .SingleOrDefaultAsync(x => x.ClientId == clientId);

            IdentityServer4.Core.Models.Client model = client.ToModel();
            return model;
        }
    }
}
