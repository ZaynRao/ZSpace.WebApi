using ZSpace.WebApi.Localization;
using Volo.Abp.Application.Services;

namespace ZSpace.WebApi;

/* Inherit your application services from this class.
 */
public abstract class WebApiAppService : ApplicationService
{
    protected WebApiAppService()
    {
        LocalizationResource = typeof(WebApiResource);
    }
}
