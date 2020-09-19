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
    class MetodosDetallePedido: ConexionBBDD
    {
        
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;

        public void InsertarDetallePedido(DetallePedido de)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            
            Comando.CommandText = "InsertarDetallePedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetallePedido", de.IdDetallePedido);
            Comando.Parameters.AddWithValue("@idProducto", de. IdProducto);
            Comando.Parameters.AddWithValue("@precioUnitario", de.PrecioUnitario);
            Comando.Parameters.AddWithValue("@cantidad", de.Cantidad);
            Comando.Parameters.AddWithValue("@subtotal", de.Subtotal);

            Comando.ExecuteNonQuery();
            Conexion.Close();
        }

        public DataTable ListarDetallePedido(DetallePedido de)
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ListarDetallePedido";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idPedido", de.IdDetallePedido);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            leerFilas.Close();
            Conexion.Close();
            return Tabla;
        }

        public DataTable ListarDetallePedidoPorId(DetallePedido de)
        {
            DataTable Tabla = new DataTable();
            Producto pr = new Producto();

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "ListarDetallePedido";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idPedido", de.IdDetallePedido);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();

            Tabla.Load(leerFilas);
            
            foreach (DataRow fila in Tabla.Rows)
            {
                pr.IdProducto = Convert.ToInt32(fila[0]);
                pr.DescripcionProducto = fila[1].ToString();
                de.PrecioUnitario = float.Parse(fila[2].ToString());
                de.Cantidad = Convert.ToInt32(fila[3]);
                de.Subtotal = float.Parse(fila[4].ToString());
            }
            leerFilas.Close();
            Conexion.Close();
            return Tabla;

        }

        public int UltimoIdDetallePedido()
        {
            DataTable Tabla = new DataTable();
            int ultimoId=0;

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "UltimoIdPedido";
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            foreach (DataRow fila in Tabla.Rows)
            {
              ultimoId = Convert.ToInt32(fila[0]);
            }
            leerFilas.Close();
            Conexion.Close();
            return ultimoId;
        }

        public void EditarDetallePedido(DetallePedido de)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "EditarDetallePedido";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetallePedido", de.IdDetallePedido);
            Comando.Parameters.AddWithValue("@idProducto", de.IdProducto);
            Comando.Parameters.AddWithValue("@precioUnitario", de.PrecioUnitario);
            Comando.Parameters.AddWithValue("@cantidad", de.Cantidad);
            Comando.Parameters.AddWithValue("@subtotal", de.Subtotal);

            Comando.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EliminarDetallePedido(DetallePedido de)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "EliminarDetalle";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetallePedido", de.IdDetallePedido);
            Comando.ExecuteNonQuery();
            Conexion.Close();
        }
    }
}
