using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
   [Table("DETALLE_REAGENDADOS")]
    public class DetalleReagendado
    {
        [Key]
        [Column("ID_DET_REA")]
        public  required  int IdDetRea { get; set; }

        [Column("DES_DET_REA")]
        public string DescripcionDetalleReagendado { get; set; }

        [Column("ID_REA")]
        public int? IdRea { get; set; }

        [ForeignKey("IdRea")]
        public virtual Reagendar Reagendar { get; set; }
    }
}
