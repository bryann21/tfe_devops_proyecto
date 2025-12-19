using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
    [Table("DETALLE_NOTA")]
    public class DetalleNota
    {
        [Key]
        [Column("ID_DET")]
        public required  int IdDet { get; set; }

        [Column("DES")]
        public string Descripcion { get; set; }

        [Column("ID_NOT")]
        public required  int IdNota { get; set; }

        [ForeignKey("IdNota")]
        public virtual Nota Nota { get; set; }
    }
}
