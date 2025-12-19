using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
    [Table("PERSONAL")]
    public class Personal
    {
        [Key]
        [Column("ID_PER")]
        [StringLength(50)]
        public required string IdPer { get; set; }

        [Column("NOM_PER")]
        public string? NomPer { get; set; }

        [Column("CON_PER")]
        public string? ConPer { get; set; }

    }
}
