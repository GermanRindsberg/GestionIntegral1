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
    class Cliente
    {
        private ConexionBBDD Conexion = new ConexionBBDD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;

        private int idCliente;
        private string razonSocial;
        private int idDireccion;
        private string tel1;
        private string tel2;
        private Boolean activo;
        private string email;
        private string cuit;
        private int idTransporte;
        private DateTime fechaAlta;
        private string observaciones;
        private int tipoLista;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public int IdDireccion { get => idDireccion; set => idDireccion = value; }
        public string Tel1 { get => tel1; set => tel1 = value; }
        public string Tel2 { get => tel2; set => tel2 = value; }
        public bool Activo { get => activo; set => activo = value; }
        public string Email { get => email; set => email = value; }
        public string Cuit { get => cuit; set => cuit = value; }
        public int IdTransporte { get => idTransporte; set => idTransporte = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public int TipoLista { get => tipoLista; set => tipoLista = value; }

        public void InsertarClientes()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "InsertarCliente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@razonSocial", RazonSocial);
            Comando.Parameters.AddWithValue("@idDireccion", IdDireccion);
            Comando.Parameters.AddWithValue("@tel1", Tel1);
            Comando.Parameters.AddWithValue("@tel2", Tel2);
            Comando.Parameters.AddWithValue("@activo", Activo);
            Comando.Parameters.AddWithValue("@email", Email);
            Comando.Parameters.AddWithValue("@cuit", Cuit);
            Comando.Parameters.AddWithValue("@idTransporte", IdTransporte);
            Comando.Parameters.AddWithValue("@fechaAlta", FechaAlta);
            Comando.Parameters.AddWithValue("@observaciones", Observaciones);
            Comando.Parameters.AddWithValue("@tipoLista", TipoLista);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }

        public void EliminarClientes()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EliminarCliente";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idCliente", IdCliente);
  
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();
        }

        public void EditarClientes()
        {
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "EditarClientes";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idCliente", IdCliente);
            Comando.Parameters.AddWithValue("@razonSocial", RazonSocial);
            Comando.Parameters.AddWithValue("@idDireccion", IdDireccion);
            Comando.Parameters.AddWithValue("@tel1", Tel1);
            Comando.Parameters.AddWithValue("@tel2", Tel2);
            Comando.Parameters.AddWithValue("@activo", Activo);
            Comando.Parameters.AddWithValue("@email", Email);
            Comando.Parameters.AddWithValue("@cuit", Cuit);
            Comando.Parameters.AddWithValue("@idTransporte", IdTransporte);
            Comando.Parameters.AddWithValue("@fechaAlta", FechaAlta);
            Comando.Parameters.AddWithValue("@observaciones", Observaciones);
            Comando.Parameters.AddWithValue("@tipoLista", TipoLista);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Desconectar();

        }

        public DataTable ListarClientes()
        {
            DataTable Tabla = new DataTable();
            Comando.Parameters.Clear();
            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "ListarClientes";
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);

            DataRow nuevaRow = Tabla.NewRow();
            nuevaRow[0] = 0;
            nuevaRow[1] = "Seleccione un valor";
            Tabla.Rows.InsertAt(nuevaRow, 0);


            leerFilas.Close();
            Conexion.Desconectar();
            return Tabla;
        }

        public DataTable BuscarCliente(string texto, Boolean activo)
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "BuscarClientes";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@texto", texto);
            Comando.Parameters.AddWithValue("@activo", activo);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);

            Comando.Connection = Conexion.Desconectar();
            return Tabla;


        }

        public DataTable BuscarTodosCliente(string texto)
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "BuscarTodosClientes";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@texto", texto);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);

            Comando.Connection = Conexion.Desconectar();
            return Tabla;


        }

        public DataTable ListarClientesEnGrilla(int estado)
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "ListarClientesActivosInactivos";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@estado", estado);
            Comando.CommandType = CommandType.StoredProcedure;

            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);
            leerFilas.Close();
            Conexion.Desconectar();
            return Tabla;
        }

        public void ListarClientePorId()
        {
            DataTable Tabla = new DataTable();

            Comando.Connection = Conexion.Conectar();
            Comando.CommandText = "TraerClientePorId";
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@idCliente", IdCliente);
            Comando.CommandType = CommandType.StoredProcedure;
            leerFilas = Comando.ExecuteReader();
            Tabla.Load(leerFilas);


            foreach(DataRow fila in Tabla.Rows)
            {
                //CLIENTE
                IdCliente =Convert.ToInt32(fila[0]);
                RazonSocial = fila[1].ToString();
                IdDireccion= Convert.ToInt32(fila[2]);
                Tel1= fila[3].ToString();
                Tel2 = fila[4].ToString();
                Activo =Convert.ToBoolean( fila[5]);
                Email= fila[6].ToString();
                Cuit = fila[7].ToString();
                IdTransporte = Convert.ToInt32(fila[8]);
                FechaAlta = Convert.ToDateTime(fila[9]);
                Observaciones = fila[10].ToString();
                TipoLista = Convert.ToInt32(fila[11]);

            }

            leerFilas.Close();
            Conexion.Desconectar();
           
        }
    }
}
