using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
        [Table("NOTA")]
    public class Nota
    {
        [Key]
        [Column("ID_NOTA")]
        public required int IdNota { get; set; }

        [Column("DES_NOT")]
        public string Descripcion { get; set; }

        public ICollection<DetalleNota> Detalles { get; set; }
    }
}
