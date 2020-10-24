using System;
using System.Collections.Generic;
using GestionIntegral.CapaNegocio;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionIntegral.CapaDatos;

namespace GestionIntegral.CapaPresentacion
{
    public partial class Talleres : Form
    {
        MetodosGenericos mg = new MetodosGenericos();
        MetodosTaller mtta = new MetodosTaller();
        MetodosDireccion mtDir = new MetodosDireccion();

        
        int idLocalidad;
        string calle;
        String numero;
        String piso;
        string depto;
        int idDireccion;

        int idTaller;
        string razonSocial;
        string observaciones;
        string telefono;
        bool activo;

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

        private void ListarTallerEnGrid(string condicion, string activo)
        {
            gridTaller.DataSource = mtta.ListarTaller(condicion, activo);
            gridTaller.Columns[0].Visible = false;
            gridTaller.Columns[2].Visible = false;
            gridTaller.Columns[12].Visible = false;

            gridTaller.Columns[1].Width = 150 ;
            gridTaller.Columns[5].Width = 60 ;
            gridTaller.Columns[6].Width = 60;
            gridTaller.Columns[7].Width = 60;
            gridTaller.Columns[10].Width = 70;


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
                idLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                calle = txtCalle.Text;
                numero = txtNro.Text;
                piso = txtPiso.Text;
                depto = txtDepto.Text;

                Direccion dir = new Direccion(idLocalidad, calle, numero, piso, depto);//creo el objeto direccion 

                mtDir.InsertarDireccion(dir);//inserto la direccion

                idDireccion = mtDir.UltimoIdDireccion();

                //creo un taller
                razonSocial = cbRazonSocial.Text.ToString();
                telefono = txtTel1.Text;
                observaciones = txtObservaciones.Text;

                Taller taller = new Taller(idDireccion,observaciones, telefono, razonSocial, true);//creo el objeto taller

                mtta.InsertarTaller(taller);//inserto el taller

                MessageBox.Show("Insertado con exito");
                limpiarCampos();
                ListarTallerEnGrid("", "1");
                ListarTallerEnComboBox();

            }
            if (operacion == "editar")
            {
                //edito la direccion
                idLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                calle = txtCalle.Text;
                numero = txtNro.Text;
                piso = txtPiso.Text;
                depto = txtDepto.Text;
                Direccion dir = new Direccion(idDireccion, idLocalidad, calle, numero, piso, depto);

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
                telefono = txtTel1.Text;
                observaciones = txtObservaciones.Text;

                Taller taller = new Taller(idTaller, idDireccion, observaciones, telefono, razonSocial, true);//creo el objeto taller
                mtta.EditarTaller(taller);

                MessageBox.Show("Editado con exito");
                operacion = "editar";
                limpiarCampos();
                ListarTallerEnGrid("", "1");
                ListarTallerEnComboBox();
                cbProvincia.SelectedIndex = 0;
            }
        }

        private void cbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRazonSocial.SelectedIndex > 0 && cbRazonSocial.Text != default)
            {
                idTaller = Convert.ToInt32(cbRazonSocial.SelectedValue.ToString()); //COn esto le mando al cliente cual es la id

                Taller cl = mtta.CrearTaller(Convert.ToString(idTaller));
                Direccion dir = mtDir.CrearDireccion(Convert.ToInt32(cl.IdDireccion));

                idDireccion = cl.IdDireccion;
                txtCalle.Text = dir.Calle;
                txtNro.Text = dir.Numero;
                txtDepto.Text = dir.Depto;
                txtPiso.Text = dir.Piso;

                cbProvincia.SelectedValue = dir.IdProvincia;
                cbLocalidad.SelectedValue = dir.IdLocalidad;

                txtCodigoPostal.Text = dir.CodigoPostal;
                txtTel1.Text = cl.Telefono;
                checkActivo.Checked = cl.Activo;
                txtObservaciones.Text = cl.Observaciones;

                operacion = "editar";
            }
            if (cbRazonSocial.SelectedIndex == 0)
            {
                operacion = "insertar";
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

        private void radioActivos_CheckedChanged(object sender, EventArgs e)
        {
            ListarTallerEnGrid("", "1");
        }

        private void radioInactivos_CheckedChanged(object sender, EventArgs e)
        {
            ListarTallerEnGrid("", "0");
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (gridTaller.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Taller, pasara a ser inactivo?", "ELIMINAR TALLER", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Taller taller = mtta.CrearTaller(Convert.ToString(idTaller));//traigo el taller y su direccion por id
                    Direccion dir = mtDir.CrearDireccion(Convert.ToInt32(taller.IdDireccion));
                    Boolean activo = false;

                    //creo una direccion
                    dir.IdLocalidad = Convert.ToInt32(cbLocalidad.SelectedValue.ToString());
                    dir.Calle = txtCalle.Text;
                    dir.Numero = txtNro.Text;
                    dir.Piso = txtPiso.Text;
                    dir.Depto = txtDepto.Text;
                    mtDir.EditarDireccion(dir);//edito la direccion


                    taller.Activo = activo;

                    taller.Observaciones = txtObservaciones.Text;

                    mtta.EditarTaller(taller);


                    MessageBox.Show("Borrado con exito");
                    operacion = "insertar";
                    limpiarCampos();
                    ListarTallerEnGrid("", "1");
                    ListarTallerEnComboBox();
                    cbProvincia.SelectedIndex = 0;

                }
            }
        }

        private void gridTaller_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkActivo.Checked == true)
            {
                cbRazonSocial.SelectedValue = int.Parse(gridTaller.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (radioActivos.Checked == true)
            {
                ListarTallerEnGrid(txtBuscar.Text, "1");
            }
            else
            {
                ListarTallerEnGrid(txtBuscar.Text, "0");
            }
        }
    }
}
