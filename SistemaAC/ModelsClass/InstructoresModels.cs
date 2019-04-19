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
                Apellidos = apellido,
                Nombres = nombre,
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
    }
}
