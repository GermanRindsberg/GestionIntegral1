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
    public partial class NuevoPedido : Form
    {
        #region VARIABLES

        int banderaFechaDeEnvio = 0;

        int ultimoId;//id para crear el ultimo idDetallePedido y agregarle datos
        int idProducto;//cambia cuando se selecciona el comboBox, sirve para no repetir en el pedido 2 productos iguales

        
        int idCliente;
        int tipoLista;
        string tipoListaColumna;//variable para buscar el tipo de precio para el txt del pedido nuevo
        string detalleProducto;

        TablaParaPedido ta = new TablaParaPedido();
        
        Cliente cl = new Cliente();
        Pedidos pedido = new Pedidos();
        Transporte tr = new Transporte();
        Producto pro = new Producto();
        DetallePedido detalle = new DetallePedido();

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
                ListarClientes();
                ListarProductos();
                CrearidDetallePedido();
                ListarTransporte();
                ta.CrearTabla(0);
            }

            if (operacion == "editar")
            {
               
                ListarProductos();//cargo combobox de productos
                ListarTransporte(); //cargo combobox de transportes
                ListarClientes(); //cargo combobox de clientes

                pedido.IdPedido = idPedido;  //le paso al objeto detalle pedido la id del pedido a traer datos

                pedido.ListarPedidoPorId(cl, tr); //traigo todos los datos de la tabla por id

                lblTotal.Text = pedido.Total.ToString();//le paso el total al lbltotal

                dtFechaPedido.Value = pedido.Fecha;//le paso la fecha del pedido al datetimepicker

                if (pedido.FechaPago != null)//si el valor de fecha de pago es distinto a nulo le paso ese valor al datetimepiker de pago, sino toma el actual
                {
                    dateTimePicker2.Value = Convert.ToDateTime(pedido.FechaPago);
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
                    txtFechaPago.Text = pedido.FechaPago.Value.ToString("dd MMMM, yyyy");

                }
                else
                {
                    checkPagado.Checked = false;
                }

                detalle.IdDetallePedido = pedido.IdDetallePedido;//le paso a detalle pedido el id a traer, que es el de pedido.idDetallePedido

                cbCliente.SelectedValue = cl.IdCliente;//selecciona el id del cliente a traer

                
         
                ElegirProducto();//usa este metodo para que el usuario pueda elegir productos a agregar

                txtNroGuia.Text = pedido.NumGuia; //le paso el numero de guia al txtnumguia

                cbTransporte.SelectedValue = cl.IdTransporte;//selecciona el id del transporte a traer*
            
                if (pedido.FechaEnvio != null)
                {
                    txtFechaEnvio.Text = pedido.FechaEnvio.Value.ToString("dd MMMM, yyyy");
                }

                ta.CrearTabla(detalle.IdDetallePedido);
                gridPedidoNuevo.DataSource = ta.Tabla;
                gridPedidoNuevo.Columns[0].Visible = false;




            }
        }

        #region EVENTOS
        private void btnGenerarPedido_Click(object sender, EventArgs e)
        {
            if (operacion == "insertar")
            {
                ultimoId = pedido.SeleccionarUltimoIdYSumarleUno() + 1;
                foreach (DataGridViewRow row in gridPedidoNuevo.Rows)
                {
                    detalle.IdDetallePedido = ultimoId;
                    detalle.IdProducto = Convert.ToInt32(row.Cells[0].Value);
                    detalle.PrecioUnitario = float.Parse(row.Cells[2].Value.ToString());
                    detalle.Cantidad = Convert.ToInt32(row.Cells[3].Value);
                    detalle.Subtotal = Convert.ToInt32(row.Cells[4].Value);
                    pedido.Total =float.Parse(lblTotal.Text);
                    detalle.InsertarDetallePedido();
                }

                if (checkPagado.Checked == true)
                {
                    pedido.IdCliente = idCliente;
                    pedido.Fecha = dtFechaPedido.Value;

                    if (txtFechaEnvio.Text=="")
                    {
                        pedido.IdEstado = 1;
                        pedido.FechaEnvio = null;
                        
                    }
                    else
                    {
                        pedido.IdEstado = 2;
                        pedido.FechaEnvio = Convert.ToDateTime(txtFechaEnvio.Text);
                    }
                    
                    pedido.FechaPago = dtFechaPedido.Value;
                    pedido.MedioPago = tipoDePago;
                    pedido.IdDetallePedido = ultimoId;
                    pedido.Total = float.Parse(lblTotal.Text);
                    pedido.NumGuia = txtNroGuia.Text;

                    pedido.InsertarPedido();

                    MessageBox.Show("Insertado con exito");

                    limpiarCamposPedido();
                }
                else
                {
                    if (MessageBox.Show("¿Pedido no pagado, ingresar igualmente?", "FALTA PAGO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        pedido.IdCliente = idCliente;
                        pedido.Fecha = dtFechaPedido.Value;

                        if (txtFechaEnvio.Text == "")
                        {
                            pedido.IdEstado = 1;
                            pedido.FechaEnvio = null;

                        }
                        else
                        {
                            pedido.IdEstado = 2;
                            pedido.FechaEnvio = dateFechaEnvio.Value;
                        }
                        pedido.NumGuia = txtNroGuia.Text;
                        pedido.MedioPago = tipoDePago;
                        pedido.IdDetallePedido = ultimoId;
                        pedido.Total = float.Parse(lblTotal.Text);

                        pedido.InsertarPedido();
                        MessageBox.Show("Insertado con exito");
                        limpiarCamposPedido();
                    }
                    else
                    {
                        return;
                    }
                }
                
            }


            if (operacion == "editar")
            {
                detalle.IdDetallePedido = pedido.IdDetallePedido;//id Detalle pedido
                detalle.EliminarDetallePedido();

                ultimoId = pedido.SeleccionarUltimoIdYSumarleUno() + 1;

                foreach (DataGridViewRow row in gridPedidoNuevo.Rows)
                {
                    detalle.IdDetallePedido = ultimoId;
                    detalle.IdProducto = Convert.ToInt32(row.Cells[0].Value);
                    detalle.PrecioUnitario = float.Parse(row.Cells[2].Value.ToString());
                    detalle.Cantidad = Convert.ToInt32(row.Cells[3].Value);
                    detalle.Subtotal = Convert.ToInt32(row.Cells[4].Value);
                    pedido.Total = float.Parse(lblTotal.Text);
                    detalle.InsertarDetallePedido();
                }

                if (checkPagado.Checked == true)
                {
                    if (txtFechaEnvio.Text == "")
                    {
                        pedido.IdEstado = 1;
                        pedido.FechaEnvio = null;

                    }
                    else
                    {
                        pedido.IdEstado = 2;
                        pedido.FechaEnvio =Convert.ToDateTime(txtFechaEnvio.Text);
                    }
                    pedido.MedioPago = tipoDePago;
                    pedido.Total = float.Parse(lblTotal.Text);
                    pedido.NumGuia = txtNroGuia.Text;
                    pedido.IdDetallePedido = detalle.IdDetallePedido;
                    pedido.EditarPedido();

                    MessageBox.Show("Editado con exito");

                    limpiarCamposPedido();
                }
                else
                {
                    if (MessageBox.Show("¿Pedido no pagado, ingresar igualmente?", "FALTA PAGO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (txtFechaEnvio.Text == "")
                        {
                            pedido.IdEstado = 1;
                            pedido.FechaEnvio = null;

                        }
                        else
                        {
                            pedido.IdEstado = 2;
                            pedido.FechaEnvio = dateFechaEnvio.Value;
                        }
                        pedido.MedioPago = tipoDePago;
                        pedido.NumGuia = txtNroGuia.Text;
                        pedido.Total = float.Parse(lblTotal.Text);
                        pedido.IdDetallePedido = detalle.IdDetallePedido;
                        pedido.EditarPedido();
                        MessageBox.Show("Editado con exito");
                        limpiarCamposPedido();
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
            ta.AgregarDatos(Convert.ToInt32(cbProducto.SelectedValue.ToString()), cbProducto.Text, float.Parse(txtPrecioLista.Text), int.Parse(txtCant.Text));
            gridPedidoNuevo.DataSource = ta.Tabla;
            gridPedidoNuevo.Columns[0].Visible = false;
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
            //no me deja borrar elemento
            if (gridPedidoNuevo.SelectedRows.Count > 0)
            {
                int fila = Convert.ToInt32(gridPedidoNuevo.CurrentRow.Index.ToString());
                ta.BorrarDatos(fila);
                gridPedidoNuevo.DataSource = ta.Tabla;
                gridPedidoNuevo.Columns[0].Visible = false;
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
                ListarTransporte();
            }
        }
        #endregion

        #region METODOS
        private void ListarProductos()
        {
           
            cbProducto.DataSource = pro.ListarProductos();
            cbProducto.DisplayMember = "descripcionProducto";
            cbProducto.ValueMember = "idProducto";
            cbProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbProducto.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void limpiarCamposPedido()
        {
            ListarProductos();
            ListarClientes();
            txtPrecioLista.Text = "";
            txtCant.Text = "";
            checkPagado.Checked = false;
            this.Close();


        }

        private void CrearidDetallePedido()
        {
            //DetallePedido de = new DetallePedido();
            detalle.UltimoIdDetallePedido();
            ultimoId = detalle.IdDetallePedido + 1;
        }

        private void ListarClientes()
        {
           
            cbCliente.DataSource = cl.ListarClientes();
            cbCliente.DisplayMember = "razonSocial";
            cbCliente.ValueMember = "id";
            cbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;



        }

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

                pro.IdProducto = Convert.ToInt32(cbProducto.SelectedValue.ToString());

                detalleProducto = cbProducto.Text;

                pro.ListarProductoPorId();

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

                idProducto = pro.IdProducto;

            }
        }

        private void ElegirCliente()
        {
          
                if (cbCliente.SelectedIndex > 0 && cbCliente.Text != default)
                {
                    idCliente = (Convert.ToInt32(cbCliente.SelectedValue.ToString())); //COn esto le mando al cliente cual es la id
                    cl.IdCliente = idCliente;

                    cl.ListarClientePorId();//con la id que le mande aca traigo todos los datos de ese objeto cliente
                                            //empiezo a setear todos los campos
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
    
        private void ListarTransporte()
        {
            Transporte tr = new Transporte();
            cbTransporte.DataSource = tr.ListarTransportes();
            cbTransporte.DisplayMember = "razonSocial";
            cbTransporte.ValueMember = "id";
            cbTransporte.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbTransporte.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        #endregion

        #region CHECKBOX
        private void checkPagado_CheckedChanged(object sender, EventArgs e)
        {

            checkDeposito.Enabled = true;
            checkCheque.Enabled = true;
            checkEfectivo.Enabled = true;
            checkEfectivo.Checked = true;
            checkOtro.Enabled = true;
            txtFechaPago.Text = dateTimePicker2.Value.ToString("dd MMMM, yyyy");

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

        private void dateFechaEnvio_ValueChanged(object sender, EventArgs e)
        {
            txtFechaEnvio.Text = dateFechaEnvio.Value.ToString("dd MMMM, yyyy");
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtFechaPago.Text = dateTimePicker2.Value.ToString("dd MMMM, yyyy");

        }

        private void txtNroGuia_TextChanged(object sender, EventArgs e)
        {
            txtFechaEnvio.Text = dateFechaEnvio.Value.ToString("dd MMMM, yyyy");
        }
    }
}
