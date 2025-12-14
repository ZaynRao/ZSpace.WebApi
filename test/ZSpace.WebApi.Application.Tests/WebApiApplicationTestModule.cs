using Volo.Abp.Modularity;

namespace ZSpace.WebApi;

[DependsOn(
    typeof(WebApiApplicationModule),
    typeof(WebApiDomainTestModule)
)]
public class WebApiApplicationTestModule : AbpModule
{

}
