using ProjectD.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ProjectD.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProjectDEntityFrameworkCoreModule),
    typeof(ProjectDApplicationContractsModule)
    )]
public class ProjectDDbMigratorModule : AbpModule
{
}
