using GestionIntegral.CapaDatos;
using GestionIntegral.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionIntegral.CapaNegocio
{
    class TablaParaPedido
    {
        MetodosDetallePedido metDetalle = new MetodosDetallePedido();
        MetodosOT metOt = new MetodosOT();

        Producto pr = new Producto();
       public DataTable Tabla = new DataTable();

        

        public void CrearTabla(int id)
        {
            Tabla= metDetalle.ListarDetallePedidoPorId(id);
            
        }

        public void CrearTablaOt(int id)
        {
       //    Tabla = metOt.Listar(id);

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
        public void InsertarFilaOt(int id, string detalle,int cantidad)
        {
            DataRow fila = Tabla.NewRow();
            fila[0] = id;
            fila[1] = detalle;
            fila[2] = cantidad;
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

        public void AgregarDatosOT(int idProducto, string detalle, int cantidad)
        {
            int bandera = 0;

            if (Tabla.Rows.Count == 0)//si la tabla no tiene datos insertar una fila nueva con los datos pasados por parametro
            {
                InsertarFilaOt(idProducto, detalle, cantidad);
                return;
            }


            foreach (DataRow row in Tabla.Rows)//si tiene datos que vaya comparando el idProducto, si es igual que lo sume y no lo ponga en fila nueva
            {
                if (int.Parse(row[0].ToString()) == idProducto)
                {
                    row[0] = idProducto;
                    row[1] = detalle;
                    row[2] = int.Parse(row[3].ToString()) + cantidad;
                    bandera = 1;
                }

            }
            if (bandera == 0)
            {
                InsertarFilaOt(idProducto, detalle, cantidad);
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

    


