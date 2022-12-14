using XmasTreeService.Core.Dto;

interface IXmasTreeService
{
    IReadOnlyList<LightingModeDto> GetAllLightingModes();
    void SetLightingMode(LightingModeDto mode);
}