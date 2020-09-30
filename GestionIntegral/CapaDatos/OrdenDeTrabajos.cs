using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GestionIntegral.CapaDatos
{
    class OrdenDeTrabajos
    {
        int idOT;
        int idDetalleOT;
        int idTaller;
        DateTime fechaEnvio;
        DateTime? fechaRetiro;
        Boolean activo;
        int estado;

        public int IdOT { get => idOT; set => idOT = value; }
        public int IdDetalleOT { get => idDetalleOT; set => idDetalleOT = value; }
        public int IdTaller { get => idTaller; set => idTaller = value; }
        public DateTime FechaEnvio { get => fechaEnvio; set => fechaEnvio = value; }
        public DateTime? FechaRetiro { get => fechaRetiro; set => fechaRetiro = value; }
        public bool Activo { get => activo; set => activo = value; }
        public int Estado { get => estado; set => estado = value; }

        public OrdenDeTrabajos(int idOT, int idDetalleOT, int idTaller, DateTime fechaEnvio, DateTime? fechaRetiro, bool activo, int estado)
        {
            IdOT = idOT;
            IdDetalleOT = idDetalleOT;
            IdTaller = idTaller;
            FechaEnvio = fechaEnvio;
            FechaRetiro = fechaRetiro;
            Activo = activo;
            Estado = estado;
        }

        public OrdenDeTrabajos(int idDetalleOT, int idTaller, DateTime fechaEnvio, DateTime? fechaRetiro, bool activo)
        {
            IdDetalleOT = idDetalleOT;
            IdTaller = idTaller;
            FechaEnvio = fechaEnvio;
            FechaRetiro = fechaRetiro;
            Activo = activo;
        }

        public OrdenDeTrabajos()
        {
        }

        public OrdenDeTrabajos(int idOT)
        {
            IdOT = idOT;
        }
    }
}
