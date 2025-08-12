using System.Threading.Tasks;

namespace ProjectD.Data;

public interface IProjectDDbSchemaMigrator
{
    Task MigrateAsync();
}
