using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SistemaAC.Data;
using SistemaAC.Models;

namespace SistemaAC.ModelsClass
{
    public class HorarioModels
    {
        private ApplicationDbContext context;
        private List<IdentityError> errorList = new List<IdentityError>();
        private string code = "", des = "";
        public HorarioModels(ApplicationDbContext context)
        {
            this.context = context;
        }

        internal List<Actividades> getActividades()
        {
            return context.Actividades.Where(c => c.Estado == true).ToList();
        }
        public List<Actividades> getActividad(int id)
        {
            return context.Actividades.Where(a => a.ActividadesID == id).ToList();
        }
        public List<IdentityError> agregarHorario(int id, string dia, string hora, int actividad, string funcion)
        {
            var horario = new Horario
            {
                Dia = dia,
                Hora = hora,
                ActividadesID = actividad,
            };
            try
            {
                context.Add(horario);
                context.SaveChanges();
                code = "Save";
                des = "Save";
            }
            catch (Exception e)
            {

                code = "error";
                des = e.Message;
            }
            errorList.Add(new IdentityError
            {
                Code = code,
                Description = des
            });
            return errorList;
        }
        public List<object[]> filtrarHorario(int numPagina, string valor, string order)
        {
            int cant, numRegistros = 0, inicio = 0, reg_por_pagina = 5;
            int can_paginas, pagina;
            string dataFilter = "", paginador = "", Estado = null;
            List<object[]> data = new List<object[]>();
            IEnumerable<Horario> query;
            List<Horario> actividades = null;
            switch (order)
            {
                case "dia":
                    actividades = context.Horario.OrderBy(c => c.Dia).ToList();
                    break;
                case "hora":
                    actividades = context.Horario.OrderBy(c => c.Hora).ToList();
                    break;
                case "actividad":
                    actividades = context.Horario.OrderBy(c => c.Actividades).ToList();
                    break;

            }
            numRegistros = actividades.Count;
            inicio = (numPagina - 1) * reg_por_pagina;
            can_paginas = (numRegistros / reg_por_pagina);
            if (valor == "null")
            {
                query = actividades.Skip(inicio).Take(reg_por_pagina);
            }
            else
            {
                query = actividades.Where(c => c.Dia.StartsWith(valor) || c.Hora.StartsWith(valor)).Skip(inicio).Take(reg_por_pagina);
            }
            cant = query.Count();
            foreach (var item in query)
            {
                var actividad = getActividad(item.ActividadesID);
                dataFilter += "<tr>" +
                    "<td>" + item.Dia + "</td>" +
                    "<td>" + item.Hora + "</td>" +
                    "<td>" + actividad[0].Nombre + "</td>" +
                    "<td>" +
                    "<a data-toggle='modal' data-target='#modalAC' onclick='editarHorario(" + item.HorarioID + ',' + 1 + ")'  class='btn btn-success'>Edit</a>" +
                    "</td>" +
                "</tr>";

            }
            object[] dataObj = { dataFilter, paginador };
            data.Add(dataObj);
            return data;
        }
    }
}
