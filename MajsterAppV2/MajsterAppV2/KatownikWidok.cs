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
        private string wartoscy;
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

        public string Wartoscy
        {
            set
            {
                if (wartoscy != value)
                {
                    wartoscy = value;
                    OnPropertyChanged("wartoscy");
                }
            }
            get
            {
                return wartoscy;
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
/*



    
        public void StartKompas()
        {
            var mojKompas = new kompas_logika();
            mojKompas.WezWartoscKompasu += mojKompas_WezWartoscKompas;
        }
        private void mojKompas_WezWartoscKompas(object sender, string e)
        {
            KompasWartosc = e;
        }
 
 */