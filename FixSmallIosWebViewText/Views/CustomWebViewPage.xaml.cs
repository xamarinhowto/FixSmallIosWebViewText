
using FixSmallIosWebViewText.ViewModels;
using Xamarin.Forms;

namespace FixSmallIosWebViewText.Views
{
    public partial class CustomWebViewPage : ContentPage
    {
        public CustomWebViewPage()
        {
            InitializeComponent();

            // Note: Creating and setting the WebView Source in this way is due to an issue with reloading content
            // in the WKWebView that exists at time of writing. Ideally you should just be able to bind to the one source.
            var vm = BindingContext as WebViewViewModel;
            var source = App.UseCustomHtmlLoad ? vm.WebViewSourceWithFix : vm.WebViewSourceWithoutFix;
            var webViewControl = new WebView { Source = source, BackgroundColor = Color.Lavender };

            if (WebViewGrid?.Children != null && WebViewGrid.Children.Count > 0)
            {
                WebViewGrid.Children.RemoveAt(0);
            }
            WebViewGrid.Children.Add(webViewControl);
        }

        void OnOffSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
            {
                // Just for demo purposes, not likely to be applicable in real world applications
                App.UseCustomHtmlLoad = e.Value;

                // Note: Creating and setting the WebView Source in this way is due to an issue with reloading content
                // in the WKWebView that exists at time of writing. Ideally you should just be able to bind to the one source.
                var vm = BindingContext as WebViewViewModel;
                var source = App.UseCustomHtmlLoad ? vm.WebViewSourceWithFix : vm.WebViewSourceWithoutFix as HtmlWebViewSource;
                var webViewControl = new WebView { Source = source, BackgroundColor = Color.Lavender };

                if (WebViewGrid?.Children != null && WebViewGrid.Children.Count > 0)
                {
                    WebViewGrid.Children.RemoveAt(0);
                }

                WebViewGrid.Children.Add(webViewControl);
            });
        }
    }
}
