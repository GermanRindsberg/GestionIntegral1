using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{

    class Transporte
    {

        private ConexionBBDD Conexion = new ConexionBBDD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;

        private int idTransporte;
        private string razonSocial;
        private int idDireccion;
        private string tel;
        private Boolean activo;
        private string observaciones;

        public int IdTransporte { get => idTransporte; set => idTransporte = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public int IdDireccion { get => idDireccion; set => idDireccion = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public bool Activo { get => activo; set => activo = value; }

        public DataTable ListarTransportes()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "ListarTransportes";
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);

            DataRow workRow = Tabla.NewRow();
            workRow[0] = 0;
            workRow[1] = "Seleccione un valor";
            workRow[2] = 0;
            workRow[3] = "";
            workRow[4] = "";
            workRow[5] = true;
            Tabla.Rows.InsertAt(workRow, 0);
            leerFilas.Close();
            Conexion.Desconectar();
            return Tabla;
        }

        public void InsertarTransporte()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "InsertarTransporte";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@razonSocial", RazonSocial);
            Comando.Parameters.AddWithValue("@idDireccion", IdDireccion);
            Comando.Parameters.AddWithValue("@telefono", Tel);
            Comando.Parameters.AddWithValue("@observaciones", Observaciones);
            Comando.Parameters.AddWithValue("@activo", Activo);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }

        public void EditarTransporte()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EditarTransportes";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idTransporte", IdTransporte);
            Comando.Parameters.AddWithValue("@razonSocial", RazonSocial);
            Comando.Parameters.AddWithValue("@idDireccion", IdDireccion);
            Comando.Parameters.AddWithValue("@tel", Tel);
            Comando.Parameters.AddWithValue("@activo", Activo);
            Comando.Parameters.AddWithValue("@observaciones", Observaciones);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();

        }

        public void ListarTransportePorId()
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "ListarTransportePorId";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idTransporte", IdTransporte);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);


            foreach (DataRow fila in Tabla.Rows)
            {
                
                IdTransporte = Convert.ToInt32(fila[0]);
                RazonSocial = fila[1].ToString();
                IdDireccion = Convert.ToInt32(fila[2]);
                Tel = fila[3].ToString();
                Observaciones = fila[4].ToString();
                Activo = Convert.ToBoolean(fila[5]);
            }
            leerFilas.Close();
            Conexion.Desconectar();

        }

        public void EliminarTransporte(int activo)
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EliminarTransporte";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idTransporte", IdTransporte);
            Comando.Parameters.AddWithValue("@activo", activo);

            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }



    }
}
