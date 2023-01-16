using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmasTreeApp.Data.Settings
{
    public class MauiPreferences : IAppPreferences
    {
        public string GetValue(string key) 
        {
            return Preferences.Get(key, string.Empty);
        }

        public void SetValue(string key, string value)
        {
            Preferences.Set(key, value);
        }
    }
}
