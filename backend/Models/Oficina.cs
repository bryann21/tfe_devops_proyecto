using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
   [Table("OFICINA")]
    public class Oficina
    {
        [Key]
        [Column("ID_OFI")]
        public required  int IdOfi { get; set; }

        [Column("AT_INI")]
        [StringLength(50)]
        public string AtIni { get; set; }

        [Column("AT_PROG")]
        [StringLength(50)]
        public string AtProg { get; set; }

        [Column("AT_FIN")]
        [StringLength(50)]
        public string AtFin { get; set; }

        [Column("ID_COM")]
        [StringLength(50)]
        public string IdCom { get; set; }

        [Column("FEC_COM")]
        public string FecCom { get; set; }

        [Column("COMU")]
        public string Comu { get; set; }

       
    }
}
