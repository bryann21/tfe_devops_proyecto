using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
     [Table("ESTADO")]
    public class Estado
    {
        [Key]
        [Column("ID_EST")]
        [StringLength(50)]
        public required  string IdEst { get; set; }

        [Column("NOM_EST")]
        public string NombreEstado { get; set; }
    }
}
