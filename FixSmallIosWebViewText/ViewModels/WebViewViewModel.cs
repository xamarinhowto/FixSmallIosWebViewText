using System;
using System.Reflection;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace FixSmallIosWebViewText.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WebViewViewModel : BaseViewModel
    {
        public WebViewViewModel()
        {
            Title = "iOS Web View Small Text";

            WebViewSourceWithoutFix = new HtmlWebViewSource
            {
                Html = @"This is some <b>example</b> HTML <i>text</i> without any <u>fancy</u>
formatting other than basic things non-technical content providers sometimes use.
<ul>
<li>A list item</li>
<li>Another list item</li>
<li>Yet another list item</li>
</ul>
</br>
iOS doesn't like this by default with Xamarin.Forms so we need to tweak it a little."
            };

            WebViewSourceWithFix = new HtmlWebViewSource
            {
                Html = @"<span style='color: #0993DB;'><b>With custom scaling meta HTML added</b></span>    </br></br>
This is some <b>example</b> HTML <i>text</i> without any <u>fancy</u>
formatting other than basic things non-technical content providers sometimes use.
<ul>
<li>A list item</li>
<li>Another list item</li>
<li>Yet another list item</li>
</ul>
</br>
iOS doesn't like this by default with Xamarin.Forms so we need to tweak it a little."
            };
        }

        public WebViewSource WebViewSourceWithoutFix { get; set; }

        public WebViewSource WebViewSourceWithFix { get; set; }

    }
}