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
    
    public partial class tblTechSpecFilter
    {
        public int Property_ID { get; set; }
        public int SubCategory_ID { get; set; }
        public Nullable<int> Min_Value { get; set; }
        public Nullable<int> Max_Value { get; set; }
    
        public virtual tblProperty tblProperty { get; set; }
        public virtual tblSubCategory tblSubCategory { get; set; }
    }
}
