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
    class MetodosTransporte : ConexionBBDD
    {
        private SqlCommand Comando = new SqlCommand();

        SqlDataReader LeerFilas;

        public void InsertarTransportes(Transporte tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "TransporteCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@razonSocial", tr.RazonSocial);
            Comando.Parameters.AddWithValue("@idDireccion", tr.IdDireccion);
            Comando.Parameters.AddWithValue("@tel1", tr.Tel);
            Comando.Parameters.AddWithValue("@activo", tr.Activo);
            Comando.Parameters.AddWithValue("@observaciones", tr.Observaciones);
            Comando.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EliminarTransportes(Transporte tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "TransporteDelete";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idTransporte", tr.IdTransporte);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

        public void EditarTransporte(Transporte tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "TransporteUpdate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idTransporte", tr.IdTransporte);
            Comando.Parameters.AddWithValue("@razonSocial", tr.RazonSocial);
            Comando.Parameters.AddWithValue("@idDireccion", tr.IdDireccion);
            Comando.Parameters.AddWithValue("@tel1", tr.Tel);
            Comando.Parameters.AddWithValue("@activo", tr.Activo);
            Comando.Parameters.AddWithValue("@observaciones", tr.Observaciones);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();

        }

        public DataTable ListarTransporte(string condicion, string activo)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "TransporteRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@activo", activo);
            Comando.Parameters.AddWithValue("@condicion", condicion);
            DataTable ListaGenerica = new DataTable();
            ListaGenerica.Load(Comando.ExecuteReader());
            Conexion.Close();
            return ListaGenerica;
        }


        public Transporte CrearTransporte(string id)
        {
            Transporte tr = new Transporte();

            Comando.Connection = Conexion;
            Comando.CommandText = "TransporteRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@activo", 1);
            Comando.Parameters.AddWithValue("@condicion", id);
            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            List<Transporte> ListaGenerica = new List<Transporte>();
            while (LeerFilas.Read())
            {
                tr.IdTransporte = LeerFilas.GetInt32(0);
                tr.RazonSocial = LeerFilas.GetString(1);
                tr.IdDireccion = LeerFilas.GetInt32(2);
                tr.Tel = LeerFilas.GetString(3);
                tr.Observaciones = LeerFilas.GetString(11);
                tr.Activo = LeerFilas.GetBoolean(12);
              
             
            }
            LeerFilas.Close();
            Conexion.Close();
          

            return tr;
        }
    }
}
