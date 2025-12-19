using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
   [Table("DAÑOS")]
    public class Dano
    {
        [Key]
        [Column("ID_DAÑO")]
        [StringLength(50)]
        public required string IdDano { get; set; }

        [Column("NOM_DAÑ")]
        public required string NomDan { get; set; }
    }
}
