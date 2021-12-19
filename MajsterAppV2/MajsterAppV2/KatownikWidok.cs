using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MajsterAppV2
{
    public class KatownikWidok : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string wartoscx;
        public string Wartoscx
        {
            set
            {
                if(wartoscx != value)
                {
                    wartoscx = value;
                    OnPropertyChanged("wartoscx");
                }
            }
            get
            {
                return wartoscx;
            }
        }

        private void OnPropertyChanged(string propertyNazwa)
        {
            var zmieniony = PropertyChanged;
            if (zmieniony != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyNazwa));
            }
        }

        public void startKatownik()
        {
            var mojKatownik = new KatownikLogika();
            mojKatownik.WezWartoscKatownika += mojKatownik_WezWartoscKatownika;
        }
        private void mojKatownik_WezWartoscKatownika(object sender, string e)
        {
            Wartoscx = e;
        }

    }
}
