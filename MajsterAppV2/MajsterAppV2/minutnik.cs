using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MajsterAppV2
{
    public class minutnik : ContentPage
    {
        public minutnik()
        {
            Title = "Minutnik";

            Label label = new Label
            {
                Text = "ekran włączania i wyłączania minutnika",
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