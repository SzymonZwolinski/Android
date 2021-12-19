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
            string dane = string.Format("{0} {1}", wartoscx.ToString("0"), wartoscy.ToString("1"));
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

