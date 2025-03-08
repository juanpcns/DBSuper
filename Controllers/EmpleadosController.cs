using DBSuper.Classes;
using DBSuper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DBSuper.Controllers
{
    [RoutePrefix("api/Empleados")]
    public class EmpleadosController : ApiController
    {
        //GET: Se utiliza para consultar información, no se debe modificar la base de datos
        //POST: SE utiliza para insertar información en la base de datos
        //PUT: Se utiliza para modificar (actualizar) informción en la base de datos
        //Delete: Se utiliza para eliminar información en la base de datos
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<EMPLeado> ConsultarTodos()
        {
            //Se crea una instanica de la clase clsEmpleado
            clsEmpleado Empleado = new clsEmpleado();
            //se invoca el métoso ConsultarTodos() de la clase clsEmpleado
            return Empleado.ConsultarTodos();
        }
        [HttpGet]
        [Route("ConsultarxDocumento")]
        public EMPLeado ConsultarxDocumento(string Documento)
        {
            clsEmpleado Empleado = new clsEmpleado();
            return Empleado.Consultar(Documento);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] EMPLeado empleado) //frombody quiere decir que los argumentos vienen de la vista, como html, json
        {
            clsEmpleado Empleado = new clsEmpleado();
            //Se pasa la propiedad empleado al objeto de la clase clsEmplead
            Empleado.empleado = empleado;
            return Empleado.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] EMPLeado empleado)
        {
            clsEmpleado Empleado = new clsEmpleado();
            Empleado.empleado = empleado;
            return Empleado.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] EMPLeado empleado)
        {
            clsEmpleado Empleado = new clsEmpleado();
            Empleado.empleado = empleado;
            return Empleado.Eliminar();
            
        }
        [HttpDelete]
        [Route("EliminarxDocumento")]
        public string EliminarxDocumento(string Documento)
        {
            clsEmpleado Empleado = new clsEmpleado();
            return Empleado.Eliminar(Documento);

        }

    }
}