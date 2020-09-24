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
    class MetodosTaller : ConexionBBDD
    {
        private SqlCommand Comando = new SqlCommand();

        SqlDataReader LeerFilas;

        public void InsertarTaller(Taller tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "TallerCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@razonSocial", tr.RazonSocial);
            Comando.Parameters.AddWithValue("@idDireccion", tr.IdDireccion);
            Comando.Parameters.AddWithValue("@tel", tr.Telefono);
            Comando.Parameters.AddWithValue("@activo", tr.Activo);
            Comando.Parameters.AddWithValue("@observaciones", tr.Observaciones);
            Comando.ExecuteNonQuery();
    
            Conexion.Close();
        }

        public void EliminarTaller(Taller tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "TallerDelete";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idTaller", tr.Id);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

        public void EditarTaller(Taller tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "TallerUpdate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idTalleres", tr.Id);
            Comando.Parameters.AddWithValue("@razonSocial", tr.RazonSocial);
            Comando.Parameters.AddWithValue("@idDireccion", tr.IdDireccion);
            Comando.Parameters.AddWithValue("@tel", tr.Telefono);
            Comando.Parameters.AddWithValue("@activo", tr.Activo);
            Comando.Parameters.AddWithValue("@observaciones", tr.Observaciones);
            Comando.ExecuteNonQuery();
            Conexion.Close();

        }

        public DataTable ListarTaller(string condicion, string activo)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "TallerRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@activo", activo);
            Comando.Parameters.AddWithValue("@condicion", condicion);
            DataTable ListaGenerica = new DataTable();
            ListaGenerica.Load(Comando.ExecuteReader());
            Conexion.Close();
            return ListaGenerica;
        }

        public Taller CrearTaller(string id)
        {
            Taller tr = new Taller();

            Comando.Connection = Conexion;
            Comando.CommandText = "TallerRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@activo", 1);
            Comando.Parameters.AddWithValue("@condicion", id);

            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            List<Taller> ListaGenerica = new List<Taller>();
            while (LeerFilas.Read())
            {
                tr.Id = LeerFilas.GetInt32(0);
                tr.RazonSocial = LeerFilas.GetString(1);
                tr.IdDireccion = LeerFilas.GetInt32(2);
                tr.Telefono = LeerFilas.GetString(3);
                tr.Observaciones = LeerFilas.GetString(11);
                tr.Activo = LeerFilas.GetBoolean(12);
                

            }
            LeerFilas.Close();
            Conexion.Close();


            return tr;
        }


    }
}
