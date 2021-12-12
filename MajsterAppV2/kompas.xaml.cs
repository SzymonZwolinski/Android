﻿using System;
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
    public partial class kompas : ContentPage
    {
        KompasWidok VM;
        public kompas()
        {
            InitializeComponent();
            BindingContext = VM = new KompasWidok();
            VM.StartKompas();
           
        }
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}