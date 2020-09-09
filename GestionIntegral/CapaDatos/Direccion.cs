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
    class Direccion
    {

        private ConexionBBDD Conexion = new ConexionBBDD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;

        private int idDireccion;
        private int idLocalidad;
        private string calle;
        private string numero;
        private string depto;
        private string piso;
        private int idProvincia;
        private string nombreLocalidad;
        private string codigoPostal;
        private string nombreProvincia;

        public int IdDireccion { get => idDireccion; set => idDireccion = value; }
        public int IdLocalidad { get => idLocalidad; set => idLocalidad = value; }
        public string Calle { get => calle; set => calle = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Depto { get => depto; set => depto = value; }
        public string Piso { get => piso; set => piso = value; }
        public int IdProvincia { get => idProvincia; set => idProvincia = value; }
        public string NombreLocalidad { get => nombreLocalidad; set => nombreLocalidad = value; }
        public string CodigoPostal { get => codigoPostal; set => codigoPostal = value; }
        public string NombreProvincia { get => nombreProvincia; set => nombreProvincia = value; }

        public void InsertarDireccion()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "InsertarDireccion";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idLocalidad", IdLocalidad);
            Comando.Parameters.AddWithValue("@calle", Calle);
            Comando.Parameters.AddWithValue("@numero", Numero);
            Comando.Parameters.AddWithValue("@depto", Depto);
            Comando.Parameters.AddWithValue("@piso", Piso);
            Comando.ExecuteNonQuery();
            SqlDataReader reader = Comando.ExecuteReader();
            reader.Read();

            IdDireccion = Convert.ToInt32(reader[0].ToString());

            Comando.Parameters.Clear();
            Conexion.Desconectar();

        }

        public DataTable ListarLocalidades()
        {
            DataTable Tabla = new DataTable();
            
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "ListarLocalidad";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idProvincia", IdProvincia);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);

            DataRow nuevaRow = Tabla.NewRow();
            nuevaRow[0] = 0;
            nuevaRow[1] = 0;
            nuevaRow[2] = "Seleccione un valor";
            nuevaRow[3] = 0000;
            Tabla.Rows.InsertAt(nuevaRow, 0);


            leerFilas.Close();
            Conexion.Desconectar();
            return Tabla;
        }

        public DataTable ListarProvincias()
        {
            DataTable Tabla = new DataTable();
            
            Comando.Connection = Conexion.Conectar();
            Comando.Parameters.Clear();
            Comando.CommandText = "ListarProvincias";
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

        public void ListarCodigoPostal(TextBox tx)
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "ListarCodigoPostal";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idLocalidad", IdLocalidad);
            Comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = Comando.ExecuteReader();
            while (dr.Read())
            {
                tx.Text = dr[0].ToString();
            }
            Conexion.Desconectar();

        }

        public void EditarDireccion()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EditarDireccion";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@id", this.IdDireccion);
            Comando.Parameters.AddWithValue("@idLocalidad", this.IdLocalidad);
            Comando.Parameters.AddWithValue("@calle", this.Calle);
            Comando.Parameters.AddWithValue("@numero", this.Numero);
            Comando.Parameters.AddWithValue("@departamento", this.Depto);
            Comando.Parameters.AddWithValue("@piso", this.Piso);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }

        public DataTable ListarDireccion()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "TraerDireccionPorId";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDireccion", IdDireccion);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            leerFilas.Close();
            Conexion.Desconectar();
            return Tabla;
        }

        public void ListarDireccionPorId()
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "TraerDireccionPorId";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idDireccion", IdDireccion);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            leerFilas.Close();

            foreach (DataRow fila in Tabla.Rows)
            {
                IdDireccion = Convert.ToInt32(fila[0]);
                IdLocalidad = Convert.ToInt32(fila[1]);
                Calle = fila[2].ToString();
                Numero = fila[3].ToString();
                Depto = fila[4].ToString();
                Piso = fila[5].ToString();

                IdProvincia = Convert.ToInt32(fila[7]);
                NombreLocalidad= fila[8].ToString();
                CodigoPostal= fila[9].ToString();
                nombreProvincia= fila[11].ToString();

            }
            Conexion.Desconectar();
        }



    }
}
