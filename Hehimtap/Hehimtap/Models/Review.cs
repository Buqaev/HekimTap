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
    
    public partial class Review
    {
        public int Id { get; set; }
        public string Basliq { get; set; }
        public System.DateTime Tarix { get; set; }
        public string Metn { get; set; }
        public bool Status { get; set; }
        public int XeberId { get; set; }
        public int UserId { get; set; }
    
        public virtual News News { get; set; }
        public virtual User User { get; set; }
    }
}