using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
    [Table("CONEXION")]
    public class Conexion
    {
        [Key]
        [Column("ID_CON")]
        public required int IdCon { get; set; }

        [Column("TAR_CON")]
        public int? TarCon { get; set; }

        [Column("PUE_CON")]
        public int? PueCon { get; set; }

        [Column("ID_SMART")]
        [StringLength(50)]
        public string IdSmart { get; set; }

        [ForeignKey("IdSmart")]
        public virtual Smart Smart { get; set; }
    }
}
