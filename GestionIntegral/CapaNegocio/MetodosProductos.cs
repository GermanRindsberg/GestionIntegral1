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
        {//problemas con fk familia y diseño
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ProductoCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDiseño", tr.IdDiseño);
            Comando.Parameters.AddWithValue("@idFamilia", tr.IdFamilia);
            Comando.Parameters.AddWithValue("@valorUnico", tr.ValorUnico);
            Comando.Parameters.AddWithValue("@descripcionProducto", tr.DescripcionProducto);
            Comando.Parameters.AddWithValue("@lista1", tr.Lista1);
            Comando.Parameters.AddWithValue("@lista2", tr.Lista2);
            Comando.Parameters.AddWithValue("@lista3", tr.Lista3);
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
            Comando.Parameters.AddWithValue("@lista1", tr.Lista1);
            Comando.Parameters.AddWithValue("@lista2", tr.Lista2);
            Comando.Parameters.AddWithValue("@lista3", tr.Lista3);
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
                    Lista1 = LeerFilas.GetDouble(5),
                    Lista2 = LeerFilas.GetDouble(6),
                    Lista3 = LeerFilas.GetDouble(7),
                    Activo = LeerFilas.GetBoolean(8)
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
                tr.IdDiseño = LeerFilas.GetInt32(1);
                tr.IdFamilia = LeerFilas.GetInt32(2);
                tr.ValorUnico = LeerFilas.GetInt32(3);
                tr.DescripcionProducto = LeerFilas.GetString(4);
                tr.Lista1 = LeerFilas.GetDouble(5);
                tr.Lista2 = LeerFilas.GetDouble(6);
                tr.Lista3 = LeerFilas.GetDouble(7);
            }
            LeerFilas.Close();
            Conexion.Close();
            return tr;
        }



    }
}
