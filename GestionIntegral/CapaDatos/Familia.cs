using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{
    class Familia 
    {
       
        int idFamilia;
        string descripcionFamilia;
        bool activo;
        

        public int IdFamilia { get => idFamilia; set => idFamilia = value; }
        public string DescripcionFamilia { get => descripcionFamilia; set => descripcionFamilia = value; }
        public bool Activo { get => activo; set => activo = value; }

        public Familia(string descripcionFamilia)
        {
            DescripcionFamilia = descripcionFamilia;
        }



        public Familia()
        {
        }

        public Familia(int idFamilia)
        {
            IdFamilia = idFamilia;
        }
    }
}
