using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
    [Table("REAGENDAR")]
    public class Reagendar
    {
        [Key]
        [Column("ID_REA")]
        public required int IdRea { get; set; }

        [Column("FEC_REA")]
        public string FecRea { get; set; }

        [Column("PRIO_REA")]
        [StringLength(50)]
        public string PrioRea { get; set; }

        public virtual ICollection<DetalleReagendado> DetalleReagendados { get; set; } = new List<DetalleReagendado>();
    }
}
