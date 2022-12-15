using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmasTreeService.Core.LedControl.PythonControl
{
    internal class PythonScriptManager
    {
        public static Process _scriptExecutionProcess;
        private static object SyncObject = new();
        public void RunPythonScript(string scriptPath)
        {
            lock(SyncObject) 
            {
                var start = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = scriptPath, //Path.Combine("scripts", "script.py");
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false
                };

                Debug.WriteLine($"Is python process null: {_scriptExecutionProcess is null}");
                if (_scriptExecutionProcess is not null)
                {
                    Debug.WriteLine($"Process with ID: {_scriptExecutionProcess.Id} is going to be killed");

                    _scriptExecutionProcess.Kill(true);
                }

                _scriptExecutionProcess = Process.Start(start);
                Debug.WriteLine($"New process rised with ID: {_scriptExecutionProcess?.Id}");
            }
        }

        public void KillCurrentScript()
        {
            lock (SyncObject)
            {
                if (_scriptExecutionProcess is null)
                {
                    return;
                }
                _scriptExecutionProcess.WaitForExit();
                _scriptExecutionProcess.Dispose();
            }
        }
    }
}
