using Microsoft.AspNetCore.Identity;
using SistemaAC.Data;
using SistemaAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAC.ModelsClass
{
    public class InstructoresModels
    {
        private ApplicationDbContext context;
        private List<IdentityError> identityError;
        private string code = "", des = "";
        public InstructoresModels(ApplicationDbContext context)
        {
            this.context = context;
            identityError = new List<IdentityError>();
        }
        public List<IdentityError> guardarInstructor(int id, string especialidad, string nombre, string apellido, string documento, string email, string telefono, Boolean estado, int funcion)
        {
            var instructor = new Instructor
            {
                ID = id,
                Especialidad = especialidad,
                Nombres = nombre,
                Apellidos = apellido,
                Documento = documento,
                Email = email,
                Telefono = telefono,
                Estado = estado
            };
            try
            {
                context.Update(instructor);
                context.SaveChanges();
                code = "1";
                des = "Save";
            }
            catch (Exception ex)
            {
                code = "0";
                des = ex.Message;
            }
            identityError.Add(new IdentityError
            {
                Code = code,
                Description = des
            });
            return identityError;
        }
        public List<object[]> filtrarInstructores(int numPagina, string valor, string order)
        {
            int cant, numRegistros = 0, inicio = 0, reg_por_pagina = 6;
            int can_paginas, pagina = 0, count = 1;
            string dataFilter = "", paginador = "", Estado = null;
            List<object[]> data = new List<object[]>();
            IEnumerable<Instructor> query;
            List<Instructor> instructor = null;
            switch (order)
            {
                case "especialidad":
                    instructor = context.Instructor.OrderBy(c => c.Especialidad).ToList();
                    break;
                case "nombre":
                    instructor = context.Instructor.OrderBy(c => c.Nombres).ToList();
                    break;
                case "apellidos":
                    instructor = context.Instructor.OrderBy(c => c.Apellidos).ToList();
                    break;
                case "documento":
                    instructor = context.Instructor.OrderBy(c => c.Documento).ToList();
                    break;
                case "email":
                    instructor = context.Instructor.OrderBy(c => c.Email).ToList();
                    break;
                case "telefono":
                    instructor = context.Instructor.OrderBy(c => c.Telefono).ToList();
                    break;
                case "estado":
                    instructor = context.Instructor.OrderBy(c => c.Estado).ToList();
                    break;

            }
            numRegistros = instructor.Count;
            inicio = (numPagina - 1) * reg_por_pagina;
            can_paginas = (numRegistros / reg_por_pagina);
            if (valor == "null")
                query = instructor.Skip(inicio).Take(reg_por_pagina);
            else
                query = instructor.Where(p => p.Especialidad.StartsWith(valor) || p.Nombres.StartsWith(valor) || 
                p.Apellidos.StartsWith(valor) || p.Documento.StartsWith(valor) || p.Email.StartsWith(valor)
                || p.Telefono.StartsWith(valor)).Skip(inicio).Take(reg_por_pagina);
            cant = query.Count();
            foreach(var item in query)
            {
                if (item.Estado == true)
                    Estado = "<a onclick='editarInstructor(" + item.ID + ',' + 0 + ")' class='btn btn-success'>Activo</a>";
                else
                    Estado = "<a onclick='editarInstructor(" + item.ID + ',' + 0 + ")' class='btn btn-danger'>No activo</a>";
                dataFilter += "<tr>" +
                    "<td>" + item.Especialidad + "</td>" +
                    "<td>" + item.Documento + "</td>" +
                    "<td>" + item.Nombres + "</td>" +
                    "<td>" + item.Apellidos + "</td>" +
                    "<td>" + item.Telefono + "</td>" +
                    "<td>" + item.Email + "</td>" +
                    "<td>" + Estado + "</td>" +
                    "<td>" +
                    "<a data-toggle='modal' data-target='#modalAS' onclick='editarInstructor(" + item.ID + ',' + 1 + ")' class='btn btn-success'>Editar</a>" +
                    "</td>" +
                    "<td>" +
                    "<a data-toggle='modal' data-target='#modalAS' onclick='editarInstructor(" + item.ID + ',' + 1 + ")' class='btn btn-danger'>Eliminar</a>" +
                    "</td>" +
                 "</tr>";
            }
            object[] dataObj = { dataFilter, paginador };
            data.Add(dataObj);
            return data;
        }
    }
}
