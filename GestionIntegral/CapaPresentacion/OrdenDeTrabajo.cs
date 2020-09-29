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
        DateTime? fechaRetiro;
        int estado;
      
        Boolean activo;

        public int idOrdenTrabajo;
        public int idDetalleAborrar;
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
                ultimoId = metDetOT.UltimoIdDetallePedido();
                int idDetalleOT = ultimoId;
                if (checkRetirado.Checked == false)
                {
                    fechaRetiro = null;
                }
                else
                    fechaRetiro = dtFechaRetirado.Value;

                foreach (DataGridViewRow row in gridOT.Rows)
                {

                    idProducto = Convert.ToInt32(row.Cells[0].Value);
                    int cantidad = Convert.ToInt32(row.Cells[2].Value);

                    DetalleOrdenTrabajo detalle = new DetalleOrdenTrabajo(idDetalleOT, idProducto, cantidad);
                    metDetOT.InsertarDetalleOT(detalle);
                }

                OrdenDeTrabajos ot = new OrdenDeTrabajos(idDetalleOT, idTaller, fechaEnvio, fechaRetiro, activo);
                metTO.InsertarOT(ot);

                MessageBox.Show("Insertado con exito");
                limpiarCamposPedido();
                this.Close();
            }

            if (operacion == "editar")
            {
                if (checkRetirado.Checked == false)
                {
                    fechaRetiro = null;
                    estado = 1;
                }
                else
                {
                    fechaRetiro = dtFechaRetirado.Value;
                    estado = 0;
                }
                
                metDetOT.EliminarDetalleOt(idDetalleAborrar);//borro detalle pedido para ingresar uno nuevo.
                //empiezo a crear un nuevo detalle
                ultimoId = metDetOT.UltimoIdDetallePedido();

                foreach (DataGridViewRow row in gridOT.Rows)
                {
                    int idDetallePedido = ultimoId;
                    int idProducto = Convert.ToInt32(row.Cells[0].Value);
                    int cantidad = Convert.ToInt32(row.Cells[2].Value);

                    DetalleOrdenTrabajo detalle = new DetalleOrdenTrabajo(idDetallePedido, idProducto, cantidad);
                    metDetOT.InsertarDetalleOT(detalle);
                }



                OrdenDeTrabajos ot = new OrdenDeTrabajos(idOrdenTrabajo,ultimoId, idTaller, fechaEnvio, fechaRetiro, activo, estado);

                metTO.EditarOT(ot);
                    
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
            ta.CrearTablaOt(0);
         

            if (operacion == "editar")
            {
                ListarTalleresEnComboBox(); //cargo combobox de Talleres
                ListarProductosEnComboBox();//cargo combobox de productos

                #region CREO Y TRAIGO DATOS DE OT

                OrdenDeTrabajos oT = metTO.CrearOT(idOrdenTrabajo);
                dateHoy.Value = oT.FechaEnvio;
                cbTaller.SelectedValue = oT.IdTaller;
                //creo la tabla

                ta.CrearTablaOt(oT.IdDetalleOT);

                gridOT.DataSource = ta.Tabla;
                gridOT.Columns[0].Visible = false;

                if (oT.FechaRetiro != null)
                {
                    checkRetirado.Checked = true;
                }

                #endregion

                ElegirProducto();//usa este metodo para que el usuario pueda elegir productos a agregar
            }

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
        
        private void cbTaller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTaller.SelectedIndex>0)
            idTaller = int.Parse(cbTaller.SelectedValue.ToString());
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
                    Producto pro = mp.CrearProducto(Convert.ToInt32(cbProducto.SelectedValue.ToString()));
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
