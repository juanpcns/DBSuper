using DBSuper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DBSuper.Classes
{
	public class clsEmpleado
	{
        private DBSuperEntities dbSuper = new DBSuperEntities();//Es el atributo (propiedad) para gestionar la conexión a la base de datos
        public EMPLeado empleado { get; set; }//propiedad para manipular la información en la base de datos: permite agregar,modificar o eliminar
        public string Insertar()
        {
            try
            {
                dbSuper.EMPLeadoes.Add(empleado);//Agregar el objeto a la lista de "empleadoes". Todavía no se agrega  a la base de datos
                dbSuper.SaveChanges();//guardar los cambios en la base de datos
                return "Empleado insertado correctamente";
            }
            catch(Exception ex)
            {
                return "Error al insertar el empleado: " + ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                //Antes de actualizar un elemento (empleado), se debe verificar que exista
                EMPLeado empl = Consultar(empleado.Documento);
                if (empl == null)
                {
                    return "El empleado con el documento ingresado no existe, por lo tanto no se puede actualizar";
                }
                //El empleado existe, se puede actualizar
                dbSuper.EMPLeadoes.AddOrUpdate(empleado);
                dbSuper.SaveChanges();
                return "Se actualizó el empleado correctamente;";
            }
            catch(Exception ex)
            {
                return "No se pudo actualizar el empleado: " + ex.Message;
            }

        }
        public List<EMPLeado> ConsultarTodos()
        {
            return dbSuper.EMPLeadoes
                .OrderBy(e => e.PrimerApellido)//ordena los empleados por medio del primer apellido
                .ToList();//Es una funcion que convierte una lista de datos a una lista de objetos
        }
        public EMPLeado Consultar(string Documento)
        {
            return dbSuper.EMPLeadoes.FirstOrDefault(e => e.Documento == Documento);
        }
        public string Eliminar()
        {
            try
            {
                //verificar que el empleado existe
                EMPLeado empl = Consultar(empleado.Documento);
                if (empl == null)
                {
                    return "El empleado con el documento ingresado no existe, por lo tanto no se puede eliminar";
                }
                //se elimina el empleado
                dbSuper.EMPLeadoes.Remove(empl);
                dbSuper.SaveChanges();
                return "Se eliminó el empleado correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el empleado: " + ex.Message;
            }
        }
        public string Eliminar(string Documento)
        {
            try
            {
                //verificar que el empleado existe}
                EMPLeado empl = Consultar(Documento);
                if (empl == null)
                {
                    return "El empleado con el documento ingresado no existe, por lo tanto no se puede eliminar";
                }
                //se elimina el empleado
                dbSuper.EMPLeadoes.Remove(empl);
                dbSuper.SaveChanges();
                return "Se eliminó el empleado correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el empleado: " + ex.Message;
            }

        }

    }
}