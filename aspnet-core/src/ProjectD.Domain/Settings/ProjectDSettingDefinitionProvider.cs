using Volo.Abp.Settings;

namespace ProjectD.Settings;

public class ProjectDSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ProjectDSettings.MySetting1));
    }
}
