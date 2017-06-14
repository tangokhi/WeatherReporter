using System.Configuration;

namespace BusinessLayer.Libraries
{
    public class ConfiguraitonMap : IConfigurationMap
    {
        public string RetrieveValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
