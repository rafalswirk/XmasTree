using XmasTreeApp.Data.Settings;
using XmasTreeApp.Pages;
using XmasTreeApp.ServiceConnection.RestAPI;

namespace XmasTreeApp
{
    public partial class MainPage : ContentPage
    {
        private readonly IAppPreferences _appPreferences;

        public MainPage(IAppPreferences appPreferences)
        {
            InitializeComponent();
            _appPreferences = appPreferences;
        }

        private async void OnConnectClicked(object sender, EventArgs e)
        {
            await Task.Run(async () => 
            {
                try
                {
                    var client = new ApiClient(entryServerUrl.Text);
                    var ligthModes = await client.GetLigthingModes();
                    await Dispatcher.DispatchAsync(async () => 
                    {
                        if(ligthModes is null) 
                        {
                            lblConnectionIssue.Text = "Cannot connect to app server :(";
                            return;
                        }
                        _appPreferences.SetValue(SettingsKeys.ServiceUrl, entryServerUrl.Text);
                        lblConnectionIssue.Text = string.Empty;
                        await Navigation.PushAsync(new XmasTreeLightingModePage(ligthModes, client));
                    });
                }
                catch (Exception)
                {
                }
            });
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            var url = _appPreferences.GetValue(SettingsKeys.ServiceUrl);
            if (url == string.Empty) 
            {
                return;
            }
            entryServerUrl.Text = url;
        }
    }
}