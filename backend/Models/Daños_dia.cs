using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
    [Table("DAÑOS_DIA")]
    public class DanoDia
    {
        [Key]
        [Column("ID_DAÑ")]
        public required int IdDanoDia { get; set; }

        [Column("TIP_DAÑ")]
        public string? TipoDan { get; set; }

        [Column("FEC_DAÑ")]
        public string? FechaDan { get; set; }

        [Column("CED_CLI")]
        public string? CedCli { get; set; }

        [Column("ID_CON")]
        public int? IdCon { get; set; }

        [Column("ID_PLA")]
        public string? IdPla { get; set; }

        [Column("ID_NOT")]
        public int? IdNot { get; set; }

        [Column("ID_EST")]
        public string? IdEst { get; set; }

        [Column("ID_TEC")]
        public int? IdTec { get; set; }

        [Column("ID_REA")]
        public int? IdRea { get; set; }

        [Column("ID_OFI")]
        public int? IdOfi { get; set; }
    }
}
