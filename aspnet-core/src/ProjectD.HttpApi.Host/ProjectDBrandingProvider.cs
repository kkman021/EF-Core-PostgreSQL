using Microsoft.Extensions.Localization;
using ProjectD.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ProjectD;

[Dependency(ReplaceServices = true)]
public class ProjectDBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ProjectDResource> _localizer;

    public ProjectDBrandingProvider(IStringLocalizer<ProjectDResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
