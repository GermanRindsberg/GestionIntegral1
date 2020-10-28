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
        string nombreTaller;
        DateTime fechaEnvio;
        DateTime? fechaRetiro;
        Boolean activo;
        int estado;

        public int IdOT { get => idOT; set => idOT = value; }
        public int IdDetalleOT { get => idDetalleOT; set => idDetalleOT = value; }
        public string NombreTaller { get => nombreTaller; set => nombreTaller = value; }
        public DateTime FechaEnvio { get => fechaEnvio; set => fechaEnvio = value; }
        public DateTime? FechaRetiro { get => fechaRetiro; set => fechaRetiro = value; }
        public bool Activo { get => activo; set => activo = value; }
        public int Estado { get => estado; set => estado = value; }

        //constructor para editar
        public OrdenDeTrabajos(int idOT, int idDetalleOT, string nombreTaller, DateTime fechaEnvio, DateTime? fechaRetiro, bool activo, int estado)
        {
            IdOT = idOT;
            IdDetalleOT = idDetalleOT;
            FechaEnvio = fechaEnvio;
            FechaRetiro = fechaRetiro;
            Activo = activo;
            Estado = estado;
            NombreTaller = nombreTaller;
        }
        //constructor para insertar
        public OrdenDeTrabajos(int idDetalleOT, string nombreTaller, DateTime fechaEnvio, DateTime? fechaRetiro, bool activo, int estado)
        {
            IdDetalleOT = idDetalleOT;
            FechaEnvio = fechaEnvio;
            FechaRetiro = fechaRetiro;
            Activo = activo;
            Estado = estado;
            NombreTaller = nombreTaller;
        }

        //constructor para crear o borrar
        public OrdenDeTrabajos(int idOT)
        {
            IdOT = idOT;
        }




    }
}
