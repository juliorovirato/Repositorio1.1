using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAC.Models
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string CedulaIns { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
