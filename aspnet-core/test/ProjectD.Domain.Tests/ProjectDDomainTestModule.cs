using Volo.Abp.Modularity;

namespace ProjectD;

[DependsOn(
    typeof(ProjectDDomainModule),
    typeof(ProjectDTestBaseModule)
)]
public class ProjectDDomainTestModule : AbpModule
{

}
