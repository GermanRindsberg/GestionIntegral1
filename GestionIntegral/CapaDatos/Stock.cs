using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionIntegral.CapaDatos
{
    class Stock
    {
        private ConexionBBDD Conexion = new ConexionBBDD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;

        int idProducto;
        int almacen;
        int taller1;
        int taller2;
        int taller3;
        int taller4;
        int stockCantidad;
        int potencialStock;
        int pedidos;
        int requerido;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Almacen { get => almacen; set => almacen = value; }
        public int Taller1 { get => taller1; set => taller1 = value; }
        public int Taller2 { get => taller2; set => taller2 = value; }
        public int Taller3 { get => taller3; set => taller3 = value; }
        public int Taller4 { get => taller4; set => taller4 = value; }
        public int StockCantidad { get => stockCantidad; set => stockCantidad = value; }
        public int PotencialStock { get => potencialStock; set => potencialStock = value; }
        public int Pedidos { get => pedidos; set => pedidos = value; }
        public int Requerido { get => requerido; set => requerido = value; }

        public DataTable ListarStock()
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "ListarStock";
            
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            leerFilas.Close();
            Conexion.Desconectar();
            return Tabla;

        }

        public void PasarStock(string columnaDesde, string columnaHasta, int valorDesde, int valorHasta)
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "PasarStock";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@columnaDesde", columnaDesde);
            Comando.Parameters.AddWithValue("@columnaHasta", columnaHasta);
            Comando.Parameters.AddWithValue("@valorDesde", valorDesde);
            Comando.Parameters.AddWithValue("@valorHasta", valorHasta);
            Comando.Parameters.AddWithValue("@idProducto", IdProducto);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }


        public void AgregarStock(int valor, string columna)
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "agregarStockAlmacen";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@cantidad", valor);
            Comando.Parameters.AddWithValue("@columna", columna);
            Comando.Parameters.AddWithValue("@idProducto", idProducto);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }
    }
    
}

