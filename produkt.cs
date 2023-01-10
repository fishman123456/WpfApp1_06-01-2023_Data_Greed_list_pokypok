using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1_06_01_2023_Data_Greed_list_pokypok
{

    public class Product:INotifyPropertyChanged
    {
        private string _Name;

        private bool _IsBuy;
        private byte _Count;

       


        public string Name
        {
            get { return _Name; }
            set {
                if (_Name == value)
                {
                    return;
                } _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public byte Count
        {
            get { return _Count; }
            set {
                if (_Count == value)
                {
                    return;
                }
                _Count = value;
                OnPropertyChanged("Count");
            }
        }

        public bool IsBuy
        {
            get { return _IsBuy; }
            set {
                if (_IsBuy==value)
                {
                    return;
                }
                _IsBuy = value;
                OnPropertyChanged("IsBuy");
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
           //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    }
