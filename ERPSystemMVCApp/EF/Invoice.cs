//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERPSystemMVCApp.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public Invoice()
        {
            this.Categories = new HashSet<Category>();
        }
    
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int CutomerId { get; set; }
        public int UserId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
