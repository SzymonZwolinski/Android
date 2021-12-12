using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MajsterAppV2
{
    public class MyCompassViewModel : kompas
    {
        public MyCompassViewModel()
        {
            StopCommand = new Command(Stop);
            StartCommand = new Command(Start);
            
        }
        string headingDisplay;

        public string HeadingDisplay
        {
            get => headingDisplay;
            set => SetProperty(ref headingDisplay, value);
        }

        private void SetProperty(ref string headingDisplay, string value)
        {
            throw new NotImplementedException();
        }

        double heading = 0;

        public double Heading
        {
            get => heading;
            set => SetProperty(ref heading, value);
        }

        private void SetProperty(ref double heading, double value)
        {
            throw new NotImplementedException();
        }

        public Command StopCommand { get; }

        void Stop()
        {
            if (!Compass.IsMonitoring)
                return;
            Compass.ReadingChanged -= Compass_ReadingChanged;
            Compass.Stop();
        }

        public Command StartCommand { get; }

        void Start()
        {
            if (Compass.IsMonitoring)
                return;
            Compass.ReadingChanged += Compass_ReadingChanged;
            Compass.Start(SensorSpeed.UI);
        }

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            Heading = e.Reading.HeadingMagneticNorth;
            HeadingDisplay = $"Heading:{Heading}";
        }
    }
}