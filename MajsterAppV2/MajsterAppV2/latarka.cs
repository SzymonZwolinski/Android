using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.ComponentModel;

namespace MajsterAppV2
{
    
public class latarka : ContentPage
    {
        public latarka()
        {
            Title = "Latarka";

            Label label = new Label
            {
                Text = "ekran włączania i wyłączania latarki",
            };

            Button button = new Button
            {
                Text = "ON",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
           
            Button button2 = new Button
            {
                Text = "OFF",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            Content = new StackLayout
            {
               
                Children = {
                    label,button,button2

                }
            };
        }
    }
}