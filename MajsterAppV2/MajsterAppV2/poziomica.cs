using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MajsterAppV2
{
    public class poziomica : ContentPage
    {
        public poziomica()
        {
            Title = "poziomica";

            Label label = new Label
            {
                Text = "ekran poziomicy",
            };

            Button button = new Button
            {
                Text = "pion",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            Button button2 = new Button
            {
                Text = "poziom",
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