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
    
    public partial class Storage
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int IdProduct { get; set; }
        public bool InStock { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
