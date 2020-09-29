using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{
    class DetalleOrdenTrabajo
    {

        int idDetalleOT;
        int idProducto;
        int cantidad;


        
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int IdDetalleOT { get => idDetalleOT; set => idDetalleOT = value; }

        public DetalleOrdenTrabajo()
        {
        }

        public DetalleOrdenTrabajo(int idDetalleOT, int idProducto, int cantidad)
        {
            IdProducto = idProducto;
            Cantidad = cantidad;
            IdDetalleOT = idDetalleOT;
        }

        public DetalleOrdenTrabajo(int idProducto)
        {
            IdProducto = idProducto;
        }
    }
}
