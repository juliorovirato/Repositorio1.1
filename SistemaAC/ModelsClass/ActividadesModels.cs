using SistemaAC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SistemaAC.Models;

namespace SistemaAC.ModelsClass
{
    public class ActividadesModels
    {
        private ApplicationDbContext context;

        public ActividadesModels (ApplicationDbContext context)
        {
            this.context = context;
            filtrarDatos(1, "Ayuwoki");
        }

        public List<IdentityError> guardarActividad(string nombre, string cantidad, string descripcion, string estado, int instructorcod)
        {
            var errorList = new List<IdentityError>();
            var actividad = new Actividades
            {
                Nombre = nombre,
                CantidadIns = cantidad,
                Descripcion = descripcion,
                InstructorCod = instructorcod,
                Estado = Convert.ToBoolean(estado)
            };
            context.Add(actividad);
            context.SaveChangesAsync();
            errorList.Add(new IdentityError
            {
                Code = "Save",
                Description = "Save"
            });
            return errorList;
        }

        public List<object[]> filtrarDatos(int numPagina, string valor)
        {
            int count = 0, cant, numregistros = 0, inicio = 0, reg_por_pagina = 5;
            int can_paginas, paginas;
            string dataFilter = "", paginador = "", Estado = null;
            List<object[]> data = new List<object[]>();
            IEnumerable<Actividades> query;
            var actividades = context.Actividades.OrderBy(c => c.Nombre).ToList();
            numregistros = actividades.Count;
            inicio = (numPagina - 1) * reg_por_pagina;
            can_paginas = (numregistros / reg_por_pagina);
            if (valor == "null")
            {
                query = actividades.Skip(inicio).Take(reg_por_pagina);
            }
            else
            {
                query = actividades.Where(c => c.Nombre.StartsWith(valor) || c.Descripcion.StartsWith(valor)).Skip(inicio).Take(reg_por_pagina);
            }
            cant = query.Count();
            return data;
        }
    }
}
