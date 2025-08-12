using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ProjectD.Data;

/* This is used if database provider does't define
 * IProjectDDbSchemaMigrator implementation.
 */
public class NullProjectDDbSchemaMigrator : IProjectDDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
