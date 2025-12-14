using Microsoft.Extensions.Localization;
using ZSpace.WebApi.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ZSpace.WebApi;

[Dependency(ReplaceServices = true)]
public class WebApiBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<WebApiResource> _localizer;

    public WebApiBrandingProvider(IStringLocalizer<WebApiResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
