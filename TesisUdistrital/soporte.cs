//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TesisUdistrital
{
    using System;
    using System.Collections.Generic;
    
    public partial class soporte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public soporte()
        {
            this.soporteXRadicado = new HashSet<soporteXRadicado>();
        }
    
        public long idSoporte { get; set; }
        public string codigoSoporte { get; set; }
        public string descripcionSoporte { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<soporteXRadicado> soporteXRadicado { get; set; }
    }
}
