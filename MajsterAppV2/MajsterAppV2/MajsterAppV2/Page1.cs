using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MajsterAppV2
{
    public class Page1 : ContentPage
    {

        public void Funkcja_Minutnik()
        {
            Title = "Minutnik";
            Label label = new Label
            {
                Text = "Włącz minutnik",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Button przyciskON = new Button
            {
                Text = "Włacz",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand

            };
            Button przyciskOFF = new Button
            {
                Text = "Wylacz",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };



        
   
        public void Minutnik()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), CzasMiniony); // Co sekunde wywoluje funkcje CzasMiniony
        }
        public bool CzasMiniony()
        {
           
            int sekunda = 0;
            int minuta = 0;
            int godzina = 0;

            Device.BeginInvokeOnMainThread(() =>
            {
                sekunda += 1;
                if (sekunda == 60)
                {
                    sekunda = 0;
                    minuta++;
                    if (minuta == 60)
                    {
                        godzina++;
                        minuta = 0;
                    }
                }
                Label czas = new Label
                {
                    Text = "Godzina: " + godzina + " Minuty:  " + minuta + " Sekundy: " + sekunda, //wyswietla czas co wywolanie funkjci
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                 };


            });
            return true; //True = dziala dalej false - stop


        }

    }
}