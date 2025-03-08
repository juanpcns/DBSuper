using DBSuper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DBSuper.Clases
{
	public class clsProducto
	{
		private DBSuperEntities dbSuper = new DBSuperEntities();//establece conexión con la base de datos
		public PRODucto producto { get; set; }
		public string Insertar()
		{
			try
			{
                dbSuper.PRODuctoes.Add(producto);
                dbSuper.SaveChanges();
                return "Producto insertado correctamente";
            }
			catch(Exception ex)
			{
				return "Error al insertar el producto: " + ex.Message;
			}
		}
		public string Actualizar()
		{
			try
			{
				PRODucto prod = Consultar(producto.Codigo);
				if (prod == null)
				{
					return "El Código del producto no existe en la base de datos";
				}
				dbSuper.PRODuctoes.AddOrUpdate(producto);
				dbSuper.SaveChanges();
				return "El producto se actualizó correctamente";
			}
			catch (Exception ex)
			{
				return "Hubo un error al actualizar el producto: " + ex.Message;
			}
		}
		public PRODucto Consultar(int Codigo)
		{
			return dbSuper.PRODuctoes.FirstOrDefault(p => p.Codigo == Codigo);
		}
		public List<PRODucto> ConsultarTodos()
		{
			return dbSuper.PRODuctoes
				.OrderBy(p => p.Nombre)
				.ToList();
		}
		public List<PRODucto> ConsultarxTipoPRoducto(int CodTipoProducto)
        {
            return dbSuper.PRODuctoes
				.Where(p => p.CodigoTipoProducto == CodTipoProducto)
                .OrderBy(p => p.Nombre)
                .ToList();

        }
		public string Eliminar()
		{
			try
			{
				PRODucto prod = Consultar(producto.Codigo);
				if (prod == null)
				{
					return "El código del producto no existe en la base de datos";
				}
				dbSuper.PRODuctoes.Remove(prod);
				dbSuper.SaveChanges();
				return "El producto se ha eliminado de la base de datos";
			}
			catch (Exception ex)
			{
				return "Hubo un error al eliminar el producto: " + ex.Message; 
			}
		}
        public string Eliminar(int Codigo)
        {
            try
            {
                PRODucto prod = Consultar(Codigo);
                if (prod == null)
                {
                    return "El código del producto no existe en la base de datos";
                }
                dbSuper.PRODuctoes.Remove(prod);
                dbSuper.SaveChanges();
                return "El producto se ha eliminado de la base de datos";
            }
            catch (Exception ex)
            {
                return "Hubo un error al eliminar el producto: " + ex.Message;
            }
        }
		public string ModificarEsado(int Codigo, bool Activo)
		{
			try
			{
				PRODucto prod = Consultar(Codigo);
				if (prod == null)
				{
					return "El código del producto no exite en la base de datos";
				}
				prod.Activo = Activo;
				dbSuper.SaveChanges();
				if (Activo)
				{
					return "Se activó correctamente el producto";
				}
				return "Se inactivó correctamente el producto";
			}
			catch(Exception ex)
			{
				return "Hubo un error al modificar el estado del producto: " + ex.Message;
			}
		}
    }
}