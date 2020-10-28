using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GestionIntegral.CapaDatos
{
    class Pedido
    {
        int idDetallePedido;
        int idPedido;
        Decimal total;

        DateTime fecha;
        int idCliente ;

        int idEstado;
        string numGuia;
        DateTime? fechaPago;//uso el ? para que acepte valores nulos
        DateTime? fechaEnvio;//uso el ? para que acepte valores nulos
        string medioPago;


        public int IdDetallePedido { get => idDetallePedido; set => idDetallePedido = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdEstado { get => idEstado; set => idEstado = value; }
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public string NumGuia { get => numGuia; set => numGuia = value; }
        public string MedioPago { get => medioPago; set => medioPago = value; }
        public DateTime? FechaPago { get => fechaPago; set => fechaPago = value; }
        public Decimal Total { get => total; set => total = value; }
        public DateTime? FechaEnvio { get => fechaEnvio; set => fechaEnvio = value; }

        public Pedido(int idDetallePedido, DateTime fecha, int idCliente, int idEstado, string numGuia, string medioPago, DateTime? fechaPago, Decimal total, DateTime? fechaEnvio)
        {
            IdDetallePedido = idDetallePedido;
            Fecha = fecha;
            IdCliente = idCliente;
            IdEstado = idEstado;
            NumGuia = numGuia;
            MedioPago = medioPago;
            FechaPago = fechaPago;
            Total = total;
            FechaEnvio = fechaEnvio;
        }

        public Pedido()
        {
        }

        public Pedido(int idPedido)
        {
            IdPedido = idPedido;
        }
    }
}
