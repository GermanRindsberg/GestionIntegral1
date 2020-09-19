using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{
    class Stock
    {
       

        int idProducto;
        int almacen;
        int taller1;
        int taller2;
        int taller3;
        int taller4;
        int stockCantidad;
        int potencialStock;
        int pedidos;
        int requerido;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Almacen { get => almacen; set => almacen = value; }
        public int Taller1 { get => taller1; set => taller1 = value; }
        public int Taller2 { get => taller2; set => taller2 = value; }
        public int Taller3 { get => taller3; set => taller3 = value; }
        public int Taller4 { get => taller4; set => taller4 = value; }
        public int StockCantidad { get => stockCantidad; set => stockCantidad = value; }
        public int PotencialStock { get => potencialStock; set => potencialStock = value; }
        public int Pedidos { get => pedidos; set => pedidos = value; }
        public int Requerido { get => requerido; set => requerido = value; }

       
    }
    
}

