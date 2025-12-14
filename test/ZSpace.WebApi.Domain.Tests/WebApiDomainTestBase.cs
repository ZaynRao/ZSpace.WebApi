using Volo.Abp.Modularity;

namespace ZSpace.WebApi;

/* Inherit from this class for your domain layer tests. */
public abstract class WebApiDomainTestBase<TStartupModule> : WebApiTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
