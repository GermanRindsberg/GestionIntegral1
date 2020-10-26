using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{
    class Diseño
    {
        int idDiseño;
        string descripcionDiseño;
        bool activo;

        

        public int IdDiseño { get => idDiseño; set => idDiseño = value; }
        public string DescripcionDiseño { get => descripcionDiseño; set => descripcionDiseño = value; }
        public bool Activo { get => activo; set => activo = value; }

        public Diseño(string descripcionDiseño)
        {
            DescripcionDiseño = descripcionDiseño;
        }
        public Diseño()
        {

        }

        public Diseño(int idDiseño, string descripcionDiseño) : this(idDiseño)
        {
            DescripcionDiseño = descripcionDiseño;
        }

        public Diseño(int idDiseño)
        {
            IdDiseño = idDiseño;
        }
    }
       
}
