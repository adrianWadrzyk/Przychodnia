//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Przychodnia
{
    using System;
    using System.Collections.Generic;
    
    public partial class specjalizacja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public specjalizacja()
        {
            this.lekarz = new HashSet<lekarz>();
        }
    
        public int id_specjalizacji { get; set; }
        public string nazwa_specjalizacji { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lekarz> lekarz { get; set; }
    }
}
