using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
       [Table("CLIENTES")]
    public class Cliente
    {
        [Key]
        [Column("CED_CLI")]
        [StringLength(50)]
        public required  string CedCli { get; set; }

        [Column("NOM_CLI")]
        [Required]
        public required string NomCli { get; set; }

        [Column("DIR_CLI")]
        public required string DirCli { get; set; }

        [Column("CON_CLI")]
        public required string ConCli { get; set; }
    }
}
