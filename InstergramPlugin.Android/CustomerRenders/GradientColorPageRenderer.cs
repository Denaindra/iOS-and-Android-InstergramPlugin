using System;
using Android.Content;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinKit.CustomRenders;
using XamarinKit.Droid.CustomerRenders;

[assembly: ExportRenderer(typeof(GradientColorPage), typeof(GradientColorPageRenderer))]
namespace XamarinKit.Droid.CustomerRenders
{
    public class GradientColorPageRenderer : PageRenderer
    {
        private Xamarin.Forms.Color StartColor { get; set; }
        private Xamarin.Forms.Color EndColor { get; set; }

        public GradientColorPageRenderer(Context context) : base(context)
        {
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            var gradient = new LinearGradient(0, 0, 0, Height,
             this.StartColor.ToAndroid(),
             this.EndColor.ToAndroid(),
             Shader.TileMode.Mirror);
            var paint = new Paint()
            {
                Dither = true,
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                var page = e.NewElement as GradientColorPage;
                this.StartColor = page.StartColor;
                this.EndColor = page.EndColor;
            }
            catch (Exception ex)
            {
                //Publish the error
            }
        }


    }
}
