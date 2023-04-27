using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingStore_ISP9_13.BD;

namespace ClothingStore_ISP9_13.Classes
{
    internal class UserDataClass
    {
        public static User User { get; set; }

        public static Employee Employee { get; set; }

        public static Client Client { get; set; }
    }
}
