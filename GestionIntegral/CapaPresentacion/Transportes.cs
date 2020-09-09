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
    public partial class Transportes : Form
    {
        Direccion dir = new Direccion();

        int idTransporte;
        
        string operacion = "insertar";

        public Transportes()
        {
            InitializeComponent();
        }

        private void Transportes_Load(object sender, EventArgs e)
        {
            ListarProvincias();
            ListarTransporte();
            limpiarCampos();

        }

        private void ListarProvincias()
        {
            cbProvincia.DataSource = dir.ListarProvincias();
            cbProvincia.DisplayMember = "nombre";
            cbProvincia.ValueMember = "id";
            cbProvincia.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbProvincia.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ListarTransporte()
        {
            Transporte tr = new Transporte();
            cbRazonSocial.DataSource = tr.ListarTransportes();
            cbRazonSocial.DisplayMember = "razonSocial";
            cbRazonSocial.ValueMember = "id";
            cbRazonSocial.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbRazonSocial.AutoCompleteSource = AutoCompleteSource.ListItems;


            ConexionBBDD con = new ConexionBBDD();

            con.ActualizarGrid(gridTransporte, "SELECT* FROM Transporte " +
                "INNER JOIN Direccion on Transporte.idDireccion = Direccion.id " +
                "INNER JOIN Localidad on Direccion.idLocalidad = Localidad.id  " +
                "INNER JOIN Provincia on Localidad.idProvincia = Provincia.id WHERE Transporte.activo=1;");
            diseñoTabla();
        }

        private void limpiarCampos()
        {
            ListarProvincias();
            ListarTransporte();
            txtCalle.Text = "";
            txtNro.Text = "";
            txtDepto.Text = "";
            txtPiso.Text = "";
            txtTel1.Text = "";
            txtObservaciones.Text = "";
            txtCodigoPostal.Text = "";
            cbLocalidad.Text = "";
         
            


        }

        private void diseñoTabla()
        {
            this.gridTransporte.Columns[0].Visible = false;//id Transporte
            //this.gridTransporte.Columns[1].Visible = false;//razon social
            this.gridTransporte.Columns[2].Visible = false;//idDireccion
            //this.gridTransporte.Columns[3].Visible = false;//Telefono
            //this.gridTransporte.Columns[4].Visible = false;//Observaciones
            this.gridTransporte.Columns[5].Visible = false;//activo
            this.gridTransporte.Columns[6].Visible = false;//idDireccion
            this.gridTransporte.Columns[7].Visible = false;//idLocalidad
            //this.gridTransporte.Columns[8].Visible = false;//calle
            //this.gridTransporte.Columns[9].Visible = false;//nro
            this.gridTransporte.Columns[10].Visible = false;//depto
            this.gridTransporte.Columns[11].Visible = false;//Piso
            this.gridTransporte.Columns[12].Visible = false;//idLocalidad
            this.gridTransporte.Columns[13].Visible = false;//Idprovincia
            //this.gridTransporte.Columns[14].Visible = false;//Localidad
            this.gridTransporte.Columns[15].Visible = false;//codigoPostañ
            this.gridTransporte.Columns[16].Visible = false;//idProvincia
            //this.gridTransporte.Columns[17].Visible = false;//provincia


            this.gridTransporte.Columns[1].HeaderText = "Razon Social";
            this.gridTransporte.Columns[3].HeaderText = "Telefono";
            this.gridTransporte.Columns[4].HeaderText = "Observaciones";
            this.gridTransporte.Columns[8].HeaderText = "Calle";
            this.gridTransporte.Columns[9].HeaderText = "Nro";
            this.gridTransporte.Columns[9].Width = 60;
            this.gridTransporte.Columns[14].HeaderText = "Localidad";
            this.gridTransporte.Columns[17].HeaderText = "Provincia";

        }

        private void ListarLocalidad()
        {
            cbLocalidad.DataSource = dir.ListarLocalidades();
            cbLocalidad.DisplayMember = "nombre";
            cbLocalidad.ValueMember = "id";
            cbLocalidad.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbLocalidad.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnAgregarTransporte_Click(object sender, EventArgs e)
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

                //INGRESO TRANSPORTE
                Transporte objTransporte = new Transporte();
                objTransporte.RazonSocial = cbRazonSocial.Text.ToString();
                objTransporte.IdDireccion = dir.IdDireccion;
                objTransporte.Tel = txtTel1.Text;
                objTransporte.Activo = true;
                objTransporte.Observaciones = txtObservaciones.Text;
                objTransporte.InsertarTransporte();
                MessageBox.Show("Insertado con exito");
                this.Close();


            }
            if (operacion == "editar")
            {
                Transporte tr = new Transporte();
                tr.IdTransporte = idTransporte;
                tr.RazonSocial = cbRazonSocial.Text;
                tr.IdDireccion = dir.IdDireccion;
                tr.Tel = txtTel1.Text;
                tr.Activo = true;
                tr.Observaciones = txtObservaciones.Text;
                tr.EditarTransporte();

               
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
                ListarTransporte();
                diseñoTabla();
                this.Close();
            }

        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            ConexionBBDD con = new ConexionBBDD();

            con.ActualizarGrid(gridTransporte, "SELECT* FROM Transporte " +
                "INNER JOIN Direccion on Transporte.idDireccion = Direccion.id " +
                "INNER JOIN Localidad on Direccion.idLocalidad = Localidad.id  " +
                "INNER JOIN Provincia on Localidad.idProvincia = Provincia.id  " +
                "WHERE Transporte.activo=1 AND Transporte.razonSocial like '%" + txtBuscar.Text + "%';");
            diseñoTabla();
        }

        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbProvincia.SelectedIndex > 0)
            {
                dir.IdProvincia = Convert.ToInt32(cbProvincia.SelectedValue.ToString());
                ListarLocalidad();
                dir.ListarCodigoPostal(txtCodigoPostal);
            }
        }

        private void cbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbLocalidad.SelectedIndex > 0)
            {
                dir.IdLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());

                dir.ListarCodigoPostal(txtCodigoPostal);
            }
        }

        private void cbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transporte tr = new Transporte();

            if (cbRazonSocial.SelectedIndex > 0 && cbRazonSocial.Text != default)
            {
                idTransporte = (Convert.ToInt32(cbRazonSocial.SelectedValue.ToString())); //COn esto le mando al cliente cual es la id
                tr.IdTransporte = idTransporte;

                tr.ListarTransportePorId();//con la id que le mande aca traigo todos los datos de ese objeto cliente
                
                //empiezo a setear todos los campos
                dir.IdDireccion = tr.IdDireccion;//seteo la id en el objeto
                dir.ListarDireccionPorId();//traigo todos los datos de ese objeto seteado
                txtCalle.Text = dir.Calle;
                txtNro.Text = dir.Numero;
                txtDepto.Text = dir.Depto;
                txtPiso.Text = dir.Piso;
                cbProvincia.SelectedValue = dir.IdProvincia;
                cbLocalidad.SelectedValue = dir.IdLocalidad;
                txtCodigoPostal.Text = dir.CodigoPostal;
                txtObservaciones.Text = tr.Observaciones;
                txtTel1.Text = tr.Tel;

                operacion = "editar";


            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ListarProvincias();
            ListarTransporte();
            limpiarCampos();
           
        }

        private void btnEditarTransporte_Click(object sender, EventArgs e)
        {
            if (gridTransporte.SelectedRows.Count > 0)
            {
                cbRazonSocial.SelectedValue = int.Parse(gridTransporte.CurrentRow.Cells[0].Value.ToString());

                operacion = "editar";
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
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
                if (MessageBox.Show("¿Desea eliminar el Transporte?", "ELIMINAR TRANSPORTE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Transporte tr = new Transporte();
                    tr.IdTransporte = int.Parse(gridTransporte.CurrentRow.Cells[0].Value.ToString());
                    tr.EliminarTransporte(0);
                }
            }

            limpiarCampos();
        }
    }
}
