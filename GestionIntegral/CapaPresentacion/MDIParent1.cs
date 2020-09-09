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
    public partial class Principal : Form
    {
        Stock stock = new Stock();

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
            radioPendiente.Checked = true;
            date20diasAntes.Value = DateTime.Now.AddDays(-20);
            llenarGridConProductosYBotones();

        }

        #region METODOS PEDIDOS

        private void actualizarGridPedidos(int estado)
        {
            Pedidos pe = new Pedidos();
            if (estado == 1 || estado == 2)
            {
                gridListaPedidos.DataSource = pe.ListarPedidoPorEstadoParaGrilla(estado, date20diasAntes.Value, dateTimePicker1.Value);
            }
            if (estado == 3) 
            {
                gridListaPedidos.DataSource = pe.ListarTodosLosPedidosParaGrilla(date20diasAntes.Value, dateTimePicker1.Value);
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

        }

        private void radioDespachados_CheckedChanged(object sender, EventArgs e)
        {
            estadoPedido = 2;
            actualizarGridPedidos(2);
        }

        private void radioTodos_CheckedChanged(object sender, EventArgs e)
        {
            estadoPedido = 3;
            actualizarGridPedidos(3);

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

        private void Principal_Activated(object sender, EventArgs e)
        {
            actualizarGridPedidos(1);
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
            Pedidos pe = new Pedidos();

            if (gridListaPedidos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Pedido? esto puede alterar el stock y balances", "ELIMINAR PEDIDO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    pe.IdPedido = int.Parse(gridListaPedidos.CurrentRow.Cells[0].Value.ToString());
                    pe.ElminarPedido();
                    MessageBox.Show("Eliminado con exito");
                    actualizarGridPedidos(1);
                }
                else
                    return;
            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void gridListaPedidos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            float suma = 0;
            foreach (DataGridViewRow row in gridListaPedidos.Rows)
            {
                suma += float.Parse( row.Cells[6].Value.ToString());
            }
            txtTotalImportes.Text = suma.ToString();

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
        private void llenarGridConProductosYBotones()
        {
            gridStock.DataSource = stock.ListarStock();

            #region BOTONES DE LA GRILLA
            DataGridViewButtonColumn boton0 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn boton1 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn boton2 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn boton3 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn boton4 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn boton5 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn boton6 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn boton7 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn boton8 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn boton9 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn boton10 = new DataGridViewButtonColumn();

            DataGridViewButtonColumn boton11= new DataGridViewButtonColumn();//sumartaller1
            DataGridViewButtonColumn boton12 = new DataGridViewButtonColumn();//sumartaller2
            DataGridViewButtonColumn boton13 = new DataGridViewButtonColumn();//sumartaller3
            DataGridViewButtonColumn boton14 = new DataGridViewButtonColumn();//sumartaller4
            DataGridViewButtonColumn boton15 = new DataGridViewButtonColumn();//agregarStock






            gridStock.Columns.Add(boton0);//11 + almacen
            gridStock.Columns.Add(boton1);//12 de taller1 a almacen
            gridStock.Columns.Add(boton2);//13 de almacen a taller1
            gridStock.Columns.Add(boton3);//14 de taller2 a taller 1
            gridStock.Columns.Add(boton4);//15 de taller1 a taller 2
            gridStock.Columns.Add(boton5);//16 de taller3 a taller 2
            gridStock.Columns.Add(boton6);//17 de taller2 a taller 3
            gridStock.Columns.Add(boton7);//18 de taller4 a taller 3
            gridStock.Columns.Add(boton8);//19 de taller3 a taller 4

            gridStock.Columns.Add(boton9);//20 de stock a taller 4
            gridStock.Columns.Add(boton10);//21 de taller 4 a stock

            gridStock.Columns.Add(boton11);//22 sumartaller1 
            gridStock.Columns.Add(boton12);//23 sumartaller2
            gridStock.Columns.Add(boton13);//24 sumartaller3
            gridStock.Columns.Add(boton14);//25 sumartaller4
            gridStock.Columns.Add(boton15);//26 agregarStock





            gridStock.Columns[11].DisplayIndex = 1 ;//11suma almacen

            gridStock.Columns[12].DisplayIndex = 3;//12de taller1 a almacen
            gridStock.Columns[22].DisplayIndex = 4;//22sumar taller1
            gridStock.Columns[13].DisplayIndex = 5;//13de almacen a taller1
            
            gridStock.Columns[14].DisplayIndex = 7;//14 de taller2 a taller 1
            gridStock.Columns[23].DisplayIndex = 8;//23 sumar taller2
            gridStock.Columns[15].DisplayIndex = 9;//15 de taller1 a taller 2

            gridStock.Columns[16].DisplayIndex = 11;//16 de taller3 a taller 2
            gridStock.Columns[24].DisplayIndex = 12;//23 sumar taller3
            gridStock.Columns[17].DisplayIndex = 13;//17 de taller2 a taller 3


            gridStock.Columns[18].DisplayIndex = 15;//18 de taller4 a taller 3
            gridStock.Columns[25].DisplayIndex = 16;//25 sumartaller4
            gridStock.Columns[19].DisplayIndex = 17;//19 de taller3 a taller 4

            gridStock.Columns[20].DisplayIndex = 19;//20 de stock a taller 4
            gridStock.Columns[26].DisplayIndex = 20;//26 sumarStock
            gridStock.Columns[21].DisplayIndex = 21;//21 de taller 4 a stock

            boton0.DefaultCellStyle.NullValue = "+";
            boton11.DefaultCellStyle.NullValue = "+";
            boton12.DefaultCellStyle.NullValue = "+";
            boton13.DefaultCellStyle.NullValue = "+";
            boton14.DefaultCellStyle.NullValue = "+";
            boton15.DefaultCellStyle.NullValue = "+";


            boton1.DefaultCellStyle.NullValue = "<-";
            boton3.DefaultCellStyle.NullValue = "<-";
            boton5.DefaultCellStyle.NullValue = "<-";
            boton7.DefaultCellStyle.NullValue = "<-";
            boton9.DefaultCellStyle.NullValue = "<-";
            boton2.DefaultCellStyle.NullValue = "->";
            boton4.DefaultCellStyle.NullValue = "->";
            boton6.DefaultCellStyle.NullValue = "->";
            boton8.DefaultCellStyle.NullValue = "->";
            boton10.DefaultCellStyle.NullValue = "->";

            gridStock.Columns[10].Width = 100;
            gridStock.Columns[11].Width = 20;
            gridStock.Columns[12].Width = 20;
            gridStock.Columns[13].Width = 20;
            gridStock.Columns[14].Width = 20;
            gridStock.Columns[15].Width = 20;
            gridStock.Columns[16].Width = 20;
            gridStock.Columns[17].Width = 20;
            gridStock.Columns[18].Width = 20;
            gridStock.Columns[19].Width = 20;
            gridStock.Columns[20].Width = 20;
            gridStock.Columns[21].Width = 20;
            gridStock.Columns[22].Width = 20;
            gridStock.Columns[23].Width = 20;
            gridStock.Columns[24].Width = 20;
            gridStock.Columns[25].Width = 20;
            gridStock.Columns[26].Width = 20;

            #endregion

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

            Pedidos pe = new Pedidos();
            foreach (DataGridViewRow row in gridStock.Rows) {
                gridStock.CurrentRow.Cells[8].Value =  pe.DevolverPedidosPendientes(int.Parse(gridStock.CurrentRow.Cells[0].Value.ToString()));
            }
            

        }

       

        #endregion

        #region EVENTOS STOCK

        private void gridStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int potencial=0;

            int num= e.ColumnIndex;

            stock.IdProducto = int.Parse(gridStock.CurrentRow.Cells[0].Value.ToString());
           
            switch (num)
            {
                case 11://sumar al almacen
                    gridStock.CurrentRow.Cells[1].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[1].Value) + 1;
                    stock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[1].Value.ToString()), "almacen");
                    break;
                case 12://de 2 a 1
                    if (int.Parse(gridStock.CurrentRow.Cells[2].Value.ToString()) > 0)
                    {
                        gridStock.CurrentRow.Cells[1].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[1].Value) + 1;
                        gridStock.CurrentRow.Cells[2].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[2].Value) - 1;
                        stock.PasarStock("taller1", "almacen", int.Parse(gridStock.CurrentRow.Cells[2].Value.ToString()), int.Parse(gridStock.CurrentRow.Cells[1].Value.ToString()));
                    }
                    break;
                case 13://de 1 a 2
                    if (int.Parse(gridStock.CurrentRow.Cells[1].Value.ToString()) > 0)
                    {
                        gridStock.CurrentRow.Cells[1].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[1].Value) - 1;
                        gridStock.CurrentRow.Cells[2].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[2].Value) + 1;
                        stock.PasarStock("almacen", "taller1", int.Parse(gridStock.CurrentRow.Cells[1].Value.ToString()), int.Parse(gridStock.CurrentRow.Cells[2].Value.ToString()));
                    }
                    break;
                case 14://de 3 a 2
                    if (int.Parse(gridStock.CurrentRow.Cells[3].Value.ToString()) > 0)
                    {
                        gridStock.CurrentRow.Cells[2].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[2].Value) + 1;
                        gridStock.CurrentRow.Cells[3].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[3].Value) - 1;
                        stock.PasarStock("taller2", "taller1", int.Parse(gridStock.CurrentRow.Cells[3].Value.ToString()), int.Parse(gridStock.CurrentRow.Cells[2].Value.ToString()));
                    }
                    break;
                case 15://de 2 a 3
                    if (int.Parse(gridStock.CurrentRow.Cells[2].Value.ToString()) > 0)
                    {
                        gridStock.CurrentRow.Cells[2].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[2].Value) - 1;
                        gridStock.CurrentRow.Cells[3].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[3].Value) + 1;
                        stock.PasarStock("taller1", "taller2", int.Parse(gridStock.CurrentRow.Cells[2].Value.ToString()), int.Parse(gridStock.CurrentRow.Cells[3].Value.ToString()));
                    }
                    break;
                case 16://de 4 a 3
                    if (int.Parse(gridStock.CurrentRow.Cells[4].Value.ToString()) > 0)
                    {
                        gridStock.CurrentRow.Cells[3].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[3].Value) + 1;
                        gridStock.CurrentRow.Cells[4].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[4].Value) - 1;
                        stock.PasarStock("taller3", "taller2", int.Parse(gridStock.CurrentRow.Cells[4].Value.ToString()), int.Parse(gridStock.CurrentRow.Cells[3].Value.ToString()));
                    }
                    break;
                case 17://de 3 a 4
                    if (int.Parse(gridStock.CurrentRow.Cells[3].Value.ToString()) > 0)
                    {
                        gridStock.CurrentRow.Cells[3].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[3].Value) - 1;
                        gridStock.CurrentRow.Cells[4].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[4].Value) + 1;
                        stock.PasarStock("taller2", "taller3", int.Parse(gridStock.CurrentRow.Cells[3].Value.ToString()), int.Parse(gridStock.CurrentRow.Cells[4].Value.ToString()));
                    }
                    break;
                case 18://5 a 4
                    if (int.Parse(gridStock.CurrentRow.Cells[5].Value.ToString()) > 0)
                    {
                        gridStock.CurrentRow.Cells[5].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[5].Value) - 1;
                        gridStock.CurrentRow.Cells[4].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[4].Value) + 1;
                        stock.PasarStock("taller4", "taller3", int.Parse(gridStock.CurrentRow.Cells[5].Value.ToString()), int.Parse(gridStock.CurrentRow.Cells[4].Value.ToString()));
                    }
                    break;
                case 19://de 4 a 5
                    if (int.Parse(gridStock.CurrentRow.Cells[4].Value.ToString()) > 0)
                    {
                        gridStock.CurrentRow.Cells[5].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[5].Value) + 1;
                        gridStock.CurrentRow.Cells[4].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[4].Value) - 1;
                        stock.PasarStock("taller3", "taller4", int.Parse(gridStock.CurrentRow.Cells[4].Value.ToString()), int.Parse(gridStock.CurrentRow.Cells[5].Value.ToString()));
                    }
                    break;
                case 20://de 6 a 5
                    if (int.Parse(gridStock.CurrentRow.Cells[6].Value.ToString()) > 0)
                    {
                        gridStock.CurrentRow.Cells[6].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[6].Value) - 1;
                        gridStock.CurrentRow.Cells[5].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[5].Value) + 1;
                        stock.PasarStock("stockCant", "taller4", int.Parse(gridStock.CurrentRow.Cells[6].Value.ToString()), int.Parse(gridStock.CurrentRow.Cells[5].Value.ToString()));
                    }
                    break;
                case 21://de 5 a 6
                    if (int.Parse(gridStock.CurrentRow.Cells[5].Value.ToString()) > 0)
                    {
                        gridStock.CurrentRow.Cells[5].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[5].Value) - 1;
                        gridStock.CurrentRow.Cells[6].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[6].Value) + 1;
                        stock.PasarStock("taller4", "stockCant", int.Parse(gridStock.CurrentRow.Cells[5].Value.ToString()), int.Parse(gridStock.CurrentRow.Cells[6].Value.ToString()));
                    }
                    break;
                case 22://sumar al taller1
                    gridStock.CurrentRow.Cells[2].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[2].Value) + 1;
                    stock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[2].Value.ToString()), "taller1");
                    break;
                case 23://sumar al taller2
                    gridStock.CurrentRow.Cells[3].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[3].Value) + 1;
                    stock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[3].Value.ToString()), "taller2");
                    break;
                case 24://sumar al taller3
                    gridStock.CurrentRow.Cells[4].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[4].Value) + 1;
                    stock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[4].Value.ToString()), "taller3");
                    break;
                case 25://sumar al taller4
                    gridStock.CurrentRow.Cells[5].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[5].Value) + 1;
                    stock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[5].Value.ToString()), "taller4");
                    break;
                case 26://sumar al cantStock
                    gridStock.CurrentRow.Cells[6].Value = Convert.ToInt32(gridStock.CurrentRow.Cells[6].Value) + 1;
                    stock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[6].Value.ToString()), "stockCant");
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
            stock.AgregarStock(Convert.ToInt32(gridStock.CurrentRow.Cells[7].Value.ToString()), "potencialStock");
        }
        #endregion

        private void gridStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int potencial = 0;

            int valor = 0;

            int num = e.ColumnIndex;

            stock.IdProducto = int.Parse(gridStock.CurrentRow.Cells[0].Value.ToString());

            switch (num)
            {
                case 1://sumar al almacen
                    valor = Convert.ToInt32(gridStock.CurrentRow.Cells[1].Value.ToString());
                    stock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[1].Value.ToString()), "almacen");

                    break;
                case 2://sumar al taller1
                    valor = Convert.ToInt32(gridStock.CurrentRow.Cells[2].Value.ToString());
                    stock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[2].Value.ToString()), "taller1");

                    break;
                case 3://sumar al taller2
                    valor = Convert.ToInt32(gridStock.CurrentRow.Cells[3].Value.ToString());
                    stock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[3].Value.ToString()), "taller2");

                    break;
                case 4://sumar al taller3
                    valor = Convert.ToInt32(gridStock.CurrentRow.Cells[4].Value.ToString());
                    stock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[4].Value.ToString()), "taller3");

                    break;
                case 5://sumar al taller4
                    valor = Convert.ToInt32(gridStock.CurrentRow.Cells[5].Value.ToString());
                    stock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[5].Value.ToString()), "taller4");

                    break;
                case 6://sumar al stock
                    valor = Convert.ToInt32(gridStock.CurrentRow.Cells[6].Value.ToString());
                    stock.AgregarStock(int.Parse(gridStock.CurrentRow.Cells[6].Value.ToString()), "stockCant");

                    break;


                default:
                    break;
            }
            
            int almacen= Convert.ToInt32(gridStock.CurrentRow.Cells[1].Value.ToString());
            int taller1 = Convert.ToInt32(gridStock.CurrentRow.Cells[2].Value.ToString());
            int taller2 = Convert.ToInt32(gridStock.CurrentRow.Cells[3].Value.ToString());
            int taller3 = Convert.ToInt32(gridStock.CurrentRow.Cells[4].Value.ToString());
            int taller4 = Convert.ToInt32(gridStock.CurrentRow.Cells[5].Value.ToString());
            
            potencial = almacen + taller1 + taller2 + taller3 + taller4;
          
            gridStock.CurrentRow.Cells[7].Value =  potencial;
            stock.AgregarStock(Convert.ToInt32(gridStock.CurrentRow.Cells[7].Value.ToString()), "potencialStock");
           
        }
    }
}

