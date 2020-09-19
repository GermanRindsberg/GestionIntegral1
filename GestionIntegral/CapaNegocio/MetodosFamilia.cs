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
    class MetodosFamilia: ConexionBBDD
    {
        private SqlCommand Comando = new SqlCommand();

        SqlDataReader LeerFilas;

        public void InsertarFamilia(Familia tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "FamiliaCreate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@descripcion", tr.DescripcionFamilia);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

        public void EliminarFamilia(Familia tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "FamiliaDelete";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idFamilia", tr.IdFamilia);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

        public void EditarFamilia(Familia tr)
        {
            Comando.Connection = Conexion;
            Conexion.Open();
            Comando.CommandText = "FamiliaUpdate";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@descripcion", tr.DescripcionFamilia);
            Comando.Parameters.AddWithValue("@idFamilia", tr.IdFamilia);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Conexion.Close();
        }

        public List<Familia> ListarFamilia(string condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "FamiliaRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@condicion", condicion);

            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            List<Familia> ListaGenerica = new List<Familia>();
            while (LeerFilas.Read())
            {
                ListaGenerica.Add(new Familia
                {
                    IdFamilia = LeerFilas.GetInt32(0),
                    DescripcionFamilia = LeerFilas.GetString(1),
                }); ;
            }
            LeerFilas.Close();
            Conexion.Close();
            return ListaGenerica;
        }

        public Familia CrearFamilia(int id)
        {
            Familia tr = new Familia();

            Comando.Connection = Conexion;
            Comando.CommandText = "FamiliaRead";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Clear();
            Comando.Parameters.AddWithValue("@condicion",Convert.ToString(id));
            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            List<Familia> ListaGenerica = new List<Familia>();
            while (LeerFilas.Read())
            {
                tr.IdFamilia = LeerFilas.GetInt32(0);
                tr.DescripcionFamilia = LeerFilas.GetString(1);
            }
            LeerFilas.Close();
            Conexion.Close();
            return tr;
        }

    }
}
