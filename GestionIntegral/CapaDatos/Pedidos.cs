using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{
    class Pedidos
    {
        private ConexionBBDD Conexion = new ConexionBBDD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;


        int idDetallePedido;
        int idPedido;
        float total;

        DateTime fecha;
        int idCliente ;

        int idEstado;
        string numGuia;
        DateTime? fechaPago;//uso el ? para que acepte valores nulos
        DateTime? fechaEnvio;//uso el ? para que acepte valores nulos
        string medioPago;


        public int IdDetallePedido { get => idDetallePedido; set => idDetallePedido = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdEstado { get => idEstado; set => idEstado = value; }
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public string NumGuia { get => numGuia; set => numGuia = value; }
        public string MedioPago { get => medioPago; set => medioPago = value; }
        public DateTime? FechaPago { get => fechaPago; set => fechaPago = value; }
        public float Total { get => total; set => total = value; }
        public DateTime? FechaEnvio { get => fechaEnvio; set => fechaEnvio = value; }

        public void InsertarPedido()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "InsertarPedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetallePedido", IdDetallePedido);
            Comando.Parameters.AddWithValue("@idCliente", IdCliente);
            Comando.Parameters.AddWithValue("@idEstado", IdEstado);
            Comando.Parameters.AddWithValue("@fecha", Fecha);
            Comando.Parameters.AddWithValue("@nroDeGuia", NumGuia);
            if (fechaPago == null)
            {
                Comando.Parameters.AddWithValue("@fechaPago", DBNull.Value);
            }
            else
            {
                Comando.Parameters.AddWithValue("@fechaPago", FechaPago);
            }
            Comando.Parameters.AddWithValue("@medioPago", MedioPago);
            Comando.Parameters.AddWithValue("@total", Total);
            if (FechaEnvio == null)
            {
                Comando.Parameters.AddWithValue("@fechaEnvio", DBNull.Value);
            }
            else
            {
                Comando.Parameters.AddWithValue("@fechaEnvio", FechaEnvio);
            }
            
            Comando.ExecuteNonQuery();
            Conexion.Desconectar();
        }

        public void EditarPedido()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EditarPedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idPedido", IdPedido);
            Comando.Parameters.AddWithValue("@idDetallePedido", IdDetallePedido);
            Comando.Parameters.AddWithValue("@idCliente", IdCliente);
            Comando.Parameters.AddWithValue("@idEstado", IdEstado);
            Comando.Parameters.AddWithValue("@nroDeGuia", NumGuia);
            if (fechaPago == null)
            {
                Comando.Parameters.AddWithValue("@fechaPago", DBNull.Value);
            }
            else
            {
                Comando.Parameters.AddWithValue("@fechaPago", FechaPago);
            }
            Comando.Parameters.AddWithValue("@medioPago", MedioPago);
            Comando.Parameters.AddWithValue("@total", Total);
            if (FechaEnvio == null)
            {
                Comando.Parameters.AddWithValue("@fechaEnvio", DBNull.Value);
            }
            else
            {
                Comando.Parameters.AddWithValue("@fechaEnvio", FechaEnvio);
            }
            Comando.ExecuteNonQuery();
            Conexion.Desconectar();
        }
    
        public void ListarPedido()
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "listarPedidos";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetallePedido", IdDetallePedido);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);


            foreach (DataRow fila in Tabla.Rows)
            {
                IdPedido=Convert.ToInt32(fila[0]);
                IdCliente = Convert.ToInt32(fila[1]);
                Total = float.Parse(fila[2].ToString());
                IdEstado= Convert.ToInt32(fila[3]);
                IdDetallePedido= Convert.ToInt32(fila[4]);
                Fecha = DateTime.Parse(fila[5].ToString());
                NumGuia = fila[6].ToString();
                FechaPago =Convert.ToDateTime(fila[7]);
                MedioPago=fila[8].ToString(); 
                FechaEnvio= Convert.ToDateTime(fila[9]);
            }
            leerFilas.Close();
            Conexion.Desconectar();

        }

        public int SeleccionarUltimoIdYSumarleUno()
        {
            int ultimoId=0;

            if (ultimoId == null)
            {
                ultimoId = 1;
            }
            
            Comando.Connection = Conexion.Conectar();
            Comando.Parameters.Clear();
            Comando.CommandText = "UltimoIdPedido";
            Comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = Comando.ExecuteReader();
            
            if (dr.Read())
            {
               ultimoId = Convert.ToInt32(dr[0]);
            }
            Conexion.Desconectar();
            dr.Close();
            return ultimoId;
        }

        public void ElminarPedido()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EliminarPedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idPedido", IdPedido);
            Comando.ExecuteNonQuery();
            Conexion.Desconectar();
        }

        public void EliminarDetallePedido()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EliminarDetallePedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetallePedido", IdDetallePedido);
            Comando.ExecuteNonQuery();
            Conexion.Desconectar();
        }

        public void ListarPedidoPorId(Cliente cl, Transporte tr)
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "listarPedidoCompletoPorId";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idPedido", IdPedido);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);


            foreach (DataRow fila in Tabla.Rows)
            {
                IdPedido = Convert.ToInt32(fila[0]);
                IdCliente = Convert.ToInt32(fila[1]);
                Total = float.Parse(fila[2].ToString());
                IdEstado = Convert.ToInt32(fila[3]);
                IdDetallePedido = Convert.ToInt32(fila[4]);
                Fecha = DateTime.Parse(fila[5].ToString());
                NumGuia = fila[6].ToString();

                if (fila[7] != DBNull.Value)
                FechaPago = Convert.ToDateTime(fila[7]);
                MedioPago = fila[8].ToString();
                if (fila[9] != DBNull.Value)
                    FechaEnvio = Convert.ToDateTime(fila[9]);

                cl.IdCliente= Convert.ToInt32(fila[10]);
                cl.RazonSocial= fila[11].ToString();
                cl.IdDireccion= Convert.ToInt32(fila[12]);
                cl.Tel1= fila[13].ToString();
                cl.Tel2= fila[14].ToString();
                cl.Activo= Convert.ToBoolean(fila[15]);
                cl.Email = fila[16].ToString();
                cl.Cuit = fila[17].ToString();
                cl.IdTransporte= Convert.ToInt32(fila[18]);
                cl.FechaAlta = Convert.ToDateTime(fila[19]);
                cl.Observaciones = fila[20].ToString();
                cl.TipoLista = Convert.ToInt32(fila[21]);

                
                tr.IdTransporte= Convert.ToInt32(fila[22]);
                tr.RazonSocial= fila[23].ToString();
                tr.IdDireccion = Convert.ToInt32(fila[24]);
                tr.Tel= fila[25].ToString();
                tr.Observaciones= fila[26].ToString();
                tr.Activo= Convert.ToBoolean(fila[27]);

            }

            leerFilas.Close();
            Conexion.Desconectar();

        }


        public DataTable ListarPedidoPorEstadoParaGrilla(int estado, DateTime fechaDesde, DateTime fechaHasta)
        {
                DataTable Tabla = new DataTable();
                Comando.Connection = Conexion.Conectar();
                Comando.Parameters.Clear();
                Comando.CommandText = "ListarPedidosPorEstado";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@idEstado", estado);
                Comando.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                Comando.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                Comando.CommandType = CommandType.StoredProcedure;
                leerFilas = Comando.ExecuteReader();
                Tabla.Load(leerFilas);
                leerFilas.Close();
                Conexion.Desconectar();
                return Tabla;
        }

        public DataTable ListarTodosLosPedidosParaGrilla(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.Conectar();
            Comando.Parameters.Clear();
            Comando.CommandText = "ListarTodosLosPedidos";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            Comando.Parameters.AddWithValue("@fechaHasta", fechaHasta);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            leerFilas.Close();
            Conexion.Desconectar();
            return Tabla;
        }

        public int DevolverPedidosPendientes(int idProducto)
        {
            int cantidad = 0;
            Comando.Connection = Conexion.Conectar();
            Comando.Parameters.Clear();
            Comando.CommandText = "DevolverPendientes";
            Comando.Parameters.AddWithValue("@idProducto", idProducto);
            Comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = Comando.ExecuteReader();

            foreach(DataRow row in dr)
            if (dr.Read())
            {
                cantidad += Convert.ToInt32(dr[0]);
            }
            Conexion.Desconectar();
            dr.Close();
            return cantidad;
        }
       
    }
}
