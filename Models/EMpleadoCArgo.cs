//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBSuper.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class EMpleadoCArgo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMpleadoCArgo()
        {
            this.DEVOlucions = new HashSet<DEVOlucion>();
            this.FActuraCOmpras = new HashSet<FActuraCOmpra>();
            this.FACTuras = new HashSet<FACTura>();
        }
    
        public int Codigo { get; set; }
        public string Documento { get; set; }
        public int CodigoCargo { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public int CodigoSucursal { get; set; }
        [JsonIgnore]
        public virtual CARGo CARGo { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEVOlucion> DEVOlucions { get; set; }
        [JsonIgnore]
        public virtual EMPLeado EMPLeado { get; set; }
        [JsonIgnore]
        public virtual SUCUrsal SUCUrsal { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FActuraCOmpra> FActuraCOmpras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<FACTura> FACTuras { get; set; }
    }
}
