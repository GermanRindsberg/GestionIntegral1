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
    class MetodosOT: ConexionBBDD
    {
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        public void InsertarOT(OrdenDeTrabajos or)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "OTCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetalleOT", or.IdDetalleOT);
            Comando.Parameters.AddWithValue("@nombreTaller", or.NombreTaller);
            Comando.Parameters.AddWithValue("@fechaIngreso", or.FechaEnvio);
            if (or.FechaRetiro == null)
            {
                Comando.Parameters.AddWithValue("@fechaRetiro", DBNull.Value);
            }
            else
            {
                Comando.Parameters.AddWithValue("@fechaRetiro", or.FechaRetiro);
            }
            Comando.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EditarOT(OrdenDeTrabajos or)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "OTUpdate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idOT", or.IdOT);
            Comando.Parameters.AddWithValue("@idDetalleOT", or.IdDetalleOT);
            Comando.Parameters.AddWithValue("@nombreTaller", or.NombreTaller);
            Comando.Parameters.AddWithValue("@fechaIngreso", or.FechaEnvio);
            if (or.FechaRetiro == null)
            {
                Comando.Parameters.AddWithValue("@fechaRetiro", DBNull.Value);
            }
            else
            {
                Comando.Parameters.AddWithValue("@fechaRetiro", or.FechaRetiro);
            }
            Comando.Parameters.AddWithValue("@activo", or.Activo);
            Comando.Parameters.AddWithValue("@estado", or.Estado);
            Comando.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EliminarOT(OrdenDeTrabajos or)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "OTDelete";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idOT", or.IdOT);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

        public OrdenDeTrabajos CrearOT(int id)
        {
            OrdenDeTrabajos or = new OrdenDeTrabajos(id);

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "OTReadPorID";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idOT", id);
            LeerFilas = Comando.ExecuteReader();
            while (LeerFilas.Read())
            {
                or.IdOT = LeerFilas.GetInt32(0);
                or.IdDetalleOT = LeerFilas.GetInt32(1);
                or.NombreTaller = LeerFilas.GetString(2);
                or.FechaEnvio = LeerFilas.GetDateTime(3);
                if (!LeerFilas.IsDBNull(4))
                {
                    or.FechaRetiro = LeerFilas.GetDateTime(4);
                }
             
                or.Activo = LeerFilas.GetBoolean(5);

            }
            LeerFilas.Close();
            Conexion.Close();
            return or;
        }

        public DataTable ListarOTParaGrilla(int estado)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "OTRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@estado", estado);
            
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.Close();
            return Tabla;
        }

    }
}
