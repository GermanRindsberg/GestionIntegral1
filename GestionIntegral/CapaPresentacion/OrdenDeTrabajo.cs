using GestionIntegral.CapaDatos;
using GestionIntegral.CapaNegocio;
using System;
using System.Windows.Forms;

namespace GestionIntegral.CapaPresentacion
{
    public partial class OrdenDeTrabajo : Form
    {
        #region VARIABLES
        TablaParaPedido ta = new TablaParaPedido();
        MetodosTaller mt = new MetodosTaller();
        MetodosProductos mp = new MetodosProductos();
        MetodosGenericos mg = new MetodosGenericos();
        MetodosDetalleOrdenTrabajo metDetOT = new MetodosDetalleOrdenTrabajo();
        MetodosOT metTO = new MetodosOT();


        int idProducto;
        string detalleProducto;//cuando selecciona el comboBox producto trae a esta variable el texto
        int ultimoId;//id para crear el ultimo idDetallePedido y agregarle datos
        int idTaller;
        DateTime fechaEnvio;
        DateTime fechaRetiro;
        Boolean activo;

        public int idOrdenTrabajo;
        public string operacion = "insertar";
        #endregion

        public OrdenDeTrabajo()
        {
            InitializeComponent();
        }

        #region EVENTOS
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (operacion == "insertar")
            {
                fechaEnvio = dateHoy.Value;
                fechaRetiro = date10diasDespues.Value;
                ultimoId = metDetOT.UltimoIdDetallePedido();

                foreach (DataGridViewRow row in gridOT.Rows)
                {
                    int idDetalleOT = ultimoId;
                    idProducto = Convert.ToInt32(row.Cells[0].Value);
                    int cantidad = Convert.ToInt32(row.Cells[2].Value);

                    DetalleOrdenTrabajo detalle = new DetalleOrdenTrabajo(idDetalleOT, idProducto, cantidad);
                    metDetOT.InsertarDetalleOT(detalle);
                }

                OrdenDeTrabajos ot = new OrdenDeTrabajos(ultimoId, idTaller, fechaEnvio, fechaRetiro, activo);
                metTO.InsertarOT(ot);

                MessageBox.Show("Insertado con exito");
                limpiarCamposPedido();
            }

            if (operacion == "editar")
            {
                OrdenDeTrabajos otAeditar = metTO.CrearOT(idOrdenTrabajo);

                OrdenDeTrabajos otABorrar = metTO.CrearOT(idOrdenTrabajo);

                
                metDetOT.EliminarDetalleOt(otABorrar.IdDetalleOT);

                ultimoId = metDetOT.UltimoIdDetallePedido();//empiezo a crear un nuevo detalle

                foreach (DataGridViewRow row in gridOT.Rows)
                {
                    int idDetallePedido = ultimoId;
                    int idProducto = Convert.ToInt32(row.Cells[1].Value);
                    int cantidad = Convert.ToInt32(row.Cells[2].Value);

                    DetalleOrdenTrabajo detalle = new DetalleOrdenTrabajo(idDetallePedido, idProducto, cantidad);
                    metDetOT.InsertarDetalleOT(detalle);
                }

                
                otAeditar.IdOT = idOrdenTrabajo;
                otAeditar.IdDetalleOT = ultimoId;
                otAeditar.FechaEnvio = fechaEnvio;
                otAeditar.FechaRetiro = fechaEnvio;
                metTO.EditarOT(otAeditar);
                    
                MessageBox.Show("Editado con exito");
                    
                limpiarCamposPedido();
                    
                this.Close();
                
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevosTaller_Click(object sender, EventArgs e)
        {
            Talleres ta = new Talleres();
            ta.ShowDialog();
        }

        private void btnAgregarProductoNuevo_Click(object sender, EventArgs e)
        {
            Productos pr = new Productos();
            pr.ShowDialog();
        }

        private void OrdenDeTrabajo_Load(object sender, EventArgs e)
        {
            ListarTalleresEnComboBox();
            ListarProductosEnComboBox();
            date10diasDespues.Value = DateTime.Now.AddDays(10);
            ta.CrearTablaOt(0);

        }

        private void btnMasCantidad_Click(object sender, EventArgs e)
        {
            if (txtCant.Text == "")
            { }
            else
                txtCant.Text = Convert.ToString(Convert.ToInt32(txtCant.Text) + 1);
        }

        private void btnMenosCantidad_Click(object sender, EventArgs e)
        {
            if (txtCant.Text == "")
            { }
            else
                txtCant.Text = Convert.ToString(Convert.ToInt32(txtCant.Text) - 1);
        }

        private void btnSumarProducto_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedIndex > 0)
            {
                ta.AgregarDatosOT(Convert.ToInt32(cbProducto.SelectedValue.ToString()), cbProducto.Text, int.Parse(txtCant.Text));
                gridOT.DataSource = ta.Tabla;
                //gridOT.Columns[0].Visible = false;
            }
        }

        private void OrdenDeTrabajo_Activated(object sender, EventArgs e)
        {
            ListarTalleresEnComboBox();
            ListarProductosEnComboBox();
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElegirProducto();

        }
    #endregion


         #region METODOS

        private void limpiarCamposPedido()
    {
            ListarProductosEnComboBox();
            txtCant.Text = "";
    }
   
        private void ListarTalleresEnComboBox()
        {
            mg.LlenarComboBox(cbTaller, "Talleres");
        }
        
        private void ElegirProducto()
        {
            if (cbProducto.SelectedIndex > 0)
            {
                if (cbTaller.Text == "Seleccione un valor")
                {
                    MessageBox.Show("Debe seleccionar un taller ");
                    return;
                }
                else
                {
                    detalleProducto = cbProducto.Text;
                    Producto pro = mp.CrearProducto(cbProducto.SelectedValue.ToString());
                    txtCant.Text = "1";

                    idProducto =int.Parse(cbProducto.SelectedValue.ToString());
                }
            }
            
        }
        
        private void ListarProductosEnComboBox()
        {
            mg.LlenarComboBox(cbProducto, "Producto");
        }

        private void CrearidDetalleOt()
        {
            ultimoId = metDetOT.UltimoIdDetallePedido()+1;
        }


        #endregion


    }
}
