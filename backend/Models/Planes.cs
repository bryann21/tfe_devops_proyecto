using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
    [Table("PLANES")]
    public class Plan
    {
        [Key]
        [Column("ID_PLA")]
        [StringLength(50)]
        public required string IdPla { get; set; }

        [Column("NOM_PLA")]
        public string NomPla { get; set; }

        [Column("VAL_PLA")]
        public string ValPla { get; set; }
    }
}
