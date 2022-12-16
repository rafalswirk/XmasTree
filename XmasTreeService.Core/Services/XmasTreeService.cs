using System.Runtime.CompilerServices;
using XmasTreeService.Core.DataModels;
using XmasTreeService.Core.Dto;
using XmasTreeService.Core.LedControl;

[assembly:InternalsVisibleTo("XmasTreeServiceWebApi")]

namespace XmasTreeService.Services;

internal class XmasTreeService : IXmasTreeService
{
    private readonly ILedControl _control;

    public XmasTreeService(ILedControl control)
    {
        _control = control;
    }

    public IReadOnlyCollection<LightingModeDto> GetAllLightingModes()
    {
        return _control.GetLightingModes().Select(Map<LightingModeDto>).ToList();

    }

    public void SetLightingMode(LightingModeDto mode)
    {
        _control.EnableLightingMode(Map<LightingMode>(mode));
    }

    private static T Map<T>(LightingMode mode) where T : LightingModeDto, new()
        => new T { Id = mode.Id};

    private static T Map<T>(LightingModeDto dto) where T : LightingMode, new()
        => new T { Id = dto.Id };
}