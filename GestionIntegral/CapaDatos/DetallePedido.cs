using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{
    class DetallePedido
    {
        private ConexionBBDD Conexion = new ConexionBBDD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;
        

        int idDetallePedido;
        int idProducto;
        float precioUnitario;
        int cantidad;
        float subtotal;
        
        

        public int IdDetallePedido { get => idDetallePedido; set => idDetallePedido = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public float PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float Subtotal { get => subtotal; set => subtotal = value; }
        
        

        public void InsertarDetallePedido()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "InsertarDetallePedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetallePedido", IdDetallePedido);
            Comando.Parameters.AddWithValue("@idProducto", IdProducto);
            Comando.Parameters.AddWithValue("@precioUnitario", PrecioUnitario);
            Comando.Parameters.AddWithValue("@cantidad", Cantidad);
            Comando.Parameters.AddWithValue("@subtotal", Subtotal);
            
            
            Comando.ExecuteNonQuery();
            Conexion.Desconectar();
        }

        public DataTable ListarDetallePedido()
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "ListarDetallePedido";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idPedido", IdDetallePedido);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            leerFilas.Close();
            Conexion.Desconectar();
            return Tabla;
        }

        public DataTable ListarDetallePedidoPorId()
        {
            DataTable Tabla = new DataTable();
            Producto pr = new Producto();
        

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "ListarDetallePedido";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idPedido", IdDetallePedido);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            
            Tabla.Load(leerFilas);


            foreach (DataRow fila in Tabla.Rows)
            {
                IdProducto = Convert.ToInt32(fila[0]);
                pr.DescripcionProducto = fila[1].ToString();
                PrecioUnitario = float.Parse(fila[2].ToString());
                Cantidad = Convert.ToInt32(fila[3]);
                Subtotal = float.Parse(fila[4].ToString());
            }
            leerFilas.Close();
            Conexion.Desconectar();
            return Tabla;

        }

        public void UltimoIdDetallePedido()
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "UltimoIdPedido";
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            foreach (DataRow fila in Tabla.Rows)
            {
                IdDetallePedido = Convert.ToInt32(fila[0]);
            }
            leerFilas.Close();
            Conexion.Desconectar();
        }

        public void EditarDetallePedido()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EditarDetallePedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetallePedido", IdDetallePedido);
            Comando.Parameters.AddWithValue("@idProducto", IdProducto);
            Comando.Parameters.AddWithValue("@precioUnitario", PrecioUnitario);
            Comando.Parameters.AddWithValue("@cantidad", Cantidad);
            Comando.Parameters.AddWithValue("@subtotal", Subtotal);
            
            Comando.ExecuteNonQuery();
            Conexion.Desconectar();
        }
        public void EliminarDetallePedido()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EliminarDetalle";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetallePedido", IdDetallePedido);
            Comando.ExecuteNonQuery();
            Conexion.Desconectar();
        }
    }
}
