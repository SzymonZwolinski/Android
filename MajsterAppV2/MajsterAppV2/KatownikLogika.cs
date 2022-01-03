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
            var wartoscx = data.Orientation.X;
            var wartoscy = data.Orientation.Y;
            var wartoscz = data.Orientation.Z;

            var wartoscw = data.Orientation.W;
            var kat = Math.Acos(wartoscw) * 2;
            kat = (180 / Math.PI) * kat;
            var ax = wartoscx / Math.Sin(Math.Sin(kat/2));
            var ay = wartoscy / Math.Sin(Math.Sin(kat/2));
            var az = wartoscz / Math.Sin(Math.Sin(kat/2));


            string dane = string.Format("{0} {1} {2} {3}",kat.ToString() ,ax.ToString(), ay.ToString(), az.ToString() );
            WezWartoscKatownika?.Invoke(this, dane);

            Console.WriteLine($"Reading: X: {data.Orientation.X}, Y: {data.Orientation.Y}, Z: {data.Orientation.Z}, W: {data.Orientation.W}");

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

