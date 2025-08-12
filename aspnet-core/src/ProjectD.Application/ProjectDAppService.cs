using System;
using System.Collections.Generic;
using System.Text;
using ProjectD.Localization;
using Volo.Abp.Application.Services;

namespace ProjectD;

/* Inherit your application services from this class.
 */
public abstract class ProjectDAppService : ApplicationService
{
    protected ProjectDAppService()
    {
        LocalizationResource = typeof(ProjectDResource);
    }
}
