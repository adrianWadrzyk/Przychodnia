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
    
    public partial class lekarz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lekarz()
        {
            this.karta_pacjenta = new HashSet<karta_pacjenta>();
            this.rejestracja = new HashSet<rejestracja>();
        }
    
        public int id_lekarza { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public Nullable<int> id_specjalizacji { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<karta_pacjenta> karta_pacjenta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rejestracja> rejestracja { get; set; }
        public virtual specjalizacja specjalizacja { get; set; }
    }
}
