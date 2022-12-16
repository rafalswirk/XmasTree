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

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var client = new ApiClient(entryServerUrl.Text);
            var ligthModes = await client.GetLigthingModes();
            await Navigation.PushAsync(new XmasTreeLightingModePage(ligthModes, client));
        }
    }
}