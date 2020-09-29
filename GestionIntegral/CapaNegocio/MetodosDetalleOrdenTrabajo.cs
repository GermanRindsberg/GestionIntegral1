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
    class MetodosDetalleOrdenTrabajo : ConexionBBDD
    {

        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        public void InsertarDetalleOT(DetalleOrdenTrabajo ot)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "DetalleOTCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetalleOT", ot.IdDetalleOT);
            Comando.Parameters.AddWithValue("@idProducto", ot.IdProducto);
            Comando.Parameters.AddWithValue("@cantidad", ot.Cantidad);
            Comando.ExecuteNonQuery();
            Conexion.Close();
        }

        public DataTable ListarDetallePedido(DetalleOrdenTrabajo ot)
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ListarDetalleOT";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idOT", ot.IdDetalleOT);
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.Close();
            return Tabla;
        }

        public DataTable ListarDetallePedidoPorId(int idDetalle)
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ListarDetalleOT";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idOT", idDetalle);
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();

            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.Close();
            return Tabla;

        }

        public int UltimoIdDetallePedido()
        {
            DataTable Tabla = new DataTable();
            int ultimoId = 0;

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "DetalleOTSeleccionarUltimoId";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            if (Tabla.Rows.Count == 0)
            {
                ultimoId = 1;
                return ultimoId;
            }
            foreach (DataRow fila in Tabla.Rows)
            {
                ultimoId = Convert.ToInt32(fila[0]);
            }
            LeerFilas.Close();
            Conexion.Close();
            return ultimoId;
        }

        public void EliminarDetalleOt(int idDetalleOT)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "DetalleOTEliminar";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetalleOT", idDetalleOT);
            Comando.ExecuteNonQuery();
            Conexion.Close();
        }

    }
}
