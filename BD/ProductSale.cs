//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClothingStore_ISP9_13.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductSale
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdEmployee { get; set; }
        public int IdClient { get; set; }
        public System.DateTime SaleDate { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }
}
