using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZSpace.WebApi.Data;
using Volo.Abp.DependencyInjection;

namespace ZSpace.WebApi.EntityFrameworkCore;

public class EntityFrameworkCoreWebApiDbSchemaMigrator
    : IWebApiDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreWebApiDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the WebApiDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<WebApiDbContext>()
            .Database
            .MigrateAsync();
    }
}
