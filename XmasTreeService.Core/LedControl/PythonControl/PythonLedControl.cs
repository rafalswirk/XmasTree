using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmasTreeService.Core.DataModels;

namespace XmasTreeService.Core.LedControl.PythonControl
{
    internal class PythonLedControl : ILedControl
    {
        private readonly string ScriptsPath = $"{AppDomain.CurrentDomain.BaseDirectory}//scripts//";
        private readonly PythonScriptManager _scriptManager = new();
        private readonly string[] IgnoredScripts = new string[] 
        {
            "test-script",
            "tree"
        };

        public void EnableLightingMode(LightingMode mode)
        {
            _scriptManager.RunPythonScript(Path.Combine(ScriptsPath, mode.Id + ".py"));
        }

        public IReadOnlyCollection<LightingMode> GetLightingModes()
        {
            var files = Directory.GetFiles(ScriptsPath)
                .Select(f => Path.GetFileNameWithoutExtension(f))
                .Where(f => !IgnoredScripts.Contains(f));
            
            return files.Select(f => new LightingMode { Id = f }).ToList();
        }
    }
}
