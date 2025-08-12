using ProjectD.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ProjectD.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ProjectDController : AbpControllerBase
{
    protected ProjectDController()
    {
        LocalizationResource = typeof(ProjectDResource);
    }
}
