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
    public partial class Clientes : Form
    {
    

        MetodosGenericos mg = new MetodosGenericos();
        MetodosCliente mtcl = new MetodosCliente();
        MetodosDireccion mtDir = new MetodosDireccion();

        int tipoLista;
        String operacion="insertar";
        public int idCliente;

        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            ListarClientesEnGrid("", "1");
            ListarClienteEnComboBox();
            ListarTransporteEnComboBox();
            ListarProvinciaEnComboBox();

            if (idCliente != null)
            {
                cbRazonSocial.SelectedValue = idCliente;
            }
        }

        #region METODOS

        private void diseñoTabla()
        {
            gridClientes.ClearSelection();

            this.gridClientes.Columns[0].Visible = false;
            this.gridClientes.Columns[1].HeaderText = "Razon Social";
            this.gridClientes.Columns[2].Visible = false;
            this.gridClientes.Columns[3].HeaderText = "Telefono 1";
            this.gridClientes.Columns[4].HeaderText = "Telefono 2";
            this.gridClientes.Columns[5].Visible = false;
            this.gridClientes.Columns[6].HeaderText = "Email";
            this.gridClientes.Columns[7].HeaderText = "CUIT";
            this.gridClientes.Columns[8].Visible = false;
            this.gridClientes.Columns[9].Visible = false;
            this.gridClientes.Columns[10].HeaderText = "Observ.";
            this.gridClientes.Columns[11].Visible = false;
            this.gridClientes.Columns[12].Visible = false;
            this.gridClientes.Columns[13].Visible = false;
            this.gridClientes.Columns[14].HeaderText = "Calle";
            this.gridClientes.Columns[15].HeaderText = "Nro";
            this.gridClientes.Columns[16].HeaderText = "Depto";
            this.gridClientes.Columns[17].HeaderText = "Piso";
            this.gridClientes.Columns[18].Visible = false;
            this.gridClientes.Columns[19].Visible = false;
            this.gridClientes.Columns[20].HeaderText = "Localidad";
            this.gridClientes.Columns[21].Visible = false;
            this.gridClientes.Columns[22].Visible = false;
            this.gridClientes.Columns[23].HeaderText = "Provincia";

            gridClientes.Columns[15].Width = 50;
            gridClientes.Columns[16].Width = 50;
            gridClientes.Columns[17].Width = 50;
            gridClientes.Columns[18].Width = 50;
            gridClientes.Columns[23].Width = 100;
            gridClientes.Columns[1].Width = 140;
        }

        private void ListarClientesEnGrid(string condicion, string activo)
        {
            gridClientes.DataSource = mtcl.ListarClientes(condicion, activo);
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
            txtCuit.Text = "";
            txtTel2.Text = "";
            txtMail.Text = "";
            txtCodigoPostal.Text = "";
            cbTipoLista.SelectedIndex = -1;
            checkActivo.Checked = true;
            operacion = "insertar";
            radioActivos.Checked = true;


        }

        private void ListarClienteEnComboBox()
        {
            mg.LlenarComboBox(cbRazonSocial, "Clientes");
        }

        private void ListarTransporteEnComboBox()
        {

            mg.LlenarComboBox(cbTransporte, "Transporte");
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

        private void btnAgregarCliente_Click_1(object sender, EventArgs e)
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
                string tel2 = txtTel2.Text;
                string email = txtMail.Text;
                string cuit = txtCuit.Text;
                int idTransporte = Convert.ToInt32(cbTransporte.SelectedValue.ToString());
                DateTime fechaAlta = dtpFechaAlta.Value;
                string observaciones = txtObservaciones.Text;

                Cliente objCliente = new Cliente(razonSocial, idDireccion, tel1, tel2, true,
                    email, cuit, idTransporte, fechaAlta, observaciones, tipoLista);//creo el objeto cliente

                mtcl.InsertarClientes(objCliente);//inserto el cliente

                MessageBox.Show("Insertado con exito");
                limpiarCampos();
                ListarClientesEnGrid("", "1");
                ListarTransporteEnComboBox();

                diseñoTabla();

            }
            if (operacion == "editar")
            {
                Cliente objCliente = mtcl.CrearCliente(Convert.ToString(idCliente));//traigo el cliente y su direccion por id
                Direccion dir = mtDir.CrearDireccion(Convert.ToString(objCliente.IdDireccion));
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

                objCliente.Email = txtMail.Text;
                objCliente.Cuit = txtCuit.Text;
                objCliente.IdTransporte = Convert.ToInt32(cbTransporte.SelectedValue.ToString());
                objCliente.Activo = activo;
                objCliente.FechaAlta = dtpFechaAlta.Value;
                objCliente.Observaciones = txtObservaciones.Text;
                objCliente.TipoLista = tipoLista;

                mtcl.EditarClientes(objCliente);

                MessageBox.Show("Editado con exito");
                operacion = "insertar";
                limpiarCampos();
                ListarClientesEnGrid("", "1");
                ListarTransporteEnComboBox();
                cbProvincia.SelectedIndex = 0;
                diseñoTabla();
            }
        }

        private void cbRazonSocial_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbRazonSocial.SelectedIndex > 0 && cbRazonSocial.Text != default)
            {
                string idCliente =  cbRazonSocial.SelectedValue.ToString(); //COn esto le mando al cliente cual es la id

                Cliente cl = mtcl.CrearCliente(idCliente);
                Direccion dir = mtDir.CrearDireccion(Convert.ToString(cl.IdDireccion));
                txtCalle.Text = dir.Calle;
                txtNro.Text = dir.Numero;
                txtDepto.Text = dir.Depto;
                txtPiso.Text = dir.Piso;
                cbProvincia.SelectedValue = dir.IdProvincia;
                cbLocalidad.SelectedValue = dir.IdLocalidad;
                cbTransporte.SelectedValue = cl.IdTransporte;
                txtCodigoPostal.Text = dir.CodigoPostal;
                txtTel1.Text = cl.Tel1;
                txtTel2.Text = cl.Tel2;
                txtCuit.Text = cl.Cuit;
                txtMail.Text = cl.Email;
                checkActivo.Checked = cl.Activo;
                cbTipoLista.SelectedIndex = cl.TipoLista;
                dtpFechaAlta.Value = cl.FechaAlta;
                txtObservaciones.Text = cl.Observaciones;
                operacion = "editar";
            }
        }
        
        private void txtBuscar_KeyUp_1(object sender, KeyEventArgs e)
        {
           
            if (radioActivos.Checked == true)
            {
                ListarClientesEnGrid(txtBuscar.Text, "1");
            }
            else
            {
                ListarClientesEnGrid(txtBuscar.Text, "2");
            }

            diseñoTabla();
        }

        private void cbProvincia_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbProvincia.SelectedIndex > 0)
            {
                mg.idProvincia = Convert.ToInt32(cbProvincia.SelectedValue.ToString());
                ListarLocalidadEnComboBox();
            }
        }

        private void cbLocalidad_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbLocalidad.SelectedIndex > 0)
            {
                int idLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());

                mtDir.ListarCodigoPostal(txtCodigoPostal, idLocalidad);
            }
        }

        private void btnTransporte_Click(object sender, EventArgs e)
        {
            Transportes tra = new Transportes();
            tra.ShowDialog();
        }

        private void cbTipoLista_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            tipoLista = (cbTipoLista.SelectedIndex);
        }

        private void btnLimpiarCliente_Click_1(object sender, EventArgs e)
        {
            limpiarCampos();
            ListarClienteEnComboBox();
            ListarProvinciaEnComboBox();
            ListarTransporteEnComboBox();

        }

        private void gridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridClientes.SelectedRows.Count > 0)
            {
                cbRazonSocial.SelectedValue = int.Parse(gridClientes.CurrentRow.Cells[0].Value.ToString());

                operacion = "editar";
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (gridClientes.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Cliente, pasara a ser inactivo?", "ELIMINAR CLIENTE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Cliente objCliente = mtcl.CrearCliente(Convert.ToString(idCliente));//traigo el cliente y su direccion por id
                    Direccion dir = mtDir.CrearDireccion(Convert.ToString(objCliente.IdDireccion));
                    Boolean activo = false;

                    //creo una direccion
                    dir.IdLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                    dir.Calle = txtCalle.Text;
                    dir.Numero = txtNro.Text;
                    dir.Piso = txtPiso.Text;
                    dir.Depto = txtDepto.Text;
                    mtDir.EditarDireccion(dir);//edito la direccion
         

                    objCliente.Email = txtMail.Text;
                    objCliente.Cuit = txtCuit.Text;
                    objCliente.IdTransporte = Convert.ToInt32(cbTransporte.SelectedValue.ToString());
                    objCliente.Activo = activo;
                    objCliente.FechaAlta = dtpFechaAlta.Value;
                    objCliente.Observaciones = txtObservaciones.Text;
                    objCliente.TipoLista = tipoLista;

                    mtcl.EditarClientes(objCliente);

                    MessageBox.Show("Borrado con exito");
                    operacion = "insertar";
                    limpiarCampos();
                    ListarClientesEnGrid("", "1");
                    ListarTransporteEnComboBox();
                    cbProvincia.SelectedIndex = 0;
                    diseñoTabla();

                }
            }
        }

        private void Clientes_Activated(object sender, EventArgs e)
        {

            if (cbRazonSocial.Text == "Seleccione un valor")
            {
                ListarClienteEnComboBox();
            }
            if (cbTransporte.Items.Count > 0)
                ListarTransporteEnComboBox();

        }

        private void radioActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (radioActivos.Checked == true)
            {
                radioInactivos.Checked = false;
                ListarClientesEnGrid("", "1");
            }
        }

        private void radioInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (radioInactivos.Checked == true)
            {
                radioActivos.Checked = false;
                ListarClientesEnGrid("", "2");
            }
        }

        #endregion




    }
}
