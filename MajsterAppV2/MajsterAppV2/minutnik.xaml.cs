using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MajsterAppV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class minutnik : ContentPage
    {
        public minutnik()
        {
            InitializeComponent();
        }
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private System.Timers.Timer _timer;
        private int _countSeconds;

        void minutnik_kod()
        {
            _timer = new System.Timers.Timer();
            //Odpala event Timer co sekunde
            _timer.Interval = 1000;
            _timer.Elapsed += OnTimedEvent;
            //liczy w dól 5 sekund
            _countSeconds = 5;

            _timer.Enabled = true;
        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            _countSeconds--;

            //tutaj upgrade UI z kazda sekunda

            if (_countSeconds == 0)
            {
                _timer.Stop();
            }
        }
    }
}