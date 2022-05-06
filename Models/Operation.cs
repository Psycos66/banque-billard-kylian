namespace ORM
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Operation")]
    public partial class Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdOperation { get; set; }

        public int? type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOperation { get; set; }

        public int? Montant { get; set; }

        public int IdCompte { get; set; }

        public virtual Compte Compte { get; set; }
    }
}
