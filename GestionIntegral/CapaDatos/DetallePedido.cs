using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{
    class DetallePedido
    {
        int idDetallePedido;
        int idProducto;
        decimal precioUnitario;
        int cantidad;
        decimal subtotal;

        public int IdDetallePedido { get => idDetallePedido; set => idDetallePedido = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }

        public DetallePedido()
        {
        }

        public DetallePedido(int idDetallePedido)
        {
            IdDetallePedido = idDetallePedido;
        }




        public DetallePedido(int idDetallePedido, int idProducto, decimal precioUnitario, int cantidad, decimal subtotal)
        {
            IdDetallePedido = idDetallePedido;
            IdProducto = idProducto;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }
    }
}
