using System.Threading.Tasks;

namespace ZSpace.WebApi.Data;

public interface IWebApiDbSchemaMigrator
{
    Task MigrateAsync();
}
