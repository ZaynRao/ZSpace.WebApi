using Volo.Abp.Settings;

namespace ZSpace.WebApi.Settings;

public class WebApiSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(WebApiSettings.MySetting1));
    }
}
