# Introduction 

a working example of setting HTML loaded into a WebView on iOS to a 'normal' font size instead of the default extremely small text in Xamarin.Forms.
# Outcome

Before

![Fix small iOS WKWebView text in Xamarin.Forms](iossmallwebviewtext.png "Fix small iOS WKWebView text in Xamarin.Forms")

After

![Fix small iOS WKWebView text in Xamarin.Forms](iossmallwebviewtextwithfix.png "Fix small iOS WKWebView text in Xamarin.Forms")


# Usage 
```csharp
using System;
using FixSmallIosWebViewText.iOS.Renderers;
using Foundation;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WebView), typeof(CustomWebViewRenderer))]
namespace FixSmallIosWebViewText.iOS.Renderers
{
    public class CustomWebViewRenderer : WkWebViewRenderer
    {
        public override WKNavigation LoadHtmlString(NSString htmlString, NSUrl baseUrl)
        {
            try
            {
                // Add additional HTML to ensure fonts scale correctly and don't appear extremely small and almost unreadable
                var iOSHtmlWithScaling = htmlString.ToString().Insert(0, "<meta name='viewport' content='width=device-width,initial-scale=1,maximum-scale=1' />");
                return base.LoadHtmlString((NSString)iOSHtmlWithScaling, baseUrl);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return base.LoadHtmlString(htmlString, baseUrl);
            }
        }
    }
}
```