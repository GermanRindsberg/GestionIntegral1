using GestionIntegral.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GestionIntegral.CapaNegocio
{
    class MetodosDireccion: ConexionBBDD
    {
        private SqlCommand Comando = new SqlCommand();
        SqlDataReader LeerFilas;

        //Metodos CRUD

        public List<Direccion> ListarDireccion(string condicion)//la condicion seria la id en este caso
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "DireccionRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDireccion", condicion);
            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            List<Direccion> ListaGenerica = new List<Direccion>();
            while (LeerFilas.Read())
            {
                ListaGenerica.Add(new Direccion
                {
                    IdDireccion = LeerFilas.GetInt32(0),
                    IdLocalidad = LeerFilas.GetInt32(1),
                    Calle = LeerFilas.GetString(2),
                    Numero = LeerFilas.GetString(3),
                    Depto = LeerFilas.GetString(4),
                    Piso = LeerFilas.GetString(5),
                    NombreLocalidad = LeerFilas.GetString(8),
                    CodigoPostal = LeerFilas.GetString(9),
                    NombreProvincia = LeerFilas.GetString(10)
                });
            }
            LeerFilas.Close();
            Conexion.Close();
            return ListaGenerica;
        }

        public void InsertarDireccion(Direccion dir)
        {
         
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "DireccionCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idLocalidad", dir.IdLocalidad);
            Comando.Parameters.AddWithValue("@calle", dir.Calle);
            Comando.Parameters.AddWithValue("@numero", dir.Numero);
            Comando.Parameters.AddWithValue("@depto", dir.Depto);
            Comando.Parameters.AddWithValue("@piso", dir.Piso);
            Comando.ExecuteNonQuery();
          
            Conexion.Close();
          
        }

        public void EditarDireccion(Direccion dir)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "DireccionUpdate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@id", dir.IdDireccion);
            Comando.Parameters.AddWithValue("@idLocalidad", dir.IdLocalidad);
            Comando.Parameters.AddWithValue("@calle", dir.Calle);
            Comando.Parameters.AddWithValue("@numero", dir.Numero);
            Comando.Parameters.AddWithValue("@departamento", dir.Depto);
            Comando.Parameters.AddWithValue("@piso", dir.Piso);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();

        }

        public void EliminarDireccion(Direccion dir)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "DireccionDelete";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idDireccion", dir.IdDireccion);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

        public Direccion CrearDireccion(int id)//metodo para crear un objeto con los datos rellenados y asi poder leerlos
        {
            Direccion dir = new Direccion();

            Comando.Connection = Conexion;
            Comando.CommandText = "DireccionRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDireccion", id);
            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();

            while (LeerFilas.Read())
            {
                dir.IdDireccion = LeerFilas.GetInt32(0);
                dir.IdLocalidad = LeerFilas.GetInt32(1);
                dir.Calle = LeerFilas.GetString(2);
                dir.Numero = LeerFilas.GetString(3);
                dir.Piso = LeerFilas.GetString(4);
                dir.Depto = LeerFilas.GetString(5);
                dir.IdLocalidad = LeerFilas.GetInt32(6);
                dir.IdProvincia = LeerFilas.GetInt32(7);
                dir.NombreLocalidad = LeerFilas.GetString(8);
                dir.CodigoPostal = Convert.ToString(LeerFilas.GetInt32(9));
                dir.NombreProvincia = LeerFilas.GetString(11);
            }
            LeerFilas.Close();
            Conexion.Close();

            return dir;
        }

        public int UltimoIdDireccion()
        {
            DataTable Tabla = new DataTable();
            int ultimoId = 0;

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.Parameters.Clear();
            Comando.CommandText = "DireccionSeleccionarUltimoId";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            foreach (DataRow fila in Tabla.Rows)
            {
                ultimoId = Convert.ToInt32(fila[0]);
            }
            LeerFilas.Close();
            Conexion.Close();
            return ultimoId;
        }

        public void ListarCodigoPostal(TextBox tx, int idLocalidad)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ListarCodigoPostal";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idLocalidad", idLocalidad);
            Comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = Comando.ExecuteReader();

            while (dr.Read())
            {
                tx.Text = dr[0].ToString();
            }
            Conexion.Close();

        }

    }
}
