using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiProyectoWeb.Models
{
  [Table("DEPARTAMENTOS")]
public class Departamento
{
    [Key]
    [Column("ID_DEP")]
    [StringLength(50)]
    public required string IdDep { get; set; }

    [Column("NOM_DEP")]
    public required string NombreDepartamento { get; set; }

   
}
}
