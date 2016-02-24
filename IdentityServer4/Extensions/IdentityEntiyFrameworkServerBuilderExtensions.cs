using IdentityServer4.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IndentityServer.EntityFramework
{
    public static class IdentityEntiyFrameworkServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddInIdentityEntity<TClientConfiguration, TScopeConfiguration>(this IIdentityServerBuilder builder)
            where TClientConfiguration : IClientConfigurationDbContext
            where TScopeConfiguration : IScopeConfigurationDbContext
        {
            builder.Services.AddTransient<IClientStore, ClientStore<TClientConfiguration>>();
            builder.Services.AddTransient<ICorsPolicyService, ClientConfigurationCorsPolicyService<TClientConfiguration>>();

            builder.Services.AddTransient<IScopeStore, ScopeStore<TScopeConfiguration>>();

            return builder;
        }
    }
}
