using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Essentials;
using System.Numerics;

namespace MajsterAppV2
{
    
    public partial class poziomica : ContentPage
    {
        public poziomica()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1f / 60), () =>
            {
                canvasView.InvalidateSurface();
                return true;
            });
        }
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        readonly SKPaint blackPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black,
            IsAntialias = true
        };

        readonly SKPaint whiteLine = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.White,
            StrokeWidth = 1
        };

        readonly SKPaint whitePaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Beige,
            IsAntialias = true
        };

        readonly SKPaint greenPaint = new SKPaint
        {
            Color = SKColors.Green,
            StrokeWidth = 2,
            Style = SKPaintStyle.Stroke,
            IsAntialias = true
        };
        void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;

            canvas.Clear(SKColors.CornflowerBlue);

            var width = e.Info.Width;
            var height = e.Info.Height;

          
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 300f);

            
            canvas.DrawCircle(0, 0, 100, blackPaint);

            canvas.DrawCircle(0, 0, 30f, greenPaint);

            // Bąbelek wskazujący poziom
            var x = (acceleration.X * RoundingValue);
            var y = (acceleration.Y * RoundingValue);
            canvas.DrawCircle(x, y, 20f, whitePaint);

           
        }

        protected override void OnAppearing()
        {
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;

            try
            {
                Accelerometer.Start(SensorSpeed.UI);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine(fnsEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            acceleration = e.Reading.Acceleration;
        }

        protected override void OnDisappearing()
        {
            Accelerometer.Stop();
            Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
        }

        Vector3 acceleration;
        const float RoundingValue = 100f;
    }
}
    





