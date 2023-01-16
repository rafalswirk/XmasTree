using XmasTreeService.Core.DataModels;

namespace XmasTreeService.Core.LedControl;

interface ILedControl
{
    void EnableLightingMode(LightingMode mode);

    IReadOnlyCollection<LightingMode> GetLightingModes();
}