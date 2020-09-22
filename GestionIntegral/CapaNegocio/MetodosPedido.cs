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
        private SqlDataReader LeerFilas;


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
            Comando.CommandText = "PedidoRead";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idEstado", estado);
            Comando.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            Comando.Parameters.AddWithValue("@fechaHasta", fechaHasta);
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
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
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
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

        public Pedido CrearPedido(int id)
        {
            Pedido pe = new Pedido();

            Comando.Connection = Conexion;
            Comando.CommandText = "PedidoReadPorID";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idPedido", id);

            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            while (LeerFilas.Read())
            {
                pe.IdPedido = LeerFilas.GetInt32(0);
                pe.IdCliente = LeerFilas.GetInt32(1);
                pe.Total = LeerFilas.GetInt32(2);
                pe.IdEstado = LeerFilas.GetInt32(3);
                pe.IdDetallePedido = LeerFilas.GetInt32(4);
                pe.Fecha = LeerFilas.GetDateTime(5);
                pe.NumGuia = LeerFilas.GetString(6);
                pe.FechaPago = LeerFilas.GetDateTime(7);
                pe.MedioPago = LeerFilas.GetString(8);
                pe.FechaEnvio = LeerFilas.GetDateTime(9);
            }
            LeerFilas.Close();
            Conexion.Close();
            return pe;
        }

    }
}
