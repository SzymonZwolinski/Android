using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
                    OnPropertyChanged("Wartoscx");
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

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private string dane1;

        public string dane { get => dane1; set => SetProperty(ref dane1, value); }

    }
}
