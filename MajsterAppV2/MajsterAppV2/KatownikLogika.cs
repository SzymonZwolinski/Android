using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
namespace MajsterAppV2
{
    public class KatownikLogika
    {
        public event EventHandler<string> WezWartoscKatownika;
        public KatownikLogika()
        {
            start();
            OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
        }

        private void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            var data = e.Reading;

            var wartoscw = data.Orientation.W;
            var kat = Math.Acos(wartoscw) * 2;
            kat = (180 / Math.PI) * kat; //zmiana radianów na stopnie

            string dane = string.Format("{0}",kat.ToString());
            WezWartoscKatownika?.Invoke(this, dane);
        }

        public void start()
        {
            try
            {
                if (OrientationSensor.IsMonitoring)
                    OrientationSensor.Stop();
                else
                    OrientationSensor.Start(SensorSpeed.UI);
            }
            catch (FeatureNotSupportedException)
            {
                // Feature not supported on device
            }
            catch (Exception)
            {
                // Other error has occurred.
            }


        }

    }
}

