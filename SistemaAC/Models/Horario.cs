using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAC.Models
{
    public class Horario
    {
        [Key]
        public int HorarioID { get; set; }
        public int ActividadesID { get; set; }
        public byte DiaAct { get; set; }
        public byte HoraAct { get; set; }
        public Actividades Actividades { get; set; }
    }
}
