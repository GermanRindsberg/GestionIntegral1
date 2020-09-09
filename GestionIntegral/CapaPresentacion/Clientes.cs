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
    public partial class Clientes : Form
    {
        Direccion dir = new Direccion();
        int tipoLista;
        String operacion="insertar";
        public int idCliente;

        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            limpiarCampos();
            ListarProvincias();
            ListarTransporte();
            ListarClientes();

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

        private void ListarClientes()
        {
            Cliente cl = new Cliente();
            cbRazonSocial.DataSource = cl.ListarClientes();
            cbRazonSocial.DisplayMember = "razonSocial";
            cbRazonSocial.ValueMember = "id";
            cbRazonSocial.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbRazonSocial.AutoCompleteSource = AutoCompleteSource.ListItems;
            
            gridClientes.DataSource = cl.ListarClientesEnGrilla(1);//el 1 representa a los activos
            
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

        private void ListarTransporte()
        {
            Transporte tr = new Transporte();
            cbTransporte.DataSource = tr.ListarTransportes();
            cbTransporte.DisplayMember = "razonSocial";
            cbTransporte.ValueMember = "id";
            cbTransporte.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbTransporte.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ListarProvincias()
        {
            Direccion dir = new Direccion();
            cbProvincia.DataSource = dir.ListarProvincias();
            cbProvincia.DisplayMember = "nombre";
            cbProvincia.ValueMember = "id";
            cbProvincia.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbProvincia.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ListarLocalidad()
        {
            cbLocalidad.DataSource = dir.ListarLocalidades();
            cbLocalidad.DisplayMember = "nombre";
            cbLocalidad.ValueMember = "id";
            cbLocalidad.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbLocalidad.AutoCompleteSource = AutoCompleteSource.ListItems;
        }


        #endregion

        #region EVENTOS

        private void cbRazonSocial_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Cliente cl = new Cliente();

            if (cbRazonSocial.SelectedIndex > 0 && cbRazonSocial.Text != default)
            {
                idCliente = (Convert.ToInt32(cbRazonSocial.SelectedValue.ToString())); //COn esto le mando al cliente cual es la id
                cl.IdCliente = idCliente;

                cl.ListarClientePorId();//con la id que le mande aca traigo todos los datos de ese objeto cliente
                                        //empiezo a setear todos los campos

                dir.IdDireccion = cl.IdDireccion;//seteo la id en el objeto
                dir.ListarDireccionPorId();//traigo todos los datos de ese objeto seteado
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

        private void cbProvincia_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (cbProvincia.SelectedIndex > 0)
            {
                dir.IdProvincia = Convert.ToInt32(cbProvincia.SelectedValue.ToString());
                ListarLocalidad();
                dir.ListarCodigoPostal(txtCodigoPostal);
            }
        }

        private void cbLocalidad_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbLocalidad.SelectedIndex > 0)
            {
                dir.IdLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());

                dir.ListarCodigoPostal(txtCodigoPostal);
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

        private void btnAgregarCliente_Click_1(object sender, EventArgs e)
        {
            if (operacion == "insertar")
            {
                Direccion dir = new Direccion();
                //INSERTO DIRECCION/LOCALIDAD/PROVINCIA

                dir.IdLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                dir.Calle = txtCalle.Text;
                dir.Numero = txtNro.Text;
                dir.Piso = txtPiso.Text;
                dir.Depto = txtDepto.Text;

                dir.InsertarDireccion();

                //INGRESO CLIENTE
                Cliente objCliente = new Cliente();
                objCliente.RazonSocial = cbRazonSocial.Text.ToString();
                objCliente.IdDireccion = dir.IdDireccion;
                objCliente.Tel1 = txtTel1.Text;
                objCliente.Tel2 = txtTel2.Text;
                if (checkActivo.Checked == true)
                {
                    objCliente.Activo = true;
                }
                if (checkActivo.Checked == false)
                {
                    objCliente.Activo = false;
                }

                objCliente.Email = txtMail.Text;
                objCliente.Cuit = txtCuit.Text;
                objCliente.IdTransporte = Convert.ToInt32(cbTransporte.SelectedValue.ToString());
                objCliente.FechaAlta = dtpFechaAlta.Value;
                objCliente.Observaciones = txtObservaciones.Text;
                objCliente.TipoLista = tipoLista;

                objCliente.InsertarClientes();

                MessageBox.Show("Insertado con exito");
                limpiarCampos();
                ListarClientes();
                ListarTransporte();

                diseñoTabla();

            }
            if (operacion == "editar")
            {
                Cliente objCliente = new Cliente();
                objCliente.IdCliente = idCliente;
                objCliente.RazonSocial = cbRazonSocial.Text.ToString();
                objCliente.IdDireccion = dir.IdDireccion;
                objCliente.Tel1 = txtTel1.Text;
                objCliente.Tel2 = txtTel2.Text;
                if (checkActivo.Checked == true)
                {
                    objCliente.Activo = true;
                }
                if (checkActivo.Checked == false)
                {
                    objCliente.Activo = false;
                }


                objCliente.Email = txtMail.Text;
                objCliente.Cuit = txtCuit.Text;
                objCliente.IdTransporte = Convert.ToInt32(cbTransporte.SelectedValue.ToString());
                objCliente.FechaAlta = dtpFechaAlta.Value;
                objCliente.Observaciones = txtObservaciones.Text;
                objCliente.TipoLista = tipoLista;
                objCliente.EditarClientes();

                dir.Calle = txtCalle.Text;
                dir.Numero = txtNro.Text;
                dir.Piso = txtPiso.Text;
                dir.Depto = txtDepto.Text;
                dir.CodigoPostal = txtCodigoPostal.Text;
                dir.IdLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                dir.EditarDireccion();

                MessageBox.Show("Editado con exito");
                operacion = "insertar";
                limpiarCampos();
                ListarClientes();
                ListarTransporte();
                cbProvincia.SelectedIndex = 0;
                diseñoTabla();
            }
        }

        private void txtBuscar_KeyUp_1(object sender, KeyEventArgs e)
        {
            Cliente cl = new Cliente();
            if (radioActivos.Checked == true)
            {
               gridClientes.DataSource= cl.BuscarCliente(txtBuscar.Text, true);
            }
            else
            {
                gridClientes.DataSource = cl.BuscarCliente(txtBuscar.Text, false);
            }
            
            diseñoTabla();
        }

        private void btnLimpiarCliente_Click_1(object sender, EventArgs e)
        {
            limpiarCampos();
            ListarClientes();
            ListarProvincias();
            ListarTransporte();

        }

        private void btnEditarCliente_Click_1(object sender, EventArgs e)
        {
            if (gridClientes.SelectedRows.Count > 0)
            {
                cbRazonSocial.SelectedValue = int.Parse(gridClientes.CurrentRow.Cells[0].Value.ToString());

                operacion = "editar";
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
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
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = idCliente;
                    objCliente.RazonSocial = cbRazonSocial.Text.ToString();
                    objCliente.IdDireccion = dir.IdDireccion;
                    objCliente.Tel1 = txtTel1.Text;
                    objCliente.Tel2 = txtTel2.Text;
                    objCliente.Activo = false;

                    objCliente.Email = txtMail.Text;
                    objCliente.Cuit = txtCuit.Text;
                    objCliente.IdTransporte = Convert.ToInt32(cbTransporte.SelectedValue.ToString());
                    objCliente.FechaAlta = dtpFechaAlta.Value;
                    objCliente.Observaciones = txtObservaciones.Text;
                    objCliente.TipoLista = tipoLista;
                    objCliente.EditarClientes();

                    dir.Calle = txtCalle.Text;
                    dir.Numero = txtNro.Text;
                    dir.Piso = txtPiso.Text;
                    dir.Depto = txtDepto.Text;
                    dir.CodigoPostal = txtCodigoPostal.Text;
                    dir.IdLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                    dir.EditarDireccion();

                    MessageBox.Show("Pasado a inactivo con exito");
                    operacion = "insertar";
                    limpiarCampos();
                    ListarClientes();
                    ListarTransporte();
                    cbProvincia.SelectedIndex = 0;
                    diseñoTabla();

                }
            }
        }

        private void Clientes_Activated(object sender, EventArgs e)
        {

            if (cbRazonSocial.Text == "Seleccione un valor" && cbTransporte.Text == "Seleccione un valor")
            {
                ListarClientes();
                ListarTransporte();

            }

        }

        private void radioActivos_CheckedChanged(object sender, EventArgs e)
        {
            Cliente cl = new Cliente();
            gridClientes.DataSource = cl.ListarClientesEnGrilla(1);//el 1 representa a los activos
        }

        private void radioInactivos_CheckedChanged(object sender, EventArgs e)
        {
            Cliente cl = new Cliente();
            gridClientes.DataSource = cl.ListarClientesEnGrilla(0);//el 0 representa a los inactivos
        }

        #endregion




    }
}
