using ZSpace.WebApi.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace ZSpace.WebApi.Permissions;

public class WebApiPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(WebApiPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(WebApiPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(WebApiPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(WebApiPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(WebApiPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(WebApiPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<WebApiResource>(name);
    }
}
