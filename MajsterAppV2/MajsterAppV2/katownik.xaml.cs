using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MajsterAppV2 
{


    public partial class katownik : ContentPage
    {
        KatownikWidok VM;
        public katownik()
        {
            InitializeComponent();
            BindingContext = VM = new KatownikWidok();
            VM.startKatownik();

        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}

