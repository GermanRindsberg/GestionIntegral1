using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{

    class Transporte
    {


        private int idTransporte;
        private string razonSocial;
        private int idDireccion;
        private string tel;
        private Boolean activo;
        private string observaciones;

        public int IdTransporte { get => idTransporte; set => idTransporte = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public int IdDireccion { get => idDireccion; set => idDireccion = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public bool Activo { get => activo; set => activo = value; }

        public Transporte(string razonSocial, int idDireccion, string tel, string observaciones, bool activo)
        {
            RazonSocial = razonSocial;
            IdDireccion = idDireccion;
            Tel = tel;
            Observaciones = observaciones;
            Activo = activo;
        }
        public Transporte() { }
    }
}
