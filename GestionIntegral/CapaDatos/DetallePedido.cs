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
        float precioUnitario;
        int cantidad;
        float subtotal;

        public int IdDetallePedido { get => idDetallePedido; set => idDetallePedido = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public float PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float Subtotal { get => subtotal; set => subtotal = value; }

        public DetallePedido()
        {
        }

        public DetallePedido(int idDetallePedido)
        {
            IdDetallePedido = idDetallePedido;
        }

        public DetallePedido(int idDetallePedido, int idProducto, float precioUnitario, int cantidad, float subtotal) : this(idDetallePedido)
        {
            IdProducto = idProducto;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }
    }
}
