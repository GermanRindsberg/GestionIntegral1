using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GestionIntegral.CapaDatos
{
    class OrdenDeTrabajo
    {
        int idOT;
        int idDetalleOT;
        int idTaller;
        DateTime fechaEnvio;
        DateTime fechaRetiro;
        Boolean activo;

        public int IdOT { get => idOT; set => idOT = value; }
        public int IdDetalleOT { get => idDetalleOT; set => idDetalleOT = value; }
        public int IdTaller { get => idTaller; set => idTaller = value; }
        public DateTime FechaEnvio { get => fechaEnvio; set => fechaEnvio = value; }
        public DateTime FechaRetiro { get => fechaRetiro; set => fechaRetiro = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}
