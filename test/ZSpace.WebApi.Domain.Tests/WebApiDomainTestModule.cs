using Volo.Abp.Modularity;

namespace ZSpace.WebApi;

[DependsOn(
    typeof(WebApiDomainModule),
    typeof(WebApiTestBaseModule)
)]
public class WebApiDomainTestModule : AbpModule
{

}
