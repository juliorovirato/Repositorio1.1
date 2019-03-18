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
    }
}
