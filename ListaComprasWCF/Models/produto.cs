namespace ListaComprasWCF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("testefcamara.produto")]
    [DataContract]
    public partial class produto
    {
        [DataMember]
        public int id { get; set; }

        [StringLength(50)]
        [DataMember]
        public string nome { get; set; }

        [DataMember]
        public bool? comprado { get; set; }

        [DataMember]
        public int? id_lista { get; set; }

        public virtual listacompra listacompra { get; set; }
    }
}
