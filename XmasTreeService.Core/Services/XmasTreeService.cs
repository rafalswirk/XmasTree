using XmasTreeService.Core.DataModels;
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

    IReadOnlyCollection<LightingModeDto> IXmasTreeService.GetAllLightingModes()
        => _control.GetLightingModes().Select(Map<LightingModeDto>).ToList();

    void IXmasTreeService.SetLightingMode(LightingModeDto mode)
        => _control.EnableLightingMode(Map<LightingMode>(mode));

    private static T Map<T>(LightingMode mode) where T : LightingModeDto, new()
        => new T { Id = mode.Id, Name = string.Empty };

    private static T Map<T>(LightingModeDto dto) where T : LightingMode, new()
        => new T { Id = dto.Id, Name = string.Empty };
}