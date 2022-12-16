using XmasTreeApp.ServiceConnection.Dto;
using XmasTreeApp.ServiceConnection.RestAPI;

namespace XmasTreeApp.Pages;

public partial class XmasTreeLightingModePage : ContentPage
{
    private readonly IEnumerable<LightModeDto> _ligthModes;
    private ApiClient _client;

    public XmasTreeLightingModePage()
    {
        InitializeComponent();
    }

    public XmasTreeLightingModePage(IEnumerable<ServiceConnection.Dto.LightModeDto> ligthModes, ApiClient client)
        :this()
	{
		
        _ligthModes = ligthModes;
        _client = client;
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        foreach(var mode in _ligthModes) 
        {
            var button = new Button 
            {
                Text = mode.Id,
                
            };
            button.Clicked += Button_Clicked;
            mainPanel.Add(button);
        }

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        
    }
}