namespace ClothingStore_ISP9_13.BD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ClothingStore_ISP9_13;
    using ClothingStore_ISP9_13.Classes;
    using ClothingStore_ISP9_13.Pages;

    public partial class Product
    {
        public int Count {
            get
            {
                var BsProd = BasketClass.products.Where(i => i.Id == Id);
                if (BsProd != null)
                {
                    return BasketClass.products.Count;
                }
                else
                {
                    return 0;
                }
            }
            set { }
        }

    }
}
