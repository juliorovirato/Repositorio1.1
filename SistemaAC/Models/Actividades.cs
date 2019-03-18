using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAC.Models
{
    public class Actividades
    {
        [Key]
        public int ActividadID { get; set; }
        public string Nombre { get; set; }
        public string CantidadIns { get; set; }
        public string Descripcion { get; set; }
        public Boolean Estado { get; set; } = true;
        public int InstructorCod { get; set; }
        public ICollection<Instructor> Instructor { get; set; }
    }
}
