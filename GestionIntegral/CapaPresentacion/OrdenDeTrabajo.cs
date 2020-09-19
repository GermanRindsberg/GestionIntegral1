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
            ListarTalleres();
        }

        private void ListarTalleres()
        {
            cbTaller.DataSource = mt.ListarTaller("","1");
            cbTaller.DisplayMember = "razonSocial";
            cbTaller.ValueMember = "id";
            cbTaller.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbTaller.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ListarProductos()
        {
            cbTaller.DataSource = mp.ListarProductos();
            cbTaller.DisplayMember = "Nombre del producto";
            cbTaller.ValueMember = "id";
            cbTaller.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbTaller.AutoCompleteSource = AutoCompleteSource.ListItems;
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

        }
    }
}
