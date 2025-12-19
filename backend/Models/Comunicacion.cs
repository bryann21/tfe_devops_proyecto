using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
     [Table("COMUNICACION")]
    public class Comunicacion
    {
        [Key]
        [Column("ID_COM")]
        [StringLength(50)]
        public required string IdCom { get; set; }

        [Column("NOM_COM")]
        public required string NomCom { get; set; }
    }
}
