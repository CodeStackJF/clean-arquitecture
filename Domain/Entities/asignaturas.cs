using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public partial class asignaturas
{
    public int id_asignatura { get; set; }
    public string nombre { get; set; }
}