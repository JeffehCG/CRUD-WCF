namespace ListaComprasWCF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("testefcamara.listacompras")]
    [DataContract]
    public partial class listacompra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public listacompra()
        {
            produtoes = new HashSet<produto>();
        }

        [DataMember]
        public int id { get; set; }

        [Column(TypeName = "date")]
        [DataMember]
        public DateTime? data_lista { get; set; }

        [DataMember]
        public int? id_usuario { get; set; }

        [StringLength(50)]
        [DataMember]
        public string descricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<produto> produtoes { get; set; }
    }
}
