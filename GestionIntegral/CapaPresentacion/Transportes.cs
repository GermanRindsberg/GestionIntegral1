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

        string operacion = "insertar";

        int idTransporte;
        int idLocalidad;
        string calle;
        String numero;
        String piso;
        string depto;
        int idDireccion;
        string razonSocial;
        string tel1;
        string observaciones;
        Boolean activo;


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
      
        private void ListarTransporteEnGrid(string condicion, string activo)
        {
            gridTransporte.DataSource = mttr.ListarTransporte(condicion, activo);
            gridTransporte.Columns[0].Visible = false;
            gridTransporte.Columns[1].Width = 200;
            gridTransporte.Columns[2].Visible = false;
            gridTransporte.Columns[5].Width = 50;
            gridTransporte.Columns[6].Width = 70;
            gridTransporte.Columns[7].Width = 70;
            gridTransporte.Columns[8].Width = 200;
            gridTransporte.Columns[9].Width = 150;
            gridTransporte.Columns[11].Width = 250;
            gridTransporte.Columns[12].Visible = false;

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

        #region EVENTOS

        private void btnAgregarTransporte_Click(object sender, EventArgs e)
        {
            if (operacion == "insertar")
            {
                //creo una direccion
                idLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                calle = txtCalle.Text;
                numero = txtNro.Text;
                piso = txtPiso.Text;
                depto = txtDepto.Text;

                Direccion dir = new Direccion(idLocalidad, calle, numero, piso, depto);//creo el objeto direccion 

                mtDir.InsertarDireccion(dir);//inserto la direccion

                idDireccion = mtDir.UltimoIdDireccion();

                //creo un transporte
                razonSocial = cbRazonSocial.Text.ToString();
                tel1 = txtTel1.Text;
                observaciones = txtObservaciones.Text;

                Transporte objtransporte = new Transporte(razonSocial, idDireccion, tel1, observaciones, true);//creo el objeto cliente

                mttr.InsertarTransportes(objtransporte);//inserto el transporte

                MessageBox.Show("Insertado con exito");
                limpiarCampos();
                ListarTransporteEnGrid("", "1");
                ListarTransporteEnComboBox();
               
            }
            if (operacion == "editar")
            {

                //edito la direccion
                idLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                calle = txtCalle.Text;
                numero = txtNro.Text;
                piso = txtPiso.Text;
                depto = txtDepto.Text;
                Direccion dir = new Direccion(idDireccion, idLocalidad, calle, numero, depto, piso);
                mtDir.EditarDireccion(dir);//edito la direccion


                if (checkActivo.Checked == true)
                {
                    activo = true;
                }
                if (checkActivo.Checked == false)
                {
                    activo = false;
                }
                razonSocial = cbRazonSocial.Text;
                tel1 = txtTel1.Text;
                observaciones = txtObservaciones.Text;

                Transporte tran = new Transporte(idTransporte, razonSocial, idDireccion, tel1, observaciones, activo);
                mttr.EditarTransporte(tran);

                MessageBox.Show("Editado con exito");
                operacion = "editar";
                limpiarCampos();
                ListarTransporteEnGrid("", "1");
                ListarTransporteEnComboBox();
                cbProvincia.SelectedIndex = 0;
            }
        }

        private void cbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRazonSocial.SelectedIndex > 0 && cbRazonSocial.Text != default)
            {
                idTransporte = Convert.ToInt32(cbRazonSocial.SelectedValue.ToString()); //COn esto le mando al cliente cual es la id

                Transporte tr = mttr.CrearTransporte(idTransporte.ToString());

                Direccion dir = mtDir.CrearDireccion(Convert.ToInt32(tr.IdDireccion));

                idDireccion = dir.IdDireccion;
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
            if (checkActivo.Checked == true)
            {
                cbRazonSocial.SelectedValue = int.Parse(gridTransporte.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (gridTransporte.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Transporte, pasara a ser inactivo?", "ELIMINAR TRANSPORTE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Transporte objTransporte = mttr.CrearTransporte(Convert.ToString(idTransporte));//traigo el cliente y su direccion por id
                    Direccion dir = mtDir.CrearDireccion(Convert.ToInt32(objTransporte.IdDireccion));
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

                }
            }
        }

        private void radioInactivos_CheckedChanged(object sender, EventArgs e)
        {
            ListarTransporteEnGrid("", "0");
        }

        private void radioActivos_CheckedChanged(object sender, EventArgs e)
        {
            ListarTransporteEnGrid("", "1");
        }

        #endregion



    }
}
