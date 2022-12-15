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
        private const string ScriptsPath = @"scripts//";
        private readonly PythonScriptManager _scriptManager = new();

        public void EnableLightingMode(LightingMode mode)
        {
            _scriptManager.RunPythonScript($"ScriptsPath{mode.Id}");
        }

        public IReadOnlyCollection<LightingMode> GetLightingModes()
        {
            var files = Directory.GetFiles(ScriptsPath);
            return files.Select(f => new LightingMode { Id = f }).ToList();
        }
    }
}
