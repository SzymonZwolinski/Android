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

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new latarka());
        }
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new poziomica());
        }
        private void Button_Clicked_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new minutnik());
        }
    }
}
