using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MajsterAppV2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new latarka());
        }
        private void NavigateButton_OnClicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new poziomica());
        }
        
        private async void NavigateButton_OnClicked_3(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new katownik());
        }
        
        private async void NavigateButton_OnClicked_4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new minutnik());
        }

        private async void NavigateButton_OnClicked_5(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new kompas());
        }


        private void NavigateButton_OnClicked_6(object sender, EventArgs e)
        {
            Navigation.PushAsync(new linijka());
        }
    }
}
