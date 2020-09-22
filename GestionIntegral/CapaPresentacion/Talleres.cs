using System;
using System.Collections.Generic;
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
    public partial class Talleres : Form
    {
        MetodosGenericos mg = new MetodosGenericos();
        MetodosTaller mtta = new MetodosTaller();
        MetodosDireccion mtDir = new MetodosDireccion();
        int idTaller;

        string operacion = "insertar";

        public Talleres()
        {
            InitializeComponent();
        }

        private void Talleres_Load_1(object sender, EventArgs e)
        {
            ListarTallerEnGrid("", "1");
            ListarTallerEnComboBox();
            ListarProvinciaEnComboBox();
            if (idTaller != null)
            {
                cbRazonSocial.SelectedValue = idTaller;
            }
        }

        #region METODOS

        private void diseñoTabla()
        {
            gridTaller.ClearSelection();

            this.gridTaller.Columns[0].Visible = false;//idTransporte
            this.gridTaller.Columns[1].HeaderText = "Razon Social";//RazonSOcial
            this.gridTaller.Columns[2].Visible = false;//idDireccion
            this.gridTaller.Columns[4].HeaderText = "Telefono";//Telefono
            this.gridTaller.Columns[3].HeaderText = "Observaciones";//Observaciones
            this.gridTaller.Columns[5].Visible = false;//Activo
            this.gridTaller.Columns[6].Visible = false;//idDIreccion
            this.gridTaller.Columns[7].Visible = false;//idLocalidad
            this.gridTaller.Columns[8].HeaderText = "Calle";//calle
            this.gridTaller.Columns[9].HeaderText = "Nro";//numero
            this.gridTaller.Columns[10].HeaderText = "Depto";//depto
            this.gridTaller.Columns[11].HeaderText = "Piso";//piso
            this.gridTaller.Columns[12].Visible = false;//idlocalidad
            this.gridTaller.Columns[13].HeaderText = "Localidad"; ;//nomre
            this.gridTaller.Columns[14].Visible = false;//cp
            this.gridTaller.Columns[15].Visible = false;//idprovincia
            this.gridTaller.Columns[16].HeaderText = "Provincia";//nombre
        }

        private void ListarTallerEnGrid(string condicion, string activo)
        {
            gridTaller.DataSource = mtta.ListarTaller(condicion, activo);
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

        private void ListarTallerEnComboBox()
        {
            mg.LlenarComboBox(cbRazonSocial, "Talleres");
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

                //creo un taller
                string razonSocial = cbRazonSocial.Text.ToString();
                int idDireccion = dir.IdDireccion;
                string tel1 = txtTel1.Text;
                string observaciones = txtObservaciones.Text;

                Taller objtransporte = new Taller(idDireccion, observaciones,tel1,razonSocial, true);//creo el objeto taller

                mtta.InsertarTaller(objtransporte);//inserto el Taller

                MessageBox.Show("Insertado con exito");
                limpiarCampos();
                ListarTallerEnGrid("", "1");
                ListarTallerEnComboBox();

                diseñoTabla();

            }
            if (operacion == "editar")
            {
                Taller objTaller = mtta.CrearTaller(Convert.ToString(idTaller));//traigo el cliente y su direccion por id
                Direccion dir = mtDir.CrearDireccion(Convert.ToInt32(objTaller.IdDireccion));
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

                objTaller.Activo = activo;

                objTaller.Observaciones = txtObservaciones.Text;

                mtta.EditarTaller(objTaller);

                MessageBox.Show("Editado con exito");
                operacion = "insertar";
                limpiarCampos();
                ListarTallerEnGrid("", "1");
                ListarTallerEnComboBox();
                cbProvincia.SelectedIndex = 0;
                diseñoTabla();
            }

        }

        private void cbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
