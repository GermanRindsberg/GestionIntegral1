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


        String operacion="insertar";
        public int idCliente;

        //variables direccion
        int idDireccion;
        int idLocalidad;
        string calle;
        String numero;
        String piso;
        string depto;
       
        //variables Cliente
        string razonSocial;
        private string tel1;
        private string tel2;
        private Boolean activo;
        private string email;
        private string cuit;
        private DateTime fechaAlta;
        private string observaciones;
        int tipoLista;
        int idTransporte;


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

        private void ListarClientesEnGrid(string condicion, string activo)
        {
            gridClientes.DataSource = mtcl.ListarClientes(condicion, activo);
            gridClientes.Columns[0].Visible = false;
            gridClientes.Columns[2].Visible = false;
            gridClientes.Columns[5].Visible = false;
            gridClientes.Columns[8].Visible = false;
            gridClientes.Columns[11].Visible = false;
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
                idLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                calle = txtCalle.Text;
                numero = txtNro.Text;
                piso = txtPiso.Text;
                depto = txtDepto.Text;

                Direccion dir = new Direccion(idLocalidad, calle, numero, piso, depto);//creo el objeto direccion 

                mtDir.InsertarDireccion(dir);//inserto la direccion

                

                //creo un cliente
                razonSocial = cbRazonSocial.Text.ToString();
                idDireccion = mtDir.UltimoIdDireccion();
                tel1 = txtTel1.Text;
                tel2 = txtTel2.Text;
                email = txtMail.Text;
                cuit = txtCuit.Text;
                idTransporte = Convert.ToInt32(cbTransporte.SelectedValue.ToString());
                fechaAlta = dtpFechaAlta.Value;
                observaciones = txtObservaciones.Text;

                Cliente objCliente = new Cliente(razonSocial, idDireccion, tel1, tel2, activo,
                    email, cuit, idTransporte, fechaAlta, observaciones, tipoLista);//creo el objeto cliente

                mtcl.InsertarClientes(objCliente);//inserto el cliente

                MessageBox.Show("Insertado con exito");
                limpiarCampos();
                ListarClientesEnGrid("", "1");
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
                tel2 = txtTel2.Text;
                email = txtMail.Text;
                cuit = txtCuit.Text;
                idTransporte = Convert.ToInt32(cbTransporte.SelectedValue.ToString());
                fechaAlta = dtpFechaAlta.Value;
                observaciones = txtObservaciones.Text;

                Cliente cl = new Cliente(idCliente,razonSocial, idDireccion,tel1,tel2,activo,email,cuit,idTransporte,fechaAlta,observaciones,tipoLista);

                mtcl.EditarClientes(cl);

                MessageBox.Show("Editado con exito");
                limpiarCampos();
                ListarClientesEnGrid("", "1");
                ListarTransporteEnComboBox();
                cbProvincia.SelectedIndex = 0;
            }
        }

        private void cbRazonSocial_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbRazonSocial.SelectedIndex > 0 && cbRazonSocial.Text != default)
            {
               idCliente =  Convert.ToInt32(cbRazonSocial.SelectedValue.ToString()); //COn esto le mando al cliente cual es la id

                Cliente cl = mtcl.CrearCliente(idCliente.ToString());
               
                Direccion dir = mtDir.CrearDireccion(Convert.ToInt32(cl.IdDireccion));
                idDireccion = cl.IdDireccion;
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
                    Direccion dir = mtDir.CrearDireccion(Convert.ToInt32(objCliente.IdDireccion));
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
                ListarClientesEnGrid("", "0");
            }
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkActivo.Checked == true)
            {
                activo = true;
            }
            else
            {
                activo = false;
            }
        }

        #endregion


    }
}
