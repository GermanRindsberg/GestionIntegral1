using System.Data.SqlClient;

namespace GestionIntegral.CapaDatos
{
    class ConexionBBDD
    {

        //static private string CadenaConexion = "Data Source=DESKTOP-SSL8DRK;Initial Catalog=Alejandro;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static private string CadenaConexion = "Server=(local);Database=Alejandro; integrated security=true";

        protected SqlConnection Conexion = new SqlConnection(CadenaConexion);

    }

}
