using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
   [Table("CAMIONETA")]
    public class Camioneta
    {
        [Key]
        [Column("ID_CAM")]
        [StringLength(50)]
        public required  string IdCam { get; set; }

        [Column("NOM_CAM")]
        public required string NomCam { get; set; }

    
    }
}
