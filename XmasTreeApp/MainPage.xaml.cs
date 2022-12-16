using XmasTreeApp.ServiceConnection.RestAPI;

namespace XmasTreeApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var client = new ApiClient(entryServerUrl.Text);
            _ = await client.GetData();
        }
    }
}