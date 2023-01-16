using XmasTreeService.Core.Dto;

interface IXmasTreeService
{
    IReadOnlyCollection<LightingModeDto> GetAllLightingModes();
    void SetLightingMode(LightingModeDto mode);
}