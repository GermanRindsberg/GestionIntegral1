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
    public partial class NuevoPedido : Form
    {
        #region VARIABLES
       
        int ultimoId;//id para crear el ultimo idDetallePedido y agregarle datos
        int idProducto;//cambia cuando se selecciona el comboBox, sirve para no repetir en el pedido 2 productos iguales
        int idCliente;//Se usa para saber que tipo de lista se usa
        int tipoLista;//Se usa para saber que precio va en el textbox precio unitario
        string tipoListaColumna;//variable para buscar el tipo de precio para el txt del pedido nuevo
        string detalleProducto;//cuando selecciona el comboBox producto trae a esta variable el texto
        
        TablaParaPedido ta = new TablaParaPedido();
        MetodosGenericos mg = new MetodosGenericos();
        MetodosDetallePedido metDetalle = new MetodosDetallePedido();
        MetodosProductos metProductos = new MetodosProductos();
        MetodosCliente metCliente = new MetodosCliente();
        MetodosPedido metPedido = new MetodosPedido();

        public int idPedido;
        public string operacion = "insertar";

        string tipoDePago = "";

        #endregion

        public NuevoPedido()
        {
            InitializeComponent();
        }

        private void NuevoPedido_Load(object sender, EventArgs e)
        {
            if (operacion == "insertar")
            {
                ListarClientesEnComboBox();
                ListarProductosEnComboBox();
                ListarTransporteEncomboBox();
                CrearidDetallePedido();
            }

            if (operacion == "editar")
            {
                ListarTransporteEncomboBox(); //cargo combobox de transportes
                ListarProductosEnComboBox();//cargo combobox de productos
                ListarClientesEnComboBox(); //cargo combobox de clientes
            
                #region CREO Y TRAIGO DATOS DE PEDIDO

                Pedido pedido = metPedido.CrearPedido(idPedido);
                dtFechaPedido.Value = pedido.Fecha;
                cbCliente.SelectedValue = pedido.IdCliente;
                //creo la tabla

                ta.CrearTabla(pedido.IdDetallePedido);
                gridPedidoNuevo.DataSource = ta.Tabla;
                gridPedidoNuevo.Columns[0].Visible = false;
                
                lblTotal.Text = pedido.Total.ToString();//le paso el total al lbltotal

                if (pedido.FechaPago != null)//si el valor de fecha de pago es distinto a nulo le paso ese valor al datetimepiker de pago, sino toma el actual
                {
                    dateFechaPago.Value = Convert.ToDateTime(pedido.FechaPago);
                }
                
                
                if (pedido.MedioPago != "")//si tiene pago pone los valores
                {
                    checkPagado.Checked = true;

                    if (pedido.MedioPago == "Efectivo")
                    {
                        checkEfectivo.Checked = true;
                        tipoDePago = "Efectivo";
                    }
                    if (pedido.MedioPago == "Cheque")
                    {
                        checkCheque.Checked = true;
                        tipoDePago = "Cheque";
                    }
                    if (pedido.MedioPago == "Deposito")
                    {
                        checkDeposito.Checked = true;
                        tipoDePago = "Deposito";
                    }
                    if (pedido.MedioPago == "Otro")
                    {
                        checkOtro.Checked = true;
                        tipoDePago = "Otro";
                    }

                    txtNroGuia.Text = pedido.NumGuia; //le paso el numero de guia al txtnumguia
                    cbCliente.SelectedValue = pedido.IdCliente;//selecciona el id del cliente a traer

                }
                else
                {
                    checkPagado.Checked = false;
                }
                if (pedido.FechaEnvio != null)
                {
                    checkEnviado.Checked = true;
                }

                if (pedido.FechaEnvio != null)
                {
                    txtFechaEnvio.Text = pedido.FechaEnvio.Value.ToString("dd MMMM, yyyy");
                }
                #endregion

                
         
                ElegirProducto();//usa este metodo para que el usuario pueda elegir productos a agregar
            }
        }

        #region EVENTOS
        private void btnGenerarPedido_Click(object sender, EventArgs e)
        {
            if (operacion == "insertar")
            {
                DateTime fecha = dtFechaPedido.Value;
                int idEstado = 0;
                string numGuia = txtNroGuia.Text;
                //tipoPago
                DateTime? fechaPago;
                float totalPedido = float.Parse(lblTotal.Text);
                DateTime? fechaEnvio;
                ultimoId = (metDetalle.UltimoIdDetallePedido())+1;

                foreach (DataGridViewRow row in gridPedidoNuevo.Rows)
                {
                    int idDetallePedido = ultimoId;
                    int idProducto = Convert.ToInt32(row.Cells[0].Value);
                    float precioUnitario = float.Parse(row.Cells[2].Value.ToString());
                    int cantidad = Convert.ToInt32(row.Cells[3].Value);
                    float subtotal = Convert.ToInt32(row.Cells[4].Value);

                    DetallePedido detalle = new DetallePedido(idDetallePedido, idProducto, precioUnitario, cantidad, subtotal);
                    metDetalle.InsertarDetallePedido(detalle);
                }
               
                if (checkPagado.Checked == true)
                {
                    fechaPago = dateFechaPago.Value;
                    
                    if (txtFechaEnvio.Text=="")
                    {
                       idEstado = 1;
                       fechaEnvio = null;
                    }
                    else
                    {
                        idEstado = 2;
                        fechaEnvio = Convert.ToDateTime(txtFechaEnvio.Text);
                    }

                    Pedido pe = new Pedido(ultimoId,fecha,idCliente,idEstado,numGuia,tipoDePago,fechaPago, totalPedido, fechaEnvio);
                    metPedido.InsertarPedido(pe);

                    MessageBox.Show("Insertado con exito");
                    limpiarCamposPedido();
                }
               
                else
                {
                    if (MessageBox.Show("¿Pedido no pagado, ingresar igualmente?", "FALTA PAGO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        fechaPago = null;
                        if (txtFechaEnvio.Text == "")
                        {
                            idEstado = 1;
                            fechaEnvio = null;
                        }
                        else
                        {
                            idEstado = 2;
                            fechaEnvio = Convert.ToDateTime(txtFechaEnvio.Text);
                        }

                        Pedido pe = new Pedido(ultimoId, fecha, idCliente, idEstado, numGuia, tipoDePago, fechaPago, totalPedido, fechaEnvio);
                        metPedido.InsertarPedido(pe);

                        MessageBox.Show("Insertado con exito");
                        limpiarCamposPedido();
                    }
                    else
                    {
                        return;
                    }
                }
                this.Close();
            }

            if (operacion == "editar")
            {
                DateTime fecha = dtFechaPedido.Value;
                int idEstado = 0;
                string numGuia = txtNroGuia.Text;
               
                //tipoPago
                DateTime? fechaPago;
                float totalPedido = float.Parse(lblTotal.Text);
                DateTime? fechaEnvio;

                Pedido pedidoAeditar = metPedido.CrearPedido(idPedido);
                Pedido pedidoAborrar = metPedido.CrearPedido(idPedido);

                //elimino el detallePedido para luego insertar uno nuevo, debo investigar para editarlo y no tener que borrarlo
                metDetalle.EliminarDetallePedido(pedidoAborrar.IdDetallePedido);

                ultimoId = (metDetalle.UltimoIdDetallePedido())+1;//empiezo a crear un nuevo detalle

                foreach (DataGridViewRow row in gridPedidoNuevo.Rows)
                {
                    int idDetallePedido = ultimoId;
                    int idProducto = Convert.ToInt32(row.Cells[0].Value);
                    float precioUnitario = float.Parse(row.Cells[2].Value.ToString());
                    int cantidad = Convert.ToInt32(row.Cells[3].Value);
                    float subtotal = Convert.ToInt32(row.Cells[4].Value);

                    DetallePedido detalle = new DetallePedido(idDetallePedido, idProducto, precioUnitario, cantidad, subtotal);
                    metDetalle.InsertarDetallePedido(detalle);
                }

                if (checkPagado.Checked == true)
                {
                    fechaPago = dateFechaPago.Value;

                    if (txtFechaEnvio.Text == "")
                    {
                        idEstado = 1;
                        fechaEnvio = null;
                    }
                    else
                    {
                        idEstado = 2;
                        fechaEnvio = Convert.ToDateTime(txtFechaEnvio.Text);
                    }
                    pedidoAeditar.IdCliente = idCliente;
                    pedidoAeditar.Total = totalPedido;
                    pedidoAeditar.IdEstado = idEstado;
                    pedidoAeditar.IdDetallePedido = ultimoId;
                    pedidoAeditar.NumGuia = numGuia;
                    pedidoAeditar.FechaPago = fechaPago;
                    pedidoAeditar.MedioPago = tipoDePago;
                    pedidoAeditar.FechaEnvio = fechaEnvio;

                    metPedido.EditarPedido(pedidoAeditar);
                    MessageBox.Show("Editado con exito");
                    limpiarCamposPedido();
                    this.Close();
                }
               
                else
                {
                    if (MessageBox.Show("¿Pedido no pagado, ingresar igualmente?", "FALTA PAGO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (checkEnviado.Checked != true)
                        {
                            idEstado = 1;
                            fechaEnvio = null;

                        }
                        else
                        {
                            idEstado = 2;
                            fechaEnvio = Convert.ToDateTime(txtFechaEnvio.Text);
                        }
                        pedidoAeditar.IdCliente = idCliente;
                        pedidoAeditar.Total = totalPedido;
                        pedidoAeditar.IdEstado = idEstado;
                        pedidoAeditar.IdDetallePedido = ultimoId;
                        pedidoAeditar.NumGuia = numGuia;
                        pedidoAeditar.FechaPago = null;
                        pedidoAeditar.MedioPago = tipoDePago;
                        pedidoAeditar.FechaEnvio = fechaEnvio;

                        metPedido.EditarPedido(pedidoAeditar);
                        
                        MessageBox.Show("Editado con exito");
                        limpiarCamposPedido();
                        this.Close();
                    }
                    else
                    {
                        return;
                    }
                }
            }
         }

        private void btnSumarProducto_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedIndex > 0)
            {
                ta.AgregarDatos(Convert.ToInt32(cbProducto.SelectedValue.ToString()), cbProducto.Text, float.Parse(txtPrecioLista.Text), int.Parse(txtCant.Text));
                gridPedidoNuevo.DataSource = ta.Tabla;
                
                gridPedidoNuevo.Columns[0].Visible = false;
                gridPedidoNuevo.Columns[1].HeaderText = "Detalle";
                gridPedidoNuevo.Columns[2].HeaderText = "Precio";
                gridPedidoNuevo.Columns[3].HeaderText = "Cantidad";
                gridPedidoNuevo.Columns[4].HeaderText = "Subtotal";


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCant.Text == "")
            { }
            else
                txtCant.Text = Convert.ToString(Convert.ToInt32(txtCant.Text) + 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtCant.Text == "" || txtCant.Text == "0")
            { }
            else
                txtCant.Text = Convert.ToString(Convert.ToInt32(txtCant.Text) - 1);
        }

        private void btnAgregarProductoNuevo_Click(object sender, EventArgs e)
        {
            Productos pro = new Productos();
            pro.ShowDialog();
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElegirProducto();
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElegirCliente();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
           
            if (gridPedidoNuevo.SelectedRows.Count > 0)
            {
                if (gridPedidoNuevo.SelectedRows.Count > 0)
                {
                    int fila = Convert.ToInt32(gridPedidoNuevo.CurrentRow.Index.ToString());
                
                ta.BorrarDatos(fila);
                gridPedidoNuevo.DataSource = ta.Tabla;
                gridPedidoNuevo.Columns[0].Visible = false;
                }
            }
            else
                MessageBox.Show("Debe seleccionar una fila");

        }

        private void btnSumarProducto_MouseClick(object sender, MouseEventArgs e)
        {
            float suma = 0;
            foreach (DataGridViewRow row in gridPedidoNuevo.Rows)
            {
                suma += float.Parse(row.Cells[4].Value.ToString());
                lblTotal.Text = suma.ToString();
            }
        }

        private void txtTransporte_Click(object sender, EventArgs e)
        {
            Transportes tr = new Transportes();
            tr.ShowDialog();
        }

        private void NuevoPedido_Activated(object sender, EventArgs e)
        {
            if (operacion == "insertar")
            {
                    ListarTransporteEncomboBox();
                    ListarClientesEnComboBox();
             
            }
            ListarProductosEnComboBox();
        }

        private void dateFechaEnvio_ValueChanged(object sender, EventArgs e)
        {
            txtFechaEnvio.Text = dateFechaEnvio.Value.ToString("dd MMMM, yyyy");

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtFechaPago.Text = dateFechaPago.Value.ToString("dd MMMM, yyyy");

        }

        private void txtNroGuia_TextChanged(object sender, EventArgs e)
        {
            txtFechaEnvio.Text = dateFechaEnvio.Value.ToString("dd MMMM, yyyy");
        }

        private void btnNuevosCliente_Click(object sender, EventArgs e)
        {
            Clientes cl = new Clientes();
            cl.ShowDialog();
        }

        private void checkEnviado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEnviado.Checked == true)
            {
                dateFechaEnvio.Enabled = true;
                txtFechaEnvio.Enabled = true;
                cbTransporte.Enabled = true;
                txtNroGuia.Enabled = true;
            }
            else
            {
                if (operacion == "editar" && txtFechaEnvio.Text != "")
                {
                    dateFechaEnvio.Enabled = false;
                    txtFechaEnvio.Enabled = false;
                    txtFechaEnvio.Text = "";
                    cbTransporte.Enabled = false;
                    ListarTransporteEncomboBox();
                    txtNroGuia.Enabled = false;
                    txtNroGuia.Text = "";
                }
            }
        }
        #endregion

        #region METODOS
       

        private void limpiarCamposPedido()
        {
            ListarProductosEnComboBox();
            ListarClientesEnComboBox();
            txtPrecioLista.Text = "";
            txtCant.Text = "";
            checkPagado.Checked = false;
            //this.Close();
        }

        private void CrearidDetallePedido()
        {
            ultimoId = metDetalle.UltimoIdDetallePedido() + 1;
        }

        private void ListarClientesEnComboBox()
        {
            mg.LlenarComboBox(cbCliente, "Clientes");
        }

        private void ListarTransporteEncomboBox()
        {
            mg.LlenarComboBox(cbTransporte, "Transporte");

        }

        private void ListarProductosEnComboBox()
        {
            mg.LlenarComboBox(cbProducto, "Producto");

        }

        /*al seleccionar un producto del comboBox automaticamente trae el
         * tipo de precio. Este tipo de columna lo trae cuando elijo el cliente en el evento del combobox*/
        private void ElegirProducto()
        {
            if (cbProducto.SelectedIndex > 0)
            {
                if (cbCliente.Text == "Seleccione un valor")
                {
                    MessageBox.Show("Debe seleccionar un cliente ");
                    return;
                }
                else

               detalleProducto = cbProducto.Text;
               idProducto =Convert.ToInt32( cbProducto.SelectedValue.ToString());
            
                Producto pro = metProductos.CrearProducto(idProducto);
                


                if (tipoListaColumna == "lista1")
                {
                    txtPrecioLista.Text = pro.Lista1.ToString();
                }
                if (tipoListaColumna == "lista2")
                {
                    txtPrecioLista.Text = pro.Lista2.ToString();
                }
                if (tipoListaColumna == "lista3")
                {
                    txtPrecioLista.Text = pro.Lista3.ToString();
                }

                txtCant.Text= "1";

            }
        }

        private void ElegirCliente()
        {
                if (cbCliente.SelectedIndex > 0 && cbCliente.Text != default)
                {
                idCliente = Convert.ToInt32(cbCliente.SelectedValue.ToString());
                Cliente cl = metCliente.CrearCliente(cbCliente.SelectedValue.ToString());
                    
                    tipoLista = cl.TipoLista;
                    if (tipoLista == 0)
                    {
                        tipoListaColumna = "lista1";
                    }
                    if (tipoLista == 1)
                    {
                        tipoListaColumna = "lista2";
                    }
                    if (tipoLista == 2)
                    {
                        tipoListaColumna = "lista3";
                    }

                    cbTransporte.SelectedValue = cl.IdTransporte;


                }
            
        }
    
       
        #endregion

        #region CHECKBOX
        private void checkPagado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPagado.Checked == true)
            {
                checkDeposito.Enabled = true;
                checkCheque.Enabled = true;
                checkEfectivo.Enabled = true;
                checkEfectivo.Checked = true;
                checkOtro.Enabled = true;
                txtFechaPago.Text = dateFechaPago.Value.ToString("dd MMMM, yyyy");
            }
            else
            {
                checkDeposito.Enabled = false;
                checkCheque.Enabled = false;
                checkEfectivo.Enabled = false;
                checkEfectivo.Checked = false;
                checkOtro.Enabled = false;
                txtFechaPago.Text = "";
            }
        }

        private void checkEfectivo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkEfectivo.Checked == true)
            {
                tipoDePago = "Efectivo";
                checkDeposito.Checked = false;
                checkCheque.Checked = false;
                checkOtro.Checked = false;
            }
           
        }

        private void checkCheque_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCheque.Checked == true)
            {
                tipoDePago = "Cheque";
                checkDeposito.Checked = false;
                checkEfectivo.Checked = false;
                checkOtro.Checked = false;
            }
  
        }

        private void checkDeposito_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDeposito.Checked == true)
            {
                tipoDePago = "Deposito";
                checkCheque.Checked = false;
                checkEfectivo.Checked = false;
                checkOtro.Checked = false;

            }
          
        }

        private void checkOtro_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkOtro.Checked == true)
            {
                tipoDePago = "Otro";
                checkCheque.Checked = false;
                checkEfectivo.Checked = false;
                checkDeposito.Checked = false;

            }
            
        }
        #endregion

      
    }
}
