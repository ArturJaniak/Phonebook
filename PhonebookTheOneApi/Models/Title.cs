//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhonebookTheOneApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Title
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Title()
        {
            this.PersonTitles = new HashSet<PersonTitle>();
        }
    
        public int TitleID { get; set; }
        public string Title1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTitle> PersonTitles { get; set; }
    }
}
