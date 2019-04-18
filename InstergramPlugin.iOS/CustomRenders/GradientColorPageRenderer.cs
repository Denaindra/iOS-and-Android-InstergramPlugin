using System;
using CoreAnimation;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinKit.CustomRenders;
using XamarinKit.iOS.CustomRenders;
using XamarinKit.Views;

[assembly: ExportRenderer(typeof(GradientColorPage), typeof(GradientColorPageRenderer))]
namespace XamarinKit.iOS.CustomRenders
{
    public class GradientColorPageRenderer: PageRenderer
    {
        public GradientColorPageRenderer()
        {
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null) return;
            if (e.NewElement is GradientColorPage page)
            {
                var gradientLayer = new CAGradientLayer
                {
                    Frame = View.Bounds,
                    Colors = new CGColor[] { page.StartColor.ToCGColor(), page.EndColor.ToCGColor() }
                };
                View.Layer.InsertSublayer(gradientLayer, 0);
            }
        }


        //public override void Draw(CGRect rect)
        //{
        //    base.Draw(rect);
        //    GradientColorStack stack = (GradientColorStack)this.Element;
        //    CGColor startColor = stack.StartColor.ToCGColor();

        //    CGColor endColor = stack.EndColor.ToCGColor();

        //    #region for Vertical Gradient

        //    var gradientLayer = new CAGradientLayer();

        //    #endregion

        //    #region for Horizontal Gradient

        //    //var gradientLayer = new CAGradientLayer()
        //    //{
        //    //  StartPoint = new CGPoint(0, 0.5),
        //    //  EndPoint = new CGPoint(1, 0.5)
        //    //};

        //    #endregion



        //    gradientLayer.Frame = rect;
        //    gradientLayer.Colors = new CGColor[] { startColor, endColor
        //};

        //    NativeView.Layer.InsertSublayer(gradientLayer, 0);

        //}
    }
}
