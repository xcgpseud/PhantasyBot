using Newtonsoft.Json;
using PhantasyBot.DataAccess.Config.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhantasyBot.DataAccess.Config
{
    public class Config
    {
        private const string ConfigFileName = "config.json";
        private ConfigModel _config;

        public ConfigModel Get()
        {
            RefreshConfig();
            return _config;
        }

        private void InitConfig()
        {
            using (var file = File.OpenText(ConfigFileName))
            using (var reader = new JsonTextReader(file))
            {
                var ser = new JsonSerializer();
                _config = ser.Deserialize<ConfigModel>(reader);
            }
        }

        private void RefreshConfig()
        {
            if(_config == null)
            {
                InitConfig();
            }
        }

        #region Helpers

        public bool IsSudoer(ulong userId)
        {
            RefreshConfig();
            return _config.Bot.Sudoers.Contains(userId);
        }

        #endregion
    }
}
