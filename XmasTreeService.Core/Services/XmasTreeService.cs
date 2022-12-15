using XmasTreeService.Core.Dto;
using XmasTreeService.Core.LedControl;

namespace XmasTreeService.Services;

internal class XmasTreeService : IXmasTreeService
{
    private readonly ILedControl _control;

    public XmasTreeService(ILedControl control)
    {
        _control = control;
    }

    IReadOnlyList<LightingModeDto> IXmasTreeService.GetAllLightingModes()
    {
        throw new NotImplementedException();
    }

    void IXmasTreeService.SetLightingMode(LightingModeDto mode)
    {
        throw new NotImplementedException();
    }
}