﻿using GestionIntegral.CapaDatos;
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
    public partial class Principal : Form
    {
        
        MetodosStock metStock = new MetodosStock();

        MetodosPedido metPedido = new MetodosPedido();
        MetodosOT metOT = new MetodosOT();

        private int childFormNumber = 0;

        private int estadoPedido = 1;

        private int banderaGridOtBorrado=0;
        private int banderaGridOtBorradoPedido = 0;
        private int idProductoStock;

        public Principal()
        {
            InitializeComponent();
        }

        #region MDIFORM

        private void btnNvaOT_Click(object sender, EventArgs e)
        {
            OrdenDeTrabajo ot = new OrdenDeTrabajo();
            ot.ShowDialog();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clientes cl = new Clientes();
            cl.ShowDialog();
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Productos pro = new Productos();
            pro.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void transportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transportes tr = new Transportes();
            tr.ShowDialog();
        }

        private void btnOt_Click(object sender, EventArgs e)
        {
            OrdenDeTrabajo ot = new OrdenDeTrabajo();
            ot.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes cl = new Clientes();
            cl.ShowDialog();
        }

        private void transportesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transportes tr = new Transportes();
            tr.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos pr = new Productos();
            pr.ShowDialog();
        }

        private void talleresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Talleres ta = new Talleres();
            ta.ShowDialog();
        }

        private void ordenesDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdenDeTrabajo ot = new OrdenDeTrabajo();
            ot.ShowDialog();
        }
        #endregion

        private void Principal_Load(object sender, EventArgs e)
        {
            actualizarGridPedidos(estadoPedido);

            date20diasAntes.Value = DateTime.Now.AddDays(-20);

            LlenarGridStock();
            LlenarGrillaResumen();
            radioPendiente.Checked = true;
            actualizarTotalImportes();
            radioPendientesStock.Checked = true;
            LlenarGridOT();
            devolverPedidosParaStock();
            devolverRequeridosParaStock();

        }

        private void Principal_Activated(object sender, EventArgs e)
        {
       
            radioPendiente.Checked = true;
            LlenarGridStock();
            radioFamilia.Checked = true;
            LlenarGrillaResumen();
            actualizarTotalImportes();
            if (banderaGridOtBorrado != 1)
            {
                LlenarGridOT();
            }
            if (banderaGridOtBorradoPedido != 1)
            {
                actualizarGridPedidos(1);
            }
            devolverRequeridosParaStock();

        }

        #region METODOS PEDIDOS

        private void actualizarGridPedidos(int estado)
        {
            if (estado == 1 || estado == 2)
            {
                gridListaPedidos.DataSource = metPedido.ListarPedidoPorEstadoParaGrilla(estado, date20diasAntes.Value, dateTimePicker1.Value);
            }
            gridListaPedidos.Columns[0].Visible = false;
            gridListaPedidos.Columns[1].Visible = false;
            gridListaPedidos.Columns[2].HeaderText = "Fecha del pedido";
            gridListaPedidos.Columns[3].HeaderText = "Razon social del cliente";
            gridListaPedidos.Columns[4].HeaderText = "Localidad";
            gridListaPedidos.Columns[5].HeaderText = "Provincia";
            gridListaPedidos.Columns[6].HeaderText = "Monto total";
            gridListaPedidos.Columns[7].HeaderText = "Fecha del pago";
            gridListaPedidos.Columns[8].HeaderText = "Medio de pago";
            gridListaPedidos.Columns[9].HeaderText = "Fecha de envio";
            gridListaPedidos.Columns[10].HeaderText = "Numero de guia/remito";
            gridListaPedidos.Columns[11].HeaderText = "Nombre del transporte";

        }

        private void actualizarTotalImportes()
        {
            
            if (radioPendiente.Checked == true)
            {
                float sumaPendientes = 0;
                foreach (DataGridViewRow row in gridListaPedidos.Rows)
                {
                    sumaPendientes += float.Parse(row.Cells[6].Value.ToString());
                }
                txtTotalImportes.Text = sumaPendientes.ToString();

            }
           
            if (radioDespachados.Checked == true)
            {
                float sumaPendientes = 0;
                foreach (DataGridViewRow row in gridListaPedidos.Rows)
                {
                    sumaPendientes += float.Parse(row.Cells[6].Value.ToString());
                }
                txtTotalImportes.Text = sumaPendientes.ToString();
            }



        }
        #endregion

        #region EVENTOS PEDIDOS 

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoPedido np = new NuevoPedido();
            np.operacion = "insertar";
            np.ShowDialog();
        }

        private void radioPendiente_CheckedChanged(object sender, EventArgs e)
        {
            estadoPedido = 1;
            actualizarGridPedidos(1);
            actualizarTotalImportes();


        }

        private void radioDespachados_CheckedChanged(object sender, EventArgs e)
        {
            estadoPedido = 2;
            actualizarGridPedidos(2);
            actualizarTotalImportes();
        }

        private void radioTodos_CheckedChanged(object sender, EventArgs e)
        {
            estadoPedido = 3;
            actualizarGridPedidos(3);
            actualizarTotalImportes();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridListaPedidos.SelectedRows.Count > 0)
            {
                NuevoPedido de = new NuevoPedido();
                de.idPedido = int.Parse(gridListaPedidos.CurrentRow.Cells[0].Value.ToString());
                de.operacion = "editar";

                de.ShowDialog();
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        

        private void btnFichaCliente_Click(object sender, EventArgs e)
        {
            if (gridListaPedidos.SelectedRows.Count > 0)
            {
                Clientes cl = new Clientes();
                cl.idCliente = int.Parse(gridListaPedidos.CurrentRow.Cells[1].Value.ToString());
                cl.ShowDialog();
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            banderaGridOtBorradoPedido = 1;
            if (gridListaPedidos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Pedido? esto puede alterar el stock y balances", "ELIMINAR PEDIDO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int idPedido = int.Parse(gridListaPedidos.CurrentRow.Cells[0].Value.ToString());
                    Pedido pe = new Pedido(idPedido);
                    metPedido.EliminarPedido(pe) ;
                    MessageBox.Show("Eliminado con exito");
                    actualizarGridPedidos(1);
                    banderaGridOtBorradoPedido = 0;
                }
                else
                    return;
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void date20diasAntes_ValueChanged(object sender, EventArgs e)
        {
            actualizarGridPedidos(estadoPedido);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            actualizarGridPedidos(estadoPedido);
        }
        #endregion

        #region METODOS STOCK

     
        private void LlenarGridStock()
        {
           gridStock.DataSource = metStock.ListarStock();
           gridStock.ClearSelection();

            gridStock.Columns[0].Visible = false;
            gridStock.Columns[1].HeaderText = "Descripcion";
            gridStock.Columns[2].HeaderText = "Almacen";
            gridStock.Columns[3].HeaderText = "Stock";
            gridStock.Columns[4].HeaderText = "Stock Potencial";
            gridStock.Columns[5].HeaderText = "Pedidos";
            gridStock.Columns[6].HeaderText ="Requeridos";


        }

        public void devolverPedidosParaStock()
        {

            

        }

        public void devolverRequeridosParaStock()//potencial mas stock menos pedidos
        {

            foreach (DataGridViewRow row in gridStock.Rows)
            {
                //int stock = int.Parse(row.Cells[6].Value.ToString());
                //int potencial = int.Parse(row.Cells[4].Value.ToString());
                //int pedidos = int.Parse(row.Cells[3].Value.ToString());
                //int resultado = pedidos - (stock + potencial);
                //if (resultado > 0)
                //{
                //    row.Cells[5].Value = resultado;
                //}
                //else
                //    row.Cells[5].Value = 0;

            }

        }

        #endregion

        #region EVENTOS STOCK
     
        private void gridStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        

        }

        #endregion
        
       

        #region METODOS RESUMEN VENTAS

        private void LlenarGrillaResumen()
        {
            if (radioFamilia.Checked==true)
            {
              gridResumen.DataSource = metPedido.ListarResumenDePedidos(1);
            }
            else
                gridResumen.DataSource = metPedido.ListarResumenDePedidos(0);
        }


        #endregion

        #region EVENTOS RESUMEN DE VENTAS
       
        private void radioFamilia_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGrillaResumen();
        }

        private void radioDiseño_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGrillaResumen();
        }

        #endregion

        #region METODOS ORDEN DE TRABAJO

        private void LlenarGridOT()
        {
            if (radioProcesoOT.Checked == true)
            {
                gridOT.DataSource = metOT.ListarOTParaGrilla(1);
            }
            else
            {
                gridOT.DataSource = metOT.ListarOTParaGrilla(0);
            }

            gridOT.Columns[0].Visible = false;//idOt
            gridOT.Columns[1].Visible = false;//idDetalle
            gridOT.Columns[2].Visible = false;//idTaller
            gridOT.Columns[5].Visible = false;//activo
            gridOT.Columns[6].Visible = false;//estado
            gridOT.Columns[7].DisplayIndex = 0;

            gridOT.Columns[3].HeaderText = "Fecha de envio";
            gridOT.Columns[4].HeaderText = "Fecha de retiro";

        }





        #endregion

        private void radioProcesoOT_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGridOT();
        }

        private void radioRetirado_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGridOT();
        }

        private void btnEditarOT_Click(object sender, EventArgs e)
        {
            if (gridOT.SelectedRows.Count > 0)
            {
                OrdenDeTrabajo ot = new OrdenDeTrabajo();
                ot.idOrdenTrabajo = int.Parse(gridOT.CurrentRow.Cells[0].Value.ToString());
                ot.idDetalleAborrar= int.Parse(gridOT.CurrentRow.Cells[1].Value.ToString());
                ot.operacion = "editar";

                ot.ShowDialog();
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void btnBorrarOT_Click(object sender, EventArgs e)
        {
            banderaGridOtBorrado = 1;
            if (gridOT.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar esta orden de trabajo? ", "ELIMINAR ORDEN DE TRABAJO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int idOT = int.Parse(gridOT.CurrentRow.Cells[0].Value.ToString());
                    OrdenDeTrabajos ot = new OrdenDeTrabajos(idOT);
                    metOT.EliminarOT(ot);
                    MessageBox.Show("Eliminado con exito");
                    LlenarGridOT();
                    banderaGridOtBorrado = 0;
                }
                else
                    return;
            }
            else
                MessageBox.Show("Debe seleccionar una fila");

        }

        private void btnMasAlmacen_Click(object sender, EventArgs e)
        {
            if (lblProducto.Text != "Producto:")
            {
                if (txtMasAlmacen.Text != "")
                {
                    metStock.AgregarStock(int.Parse(txtMasAlmacen.Text), "almacen", idProductoStock);
                    LlenarGridStock();
                }
            }
            else
                MessageBox.Show("Debes seleccionar un producto de la tabla stock");
        }

        private void gridStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
                idProductoStock = int.Parse(gridStock.CurrentRow.Cells[0].Value.ToString());
                lblProducto.Text = "Producto: " + gridStock.CurrentRow.Cells[1].Value.ToString();
           
        }

        private void btnMenosAlmacen_Click(object sender, EventArgs e)
        {
            if (lblProducto.Text != "Producto:")
            {
                if (txtMenosAlmacen.Text != "")
                {
                    metStock.RestarStock(int.Parse(txtMenosAlmacen.Text), "almacen", idProductoStock);
                    LlenarGridStock();
                    
                }
            }
            else
                MessageBox.Show("Debes seleccionar un producto de la tabla stock");
           
        }

        private void btnMasStock_Click(object sender, EventArgs e)
        {

            if (lblProducto.Text != "Producto:")
            {
                if (txtMasStock.Text != "")
                {
                    metStock.AgregarStock(int.Parse(txtMasStock.Text), "stock", idProductoStock);
                    LlenarGridStock();
                }
            }
            else
                MessageBox.Show("Debes seleccionar un producto de la tabla stock");
        }

        private void btnMenosStock_Click(object sender, EventArgs e)
        {
            if (lblProducto.Text != "Producto:")
            {
                if (txtMenosStock.Text != "")
                {
                    metStock.RestarStock(int.Parse(txtMenosStock.Text), "stock", idProductoStock);
                    LlenarGridStock();
                }
            }
            else
                MessageBox.Show("Debes seleccionar un producto de la tabla stock");
        }

        
    }
}

