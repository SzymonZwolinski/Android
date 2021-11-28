using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
namespace MajsterAppV2
{
    public class kompas_logika
    {
        public event EventHandler<string> WezWartoscKompasu;
        public kompas_logika()
        {
            start();
            Compass.ReadingChanged += Compass_ReadingChanged;
        }

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            double value = e.Reading.HeadingMagneticNorth;
            string valueFormat = string.Format("{0} {1} {2}", value.ToString("0"), CalculateDirection(value), "\u00b0");
            WezWartoscKompasu?.Invoke(this, valueFormat);
        }

        public void start()
        {
            try
            {
                Compass.Start(SensorSpeed.UI);

            }catch(FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine(fnsEx.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private string CalculateDirection(double degree)
        {
            if (degree < 22)
            {
                return "Północ";
            }
            else if (degree < 67)
            {
                return "Północny wschód";
            }
            else if (degree < 112)
            {
                return "Wschód";
            }
            else if (degree < 157)
            {
                return "Południowy wschód";
            }
            else if (degree < 202)
            {
                return "Południe";
            }
            else if (degree < 247)
            {
                return "Południowy zachód";
            }
            else if (degree < 292)
            {
                return "Zachód";
            }
            else if (degree < 337)
            {
                return "Północny zachód";
            }
            else
            {
                return "Północ";
            }
        }

    }
}
