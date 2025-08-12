using ProjectD.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ProjectD.Permissions;

public class ProjectDPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProjectDPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ProjectDPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProjectDResource>(name);
    }
}
