//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Roman_DB_CURSED
{
    using System;
    using System.Collections.Generic;
    
    public partial class storagecontains
    {
        public int StorageId { get; set; }
        public int NomId { get; set; }
        public decimal NumCount { get; set; }
    
        public virtual nom nom { get; set; }
        public virtual storage storage { get; set; }
    }
}
