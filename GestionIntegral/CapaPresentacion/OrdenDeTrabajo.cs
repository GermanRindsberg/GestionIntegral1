using GestionIntegral.CapaDatos;
using GestionIntegral.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionIntegral.CapaPresentacion
{
    public partial class OrdenDeTrabajo : Form
    {
        TablaParaPedido ta = new TablaParaPedido();
        MetodosTaller mt = new MetodosTaller();
        MetodosProductos mp = new MetodosProductos();
        MetodosGenericos mg = new MetodosGenericos();

        int idProducto;
        string detalleProducto;//cuando selecciona el comboBox producto trae a esta variable el texto


        public OrdenDeTrabajo()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevosTaller_Click(object sender, EventArgs e)
        {
            Talleres ta = new Talleres();
            ta.ShowDialog();
        }

        private void btnAgregarProductoNuevo_Click(object sender, EventArgs e)
        {
            Productos pr = new Productos();
            pr.ShowDialog();
        }

        private void OrdenDeTrabajo_Load(object sender, EventArgs e)
        {
            ListarTalleresEnComboBox();
            ListarProductosEnComboBox();
            date10diasDespues.Value= DateTime.Now.AddDays(10);
            
        }

        private void ListarTalleresEnComboBox()
        {
            mg.LlenarComboBox(cbTaller, "Talleres");
        }
        private void ElegirProducto()
        {
            if (cbProducto.SelectedIndex > 0)
            {
                detalleProducto = cbProducto.Text;
                Producto pro = mp.CrearProducto(cbProducto.SelectedValue.ToString());
                txtCant.Text = "1";

                idProducto = pro.IdProducto;

            }
        }

        private void ListarProductosEnComboBox()
        {
            mg.LlenarComboBox(cbProducto, "Producto");
        }

        private void btnMasCantidad_Click(object sender, EventArgs e)
        {
            if (txtCant.Text == "")
            { }
            else
                txtCant.Text = Convert.ToString(Convert.ToInt32(txtCant.Text) + 1);
        }

        private void btnMenosCantidad_Click(object sender, EventArgs e)
        {
            if (txtCant.Text == "")
            { }
            else
                txtCant.Text = Convert.ToString(Convert.ToInt32(txtCant.Text) - 1);
        }

        private void btnSumarProducto_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedIndex > 0)
            {
                ta.AgregarDatosOT(Convert.ToInt32(cbProducto.SelectedValue.ToString()), cbProducto.Text, int.Parse(txtCant.Text));
                gridOT.DataSource = ta.Tabla;
                gridOT.Columns[0].Visible = false;
            }
        }

        private void OrdenDeTrabajo_Activated(object sender, EventArgs e)
        {
            ListarTalleresEnComboBox();
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElegirProducto();
            



        }
    }
}
