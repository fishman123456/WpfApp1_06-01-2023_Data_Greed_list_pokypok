using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1_06_01_2023_Data_Greed_list_pokypok
{

    public class Product
    {
        public string? Name { get; set; }

        private bool _IsBuy;
        private byte _Count;

        public byte Count
        {
            get { return _Count; }
            set { _Count = value; }
        }

        public bool IsBuy
        {
            get { return _IsBuy; }
            set { _IsBuy = value; }
        }
    }
    }
