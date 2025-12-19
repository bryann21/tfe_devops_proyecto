using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
   [Table("SMART")]
    public class Smart
    {
        [Key]
        [Column("ID_SMART")]
        [StringLength(50)]
        public required  string IdSmart { get; set; }

        [Column("NOM_SMART")]
        public string NombreSmart { get; set; }

        public virtual ICollection<Conexion> Conexiones { get; set; } = new List<Conexion>();
    }
}
