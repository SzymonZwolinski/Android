using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MajsterAppV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class linijka : ContentPage
    {
        public linijka()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1f / 60), () =>
            {
                // canvasView.InvalidateSurface();
                return true;
            });
        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        readonly SKPaint magentaPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Magenta,
            IsAntialias = true
        };


        readonly SKPaint redPaint = new SKPaint
        {
            Style = SKPaintStyle.StrokeAndFill,
            Color = SKColors.Red,
            IsAntialias = true
        };

        readonly SKPaint greenPaint = new SKPaint
        {
            Color = SKColors.Green,
            Style = SKPaintStyle.Fill,
            IsAntialias = true
        };
        void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;

            canvas.Clear(SKColors.White);

            var width = e.Info.Width;
            var height = e.Info.Height;

            canvas.Translate(0, 0);
            //mm = 3.77957517575 , 5 = (18.89787587875) 10 = 37.7957517575
            float x = 10;
            float mm_pixel = 3.77957517575f;
            int i = 1; // ilosc kresek

            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            var density = mainDisplayInfo.Density;
            double wysokosc = (double)height / density;
            double zakres = Math.Floor(wysokosc / mm_pixel);

            canvas.DrawText(zakres.ToString(), 100, 100, magentaPaint);
            while (zakres > 0)
            {
                if (i % 4 == 0)
                {
                    //5mm
                    canvas.DrawCircle(0, mm_pixel, 30, greenPaint);
                    i++;
                }
                else if (i % 9 == 0)
                {
                    //10mm

                    canvas.DrawCircle(x, mm_pixel, 15, magentaPaint);
                    i++;
                }
                else
                {
                    //1mm 
                    canvas.DrawCircle(x, mm_pixel, 50, redPaint);
                    i++;
                }
                mm_pixel = mm_pixel + mm_pixel;
                zakres--;
            }
        }
    }
}


