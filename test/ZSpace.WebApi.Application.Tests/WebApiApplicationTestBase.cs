using Volo.Abp.Modularity;

namespace ZSpace.WebApi;

public abstract class WebApiApplicationTestBase<TStartupModule> : WebApiTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
