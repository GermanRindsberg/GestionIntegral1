using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{
    class Producto
    {
        int idProducto;
        int idDiseño;
        int idFamilia;
        int valorUnico;
        string descripcionProducto;
        float lista1;
        float lista2;
        float lista3;
        bool activo;

       

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int IdDiseño { get => idDiseño; set => idDiseño = value; }
        public int ValorUnico { get => valorUnico; set => valorUnico = value; }
        public int IdFamilia { get => idFamilia; set => idFamilia = value; }
        public string DescripcionProducto { get => descripcionProducto; set => descripcionProducto = value; }
        public float Lista1 { get => lista1; set => lista1 = value; }
        public float Lista2 { get => lista2; set => lista2 = value; }
        public float Lista3 { get => lista3; set => lista3 = value; }
        public bool Activo { get => activo; set => activo = value; }

        public Producto(int idDiseño, int valorUnico, int idFamilia, string descripcionProducto, float lista1, float lista2, float lista3)
        {
            IdDiseño = idDiseño;
            ValorUnico = valorUnico;
            IdFamilia = idFamilia;
            DescripcionProducto = descripcionProducto;
            Lista1 = lista1;
            Lista2 = lista2;
            Lista3 = lista3;
        }

        public Producto()
        {
        }

        public Producto(int idProducto, int idDiseño, int valorUnico, int idFamilia, string descripcionProducto, float lista1, float lista2, float lista3)
        {
            IdProducto = idProducto;
            IdDiseño = idDiseño;
            ValorUnico = valorUnico;
            IdFamilia = idFamilia;
            DescripcionProducto = descripcionProducto;
            Lista1 = lista1;
            Lista2 = lista2;
            Lista3 = lista3;
        }
        public Producto(int idProducto)
        {
            IdProducto = idProducto;
        }
    }
}
