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
    public partial class Productos : Form
    {
        MetodosGenericos mg = new MetodosGenericos();
        MetodosFamilia mfa = new MetodosFamilia();
        MetodosDiseño mDi = new MetodosDiseño();
        MetodosProductos mpro = new MetodosProductos();

        int idFamilia;
        int idDiseño;
        int idUnico;

        string operacion = "insertar";

        public Productos()
        {
            InitializeComponent();

        }

        #region METODOS

        private void ListarDiseñoEnComboBox()
        {
            mg.LlenarComboBox(cbDiseño, "Diseños");
        }
        
        private void ListarFamiliaEnComboBox()
        {
            mg.LlenarComboBox(cbFamilia, "Familia");
        }

        private void diseñoTabla()
        {
            this.gridProducto.Columns[0].Visible = false;//idProducto
            this.gridProducto.Columns[1].Visible = false;//idProducto
            this.gridProducto.Columns[2].Visible = false;//idProducto
            this.gridProducto.Columns[3].Visible = false;//idProducto
        }

        private void limpiarCampos()
        {
            cbDiseño.Text = "Seleccione un valor";
            txtDescripcionDiseño.Text = "";
            cbFamilia.Text = "Seleccione un valor";
            txtDescripcionFamilia.Text = "";
            txtFami.Text = "";
            txtDise.Text = "";
            txtLista1.Text = "";
            txtLista2.Text = "";
            txtLista3.Text = "";
        }

        private void ListarProductosEnGrid(string condicion)
        {
            gridProducto.DataSource = mpro.ListarProducto(condicion);
            diseñoTabla();
        }

        private Boolean encuentraValorUnico()
        {
            if (gridProducto.RowCount > 0)
            {
                for (int i = 0; i < gridProducto.RowCount; i++)
                {
                    if (Convert.ToInt32(gridProducto.Rows[i].Cells[3].Value) == idUnico)
                    {
                        MessageBox.Show("El producto ya ha sido ingresado");
                        return true;
                    }
                    else
                        return false;
                }
            }
            return false;
        }

        #endregion


        #region EVENTOS

        private void Productos_Load(object sender, EventArgs e)
        {

            ListarDiseñoEnComboBox();
            ListarFamiliaEnComboBox();
            ListarProductosEnGrid("");
            

        }

        private void btnAgregarFamilia_Click_1(object sender, EventArgs e)
        {
            Boolean existe = true;

            foreach (var item in cbFamilia.Items)
            {
                if (cbFamilia.Text==txtDescripcionFamilia.Text)
                {
                    MessageBox.Show("El producto ya existe");
                    existe = true;
                    break;
                }
                else
                {
                    existe = false;
                }
            }

            if (existe == false)
            {

                if (txtDescripcionFamilia.Text == "" )
                {
                    MessageBox.Show("Debes rellenar todos los campos");
                }

                else
                {
                    string descripcionFamilia = txtDescripcionFamilia.Text;
                    Familia fam = new Familia(descripcionFamilia);
                    mfa.InsertarFamilia(fam);
                    ListarFamiliaEnComboBox();
                    ListarProductosEnGrid("");

                }
            }
        }

        private void btnAgregarDiseño_Click_1(object sender, EventArgs e)
        {
            Boolean existe = true;

            foreach (var item in cbDiseño.Items)
            {

                if (cbDiseño.Text==txtDescripcionDiseño.Text)
                {
                    MessageBox.Show("El diseño ya existe");
                    existe = true;
                    break;
                }
                else
                {
                    existe = false;
                }
            }

            if (existe == false)
            {
                if (txtDescripcionDiseño.Text == "")
                {
                    MessageBox.Show("Debes rellenar todos los campos");

                }
                else
                {
                    string descripcionDiseño = txtDescripcionDiseño.Text;
                    Diseño dis = new Diseño(descripcionDiseño);
                    mDi.InsertarDiseño(dis);
                    ListarDiseñoEnComboBox();
                    ListarProductosEnGrid("");
                }
            }

        }

        private void cbFamilia_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbFamilia.SelectedIndex > 0)
            {
                if (cbFamilia.SelectedIndex > 0 && cbFamilia.Text != default)
                {
                    idFamilia = Convert.ToInt32(cbFamilia.SelectedValue.ToString());

                    Familia fa = mfa.CrearFamilia(idFamilia);

                    txtDescripcionFamilia.Text = fa.DescripcionFamilia;
                    operacion = "editar";
                }
            }
        }
        
        private void cbDiseño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDiseño.SelectedIndex > 0 && cbDiseño.Text != default)
            {
                idDiseño = Convert.ToInt32(cbDiseño.SelectedValue.ToString());

                Diseño di = mDi.CrearDiseño(idDiseño);

                txtDescripcionDiseño.Text = di.DescripcionDiseño;
                operacion = "editar";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void gridProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridProducto.SelectedRows.Count > 0)
            {
                cbFamilia.SelectedValue = int.Parse(gridProducto.CurrentRow.Cells[1].Value.ToString());
                cbDiseño.SelectedValue = int.Parse(gridProducto.CurrentRow.Cells[2].Value.ToString());
                txtLista1.Text = gridProducto.CurrentRow.Cells[5].Value.ToString();
                txtLista2.Text = gridProducto.CurrentRow.Cells[6].Value.ToString();
                txtLista3.Text = gridProducto.CurrentRow.Cells[7].Value.ToString();
                operacion = "editar";
            }
            
        }

        private void txtBuscar_KeyUp_1(object sender, KeyEventArgs e)
        {
            ListarProductosEnGrid(txtBuscar.Text); 
          
        }
        
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            idUnico = Convert.ToInt32(idFamilia.ToString() + idDiseño.ToString());
            string descripcionProducto = txtDescripcionDiseño.Text + " " + txtDescripcionFamilia;
           

            if (operacion == "insertar")
            {
                Producto producto = new Producto(idDiseño, idUnico, idFamilia, descripcionProducto,
               float.Parse(txtLista1.Text), float.Parse(txtLista2.Text), float.Parse(txtLista3.Text));

                if (encuentraValorUnico() == false && operacion == "insertar" )
                {
                    if (txtLista1.Text != ""|| txtLista2.Text != "" || txtLista3.Text != "")
                    {
                        mpro.InsertarProducto(producto);

                        //pro.InsertarStock();

                        MessageBox.Show("Datos Insertados con exito" );
                        ListarProductosEnGrid("");
                        limpiarCampos();
                    }
                    else {
                        MessageBox.Show("Falta ingresar los precios del producto");
                    }
                }
                else
                {
                    MessageBox.Show("Datos no insertados");
                }
            }
            if (operacion == "editar")
            {

                int idProducto = int.Parse(gridProducto.CurrentRow.Cells[0].Value.ToString());

                Producto productoAeditar = new Producto(idProducto,idDiseño, idUnico, idFamilia, descripcionProducto,
                 float.Parse(txtLista1.Text), float.Parse(txtLista2.Text), float.Parse(txtLista3.Text));

                mpro.EditarProducto(productoAeditar);

                MessageBox.Show("Editado con exito");
                limpiarCampos();
                ListarProductosEnGrid("");

            }
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gridProducto.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Producto?", "ELIMINAR PRODUCTO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int idProducto = int.Parse(gridProducto.CurrentRow.Cells[0].Value.ToString());
                    string descripcionProducto = txtDescripcionDiseño.Text + " " + txtDescripcionFamilia;

                    Producto productoABorrar = new Producto(idProducto);

                    mpro.EliminarProducto(productoABorrar);

                    MessageBox.Show("Borrado con exito");
                    limpiarCampos();
                    ListarProductosEnGrid("");
                }
            }

        }

        private void btnBorrarFamilia_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Desea eliminar esta Familia?", "ELIMINAR FAMILIAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                int idFamilia = int.Parse(gridProducto.CurrentRow.Cells[1].Value.ToString());

                Familia familiaABorrar = new Familia(idFamilia);

                mfa.EliminarFamilia(familiaABorrar);

                MessageBox.Show("Borrado con exito");
                limpiarCampos();
                ListarProductosEnGrid("");

            }
            if (cbFamilia.Items.Count > 0)
            {
                ListarFamiliaEnComboBox();
            }
            else
            {
                cbFamilia.Text = "Seleccione un valor";
            }
        }

        private void btnBorrarDiseño_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar esta Familia?", "ELIMINAR FAMILIAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int idDiseño = int.Parse(gridProducto.CurrentRow.Cells[2].Value.ToString());

                Diseño diseñoABorrar = new Diseño(idDiseño);

                mDi.EliminarDiseño(diseñoABorrar);

                MessageBox.Show("Borrado con exito");
                limpiarCampos();
                ListarProductosEnGrid("");

            }
            if (cbDiseño.Items.Count > 0)
            {
                ListarDiseñoEnComboBox();
            }
            else
            {
                cbDiseño.Text = "Seleccione un valor";
            }


        }
        #endregion


    }
}


