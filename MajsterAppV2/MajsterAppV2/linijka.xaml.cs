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
            TextSize = 1.5f,
            IsAntialias = true
        };


        readonly SKPaint redPaint = new SKPaint
        {
            Style = SKPaintStyle.StrokeAndFill,
            Color = SKColors.Red,
            TextSize = 1.5f,
            IsAntialias = true
        };

        readonly SKPaint greenPaint = new SKPaint
        {
            Color = SKColors.Green,
            Style = SKPaintStyle.Fill,
            TextSize = 1.5f,
            IsAntialias = true
        };
        void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;

            canvas.Clear(SKColors.AliceBlue);

            var width = e.Info.Width;
            var height = e.Info.Height;

            canvas.Translate(0, 0);
            canvas.Scale(width / 300f);

            //mm = 3.77957517575 , 5 = (18.89787587875) 10 = 37.7957517575
            Maluj(height, canvas);

        }

        #region Malowanie
        private void Maluj(int Wysokosc, SKCanvas canva)
        {
            canva.Translate(0, 0);
            float x = 10;
            double mm_pixel = 3.77957517575;
            double zakres = Math.Floor(Wysokosc / mm_pixel) ;
            int i = 0; // ilosc kresek
            float[] temp_tab = new float[(int)zakres];
            for(int temp =0; temp != zakres;temp++)
            {
                temp_tab[temp] = (temp+1)/10;
                
            }
            while (zakres > 0)
            {
                if (i % 4 == 0)
                {
                    //5mm zielony
                    canva.DrawText(temp_tab[i].ToString(), x, (float)mm_pixel, greenPaint);
                }
                else if(i % 9 == 0)
                {
                    //10mm madżenta 
                    canva.DrawText(temp_tab[i].ToString(), x, (float)mm_pixel, magentaPaint);
                }
                else
                {
                    //1mm czerw
                    canva.DrawText(temp_tab[i].ToString(), x, (float)mm_pixel, redPaint);
                }
                mm_pixel += mm_pixel;
                zakres--;
            }
        }
        #endregion

    }


}