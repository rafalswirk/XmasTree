using Microsoft.Maui.Graphics;
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
                MaximumWidthRequest = 200,
            };
            button.BorderWidth = 2;
            button.BorderColor = Colors.DarkGray;
            button.Clicked += Button_Clicked;
            mainPanel.Add(button);
        }

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Task.Run(async () =>
        {
            try
            {
                var button = sender as Button;
                await _client.SetLigthingMode(_ligthModes.Single(x => x.Id == button.Text));
            }
            catch (Exception)
            {
            }
        });
    }
}