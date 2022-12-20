using XmasTreeApp.Pages;
using XmasTreeApp.ServiceConnection.RestAPI;

namespace XmasTreeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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
                        lblConnectionIssue.Text = string.Empty;
                        await Navigation.PushAsync(new XmasTreeLightingModePage(ligthModes, client));
                    });
                }
                catch (Exception)
                {
                }
            });
        }
    }
}