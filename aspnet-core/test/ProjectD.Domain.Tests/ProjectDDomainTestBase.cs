using Volo.Abp.Modularity;

namespace ProjectD;

/* Inherit from this class for your domain layer tests. */
public abstract class ProjectDDomainTestBase<TStartupModule> : ProjectDTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
