//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JoolServerApp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPropertyValue
    {
        public int Property_ID { get; set; }
        public int Product_ID { get; set; }
        public Nullable<int> Value { get; set; }
    
        public virtual tblProduct tblProduct { get; set; }
        public virtual tblProperty tblProperty { get; set; }
    }
}
