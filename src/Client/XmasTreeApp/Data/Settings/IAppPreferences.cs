﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmasTreeApp.Data.Settings
{
    public interface IAppPreferences
    {
        string GetValue(string key);
        void SetValue(string key, string value);
    }
}
