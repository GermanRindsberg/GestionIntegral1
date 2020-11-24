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
    class MetodosCliente : ConexionBBDD
    {
        private SqlCommand Comando = new SqlCommand();
        
        SqlDataReader LeerFilas;

        public void InsertarClientes(Cliente cl)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ClientesCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@razonSocial", cl.RazonSocial);
            Comando.Parameters.AddWithValue("@idDireccion", cl.IdDireccion);
            Comando.Parameters.AddWithValue("@tel1", cl.Tel1);
            Comando.Parameters.AddWithValue("@tel2", cl.Tel2);
            Comando.Parameters.AddWithValue("@activo", true);
            Comando.Parameters.AddWithValue("@email", cl.Email);
            Comando.Parameters.AddWithValue("@cuit", cl.Cuit);
            Comando.Parameters.AddWithValue("@idTransporte", cl.IdTransporte);
            Comando.Parameters.AddWithValue("@fechaAlta", cl.FechaAlta);
            Comando.Parameters.AddWithValue("@observaciones", cl.Observaciones);
            Comando.Parameters.AddWithValue("@tipoLista", cl.TipoLista);

            Comando.ExecuteNonQuery();
           
            Conexion.Close();
        }

        public void EliminarClientes(Cliente cl)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ClienteDelete";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idCliente", cl.IdCliente);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

        public void EditarClientes(Cliente cl)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ClientesUpdate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idCliente", cl.IdCliente);
            Comando.Parameters.AddWithValue("@razonSocial", cl.RazonSocial);
            Comando.Parameters.AddWithValue("@idDireccion", cl.IdDireccion);
            Comando.Parameters.AddWithValue("@tel1", cl.Tel1);
            Comando.Parameters.AddWithValue("@tel2", cl.Tel2);
            Comando.Parameters.AddWithValue("@activo", cl.Activo);
            Comando.Parameters.AddWithValue("@email", cl.Email);
            Comando.Parameters.AddWithValue("@cuit", cl.Cuit);
            Comando.Parameters.AddWithValue("@idTransporte", cl.IdTransporte);
            Comando.Parameters.AddWithValue("@fechaAlta", cl.FechaAlta);
            Comando.Parameters.AddWithValue("@observaciones", cl.Observaciones);
            Comando.Parameters.AddWithValue("@tipoLista", cl.TipoLista);
            Comando.ExecuteNonQuery();
            Conexion.Close();

        }

        public List<Cliente> ListarClientes(string condicion, string activo)
        {
            Comando.Connection = Conexion;

            Conexion.Open();
            Comando.CommandText = "ClientesRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@activo", activo);
            Comando.Parameters.AddWithValue("@condicion", condicion);
            Comando.Parameters.AddWithValue("@id","");
            LeerFilas = Comando.ExecuteReader();
            List<Cliente> ListaGenerica = new List<Cliente>();
            while (LeerFilas.Read())
            {
                ListaGenerica.Add(new Cliente
                {
                    IdCliente = LeerFilas.GetInt32(0),
                    RazonSocial = LeerFilas.GetString(1),
                    IdDireccion = LeerFilas.GetInt32(2),
                    Tel1 = LeerFilas.GetString(3),
                    Tel2 = LeerFilas.GetString(4),
                    Activo = LeerFilas.GetBoolean(5),
                    Email = LeerFilas.GetString(6),
                    Cuit = LeerFilas.GetString(7),
                    IdTransporte = LeerFilas.GetInt32(8),
                    FechaAlta = LeerFilas.GetDateTime(9),
                    Observaciones = LeerFilas.GetString(10),
                    TipoLista = LeerFilas.GetInt32(11)
                }); ;
            }
            LeerFilas.Close();
            Conexion.Close();
            return ListaGenerica;
        }

        public Cliente CrearCliente(int id)
        {
            Cliente cl = new Cliente();

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ClientesRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@activo", 1);
            Comando.Parameters.AddWithValue("@condicion", " ");
            Comando.Parameters.AddWithValue("@id", id);
     
            LeerFilas = Comando.ExecuteReader();
            
            while (LeerFilas.Read())
            {
                cl.IdCliente = LeerFilas.GetInt32(0);
                cl.RazonSocial = LeerFilas.GetString(1);
                cl.IdDireccion = LeerFilas.GetInt32(2);
                cl.Tel1 = LeerFilas.GetString(3);
                cl.Tel2 = LeerFilas.GetString(4);
                cl.Activo = LeerFilas.GetBoolean(5);
                cl.Email = LeerFilas.GetString(6);
                cl.Cuit = LeerFilas.GetString(7);
                cl.IdTransporte = LeerFilas.GetInt32(8);
                cl.FechaAlta = LeerFilas.GetDateTime(9);
                cl.Observaciones = LeerFilas.GetString(10);
                cl.TipoLista = LeerFilas.GetInt32(11);
            }
            LeerFilas.Close();
            Conexion.Close();

            return cl;
        }
    }
}
