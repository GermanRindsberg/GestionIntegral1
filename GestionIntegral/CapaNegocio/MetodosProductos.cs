using GestionIntegral.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaNegocio
{
    class MetodosProductos:ConexionBBDD
    {
        private SqlCommand Comando = new SqlCommand();

        SqlDataReader LeerFilas;

        public void InsertarProducto(Producto tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ProductoCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDiseño", tr.IdDiseño);
            Comando.Parameters.AddWithValue("@idFamilia", tr.IdFamilia);
            Comando.Parameters.AddWithValue("@valorUnico", tr.ValorUnico);
            Comando.Parameters.AddWithValue("@descripcionProducto", tr.DescripcionProducto);
            Comando.Parameters.AddWithValue("@almacen", tr.Almacen);
            Comando.Parameters.AddWithValue("@taller1", tr.Taller1);
            Comando.Parameters.AddWithValue("@taller2", tr.Taller2);
            Comando.Parameters.AddWithValue("@taller3", tr.Taller3);
            Comando.Parameters.AddWithValue("@taller4", tr.Taller4);
            Comando.Parameters.AddWithValue("@stockMinimo", tr.StockMinimo);
            Comando.Parameters.AddWithValue("@stock", tr.Stock);
            Comando.Parameters.AddWithValue("@potencialStock", tr.PotencialStock);
            Comando.Parameters.AddWithValue("@pedidos", tr.Pedidos);
            Comando.Parameters.AddWithValue("@requeridos", tr.Requeridos);
            Comando.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EliminarProducto(Producto tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ProductoDelete";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idProducto", tr.IdProducto);
            Comando.ExecuteNonQuery();
          
            Conexion.Close();
        }

        public void EditarProducto(Producto tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ProductoUpdate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDiseño", tr.IdDiseño);
            Comando.Parameters.AddWithValue("@idFamilia", tr.IdFamilia);
            Comando.Parameters.AddWithValue("@valorUnico", tr.ValorUnico);
            Comando.Parameters.AddWithValue("@descripcionProducto", tr.DescripcionProducto);
            Comando.Parameters.AddWithValue("@almacen", tr.Almacen);
            Comando.Parameters.AddWithValue("@taller1", tr.Taller1);
            Comando.Parameters.AddWithValue("@taller2", tr.Taller2);
            Comando.Parameters.AddWithValue("@taller3", tr.Taller3);
            Comando.Parameters.AddWithValue("@taller4", tr.Taller4);
            Comando.Parameters.AddWithValue("@stockMinimo", tr.StockMinimo);
            Comando.Parameters.AddWithValue("@stock", tr.Stock);
            Comando.Parameters.AddWithValue("@potencialStock", tr.PotencialStock);
            Comando.Parameters.AddWithValue("@pedidos", tr.Pedidos);
            Comando.Parameters.AddWithValue("@requeridos", tr.Requeridos);
            Comando.Parameters.AddWithValue("@idProducto", tr.IdProducto);
            Comando.Parameters.AddWithValue("@activo", tr.Activo);
            Comando.ExecuteNonQuery();
     
            Conexion.Close();

        }

        public DataTable ListarProducto(string condicion)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion;
            Comando.CommandText = "ProductoRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@condicion", condicion);

            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.Close();
            return Tabla;

        }

        public Producto CrearProducto(int id)
        {
            Producto tr = new Producto();

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ProductoRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@condicion", id);
            LeerFilas = Comando.ExecuteReader();
            List<Producto> ListaGenerica = new List<Producto>();
            while (LeerFilas.Read())
            {


                tr.IdProducto = LeerFilas.GetInt32(0);
                tr.IdFamilia = LeerFilas.GetInt32(1);
                tr.IdDiseño = LeerFilas.GetInt32(2);
                tr.ValorUnico = LeerFilas.GetInt32(3);
                tr.DescripcionProducto = LeerFilas.GetString(4);
                tr.Almacen = LeerFilas.GetInt32(5);
                tr.Taller1 = LeerFilas.GetInt32(6);
                tr.Taller2 = LeerFilas.GetInt32(7);
                tr.Taller3 = LeerFilas.GetInt32(8);
                tr.Taller4 = LeerFilas.GetInt32(9);
                tr.StockMinimo = LeerFilas.GetInt32(10);
                tr.Stock = LeerFilas.GetInt32(11);
                tr.PotencialStock = LeerFilas.GetInt32(12);
                tr.Pedidos = LeerFilas.GetInt32(13);
                tr.Requeridos = LeerFilas.GetInt32(14);
                tr.PliegosRequeridos= LeerFilas.GetInt32(15);
                tr.PliegosSinStock = LeerFilas.GetInt32(16);
                tr.PapelRequerido = LeerFilas.GetInt32(17);
                tr.PapelSinStock = LeerFilas.GetInt32(18);
                tr.Activo = LeerFilas.GetBoolean(19);

            }
            LeerFilas.Close();
            Conexion.Close();
            return tr;
        }

        public Boolean BuscarRepetidosProducto(string valorAbuscar)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion;

            Conexion.Open();
            Comando.CommandText = "BuscarExistenciaProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@valorAbuscar", valorAbuscar);
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            if (Tabla.Rows.Count > 0)
            {
                Conexion.Close();
                return true;
            }
            else
            {
                Conexion.Close();
                return false;
            }


        }


    }
}
