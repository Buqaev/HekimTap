//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hehimtap.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NewsCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NewsCategory()
        {
            this.News = new HashSet<News>();
        }
    
        public int Id { get; set; }
        public string Ad { get; set; }
        public bool Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }
        public virtual NewsCategory NewsCategories1 { get; set; }
        public virtual NewsCategory NewsCategory1 { get; set; }
    }
}
