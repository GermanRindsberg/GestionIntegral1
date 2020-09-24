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
        private SqlDataReader LeerFilas;

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
            Comando.CommandText = "ListarDetallePedido";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idPedido", idDetalle);
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
            int ultimoId=0;

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "DetalleSeleccionarUltimoId";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            foreach (DataRow fila in Tabla.Rows)
            {
              ultimoId = Convert.ToInt32(fila[0])+1;
            }
            LeerFilas.Close();
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

        public void EliminarDetallePedido(int idDetallePedido)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "DetallePedidoEliminar";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDetallePedido", idDetallePedido);
            Comando.ExecuteNonQuery();
            Conexion.Close();
        }

      
    }
}
