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
            Comando.Parameters.AddWithValue("@idProducto", tr.IdProducto);
            Comando.ExecuteNonQuery();
     
            Conexion.Close();

        }

        public List<Producto> ListarProducto(string condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ProductoRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@condicion", condicion);

            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            List<Producto> ListaGenerica = new List<Producto>();
         
            while (LeerFilas.Read())
            {
                ListaGenerica.Add(new Producto
                {
                    IdProducto = LeerFilas.GetInt32(0),
                    IdFamilia = LeerFilas.GetInt32(1),
                    IdDiseño = LeerFilas.GetInt32(2),
                    ValorUnico = LeerFilas.GetInt32(3),
                    DescripcionProducto = LeerFilas.GetString(4),
                    
                    Almacen= LeerFilas.GetInt32(5),
                    Taller1 = LeerFilas.GetInt32(6),
                    Taller2 = LeerFilas.GetInt32(7),
                    Taller3 = LeerFilas.GetInt32(8),
                    Taller4 = LeerFilas.GetInt32(9),
                    StockMinimo = LeerFilas.GetInt32(10),
                    Stock = LeerFilas.GetInt32(11),
                    PotencialStock = LeerFilas.GetInt32(12),
                    Pedidos = LeerFilas.GetInt32(13),
                    Requeridos = LeerFilas.GetInt32(14),
                    Activo = LeerFilas.GetBoolean(15)

                }); ;
            }
            LeerFilas.Close();
            Conexion.Close();
            return ListaGenerica;
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
                tr.Activo = LeerFilas.GetBoolean(5);
                tr.StockMinimo = LeerFilas.GetInt32(6);
                tr.Almacen = LeerFilas.GetInt32(7);
                tr.Stock = LeerFilas.GetInt32(8);
                tr.PotencialStock = LeerFilas.GetInt32(9);
                tr.Pedidos = LeerFilas.GetInt32(10);
                tr.Requeridos = LeerFilas.GetInt32(11);


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
