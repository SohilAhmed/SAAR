//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAAR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EInvoiceAPI
    {
        public int ID { get; set; }
        public string CompGSTN { get; set; }
        public Nullable<decimal> AllotedBalance { get; set; }
        public Nullable<decimal> UsedBalance { get; set; }
        public Nullable<System.DateTime> ActivatedTill { get; set; }
    }
}
