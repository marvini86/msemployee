
namespace MsEmployee.Infrastrucuture.Configuration
{
    public interface IConfigManager
    {
        void Set(string key, string value);
        string Get(string key);
    }
}
