using Volo.Abp.Modularity;

namespace ProjectD;

[DependsOn(
    typeof(ProjectDApplicationModule),
    typeof(ProjectDDomainTestModule)
)]
public class ProjectDApplicationTestModule : AbpModule
{

}
