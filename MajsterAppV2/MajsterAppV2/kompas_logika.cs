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
            WezWartoscKompasu.Invoke(this, e.Reading.HeadingMagneticNorth.ToString());
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

    }
}
