using GestionIntegral.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaNegocio
{
    class MetodosPedido: ConexionBBDD
    {
   
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;


        public void InsertarPedido(Pedido pe)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "PedidoCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetallePedido", pe.IdDetallePedido);
            Comando.Parameters.AddWithValue("@idCliente", pe.IdCliente);
            Comando.Parameters.AddWithValue("@idEstado", pe.IdEstado);
            Comando.Parameters.AddWithValue("@fecha", pe.Fecha);
            Comando.Parameters.AddWithValue("@nroDeGuia", pe.NumGuia);
            if (pe.FechaPago == null)
            {
                Comando.Parameters.AddWithValue("@fechaPago", DBNull.Value);
            }
            else
            {
                Comando.Parameters.AddWithValue("@fechaPago", pe.FechaPago);
            }
            Comando.Parameters.AddWithValue("@medioPago", pe.MedioPago);
            Comando.Parameters.AddWithValue("@total", pe.Total);
            if (pe.FechaEnvio == null)
            {
                Comando.Parameters.AddWithValue("@fechaEnvio", DBNull.Value);
            }
            else
            {
                Comando.Parameters.AddWithValue("@fechaEnvio", pe.FechaEnvio);
            }

            Comando.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EditarPedido(Pedido pe)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "PedidoUpdate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idPedido", pe.IdPedido);
            Comando.Parameters.AddWithValue("@idDetallePedido", pe.IdDetallePedido);
            Comando.Parameters.AddWithValue("@idCliente", pe.IdCliente);
            Comando.Parameters.AddWithValue("@idEstado", pe.IdEstado);
            Comando.Parameters.AddWithValue("@nroDeGuia", pe.NumGuia);
            if (pe.FechaPago == null)
            {
                Comando.Parameters.AddWithValue("@fechaPago", DBNull.Value);
            }
            else
            {
                Comando.Parameters.AddWithValue("@fechaPago", pe.FechaPago);
            }
            Comando.Parameters.AddWithValue("@medioPago", pe.MedioPago);
            Comando.Parameters.AddWithValue("@total", pe.Total);
            if (pe.FechaEnvio == null)
            {
                Comando.Parameters.AddWithValue("@fechaEnvio", DBNull.Value);
            }
            else
            {
                Comando.Parameters.AddWithValue("@fechaEnvio", pe.FechaEnvio);
            }
            Comando.ExecuteNonQuery();
            Conexion.Close();
        }

        public DataTable ListarPedidoPorEstadoParaGrilla(int estado, DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.Parameters.Clear();
            Comando.CommandText = "PedidosRead";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idEstado", estado);
            Comando.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            Comando.Parameters.AddWithValue("@fechaHasta", fechaHasta);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            leerFilas.Close();
            Conexion.Close();
            return Tabla;
        }

        public int DevolverPedidosPendientes(int idProducto)
        {
            int cantidad = 0;
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.Parameters.Clear();
            Comando.CommandText = "DevolverPendientes";
            Comando.Parameters.AddWithValue("@idProducto", idProducto);
            Comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = Comando.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0] == DBNull.Value)
                {

                }
                else
                {
                    cantidad = Convert.ToInt32(dr[0]);
                }
            }
            Conexion.Close();
            dr.Close();
            return cantidad;
        }

        public DataTable ListarResumenDePedidos(int estado)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.Parameters.Clear();
            Comando.CommandText = "ListarResumenDeVentasPorProducto";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idEstado", estado);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            leerFilas.Close();
            Conexion.Close();
            return Tabla;
        }

        public void EliminarPedido(Pedido pe)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "PedidoDelete";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idCliente", pe.IdPedido);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

    }
}
