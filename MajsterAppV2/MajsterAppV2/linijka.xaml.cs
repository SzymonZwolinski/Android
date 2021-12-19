using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            canvas.Clear(SKColors.AliceBlue);

            var width = e.Info.Width;
            var height = e.Info.Height;


            //mm = 3.77957517575 , 5 = (18.89787587875) 10 = 37.7957517575



        }

    }


}