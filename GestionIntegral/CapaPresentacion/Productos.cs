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
        int idProducto;



        string operacion = "insertar";
        string operacionDiseño = "insertar";
        string operacionProducto = "insertar";

        public Productos()
        {
            InitializeComponent();

        }

        #region METODOS

        private void ListarDiseñoEnComboBox()
        {
            mg.LlenarComboBox(cbDiseño, "Diseño");
        }
        
        private void ListarFamiliaEnComboBox()
        {
            mg.LlenarComboBox(cbFamilia, "Familia");
        }

        private void diseñoTabla()
        {
            gridProducto.Columns[0].Visible = false;//idProducto
            gridProducto.Columns[1].Visible = false;//idFamilia
            gridProducto.Columns[2].Visible = false;//idDIseño
            gridProducto.Columns[3].Visible = false;//Valor unico
            //gridProducto.Columns[4].Visible = false;//descripcion producto
            gridProducto.Columns[5].Visible = false;//almacen
            gridProducto.Columns[6].Visible = false;//taller1
            gridProducto.Columns[7].Visible = false;//taller2
            gridProducto.Columns[8].Visible = false;//taller3
            gridProducto.Columns[9].Visible = false;//taller4
            gridProducto.Columns[10].Visible = false;//stockMinimo
            gridProducto.Columns[11].Visible = false;//stock
            gridProducto.Columns[12].Visible = false;//potencialstock
            gridProducto.Columns[13].Visible = false;//pedidos
            gridProducto.Columns[14].Visible = false;//requeridos
            gridProducto.Columns[15].Visible = false;//activoProducto
            gridProducto.Columns[16].Visible = false;//idFamilia
            gridProducto.Columns[17].Visible = false;//descripcionFamilia
            //gridProducto.Columns[18].Visible = false;//Lista1
            //gridProducto.Columns[19].Visible = false;//lista2
            //gridProducto.Columns[20].Visible = false;//lista3
            //gridProducto.Columns[21].Visible = false;//tizada
            //gridProducto.Columns[22].Visible = false;//papel
            //gridProducto.Columns[23].Visible = false;//tela
            gridProducto.Columns[24].Visible = false;//activoFamilia





        }

        private void limpiarCampos()
        {
            cbDiseño.Text = "Seleccione un valor";
            txtDescripcionDiseño.Text = "";

            cbFamilia.Text = "Seleccione un valor";
            txtDescripcionFamilia.Text = "";
            
            txtLista1.Text = "";
            txtLista2.Text = "";
            txtLista3.Text = "";
            txtTizada.Text = "";
            txtTela.Text = "";
            txtPapel.Text = "";
            txtStockMinimo.Text = "";
        }

        private void limpiarCamposFamilia() 
        {
            txtDescripcionFamilia.Text = "";
            txtLista1.Text = "";
            txtLista2.Text = "";
            txtLista3.Text = "";
            txtTizada.Text = "";
            txtTela.Text = "";
            txtPapel.Text = "";

        }

        private void limpiarCamposDiseño() {

            txtDescripcionDiseño.Text = "";

        }

        private void ListarProductosEnGrid(string condicion)
        {
            gridProducto.DataSource = mpro.ListarProducto(condicion);
            diseñoTabla();
        }

        private Boolean encuentraValorUnicoFamilia(string valorAbuscar)
        {
            Boolean existe = mfa.BuscarRepetidosFamilia(valorAbuscar);
            return existe;
        }

        private Boolean encuentraValorUnicoProducto(string valorAbuscar)
        {
            Boolean existe = mpro.BuscarRepetidosProducto(valorAbuscar);
            return existe;
        }

        private Boolean verificarActivo(string nombreTabla)
        {
            return mg.BuscarActivo(nombreTabla);
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
            Boolean existe = encuentraValorUnicoFamilia(txtDescripcionFamilia.Text);//busco si existe la familia
            Boolean activo = verificarActivo("Familia");

            //si la operacion es insertar y el producto no existe en la bbdd
            if (operacion == "insertar" && existe == false)
            {
                //valido que los txtbox importantes no queden vacios
                if (txtDescripcionFamilia.Text == "" || txtLista1.Text == "" || txtLista2.Text == "" || txtLista3.Text == "")
                {
                    MessageBox.Show("Debes rellenar todos los campos");
                }
                //inserto
                else
                {
                    //creo las variables para llenar el constructor a de la familia a insertar
                    string descripcionFamilia = txtDescripcionFamilia.Text;
                    Decimal lista1 = Decimal.Parse((txtLista1.Text).Replace(".", ","));
                    Decimal lista2 = Decimal.Parse((txtLista2.Text).Replace(".", ","));
                    Decimal lista3 = Decimal.Parse((txtLista3.Text).Replace(".", ","));
                    int tizada = int.Parse(txtTizada.Text);
                    Decimal papel = Decimal.Parse((txtPapel.Text).Replace(".", ","));
                    Decimal tela = Decimal.Parse((txtTela.Text).Replace(".", ","));
                    //creo el objeto familia
                    Familia fam = new Familia(descripcionFamilia, lista1, lista2, lista3, tizada, papel, tela);
                    //inserto el objeto con el metodo insertar
                    mfa.InsertarFamilia(fam);
                    MessageBox.Show("Familia creada con exito");
                    ListarFamiliaEnComboBox();
                    ListarProductosEnGrid("");

                }
            }

            //si la operacion es insertar y si existe la familia en la bbdd
            else if (operacion == "insertar" && existe == true)
            {
                //si la familia existe y esta inactiva
                if (activo == false)
                {
                    //creo las variables para llenar el constructor a de la familia a editar
                    string descripcionFamilia = txtDescripcionFamilia.Text;
                    Decimal lista1 = Decimal.Parse((txtLista1.Text).Replace(".", ","));
                    Decimal lista2 = Decimal.Parse((txtLista2.Text).Replace(".", ","));
                    Decimal lista3 = Decimal.Parse((txtLista3.Text).Replace(".", ","));
                    int tizada = int.Parse(txtTizada.Text);
                    Decimal papel = Decimal.Parse((txtPapel.Text).Replace(".", ","));
                    Decimal tela = Decimal.Parse((txtTela.Text).Replace(".", ","));
                    Boolean activar = true;
                    //creo el objeto familia
                    Familia fam = new Familia(idFamilia, descripcionFamilia, lista1, lista2, lista3, tizada, papel, tela, activar);
                    //edito el objeto con el metodo editar
                    mfa.EditarFamilia(fam);
                    MessageBox.Show("Editado con exito");

                    ListarFamiliaEnComboBox();
                    ListarProductosEnGrid("");
                }
                //si esta activo solo editar
                else
                {
                    MessageBox.Show("El producto ya existe, seleccionelo y despues edite");


                }


            }

            else if (operacion == "editar")
            {
                if (txtDescripcionFamilia.Text == "")
                {
                    MessageBox.Show("Debes rellenar todos los campos");
                }

                else
                {
                    //creo las variables para llenar el constructor a de la familia a insertar
                    string descripcionFamilia = txtDescripcionFamilia.Text;
                    Decimal lista1 = Decimal.Parse((txtLista1.Text).Replace(".", ","));
                    Decimal lista2 = Decimal.Parse((txtLista2.Text).Replace(".", ","));
                    Decimal lista3 = Decimal.Parse((txtLista3.Text).Replace(".", ","));
                    int tizada = int.Parse(txtTizada.Text);
                    Decimal papel = Decimal.Parse((txtPapel.Text).Replace(".", ","));
                    Decimal tela = Decimal.Parse((txtTela.Text).Replace(".", ","));
                    Boolean activado = true;
                    //creo el objeto familia
                    Familia fam = new Familia(idFamilia, descripcionFamilia, lista1, lista2, lista3, tizada, papel, tela, activado);
                    //edito el objeto con el metodo insertar
                    mfa.EditarFamilia(fam);
                    MessageBox.Show("Editado con exito");

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

            if (existe == false && operacionDiseño == "insertar")
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
           
            else if (operacionDiseño == "editar")
            {
                if (txtDescripcionDiseño.Text == "")
                {
                    MessageBox.Show("Debes rellenar todos los campos");
                }

                else
                {
                    //creo las variables para llenar el constructor a del diseño a editar
                    string descripcionDiseño = txtDescripcionDiseño.Text;
                    //creo el objeto diseño
                    Diseño dis = new Diseño(idDiseño, descripcionDiseño);
                    //edito el objeto con el metodo insertar
                    mDi.EditarDiseño(dis);
                    MessageBox.Show("Editado con exito");

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
                    operacion = "editar";
                    idFamilia = Convert.ToInt32(cbFamilia.SelectedValue.ToString());

                    Familia fa = mfa.CrearFamilia(idFamilia);

                    txtDescripcionFamilia.Text = fa.DescripcionFamilia;
                    txtLista1.Text = fa.Lista1.ToString();
                    txtLista2.Text = fa.Lista2.ToString();
                    txtLista3.Text = fa.Lista3.ToString();
                    txtTizada.Text = fa.Tizada.ToString();
                    txtPapel.Text = fa.Papel.ToString();
                    txtTela.Text = fa.Tela.ToString();
                }
             

            }
            if (cbFamilia.Text == "Seleccione un valor")
            {
                limpiarCamposFamilia();
                operacion = "insertar";
            }
        }
        
        private void cbDiseño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDiseño.SelectedIndex > 0 && cbDiseño.Text != default)
            {
                operacionDiseño = "editar";
                idDiseño = Convert.ToInt32(cbDiseño.SelectedValue.ToString());

                Diseño di = mDi.CrearDiseño(idDiseño);

                txtDescripcionDiseño.Text = di.DescripcionDiseño;

            }
            if (cbDiseño.Text == "Seleccione un valor")
            {
                operacion = "insertar";
                limpiarCamposDiseño();
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
                cbFamilia.SelectedValue=Convert.ToInt32( gridProducto.CurrentRow.Cells[1].Value.ToString());
                cbDiseño.SelectedValue = Convert.ToInt32(gridProducto.CurrentRow.Cells[2].Value.ToString());
                txtStockMinimo.Text = gridProducto.CurrentRow.Cells[10].Value.ToString();
                idProducto = int.Parse(gridProducto.CurrentRow.Cells[0].Value.ToString());
                operacionProducto = "editar";
                operacion = "editar";
                
            }
        }

        private void txtBuscar_KeyUp_1(object sender, KeyEventArgs e)
        {
            ListarProductosEnGrid(txtBuscar.Text); 
          
        }
        
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            //genero un id unico para evitar productos duplicados
            idUnico = Convert.ToInt32(idFamilia.ToString() + idDiseño.ToString());
            
            //genero una descripcion del producto ejemplo mochila bananas
            string descripcionProducto = txtDescripcionFamilia.Text + " " + txtDescripcionDiseño.Text;

            int stockMinimo = int.Parse(txtStockMinimo.Text);
            
            //valido que la operacion sea insertar
            if (operacionProducto == "insertar")
            {
                //valido que el valor unico no se repita con el metodo encuentravalorunico
                if (encuentraValorUnicoProducto(idUnico.ToString()) == false)
                {
                    //valido que tenga seleccionado una familia y un diseño
                    if (txtDescripcionFamilia.Text!="" && txtDescripcionDiseño.Text!="")
                    {
                        //creo un producto con todos los datos 
                        Producto producto = new Producto(idDiseño, idUnico, idFamilia, descripcionProducto, 0,0,0,0,0,stockMinimo,0,0,0,0,true);
                        //inserto el producto
                        mpro.InsertarProducto(producto);
                        MessageBox.Show("Datos Insertados con exito" );
                       //actualizo el grid las comillas son un parametro de busqueda, sirve para buscar por id o nombre
                        ListarProductosEnGrid("");
                        //limpio todo los txtbox y comboBox
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
            //edito
            if (operacionProducto == "editar")
            {
                Producto producto = new Producto(idProducto, idDiseño, idUnico, idFamilia, descripcionProducto, 0, 0, 0, 0, 0, stockMinimo, 0, 0, 0, 0, true);

                mpro.EditarProducto(producto);

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

            if (MessageBox.Show("¿Desea eliminar esta Familia?", "ELIMINAR FAMILIA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                //int idFamilia = int.Parse(gridProducto.CurrentRow.Cells[1].Value.ToString());

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


