using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MajsterAppV2
{
    class KompasWidok : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string kompasWartosc;

        public string KompasWartosc
        {
            set
            {
                if(kompasWartosc != value)
                {
                    kompasWartosc = value;
                    OnPropertyChanged("KompasWartosc");
                }
            }
            get
            {
                return kompasWartosc;
            }
        }

        public void StartKompas()
        {
            var mojKompas = new kompas_logika();
            mojKompas.WezWartoscKompasu += mojKompas_WezWartoscKompas;
        }
        private void mojKompas_WezWartoscKompas(object sender, string e)
        {
            kompasWartosc = e;
        }
        protected virtual void OnPropertyChanged(string propertyNazwa)
        {
            var zmieniony = PropertyChanged;
            if(zmieniony !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyNazwa));
            }
        }
    }
}
