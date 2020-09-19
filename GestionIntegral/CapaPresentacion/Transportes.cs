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
    public partial class Transportes : Form
    {
        MetodosGenericos mg = new MetodosGenericos();
        MetodosTransporte mttr = new MetodosTransporte();
        MetodosDireccion mtDir = new MetodosDireccion();
        int idTransporte;
        string operacion = "insertar";

        public Transportes()
        {
            InitializeComponent();
        }

        private void Transportes_Load(object sender, EventArgs e)
        {
            ListarTransporteEnGrid("", "1");
            ListarTransporteEnComboBox();
            ListarProvinciaEnComboBox();
            if (idTransporte != null)
            {
                cbRazonSocial.SelectedValue = idTransporte;
            }
        }

        #region METODOS

        private void diseñoTabla()
        {
            gridTransporte.ClearSelection();

            this.gridTransporte.Columns[0].Visible = false;//idTransporte
            this.gridTransporte.Columns[1].HeaderText = "Razon Social";//RazonSOcial
            this.gridTransporte.Columns[2].Visible = false;//idDireccion
            this.gridTransporte.Columns[3].HeaderText = "Telefono 1";//Telefono
            this.gridTransporte.Columns[4].HeaderText = "Observaciones";//Observaciones
            this.gridTransporte.Columns[5].Visible = false;//Activo
            this.gridTransporte.Columns[6].Visible = false;//idDIreccion
            this.gridTransporte.Columns[7].Visible = false;//idLocalidad
            this.gridTransporte.Columns[8].HeaderText = "Calle";//calle
            this.gridTransporte.Columns[9].HeaderText = "Nro";//numero
            this.gridTransporte.Columns[10].HeaderText = "Depto";//depto
            this.gridTransporte.Columns[11].HeaderText = "Piso";//piso
            this.gridTransporte.Columns[12].Visible=false;//idlocalidad
            this.gridTransporte.Columns[13].HeaderText = "Localidad"; ;//nomre
            this.gridTransporte.Columns[14].Visible = false;//cp
            this.gridTransporte.Columns[15].Visible = false;//idprovincia
            this.gridTransporte.Columns[16].HeaderText = "Provincia";//nombre
        }

        private void ListarTransporteEnGrid(string condicion, string activo)
        {
            gridTransporte.DataSource = mttr.ListarTransporte(condicion, activo);
            diseñoTabla();
        }

        private void limpiarCampos()
        {
            txtCalle.Text = "";
            txtNro.Text = "";
            txtDepto.Text = "";
            txtPiso.Text = "";
            txtTel1.Text = "";
            txtObservaciones.Text = "";
            txtCodigoPostal.Text = "";
            cbLocalidad.Text = "";
            txtCodigoPostal.Text = "";
            checkActivo.Checked = true;
            operacion = "insertar";
            radioActivos.Checked = true;


        }

        private void ListarTransporteEnComboBox()
        {
            mg.LlenarComboBox(cbRazonSocial, "Transporte");
        }
   
        private void ListarProvinciaEnComboBox()
        {
            mg.LlenarComboBox(cbProvincia, "Provincia");
        }

        private void ListarLocalidadEnComboBox()
        {
            mg.LlenarComboBox(cbLocalidad, "Localidad");
        }

        #endregion



        private void btnAgregarTransporte_Click(object sender, EventArgs e)
        {
            if (operacion == "insertar")
            {
                //creo una direccion
                int idLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                string calle = txtCalle.Text;
                String numero = txtNro.Text;
                String piso = txtPiso.Text;
                string depto = txtDepto.Text;
                Direccion dir = new Direccion(idLocalidad, calle, numero, piso, depto);//creo el objeto direccion 
                mtDir.InsertarDireccion(dir);//inserto la direccion

                //creo un cliente
                string razonSocial = cbRazonSocial.Text.ToString();
                int idDireccion = dir.IdDireccion;
                string tel1 = txtTel1.Text;
                string observaciones = txtObservaciones.Text;

                Transporte objtransporte = new Transporte(razonSocial, idDireccion, tel1, observaciones, true);//creo el objeto cliente

                mttr.InsertarTransportes(objtransporte);//inserto el cliente

                MessageBox.Show("Insertado con exito");
                limpiarCampos();
                ListarTransporteEnGrid("", "1");
                ListarTransporteEnComboBox();

                diseñoTabla();

            }
            if (operacion == "editar")
            {
                Transporte objTransporte = mttr.CrearTransporte(Convert.ToString(idTransporte));//traigo el cliente y su direccion por id
                Direccion dir = mtDir.CrearDireccion(Convert.ToString(objTransporte.IdDireccion));
                Boolean activo = true;

                //creo una direccion
                dir.IdLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                dir.Calle = txtCalle.Text;
                dir.Numero = txtNro.Text;
                dir.Piso = txtPiso.Text;
                dir.Depto = txtDepto.Text;
                mtDir.EditarDireccion(dir);//edito la direccion
                if (checkActivo.Checked == true)
                {
                    activo = true;
                }
                if (checkActivo.Checked == false)
                {
                    activo = false;
                }

                objTransporte.Activo = activo;
               
                objTransporte.Observaciones = txtObservaciones.Text;

                mttr.EditarTransporte(objTransporte);

                MessageBox.Show("Editado con exito");
                operacion = "insertar";
                limpiarCampos();
                ListarTransporteEnGrid("", "1");
                ListarTransporteEnComboBox();
                cbProvincia.SelectedIndex = 0;
                diseñoTabla();
            }
        }

        private void cbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRazonSocial.SelectedIndex > 0 && cbRazonSocial.Text != default)
            {
                string idTransporte = cbRazonSocial.SelectedValue.ToString(); //COn esto le mando al cliente cual es la id

                Transporte tr = mttr.CrearTransporte(idTransporte);

                Direccion dir = mtDir.CrearDireccion(Convert.ToString(tr.IdDireccion));
                txtCalle.Text = dir.Calle;
                txtNro.Text = dir.Numero;
                txtDepto.Text = dir.Depto;
                txtPiso.Text = dir.Piso;
                cbProvincia.SelectedValue = dir.IdProvincia;
                cbLocalidad.SelectedValue = dir.IdLocalidad;
               
                txtCodigoPostal.Text = dir.CodigoPostal;
                txtTel1.Text = tr.Tel;
                checkActivo.Checked = tr.Activo;
                txtObservaciones.Text = tr.Observaciones;
                operacion = "editar";


            }

        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {

            if (radioActivos.Checked == true)
            {
                ListarTransporteEnGrid(txtBuscar.Text, "1");
            }
            else
            {
                ListarTransporteEnGrid(txtBuscar.Text, "2");
            }

            diseñoTabla();
        }


        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProvincia.SelectedIndex > 0)
            {
                mg.idProvincia = Convert.ToInt32(cbProvincia.SelectedValue.ToString());
                ListarLocalidadEnComboBox();
            }
        }

        private void cbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbLocalidad.SelectedIndex > 0)
            {
                int idLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());

                mtDir.ListarCodigoPostal(txtCodigoPostal, idLocalidad);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            ListarTransporteEnComboBox();
            ListarProvinciaEnComboBox();
            ListarTransporteEnComboBox();


        }

        private void gridTransporte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridTransporte.SelectedRows.Count > 0)
            {
                cbRazonSocial.SelectedValue = int.Parse(gridTransporte.CurrentRow.Cells[0].Value.ToString());

                operacion = "editar";
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (gridTransporte.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Transporte, pasara a ser inactivo?", "ELIMINAR TRANSPORTE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Transporte objTransporte = mttr.CrearTransporte(Convert.ToString(idTransporte));//traigo el cliente y su direccion por id
                    Direccion dir = mtDir.CrearDireccion(Convert.ToString(objTransporte.IdDireccion));
                    Boolean activo = false;

                    //creo una direccion
                    dir.IdLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                    dir.Calle = txtCalle.Text;
                    dir.Numero = txtNro.Text;
                    dir.Piso = txtPiso.Text;
                    dir.Depto = txtDepto.Text;
                    mtDir.EditarDireccion(dir);//edito la direccion
            

                    objTransporte.Activo = activo;

                    objTransporte.Observaciones = txtObservaciones.Text;

                    mttr.EditarTransporte(objTransporte);


                    MessageBox.Show("Borrado con exito");
                    operacion = "insertar";
                    limpiarCampos();
                    ListarTransporteEnGrid("", "1");
                    ListarTransporteEnComboBox();
                    cbProvincia.SelectedIndex = 0;
                    diseñoTabla();

                }
            }
        }

            
        
    }
}
