using GestionIntegral.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GestionIntegral.CapaNegocio
{
    class MetodosStock: ConexionBBDD
    {
        
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;


        public DataTable ListarStock()
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "StockRead";
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            leerFilas.Close();
            Conexion.Close();

            foreach (DataRow fila in Tabla.Rows)
            {
                int valor = int.Parse(fila[14].ToString());
                if (valor < 0)
                {
                    fila[14] = 0;
                }
            }

            return Tabla;
        }

        public void PasarStock(string columnaDesde, string columnaHasta, int valorDesde, int valorHasta,  int idProducto)
        {
        
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "PasarStock";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@columnaDesde", columnaDesde);
            Comando.Parameters.AddWithValue("@columnaHasta", columnaHasta);
            Comando.Parameters.AddWithValue("@valorDesde", valorDesde);
            Comando.Parameters.AddWithValue("@valorHasta", valorHasta);
            Comando.Parameters.AddWithValue("@idProducto", idProducto);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

        public void AgregarStock(int cantidad, string nombreColumna, int idProducto)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "StockCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@cantidad", cantidad);
            Comando.Parameters.AddWithValue("@nombreColumna", nombreColumna);
            Comando.Parameters.AddWithValue("@idProducto", idProducto);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();

        }

        public void RestarStock(int cantidad, string nombreColumna, int idProducto)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "StockDescontar";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@cantidad", cantidad);
            Comando.Parameters.AddWithValue("@nombreColumna", nombreColumna);
            Comando.Parameters.AddWithValue("@idProducto", idProducto);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();

        }
    }
}
