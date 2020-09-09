using GestionIntegral.CapaDatos;
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
        ConexionBBDD con = new ConexionBBDD();
        int idUnico;
        string descripcionProducto;
        Familia fa = new Familia();
        Diseño di = new Diseño();
        Producto pro = new Producto();

        string operacion = "insertar";

        public Productos()
        {
            InitializeComponent();

        }

        #region METODOS

        private void ListarDiseños()
        {
            cbDiseño.DataSource = di.ListarDiseños();
            cbDiseño.DisplayMember = "descripcion";
            cbDiseño.ValueMember = "idDiseños";
            cbDiseño.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbDiseño.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ListarFamilia()
        {
            cbFamilia.DataSource = fa.ListarFamilia();
            cbFamilia.DisplayMember = "descripcion";
            cbFamilia.ValueMember = "idFamilia";
            cbFamilia.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbFamilia.AutoCompleteSource = AutoCompleteSource.ListItems;
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

        private void LlenarGrid()
        {
            con.ActualizarGrid(gridProducto, "Select * from Producto ");
            diseñoTabla();
        }


        private Boolean encuentraValorUnico(int mensaje)
        {
            bool existe = false;

            if (gridProducto.RowCount > 0)
            {
                for (int i = 0; i < gridProducto.RowCount; i++)
                {
                    if (Convert.ToInt32(gridProducto.Rows[i].Cells[3].Value) == Convert.ToInt32(idUnico) && mensaje == 1)
                    {
                        MessageBox.Show("El producto ya ha sido ingresado");
                        existe = true;
                        break;
                    }
                    if (Convert.ToInt32(gridProducto.Rows[i].Cells[3].Value) == Convert.ToInt32(idUnico) && mensaje == 0)
                    {
                        existe = true;
                        break;
                    }
                }


                if (existe == false)
                {
                    existe = false;

                }
            }
            return existe;
        }
        #endregion


        #region EVENTOS
        private void Productos_Load(object sender, EventArgs e)
        {

            ListarDiseños();
            ListarFamilia();
            LlenarGrid();
            

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
                    Familia fam = new Familia();
                    fam.DescripcionFamilia = txtDescripcionFamilia.Text;
                    fam.InsertarFamilia();
                    existe = true;
                    limpiarCampos();
                    ListarFamilia();

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
                    Diseño di = new Diseño();
                    di.DescripcionDiseño = txtDescripcionDiseño.Text;
                    di.InsertarDiseño();
                    existe = true;
                    limpiarCampos();
                    ListarDiseños();

                }
            }




        }

        private void cbFamilia_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbFamilia.SelectedIndex > 0)
            {
                fa.IdFamilia = (Convert.ToInt32(cbFamilia.SelectedValue.ToString()));
                
              
                fa.ListarFamiliaPorId();

                txtFami.Text = fa.DescripcionFamilia;
                txtLista1.Text = pro.Lista1.ToString();
                txtLista2.Text = pro.Lista2.ToString();
                txtLista3.Text = pro.Lista3.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (gridProducto.SelectedCells.Count > 0)
            {
                
                cbFamilia.SelectedValue = int.Parse(gridProducto.CurrentRow.Cells[1].Value.ToString());
                cbDiseño.SelectedValue = int.Parse(gridProducto.CurrentRow.Cells[2].Value.ToString());
                pro.IdProducto = int.Parse(gridProducto.CurrentRow.Cells[0].Value.ToString());
                pro.ListarProductoPorId();
                txtLista1.Text = pro.Lista1.ToString();
                txtLista2.Text = pro.Lista2.ToString();
                txtLista3.Text = pro.Lista3.ToString();
                operacion = "editar";
             
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
            

        }
    
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void gridProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnActualizar.Enabled = true;
        }

        private void gridProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnActualizar.Enabled = true;
        }

        private void gridProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (gridProducto.SelectedCells.Count > 0)
            {

                cbFamilia.SelectedValue = int.Parse(gridProducto.CurrentRow.Cells[1].Value.ToString());
                cbDiseño.SelectedValue = int.Parse(gridProducto.CurrentRow.Cells[2].Value.ToString());
                pro.IdProducto = int.Parse(gridProducto.CurrentRow.Cells[0].Value.ToString());
                pro.ListarProductoPorId();
                txtLista1.Text = pro.Lista1.ToString();
                txtLista2.Text = pro.Lista2.ToString();
                txtLista3.Text = pro.Lista3.ToString();
                operacion = "editar";

            }
            else
                MessageBox.Show("Debe seleccionar una fila");

        }

        private void txtBuscar_KeyUp_1(object sender, KeyEventArgs e)
        {
            ConexionBBDD con = new ConexionBBDD();

            con.ActualizarGrid(gridProducto, "SELECT* FROM Producto WHERE Producto.descripcionProducto like '%" + txtBuscar.Text + "%';");

            diseñoTabla();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

            idUnico = Convert.ToInt32( fa.IdFamilia.ToString() + di.IdDiseño.ToString());
            descripcionProducto = fa.DescripcionFamilia + " " + di.DescripcionDiseño;

            if (operacion == "insertar")
            {
                if (encuentraValorUnico(1) == false && operacion == "insertar" )
                {
                    if (txtLista1.Text != ""|| txtLista2.Text != "" || txtLista3.Text != "")
                    {
                        pro.IdDiseño = di.IdDiseño;
                        pro.IdFamilia = fa.IdFamilia;
                        pro.ValorUnico = idUnico;
                        pro.Lista1 = float.Parse(txtLista1.Text);
                        pro.Lista2 = float.Parse(txtLista2.Text);
                        pro.Lista3 = float.Parse(txtLista3.Text);
                        pro.DescripcionProducto = descripcionProducto;
                        pro.InsertarProductos();

                        LlenarGrid();

                        MessageBox.Show("Datos Insertados con exito");
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
                pro.IdProducto = int.Parse(gridProducto.CurrentRow.Cells[0].Value.ToString());
                pro.IdDiseño = di.IdDiseño;
                pro.IdFamilia = fa.IdFamilia;
                pro.ValorUnico = idUnico;
                pro.DescripcionProducto = descripcionProducto;
                pro.Lista1 = float.Parse(txtLista1.Text);
                pro.Lista2 = float.Parse(txtLista2.Text);
                pro.Lista3 = float.Parse(txtLista3.Text);

                fa.IdFamilia = int.Parse(gridProducto.CurrentRow.Cells[1].Value.ToString());
                fa.DescripcionFamilia = txtDescripcionFamilia.Text;


                di.IdDiseño = int.Parse(gridProducto.CurrentRow.Cells[2].Value.ToString());
                di.DescripcionDiseño = txtDescripcionDiseño.Text;

                di.EditarDiseño();
                fa.EditarFamilia();
                pro.EditarProducto();

                MessageBox.Show("Editado con exito");
                limpiarCampos();
                LlenarGrid();

            }
            this.Close();

        }

        private void cbDiseño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDiseño.SelectedIndex > 0)
            {
                di.IdDiseño = Convert.ToInt32(cbDiseño.SelectedValue.ToString());
                di.ListarDiseñoPorId();

                txtDise.Text = di.DescripcionDiseño;
            }
        }



        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (gridProducto.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Producto?", "ELIMINAR PRODUCTO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Producto pr = new Producto();
                    pr.IdProducto= int.Parse(gridProducto.CurrentRow.Cells[0].Value.ToString());
                    pr.EliminarProducto();
                }
            }
            LlenarGrid();
            limpiarCampos();
        }

        private void btnBorrarFamilia_Click(object sender, EventArgs e)
        {
        
                if (MessageBox.Show("¿Desea eliminar esta Familia?", "ELIMINAR FAMILIAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                Familia fam = new Familia();
                fam.IdFamilia = int.Parse(cbFamilia.SelectedValue.ToString());
                fam.EliminarFamilia();

                

                limpiarCampos();
                if (cbFamilia.Items.Count > 0)
                {
                    ListarFamilia();
                }
                else
                {
                    cbFamilia.Text = "Seleccione un valor";
                }


            }
      
            }

        private void btnBorrarDiseño_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar esta Familia?", "ELIMINAR FAMILIAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Diseño di = new Diseño();
                di.IdDiseño = int.Parse(cbDiseño.SelectedValue.ToString());
                di.EliminarDiseño();

                
                limpiarCampos();
                if (cbDiseño.Items.Count > 0)
                {
                    ListarDiseños();
                }
                else
                {
                    cbDiseño.Text = "Seleccione un valor";
                }
            }

        
        }
    }
}


