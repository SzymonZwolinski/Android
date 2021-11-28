using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        DateTime _triggerTime;
        public minutnik()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
            
        }

        bool OnTimerTick()
        {
            if (_switch.IsToggled && DateTime.Now >= _triggerTime)
            {
                _switch.IsToggled = false;
                DisplayAlert("Koniec czasu", "Ustawione - '" + _entry.Text + "'wydarzenie się zakończyło", "OK");
            }
            return true;
        }
        void OnTimePickerPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Time")
            {
                SetTriggerTime();
            }
        }

        void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
            SetTriggerTime();
        }

        void SetTriggerTime()
        {
            if (_switch.IsToggled)
            {
                _triggerTime = DateTime.Today + _timePicker.Time;
                if (_triggerTime < DateTime.Now)
                {
                    _triggerTime += TimeSpan.FromDays(1);
                }
            }
        }
                private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }



        /*private System.Timers.Timer _timer;
        public int _countSeconds;

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
        */
    }
}