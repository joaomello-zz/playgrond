using IdentityServer4.Core.Models;
using IdentityServer4.Core.Services;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndentityServer.EntityFramework
{
    public class ScopeStore<T> : IScopeStore where T : IScopeConfigurationDbContext
    {
        private readonly T _context;

        public ScopeStore(T context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Scope>> FindScopesAsync(IEnumerable<string> scopeNames)
        {
            var scopes = from s in _context.Scopes.Include(x => x.ScopeClaims).Include(x => x.ScopeSecrets)
                         select s;

            if (scopeNames != null && scopeNames.Any())
            {
                scopes = from s in scopes
                         where scopeNames.Contains(s.Name)
                         select s;
            }

            var list = await scopes.ToListAsync();
            return list.Select(x => x.ToModel());
        }

        public async Task<IEnumerable<Scope>> GetScopesAsync(bool publicOnly = true)
        {
            var scopes = from s in _context.Scopes.Include(x => x.ScopeClaims).Include(x => x.ScopeSecrets)
                         select s;

            if (publicOnly)
            {
                scopes = from s in scopes
                         where s.ShowInDiscoveryDocument == true
                         select s;
            }

            var list = await scopes.ToListAsync();
            return list.Select(x => x.ToModel());
        }
    }
}