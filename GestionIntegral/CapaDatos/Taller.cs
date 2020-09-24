using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{
    class Taller
    {
        int id;
        string razonSocial;
        int idDireccion;
        string observaciones;
        string telefono;
        bool activo;

        public int Id { get => id; set => id = value; }
        public int IdDireccion { get => idDireccion; set => idDireccion = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public bool Activo { get => activo; set => activo = value; }

        public Taller(int idDireccion, string observaciones, string telefono, string razonSocial, bool activo)
        {
            IdDireccion = idDireccion;
            Observaciones = observaciones;
            Telefono = telefono;
            RazonSocial = razonSocial;
            Activo = activo;
        }

        public Taller()
        {
        }

        public Taller(int id, int idDireccion, string observaciones, string telefono, string razonSocial, bool activo)
        {
            Id = id;
            IdDireccion = idDireccion;
            Observaciones = observaciones;
            Telefono = telefono;
            RazonSocial = razonSocial;
            Activo = activo;
        }
    }
}
