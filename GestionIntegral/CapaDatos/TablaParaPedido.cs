using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaDatos
{
    class TablaParaPedido
    {
        DetallePedido de = new DetallePedido();
        Producto pr = new Producto();
        DataTable tabla = new DataTable();

        public DataTable Tabla { get => tabla; set => tabla = value; }

        public void CrearTabla(int id)
        {
            de.IdDetallePedido = id;
            Tabla = de.ListarDetallePedidoPorId();
            
        }

        public void InsertarFila(int id, string detalle, float precioUnitario, int cantidad, float subTotal)
        {

            DataRow fila = Tabla.NewRow();

            fila[0] = id;
            fila[1] = detalle;
            fila[2] = precioUnitario;
            fila[3] = cantidad;
            fila[4] = subTotal;

            Tabla.Rows.Add(fila);

            
        }
       
        public void AgregarDatos(int idProducto, string detalle, float precioUnitario, int cantidad)
        {
            float subtotal = precioUnitario * cantidad;
            int bandera=0;
      
            if (Tabla.Rows.Count == 0)
            {
                InsertarFila(idProducto, detalle, precioUnitario, cantidad, subtotal);
                return;
            }

            
            foreach (DataRow row in Tabla.Rows)
            {
                if (int.Parse(row[0].ToString()) == idProducto)
                {
                    row[0] = idProducto;
                    row[1] = detalle;
                    row[2] = precioUnitario;
                    row[3] = int.Parse(row[3].ToString()) + cantidad;
                    row[4] = subtotal + float.Parse(row[4].ToString());
                    bandera = 1;
                }
               
            }
            if (bandera == 0)
            {
                InsertarFila(idProducto, detalle, precioUnitario, cantidad, subtotal);
                bandera = 1;
            }
        }

        public void BorrarDatos(int fila)
        {
            int index = fila;
            Tabla.Rows[index].Delete();
            Tabla.AcceptChanges();
        }

    }
}

    


