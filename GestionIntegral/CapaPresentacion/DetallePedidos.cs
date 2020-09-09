using GestionIntegral.CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionIntegral.CapaPresentacion
{
    public partial class DetallePedidos : Form
    {
        public int idDetallePedido;
        public int idCliente;
        int idDireccion;
        int idTransporte;

        public DetallePedidos()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DiseñoTabla()
        {
            dvPedido.Columns[0].Visible = false;//idDetallePedido
            dvPedido.Columns[1].Visible = false;//idProducto
            // dvPedido.Columns[2].Visible = false;//preciounitario
            //  dvPedido.Columns[3].Visible = false;//cantidad
            // dvPedido.Columns[4].Visible = false;//subtotal
            dvPedido.Columns[5].Visible = false;//idProducto
            dvPedido.Columns[6].Visible = false;//idfamilia
            dvPedido.Columns[7].Visible = false;//idDiseño
            dvPedido.Columns[8].Visible = false;//ValorUnico
            //dvPedido.Columns[9].Visible = false;//Descripcion
            dvPedido.Columns[10].Visible = false;//Lista1
            dvPedido.Columns[11].Visible = false;//Lista2
            dvPedido.Columns[12].Visible = false;//Lista3
            dvPedido.Columns[13].Visible = false;//id
            dvPedido.Columns[14].Visible = false;//idCliente
            dvPedido.Columns[15].Visible = false;//total
            dvPedido.Columns[16].Visible = false;//idEstado
            dvPedido.Columns[17].Visible = false;//idDetallePedido
            dvPedido.Columns[18].Visible = false;//Fecha
            dvPedido.Columns[19].Visible = false;//nroguia
            dvPedido.Columns[20].Visible = false;//Pagado



            dvPedido.Columns[2].HeaderText = "Precio unitario";
            dvPedido.Columns[3].HeaderText = "Cantidad";
            dvPedido.Columns[4].HeaderText = "Subtotal";
            dvPedido.Columns[9].HeaderText = "Detalle producto";
            dvPedido.Columns[2].Width = 80;
            dvPedido.Columns[3].Width = 80;
            dvPedido.Columns[4].Width = 80;


            dvPedido.Columns[9].DisplayIndex = 0;
            dvPedido.Columns[3].DisplayIndex = 1;

            lblFechaAlta.Text = dvPedido.Rows[0].Cells[18].Value.ToString();
            lblTotal.Text = "Total: $ "+ dvPedido.Rows[0].Cells[15].Value.ToString();
            dvPedido.ClearSelection();



        }

        private void DetallePedido_Load(object sender, EventArgs e)
        {
            Pedidos pe = new Pedidos();
            pe.IdDetallePedido = idDetallePedido;

            lblNumPedido.Text = "Pedido Nº: " + idDetallePedido.ToString();

            ListarClienteEnLabels();
            ListarDireccionEnLabels();
            ListarTransporteEnLabels();
            DiseñoTabla();
        }

        private void ListarClienteEnLabels()
        {
            Cliente cl = new Cliente();
            cl.IdCliente = idCliente;
            
            cl.ListarClientePorId();

            lblRazonSocial.Text = cl.RazonSocial;
            lblTel1.Text = cl.Tel1;
            lblTel2.Text = cl.Tel2;
            lblEmail.Text = cl.Email;
            lblCuit.Text = cl.Cuit;
      
            lblObsCliente.Text = cl.Observaciones;
            idDireccion = cl.IdDireccion;
            idTransporte = cl.IdTransporte;
           

        }

        private void ListarDireccionEnLabels()
        {
            Direccion di = new Direccion();
            di.IdDireccion = idDireccion;
            di.ListarDireccionPorId();

            lblCalleCliente.Text = di.Calle;
            lblNro.Text = di.Numero;
            lblDepto.Text = di.Depto;
            lblPiso.Text = di.Piso;
            lblLocalidad.Text = di.NombreLocalidad;
            lblProvincia.Text = di.NombreProvincia;
            lblCp.Text = di.CodigoPostal;
        }

        private void ListarTransporteEnLabels()
        {
            Transporte tr = new Transporte();
            tr.IdTransporte = idTransporte;
            tr.ListarTransportePorId();

            lblRazonTransporte.Text = tr.RazonSocial;
            lblTelTransporte.Text = tr.Tel;
            lblObservacionesTransporte.Text = tr.Observaciones;
          
        }


        #region IMPRESION

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap objBmp = new Bitmap(this.Width, this.Height);
            panel.DrawToBitmap(objBmp, new Rectangle(0, 0, this.Width, this.Height));

            e.Graphics.DrawImage(objBmp, 1, 10);
            printDocument1.PrinterSettings.Copies = 1;
        }

        #endregion

    }
}

