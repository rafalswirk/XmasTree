using XmasTreeApp.Data.Settings;

namespace XmasTreeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(new MauiPreferences()))
            {
                BarBackgroundColor = Colors.LightSkyBlue
            };
            
        }
    }
}