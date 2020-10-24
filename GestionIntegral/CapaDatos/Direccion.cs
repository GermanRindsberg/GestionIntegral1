using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GestionIntegral.CapaDatos
{
    class Direccion
    {
        private int idDireccion;
        private int idLocalidad;
        private string calle;
        private string numero;
        private string depto;
        private string piso;

        private int idProvincia;
        private string nombreLocalidad;
        private string codigoPostal;
        private string nombreProvincia;

        public int IdDireccion { get => idDireccion; set => idDireccion = value; }
        public int IdLocalidad { get => idLocalidad; set => idLocalidad = value; }
        public string Calle { get => calle; set => calle = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Depto { get => depto; set => depto = value; }
        public string Piso { get => piso; set => piso = value; }
        public int IdProvincia { get => idProvincia; set => idProvincia = value; }
        public string NombreLocalidad { get => nombreLocalidad; set => nombreLocalidad = value; }
        public string CodigoPostal { get => codigoPostal; set => codigoPostal = value; }
        public string NombreProvincia { get => nombreProvincia; set => nombreProvincia = value; }

        public Direccion(int idLocalidad, string calle, string numero, string depto, string piso)
        {
            IdLocalidad = idLocalidad;
            Calle = calle;
            Numero = numero;
            Depto = depto;
            Piso = piso;
        }

        public Direccion()
        { }

        public Direccion(int idDireccion, int idLocalidad, string calle, string numero, string depto, string piso)
        {
            IdDireccion = idDireccion;
            IdLocalidad = idLocalidad;
            Calle = calle;
            Numero = numero;
            Depto = depto;
            Piso = piso;
        }
    }
}
