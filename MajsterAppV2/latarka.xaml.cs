using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MajsterAppV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class latarka : ContentPage
    {
        public latarka()
        {
            InitializeComponent();
        }
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        
        private async void PrzyciskON(object sender, EventArgs e)
        {
            try
            {
                await Flashlight.TurnOnAsync();
            }catch(Exception)
            {
                
            }
            
        }
        private async void PrzyciskOFF(object sender, EventArgs e)
        {
            try
            {
                await Flashlight.TurnOffAsync();
            }
            catch(Exception)
            {
                
            }
        }
    }
}