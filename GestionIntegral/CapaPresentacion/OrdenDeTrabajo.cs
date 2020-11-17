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
        MetodosStock metStock = new MetodosStock();



        int idProducto;
        string detalleProducto;//cuando selecciona el comboBox producto trae a esta variable el texto
        int ultimoId;//id para crear el ultimo idDetallePedido y agregarle datos
        string nombreTaller;
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
            string nombreColumna = "";
            if (nombreTaller == "Taller 1")
            {
                nombreColumna = "taller1";
            }
            else if (nombreTaller == "Taller 2")
            {
                nombreColumna = "taller2";
            }
            else if (nombreTaller == "Taller 3")
            {
                nombreColumna = "taller3";
            }
            else if (nombreTaller == "Taller 4")
            {
                nombreColumna = "taller4";
            }
            else if (nombreTaller == "Almacen")
            {
                nombreColumna = "almacen";
            }

            if (operacion == "insertar")
            {
                fechaEnvio = dateHoy.Value;
                ultimoId = metDetOT.UltimoIdDetallePedido();
                int idDetalleOT = ultimoId;

                foreach (DataGridViewRow row in gridOT.Rows)
                {
                    idProducto = Convert.ToInt32(row.Cells[0].Value);
                    int cantidad = Convert.ToInt32(row.Cells[2].Value);
                    DetalleOrdenTrabajo detalle = new DetalleOrdenTrabajo(idDetalleOT, idProducto, cantidad);
                    metDetOT.InsertarDetalleOT(detalle);

                }

                if (checkRetirado.Checked == false)
                {
                    fechaRetiro = null;
                }
                else
                {
                    fechaRetiro = dtFechaRetirado.Value;
                }

                if (gridOT.RowCount == 0)
                {
                    MessageBox.Show("Debes ingresar algun valor");
                }
                else
                {
                    OrdenDeTrabajos ot = new OrdenDeTrabajos(idDetalleOT, nombreTaller, fechaEnvio, fechaRetiro, activo, 1);
                    metTO.InsertarOT(ot);
                    MessageBox.Show("Insertado con exito");
                    limpiarCamposPedido();
                    this.Close();
                    
                }
                    
           
            }

            if (operacion == "editar")
            {
                OrdenDeTrabajos poAeditar = metTO.CrearOT(idOrdenTrabajo);
                OrdenDeTrabajos otAborrar = metTO.CrearOT(idOrdenTrabajo);

                fechaRetiro = poAeditar.FechaRetiro;
                fechaEnvio = poAeditar.FechaEnvio;
                
                

                //elimino el detallePedido para luego insertar uno nuevo, debo investigar para editarlo y no tener que borrarlo
                metDetOT.EliminarDetalleOt(otAborrar.IdDetalleOT);//borro el detalle anterior para agregar uno nuevo
                
                ultimoId = metDetOT.UltimoIdDetallePedido()+1;//empiezo a crear un nuevo detalle

                foreach (DataGridViewRow row in gridOT.Rows)
                {
                    int idDetallePedido = ultimoId;
                    int idProducto = Convert.ToInt32(row.Cells[0].Value);
                    int cantidad = Convert.ToInt32(row.Cells[2].Value);
                    DetalleOrdenTrabajo detalle = new DetalleOrdenTrabajo(idDetallePedido, idProducto, cantidad);
                    metDetOT.InsertarDetalleOT(detalle);
                   
                }

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


                if (gridOT.RowCount == 0)
                {
                    MessageBox.Show("Debes ingresar algun valor");
                }
                else
                {
                    poAeditar.IdOT = idOrdenTrabajo;
                    poAeditar.NombreTaller = nombreTaller;
                    poAeditar.Estado = estado;
                    poAeditar.IdDetalleOT = ultimoId;
                    poAeditar.FechaEnvio = fechaEnvio;
                    poAeditar.FechaRetiro = fechaRetiro;
                    poAeditar.Activo = activo;
                    metTO.EditarOT(poAeditar);
                    MessageBox.Show("Editado con exito");
                    limpiarCamposPedido();
                    this.Close();
                }
                }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarProductoNuevo_Click(object sender, EventArgs e)
        {
            Productos pr = new Productos();
            pr.ShowDialog();
        }

        private void OrdenDeTrabajo_Load(object sender, EventArgs e)
        {
      
            ListarProductosEnComboBox();
            ta.CrearTablaOt(0);
            if (gridOT.Rows.Count > 0)
            {
                gridOT.Columns[0].Visible = false;
            }
            
            gridOT.ClearSelection();



            if (operacion == "editar")
            {
                ListarProductosEnComboBox();//cargo combobox de productos

                #region CREO Y TRAIGO DATOS DE OT

                OrdenDeTrabajos oT = metTO.CrearOT(idOrdenTrabajo);

                idOrdenTrabajo = oT.IdOT;
                idDetalleAborrar = oT.IdDetalleOT;
                
                dateHoy.Value = oT.FechaEnvio;

                cbTaller.SelectedItem = oT.NombreTaller;//falta esto

                //creo la tabla
                int idTablaOT = oT.IdDetalleOT;

                ta.CrearTablaOt(idTablaOT);

                gridOT.DataSource = ta.Tabla;
                gridOT.Columns[0].Visible = false;

                if (oT.FechaRetiro != null)
                {
                    checkRetirado.Checked = true;
                }
                fechaEnvio = oT.FechaEnvio;
                activo = oT.Activo;
                estado = oT.Estado;
                gridOT.Columns[0].Visible = false;
                #endregion
                gridOT.ClearSelection();
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
                gridOT.Columns[0].Visible = false;
               

            }
        }

        private void OrdenDeTrabajo_Activated(object sender, EventArgs e)
        {
        
            ListarProductosEnComboBox();

        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElegirProducto();

        }
        
        private void cbTaller_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreTaller = cbTaller.SelectedItem.ToString();
        }
        #endregion


        #region METODOS

        private void limpiarCamposPedido()
    {
            ListarProductosEnComboBox();
            txtCant.Text = "";
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

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {

            if (gridOT.SelectedRows.Count > 0)
            {
                if (gridOT.SelectedRows.Count != null)
                {
                    int fila = Convert.ToInt32(gridOT.CurrentRow.Index.ToString());

                    ta.BorrarDatos(fila);
                    gridOT.DataSource = ta.Tabla;
                    gridOT.Columns[0].Visible = false;
                }
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }
    }
}
