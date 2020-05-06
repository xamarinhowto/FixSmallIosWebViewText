using Xamarin.Forms;

namespace FixSmallIosWebViewText
{
    public partial class App : Application
    {
        // NOTE: Just for demo project obviously ...
        public static bool UseCustomHtmlLoad;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
