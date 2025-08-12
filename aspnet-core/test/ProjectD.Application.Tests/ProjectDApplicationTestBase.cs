using Volo.Abp.Modularity;

namespace ProjectD;

public abstract class ProjectDApplicationTestBase<TStartupModule> : ProjectDTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
