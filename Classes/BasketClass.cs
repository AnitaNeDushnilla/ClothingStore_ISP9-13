using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore_ISP9_13.Classes
{
    internal class BasketClass
    {
        public static ObservableCollection<BD.Product> products = new ObservableCollection<BD.Product>();
    }
}
