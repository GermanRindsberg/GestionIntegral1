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
        decimal lista1;
        decimal lista2;
        decimal lista3;
        int tizada;
        decimal papel;
        decimal tela;
        bool activo;

        public int IdFamilia { get => idFamilia; set => idFamilia = value; }
        public string DescripcionFamilia { get => descripcionFamilia; set => descripcionFamilia = value; }
        public decimal Lista1 { get => lista1; set => lista1 = value; }
        public decimal Lista2 { get => lista2; set => lista2 = value; }
        public decimal Lista3 { get => lista3; set => lista3 = value; }
        public int Tizada { get => tizada; set => tizada = value; }
        public decimal Papel { get => papel; set => papel = value; }
        public decimal Tela { get => tela; set => tela = value; }
        public bool Activo { get => activo; set => activo = value; }

        //constructor para insertar
        public Familia(string descripcionFamilia, decimal lista1, decimal lista2, decimal lista3, int tizada, decimal papel, decimal tela)
        {
            DescripcionFamilia = descripcionFamilia;
            Lista1 = lista1;
            Lista2 = lista2;
            Lista3 = lista3;
            Tizada = tizada;
            Papel = papel;
            Tela = tela;
        }
       
        //constructor para editar
        public Familia(int idFamilia, string descripcionFamilia, decimal lista1, decimal lista2, decimal lista3, int tizada, decimal papel, decimal tela, bool activo)
        {
            IdFamilia = idFamilia;
            DescripcionFamilia = descripcionFamilia;
            Lista1 = lista1;
            Lista2 = lista2;
            Lista3 = lista3;
            Tizada = tizada;
            Papel = papel;
            Tela = tela;
            Activo = activo;
        }

        //constructor vacio para rellenar desde base de datos y usar en buscadores por ejemplo
        public Familia() { }
        
        //constructor para borrar
        public Familia(int idFamilia)
        {
            IdFamilia = idFamilia;
        }
    }
}
