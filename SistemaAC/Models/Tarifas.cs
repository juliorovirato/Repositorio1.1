using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAC.Models
{
    public class Tarifas
    {
        [Key]
        public int TarifaID { get; set; }
        public int ActividadesID { get; set; }
        public decimal ValorEst { get; set; }
        public decimal ValorEmp { get; set; }
        public decimal ValorFam { get; set; }
        public decimal ValorGrad { get; set; }
        public Actividades Actividades { get; set; }
    }
}
