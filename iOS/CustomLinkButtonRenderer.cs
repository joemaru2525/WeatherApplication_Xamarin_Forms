using UIKit;
using Foundation;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using AppName.Controls;
[assembly: ExportRenderer(typeof(BaseLinkButton), typeof(CustomLinkButtonRenderer))]
namespace AppName.iOS.Renderer
{
    public class CustomLinkButtonRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Element == null)
            {
                return;
            }

            var view = (BaseLinkButton)Element;
            UpdateUi(view, Control);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Element == null)
            {
                return;
            }

            var view = (BaseLinkButton)Element;

            if (e.PropertyName == BaseLinkButton.IsUnderlineProperty.PropertyName)
            {
                UpdateUi(view, Control);
            }
        }

        private static void UpdateUi(BaseLinkButton view, UILabel control)
        {
            var labelTitle = new NSMutableAttributedString(control.Text);

            if (view.IsUnderline)
            {
                labelTitle.AddAttribute(UIStringAttributeKey.UnderlineStyle,
                                        NSNumber.FromInt32((int)NSUnderlineStyle.Single),
                                        new NSRange(0, labelTitle.Length));
            }

            control.AttributedText = labelTitle;
        }
    }
}