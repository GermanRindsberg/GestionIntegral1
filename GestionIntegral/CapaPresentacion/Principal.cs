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

        private int childFormNumber = 0;

        private int estadoPedido = 1;

        public Principal()
        {
            InitializeComponent();
        }

        #region MDIFORM
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
        #endregion

        private void Principal_Load(object sender, EventArgs e)
        {
            actualizarGridPedidos(estadoPedido);
            date20diasAntes.Value = DateTime.Now.AddDays(-20);
            DiseñoTabla();
            LlenarGrillaResumen();
            radioPendiente.Checked = true;
            actualizarTotalImportes();
            radioPendientesStock.Checked = true;
        }

        private void Principal_Activated(object sender, EventArgs e)
        {
            actualizarGridPedidos(1);
            radioPendiente.Checked = true;
            DiseñoTabla();
            radioFamilia.Checked = true;
            LlenarGrillaResumen();
            actualizarTotalImportes();

        }
       
        #region METODOS PEDIDOS

        private void actualizarGridPedidos(int estado)
        {
            Pedido pe = new Pedido();
            if (estado == 1 || estado == 2)
            {
                gridListaPedidos.DataSource = metPedido.ListarPedidoPorEstadoParaGrilla(estado, date20diasAntes.Value, dateTimePicker1.Value);
            }
            if (estado == 3) 
            {
                gridListaPedidos.DataSource = metPedido.ListarPedidoPorEstadoParaGrilla(0, date20diasAntes.Value, dateTimePicker1.Value);
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

            if (radioTodos.Checked == true)
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
            Pedido pe = new Pedido();

            if (gridListaPedidos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Pedido? esto puede alterar el stock y balances", "ELIMINAR PEDIDO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    pe.IdPedido = int.Parse(gridListaPedidos.CurrentRow.Cells[0].Value.ToString());
                    metPedido.EliminarPedido(pe);
                    MessageBox.Show("Eliminado con exito");
                    actualizarGridPedidos(1);
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

     
        private void DiseñoTabla()
        {
            gridStock.DataSource = metStock.ListarStock();
            gridStock.Columns[0].Visible = false;//idProducto
            gridStock.Columns[10].DisplayIndex = 0;
            gridStock.Columns[1].HeaderText = "Almacen";
            gridStock.Columns[2].HeaderText = "Taller 1";
            gridStock.Columns[3].HeaderText = "Taller 2";
            gridStock.Columns[4].HeaderText = "Taller 3";
            gridStock.Columns[5].HeaderText = "Taller 4";
            gridStock.Columns[6].HeaderText = "Cant Stock";
            gridStock.Columns[7].HeaderText = "Potencial Stock";
            gridStock.Columns[8].HeaderText = "Pedidos";
            gridStock.Columns[9].HeaderText = "Requerido";
            gridStock.Columns[10].HeaderText = "Descripcion del producto";
            devolverPedidosParaStock();
            devolverRequeridosParaStock();

        }

        public void devolverPedidosParaStock()
        {

            foreach (DataGridViewRow row in gridStock.Rows)
            {
                row.Cells[8].Value = metPedido.DevolverPedidosPendientes(int.Parse(row.Cells[0].Value.ToString()));
            }

        }

        public void devolverRequeridosParaStock()//potencial mas stock menos pedidos
        {
            Pedido pe = new Pedido();

            foreach (DataGridViewRow row in gridStock.Rows)
            {
                int stock = int.Parse( row.Cells[6].Value.ToString());
                int potencial = int.Parse(row.Cells[7].Value.ToString());
                int pedidos = int.Parse(row.Cells[8].Value.ToString());
                int resultado= pedidos-(stock + potencial) ;
                if (resultado > 0)
                {
                    row.Cells[9].Value = resultado;
                }else
                    row.Cells[9].Value = 0;

            }

        }

        #endregion

        #region EVENTOS STOCK
        private void gridStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int potencial = 0;

            int valor = 0;

            int num = e.ColumnIndex;
            Stock stock = new Stock();
            stock.IdProducto = int.Parse(gridStock.CurrentRow.Cells[0].Value.ToString());

            switch (num)
            {
                case 1://sumar al almacen
                    valor = Convert.ToInt32(gridStock.CurrentRow.Cells[1].Value.ToString());
                  metStock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[1].Value.ToString()), "almacen");

                    break;
                case 2://sumar al taller1
                    valor = Convert.ToInt32(gridStock.CurrentRow.Cells[2].Value.ToString());
                    metStock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[2].Value.ToString()), "taller1");

                    break;
                case 3://sumar al taller2
                    valor = Convert.ToInt32(gridStock.CurrentRow.Cells[3].Value.ToString());
                    metStock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[3].Value.ToString()), "taller2");

                    break;
                case 4://sumar al taller3
                    valor = Convert.ToInt32(gridStock.CurrentRow.Cells[4].Value.ToString());
                    metStock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[4].Value.ToString()), "taller3");

                    break;
                case 5://sumar al taller4
                    valor = Convert.ToInt32(gridStock.CurrentRow.Cells[5].Value.ToString());
                    metStock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[5].Value.ToString()), "taller4");

                    break;
                case 6://sumar al stock
                    valor = Convert.ToInt32(gridStock.CurrentRow.Cells[6].Value.ToString());
                    metStock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[6].Value.ToString()), "stockCant");

                    break;


                default:
                    break;
            }

            int almacen = Convert.ToInt32(gridStock.CurrentRow.Cells[1].Value.ToString());
            int taller1 = Convert.ToInt32(gridStock.CurrentRow.Cells[2].Value.ToString());
            int taller2 = Convert.ToInt32(gridStock.CurrentRow.Cells[3].Value.ToString());
            int taller3 = Convert.ToInt32(gridStock.CurrentRow.Cells[4].Value.ToString());
            int taller4 = Convert.ToInt32(gridStock.CurrentRow.Cells[5].Value.ToString());

            potencial = almacen + taller1 + taller2 + taller3 + taller4;

            gridStock.CurrentRow.Cells[7].Value = potencial;
            metStock.AgregarStock(Convert.ToInt32(gridStock.CurrentRow.Cells[7].Value.ToString()), "potencialStock");
            devolverRequeridosParaStock();

        }

        #endregion

        #region METODOS RESUMEN VENTAS
        private void LlenarGrillaResumen()
        {
            Pedido pe = new Pedido();
            if (radioFamilia.Checked==true)
            {
              gridResumen.DataSource = metPedido.ListarResumenDePedidos(1);
            }
            else
                gridResumen.DataSource = metPedido.ListarResumenDePedidos(0);
        }


        #endregion

        private void radioFamilia_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGrillaResumen();
        }

        private void radioDiseño_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGrillaResumen();
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
    }
}
