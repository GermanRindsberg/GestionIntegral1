using GestionIntegral.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaNegocio
{
    class MetodosOT
    {
        OrdenDeTrabajo ot = new OrdenDeTrabajo();
        
        private ConexionBBDD Conexion = new ConexionBBDD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader leerFilas;
    }
}
