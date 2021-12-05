using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Numerics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MajsterAppV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class poziomica : ContentPage
    {
        public poziomica()
        {
            InitializeComponent();
        }
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
    protected override void Wywolanie()
    {
        Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;


        try
        {
            Accelerometer.Start(SensorSpeed.UI);
        }
        catch (FeatureNotSupportedException ex)
        {
            Console.WriteLine($"Accelerometer - {ex.Message}");
        }
    }


    void Accelerometer_ReadingChanged(AccelerometerChangedEventArgs e)
    {
        acceleration = e.Reading.Acceleration;
    }

    protected override void odznikanie()
    {

        Accelerometer.Stop();
        Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
    }


}


