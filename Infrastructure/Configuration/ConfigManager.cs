using System;
using System.Collections.Generic;
using System.Text;

namespace MsEmployee.Infrastrucuture.Configuration
{
    public class ConfigManager : IConfigManager
    {
        private readonly Dictionary<string, string> values;

        public ConfigManager()
        {
            this.values = new Dictionary<string, string>();
        }

        public void Set(string key, string value)
        {
            this.values.TryAdd(key, value);
        }

        public string Get(string key)
        {
            string value = null;
            this.values.TryGetValue(key, out value);
            return value;
        }
    
    }
}
