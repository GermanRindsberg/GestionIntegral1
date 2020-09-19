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
    class MetodosDiseño : ConexionBBDD
    {
        private SqlCommand Comando = new SqlCommand();

        SqlDataReader LeerFilas;

        public void InsertarDiseño(Diseño tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "DiseñoCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@descripcion", tr.DescripcionDiseño);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

        public void EliminarDiseño(Diseño tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "DiseñoDelete";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idDiseño", tr.IdDiseño);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

        public void EditarDiseño(Diseño tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "DiseñoUpdate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@descripcion", tr.DescripcionDiseño);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

        public List<Diseño> ListarDiseño(string condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "DiseñoRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@condicion", condicion);

            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            List<Diseño> ListaGenerica = new List<Diseño>();
            while (LeerFilas.Read())
            {
                ListaGenerica.Add(new Diseño
                {
                    IdDiseño = LeerFilas.GetInt32(0),
                    DescripcionDiseño= LeerFilas.GetString(1),
                }); ;
            }
            LeerFilas.Close();
            Conexion.Close();
            return ListaGenerica;
        }

        public Diseño CrearDiseño(int id)
        {
            Diseño tr = new Diseño();

            Comando.Connection = Conexion;
            Comando.CommandText = "DiseñoRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@condicion",Convert.ToString(id));

            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            List<Diseño> ListaGenerica = new List<Diseño>();
            while (LeerFilas.Read())
            {
                tr.IdDiseño = LeerFilas.GetInt32(0);
                tr.DescripcionDiseño = LeerFilas.GetString(1);
            }
            LeerFilas.Close();
            Conexion.Close();


            return tr;
        }

    }
}

