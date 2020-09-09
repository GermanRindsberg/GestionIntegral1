

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
    class Producto
    {

        private ConexionBBDD Conexion = new ConexionBBDD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;

        
        int idProducto;
        int idDiseño;
        int idFamilia;
        int valorUnico;
        string descripcionProducto;
        float lista1;
        float lista2;
        float lista3;
        string nombreColumna;


        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int IdDiseño { get => idDiseño; set => idDiseño = value; }
        public int ValorUnico { get => valorUnico; set => valorUnico = value; }
        public int IdFamilia { get => idFamilia; set => idFamilia = value; }
        public string DescripcionProducto { get => descripcionProducto; set => descripcionProducto = value; }
        public float Lista1 { get => lista1; set => lista1 = value; }
        public float Lista2 { get => lista2; set => lista2 = value; }
        public float Lista3 { get => lista3; set => lista3 = value; }
        public string NombreColumna { get => nombreColumna; set => nombreColumna = value; }

        public void InsertarProductos()
        {
            Familia fam = new Familia();


            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "InsertarProductos";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idFamilia", IdFamilia);
            Comando.Parameters.AddWithValue("@idDiseño", IdDiseño);
            Comando.Parameters.AddWithValue("@valorUnico", ValorUnico);
            Comando.Parameters.AddWithValue("@descripcionProducto", DescripcionProducto);
            Comando.Parameters.AddWithValue("@lista1", Lista1);
            Comando.Parameters.AddWithValue("@lista2", Lista2);
            Comando.Parameters.AddWithValue("@lista3", Lista3);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }

        public DataTable ListarProductos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.Conectar();
            Comando.Parameters.Clear();
            Comando.CommandText = "ListarProductos";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);

            DataRow nuevaRow = Tabla.NewRow();
            nuevaRow[0] = 0;
            nuevaRow[1] = 0;
            nuevaRow[2] = 0;
            nuevaRow[3] = 0;
            nuevaRow[4] = "Seleccione un valor";
            nuevaRow[5] = 0;
            nuevaRow[6] = 0;
            nuevaRow[7] = 0;
            Tabla.Rows.InsertAt(nuevaRow, 0);

            leerFilas.Close();
            Conexion.Desconectar(); 
            return Tabla;
        }

        public void EditarProducto()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EditarProductos";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idProducto", IdProducto);
            Comando.Parameters.AddWithValue("@idFamilia", IdFamilia);
            Comando.Parameters.AddWithValue("@idDiseño", IdDiseño);
            Comando.Parameters.AddWithValue("@valorUnico", ValorUnico);
            Comando.Parameters.AddWithValue("@descripcionProducto", DescripcionProducto);
            Comando.Parameters.AddWithValue("@lista1", Lista1);
            Comando.Parameters.AddWithValue("@lista2", Lista2);
            Comando.Parameters.AddWithValue("@lista3", Lista3);

            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();

        }

        public void ListarProductoPorId()
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "TraerProductoPorId";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idProducto", IdProducto);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);


            foreach (DataRow fila in Tabla.Rows)
            {
                //familia
                IdProducto = Convert.ToInt32(fila[0]);
                IdFamilia = Convert.ToInt32(fila[1]);
                IdDiseño=Convert.ToInt32(fila[2]);
                ValorUnico = Convert.ToInt32(fila[3]);
                DescripcionProducto = fila[4].ToString();
                Lista1 = Convert.ToInt32(fila[5]);
                Lista2 = Convert.ToInt32(fila[6]);
                Lista3 = Convert.ToInt32(fila[7]);
            }
            leerFilas.Close();
            Conexion.Desconectar();

        }
     
        public void EliminarProducto()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EliminarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idProducto", IdProducto);

            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }

    }
}
