using GestionIntegral.CapaDatos;
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
    class Familia 
    {
        private ConexionBBDD Conexion = new ConexionBBDD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;

        int idFamilia;
        string descripcionFamilia;
        float lista1;
        float lista2;
        float lista3;

        public int IdFamilia { get => idFamilia; set => idFamilia = value; }
        public string DescripcionFamilia { get => descripcionFamilia; set => descripcionFamilia = value; }
        public float Lista1 { get => lista1; set => lista1 = value; }
        public float Lista2 { get => lista2; set => lista2 = value; }
        public float Lista3 { get => lista3; set => lista3 = value; }
        

        public DataTable ListarFamilia()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.Conectar();
            Comando.Parameters.Clear();
            Comando.CommandText = "ListarFamilia";
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

        public void InsertarFamilia()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "InsertarFamilia";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@descripcion", DescripcionFamilia);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }

        public void ListarFamiliaPorId()
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "TraerFamiliaPorId";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idFamilia", IdFamilia);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);


            foreach (DataRow fila in Tabla.Rows)
            {
                //familia
                IdFamilia = Convert.ToInt32(fila[0]);
                DescripcionFamilia = fila[1].ToString();
               
            }
            leerFilas.Close();
            Conexion.Desconectar();

        }

        public void EditarFamilia()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EditarFamilia";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idFamilia", IdFamilia);
            Comando.Parameters.AddWithValue("@descripcion", DescripcionFamilia);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }

        public void EliminarFamilia()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EliminarFamilia";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idFamilia", IdFamilia);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }


    }
}
