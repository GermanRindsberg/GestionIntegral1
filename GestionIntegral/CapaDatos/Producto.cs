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
        int almacen;
        int taller1;
        int taller2;
        int taller3;
        int taller4;
        int stockMinimo;
        int stock;
        int potencialStock;
        int pedidos;
        int requeridos;
        bool activo;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int IdDiseño { get => idDiseño; set => idDiseño = value; }
        public int IdFamilia { get => idFamilia; set => idFamilia = value; }
        public int ValorUnico { get => valorUnico; set => valorUnico = value; }
        public string DescripcionProducto { get => descripcionProducto; set => descripcionProducto = value; }
        public int Almacen { get => almacen; set => almacen = value; }
        public int Taller1 { get => taller1; set => taller1 = value; }
        public int Taller2 { get => taller2; set => taller2 = value; }
        public int Taller3 { get => taller3; set => taller3 = value; }
        public int Taller4 { get => taller4; set => taller4 = value; }
        public int StockMinimo { get => stockMinimo; set => stockMinimo = value; }
        public int Stock { get => stock; set => stock = value; }
        public int PotencialStock { get => potencialStock; set => potencialStock = value; }
        public int Pedidos { get => pedidos; set => pedidos = value; }
        public int Requeridos { get => requeridos; set => requeridos = value; }
        public bool Activo { get => activo; set => activo = value; }

        //constructor para insertar
        public Producto(int idDiseño,  int valorUnico, int idFamilia, string descripcionProducto, int almacen, int taller1, int taller2, int taller3, int taller4, int stockMinimo, int stock, int potencialStock, int pedidos, int requeridos, bool activo)
        {
            
            this.idDiseño = idDiseño;
            this.idFamilia = idFamilia;
            this.valorUnico = valorUnico;
            this.descripcionProducto = descripcionProducto;
            this.almacen = almacen;
            this.taller1 = taller1;
            this.taller2 = taller2;
            this.taller3 = taller3;
            this.taller4 = taller4;
            this.stockMinimo = stockMinimo;
            this.stock = stock;
            this.potencialStock = potencialStock;
            this.pedidos = pedidos;
            this.requeridos = requeridos;
            this.activo = activo;
        }
        
        //constructor para editar
        public Producto(int idProducto, int idDiseño,  int valorUnico, int idFamilia, string descripcionProducto, int almacen,
            int taller1, int taller2, int taller3, int taller4, int stockMinimo, int stock, int potencialStock, int pedidos,
            int requeridos, bool activo)
        {
            IdProducto = idProducto;
            IdDiseño = idDiseño;
            IdFamilia = idFamilia;
            ValorUnico = valorUnico;
            DescripcionProducto = descripcionProducto;
            Almacen = almacen;
            Taller1 = taller1;
            Taller2 = taller2;
            Taller3 = taller3;
            Taller4 = taller4;
            StockMinimo = stockMinimo;
            Stock = stock;
            PotencialStock = potencialStock;
            Pedidos = pedidos;
            Requeridos = requeridos;
            Activo = activo;
        }

        //constructor para borrar
        public Producto(int idProducto)
        {
            IdProducto = idProducto;
        }

        //contructor vacio para tabla de pedidos
        public Producto() { }

       
    }
}
