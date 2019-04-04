using Microsoft.AspNetCore.Identity;
using SistemaAC.Data;
using SistemaAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAC.ModelsClass
{
    public class ActividadesModels
    {
        ApplicationDbContext context;
        public ActividadesModels(ApplicationDbContext context)
        {
            this.context = context;
            filtrarDatos(1, "Android");
        }
        public List<IdentityError> guardarActividad(string nombre, string cantidadIns, string descripcion, string estado)
        {
            var errorList = new List<IdentityError>();
            var actividad = new Actividades
            {
                NombreAct = nombre,
                CantidadIns = cantidadIns,
                Descripcion = descripcion,
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
            int count = 0, cant, numRegistros = 0, inicio = 0, reg_por_pagina = 2;
            int can_paginas, paginas;
            string dataFilter = "", paginador = "", Estado = null;
            List<object[]> data = new List<object[]>();
            IEnumerable<Actividades> query;
            var actividades = context.Actividades.OrderBy(a => a.NombreAct).ToList();
            numRegistros = actividades.Count;
            inicio = (numPagina - 1) * reg_por_pagina;
            can_paginas = (numRegistros / reg_por_pagina);
            if(valor == "null")
            {
                query = actividades.Skip(inicio).Take(reg_por_pagina);
            }
            else
            {
                query = actividades.Where(a => a.NombreAct.StartsWith(valor) || a.Descripcion.StartsWith(valor)).Skip(inicio).Take(reg_por_pagina);
            }
            cant = query.Count();
            foreach (var item in query)
            {
                if (item.Estado == true)
                {
                    Estado = "<a data-toggle='modal' data-target='#ModaEstado' onclick='editarEstado(" + item.ActividadesID + ")' class='btn btn-success'>Activo</a>";
                }
                else
                {
                    Estado = "<a data-toggle='modal' data-target='#ModaEstado' onclick='editarEstado(" + item.ActividadesID + ")' class='btn btn-danger'>No activo</a>";
                }
                dataFilter += "<tr>" +
                    "<td>" + item.NombreAct + "</td>" +
                    "<td>" + item.CantidadIns + "</td>" +
                    "<td>" + item.Descripcion + "</td>" +
                    "<td>" + Estado + " </td>" +
                    "<td>" +
                    "<a data-toggle = 'modal' data-target = '#myModal' class='btn btn-success'>Editar</a>|" +
                    "<a data-toggle='modal' data-target='#myModal3' class='btn btn-danger' >Eliminar</a>" +
                    "</td>" +
                    "</tr>";
            }
            object[] dataObj = { dataFilter, paginador };
            data.Add(dataObj);
            return data;
        }
        public List<Actividades> getActividad(int id)
        {
            return context.Actividades.Where(a => a.ActividadesID == id).ToList();
        }
    }
}
