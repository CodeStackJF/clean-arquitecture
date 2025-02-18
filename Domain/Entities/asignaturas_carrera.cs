namespace Domain.Entities
{
    public partial class asignaturas_carrera
    {
        public int carrera_id { get; set; }
        public int asignatura_id { get; set; }

        public virtual asignaturas asignatura {get; set;}
        public virtual carreras carrera {get; set;}
    }
}