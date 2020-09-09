using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionIntegral.CapaDatos
{
    class ConexionBBDD
    {

        
        
        //static private string CadenaConexion = "Data Source=DESKTOP-SSL8DRK;Initial Catalog=Alejandro;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static private string CadenaConexion = "Server=(local);Database=Alejandro; integrated security=true";
        
        private SqlConnection Conexion = new SqlConnection(CadenaConexion);

        public SqlConnection Conectar()
        {
            if (Conexion.State == ConnectionState.Closed)
            Conexion.Open();
            
            return Conexion;
        }

        public SqlConnection Desconectar()
        {
            if (Conexion.State == ConnectionState.Open)
            Conexion.Close();
            return Conexion;
        }

        public void EjecutarSql(String consulta)
        {
            Conectar();
            SqlCommand com = new SqlCommand(consulta, Conexion);

            int filasAfectadas = com.ExecuteNonQuery();

          
            Desconectar();
        }

        public void ActualizarGrid(DataGridView dg, string Consulta)
        {
            Conectar();

            System.Data.DataSet ds = new System.Data.DataSet();

            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conexion);

            da.Fill(ds, "tabla");

            dg.DataSource = ds;
            dg.DataMember = "tabla";

            this.Desconectar();
        }

        public string[] RellenarComboBox(ComboBox cb, String Consulta)
        {
                Conectar();
                SqlCommand cmd = new SqlCommand(Consulta, Conexion);
                SqlDataReader dr = cmd.ExecuteReader();
                string[] valores = null;
                string[] resultado = null;

                while (dr.Read())
                {
                for (int i = 0; i > dr.FieldCount; i++)
                {
                   valores = new string[]{dr[i].ToString()};
                }
                resultado = valores;
                }
                Desconectar();
                return resultado;
            }
        }

}
