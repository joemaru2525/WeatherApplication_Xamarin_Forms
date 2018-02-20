using Android.Widget;
using Android.Graphics;
using System.ComponentModel;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using AppName.Controls;
[assembly: ExportRenderer(typeof(BaseLinkButton), typeof(AppName.Droid.Renderer.CustomLinkButtonRenderer))]
namespace AppName.Droid.Renderer
{
    public class CustomLinkButtonRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (BaseLinkButton)Element;
            var control = Control;

            UpdateUi(view, control);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (BaseLinkButton)Element;

            if (e.PropertyName == BaseLinkButton.IsUnderlineProperty.PropertyName)
            {
                Control.PaintFlags = view.IsUnderline ? Control.PaintFlags | PaintFlags.UnderlineText : Control.PaintFlags &= ~PaintFlags.UnderlineText;
            }
        }

        static void UpdateUi(BaseLinkButton view, TextView control)
        {
            if (view.FontSize > 0)
            {
                control.TextSize = (float)view.FontSize;
            }

            if (view.IsUnderline)
            {
                control.PaintFlags = control.PaintFlags | PaintFlags.UnderlineText;
            }
        }
    }
}