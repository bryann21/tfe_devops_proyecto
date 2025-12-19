using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
      [Table("TECNICOS")]
    public class Tecnico
    {
        [Key]
        [Column("ID_TEC")]
        public required  int IdTec { get; set; }

        [Column("CAU_TEC")]
        public string Causa { get; set; } = string.Empty;

        [Column("SOLU_TEC")]
        public string Solucion { get; set; }

        [Column("ID_CAM")]
        [StringLength(50)]
        public required string IdCam { get; set; }

        [Column("FEC_ING")]
        public string FechaIngreso { get; set; }

        [Column("FEC_SOL")]
        public string FechaSolucion { get; set; }
    }
}
