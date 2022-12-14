using XmasTreeService.Core.DataModels;

namespace XmasTreeService.Core.LedControl;

interface ILedControl
{
    void EnableLedProgram(LightingMode mode);
}