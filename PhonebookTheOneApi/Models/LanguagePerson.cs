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
    
    public partial class LanguagePerson
    {
        public int LanguagePersonID { get; set; }
        public string LanguageLevel { get; set; }
        public string CertificateInstitute { get; set; }
        public int LanguageID { get; set; }
        public int PersonID { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Person Person { get; set; }
    }
}