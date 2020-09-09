using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{
    class Diseño
    {
        private ConexionBBDD Conexion = new ConexionBBDD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;

        int idDiseño;
        string descripcionDiseño;

        public int IdDiseño { get => idDiseño; set => idDiseño = value; }
        public string DescripcionDiseño { get => descripcionDiseño; set => descripcionDiseño = value; }

        public DataTable ListarDiseños()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.Conectar();
            Comando.Parameters.Clear();
            Comando.CommandText = "ListarDiseños";
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            
            DataRow workRow = Tabla.NewRow();
            workRow[0] = 0;
            workRow[1] = "Seleccione un valor";
            Tabla.Rows.InsertAt(workRow, 0);
           
            leerFilas.Close();
            Conexion.Desconectar();
            return Tabla;
        }

        public void InsertarDiseño()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "InsertarDiseño";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@descripcion", DescripcionDiseño);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }

        public void ListarDiseñoPorId()
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "TraerDiseñoPorId";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDiseño", IdDiseño);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);


            foreach (DataRow fila in Tabla.Rows)
            {
                IdDiseño = Convert.ToInt32(fila[0]);
                DescripcionDiseño = fila[1].ToString();
            }
            leerFilas.Close();
            Conexion.Desconectar();

        }

        public void EditarDiseño()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EditarDiseño";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDiseño", IdDiseño);
            Comando.Parameters.AddWithValue("@descripcion", DescripcionDiseño);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }

        public void EliminarDiseño()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EliminaDiseño";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idDiseño", IdDiseño);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }
    }
}
