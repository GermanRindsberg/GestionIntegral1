namespace GestionIntegral.CapaPresentacion
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.transportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mediosDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gridListaPedidos = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.date20diasAntes = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioPendiente = new System.Windows.Forms.RadioButton();
            this.radioDespachados = new System.Windows.Forms.RadioButton();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnFichaCliente = new System.Windows.Forms.Button();
            this.txtTotalImportes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioTodos = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.gridStock = new System.Windows.Forms.DataGridView();
            this.radioTodosStock = new System.Windows.Forms.RadioButton();
            this.radioPendientesStock = new System.Windows.Forms.RadioButton();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.informesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1600, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem1,
            this.transportesToolStripMenuItem,
            this.productosToolStripMenuItem1,
            this.mediosDePagoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.clientesToolStripMenuItem1.Text = "Clientes";
            this.clientesToolStripMenuItem1.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
            // 
            // transportesToolStripMenuItem
            // 
            this.transportesToolStripMenuItem.Name = "transportesToolStripMenuItem";
            this.transportesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.transportesToolStripMenuItem.Text = "Transportes";
            this.transportesToolStripMenuItem.Click += new System.EventHandler(this.transportesToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem1
            // 
            this.productosToolStripMenuItem1.Name = "productosToolStripMenuItem1";
            this.productosToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.productosToolStripMenuItem1.Text = "Productos";
            this.productosToolStripMenuItem1.Click += new System.EventHandler(this.productosToolStripMenuItem1_Click);
            // 
            // mediosDePagoToolStripMenuItem
            // 
            this.mediosDePagoToolStripMenuItem.Name = "mediosDePagoToolStripMenuItem";
            this.mediosDePagoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.mediosDePagoToolStripMenuItem.Text = "Medios de pago";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // gridListaPedidos
            // 
            this.gridListaPedidos.AllowUserToAddRows = false;
            this.gridListaPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridListaPedidos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridListaPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridListaPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridListaPedidos.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridListaPedidos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridListaPedidos.Location = new System.Drawing.Point(12, 81);
            this.gridListaPedidos.Name = "gridListaPedidos";
            this.gridListaPedidos.RowHeadersVisible = false;
            this.gridListaPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridListaPedidos.ShowCellErrors = false;
            this.gridListaPedidos.ShowCellToolTips = false;
            this.gridListaPedidos.ShowEditingIcon = false;
            this.gridListaPedidos.ShowRowErrors = false;
            this.gridListaPedidos.Size = new System.Drawing.Size(1572, 269);
            this.gridListaPedidos.TabIndex = 4;
            this.gridListaPedidos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridListaPedidos_RowsAdded);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(182, 55);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pedidos";
            // 
            // date20diasAntes
            // 
            this.date20diasAntes.Location = new System.Drawing.Point(182, 29);
            this.date20diasAntes.Name = "date20diasAntes";
            this.date20diasAntes.Size = new System.Drawing.Size(200, 20);
            this.date20diasAntes.TabIndex = 8;
            this.date20diasAntes.ValueChanged += new System.EventHandler(this.date20diasAntes_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(138, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(138, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hasta";
            // 
            // radioPendiente
            // 
            this.radioPendiente.AutoSize = true;
            this.radioPendiente.BackColor = System.Drawing.Color.Transparent;
            this.radioPendiente.Location = new System.Drawing.Point(388, 59);
            this.radioPendiente.Name = "radioPendiente";
            this.radioPendiente.Size = new System.Drawing.Size(78, 17);
            this.radioPendiente.TabIndex = 11;
            this.radioPendiente.TabStop = true;
            this.radioPendiente.Text = "Pendientes";
            this.radioPendiente.UseVisualStyleBackColor = false;
            this.radioPendiente.CheckedChanged += new System.EventHandler(this.radioPendiente_CheckedChanged);
            // 
            // radioDespachados
            // 
            this.radioDespachados.AutoSize = true;
            this.radioDespachados.BackColor = System.Drawing.Color.Transparent;
            this.radioDespachados.Location = new System.Drawing.Point(472, 59);
            this.radioDespachados.Name = "radioDespachados";
            this.radioDespachados.Size = new System.Drawing.Size(91, 17);
            this.radioDespachados.TabIndex = 12;
            this.radioDespachados.TabStop = true;
            this.radioDespachados.Text = "Despachados";
            this.radioDespachados.UseVisualStyleBackColor = false;
            this.radioDespachados.CheckedChanged += new System.EventHandler(this.radioDespachados_CheckedChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(802, 356);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(188, 34);
            this.btnNuevo.TabIndex = 14;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(1000, 356);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(188, 34);
            this.btnEditar.TabIndex = 15;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(1198, 356);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(188, 34);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnFichaCliente
            // 
            this.btnFichaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFichaCliente.Location = new System.Drawing.Point(1396, 356);
            this.btnFichaCliente.Name = "btnFichaCliente";
            this.btnFichaCliente.Size = new System.Drawing.Size(188, 34);
            this.btnFichaCliente.TabIndex = 17;
            this.btnFichaCliente.Text = "Ficha Cliente";
            this.btnFichaCliente.UseVisualStyleBackColor = true;
            this.btnFichaCliente.Click += new System.EventHandler(this.btnFichaCliente_Click);
            // 
            // txtTotalImportes
            // 
            this.txtTotalImportes.Location = new System.Drawing.Point(665, 356);
            this.txtTotalImportes.Name = "txtTotalImportes";
            this.txtTotalImportes.Size = new System.Drawing.Size(131, 20);
            this.txtTotalImportes.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(571, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Total de importes";
            // 
            // radioTodos
            // 
            this.radioTodos.AutoSize = true;
            this.radioTodos.BackColor = System.Drawing.Color.Transparent;
            this.radioTodos.Location = new System.Drawing.Point(569, 59);
            this.radioTodos.Name = "radioTodos";
            this.radioTodos.Size = new System.Drawing.Size(55, 17);
            this.radioTodos.TabIndex = 13;
            this.radioTodos.TabStop = true;
            this.radioTodos.Text = "Todos";
            this.radioTodos.UseVisualStyleBackColor = false;
            this.radioTodos.CheckedChanged += new System.EventHandler(this.radioTodos_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label8.Location = new System.Drawing.Point(12, 411);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 29);
            this.label8.TabIndex = 22;
            this.label8.Text = "Disponibilidad";
            // 
            // gridStock
            // 
            this.gridStock.AllowUserToAddRows = false;
            this.gridStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridStock.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridStock.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridStock.Location = new System.Drawing.Point(12, 443);
            this.gridStock.Name = "gridStock";
            this.gridStock.RowHeadersVisible = false;
            this.gridStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridStock.ShowCellErrors = false;
            this.gridStock.ShowCellToolTips = false;
            this.gridStock.ShowEditingIcon = false;
            this.gridStock.ShowRowErrors = false;
            this.gridStock.Size = new System.Drawing.Size(1572, 269);
            this.gridStock.TabIndex = 20;
            this.gridStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStock_CellContentClick);
            this.gridStock.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStock_CellEndEdit);
            // 
            // radioTodosStock
            // 
            this.radioTodosStock.AutoSize = true;
            this.radioTodosStock.BackColor = System.Drawing.Color.Transparent;
            this.radioTodosStock.Location = new System.Drawing.Point(274, 420);
            this.radioTodosStock.Name = "radioTodosStock";
            this.radioTodosStock.Size = new System.Drawing.Size(55, 17);
            this.radioTodosStock.TabIndex = 24;
            this.radioTodosStock.TabStop = true;
            this.radioTodosStock.Text = "Todos";
            this.radioTodosStock.UseVisualStyleBackColor = false;
            // 
            // radioPendientesStock
            // 
            this.radioPendientesStock.AutoSize = true;
            this.radioPendientesStock.BackColor = System.Drawing.Color.Transparent;
            this.radioPendientesStock.Location = new System.Drawing.Point(190, 420);
            this.radioPendientesStock.Name = "radioPendientesStock";
            this.radioPendientesStock.Size = new System.Drawing.Size(78, 17);
            this.radioPendientesStock.TabIndex = 23;
            this.radioPendientesStock.TabStop = true;
            this.radioPendientesStock.Text = "Pendientes";
            this.radioPendientesStock.UseVisualStyleBackColor = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1600, 861);
            this.Controls.Add(this.radioTodosStock);
            this.Controls.Add(this.radioPendientesStock);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gridStock);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalImportes);
            this.Controls.Add(this.btnFichaCliente);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.radioTodos);
            this.Controls.Add(this.radioDespachados);
            this.Controls.Add(this.radioPendiente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date20diasAntes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.gridListaPedidos);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Principal";
            this.Text = "Principal";
            this.Activated += new System.EventHandler(this.Principal_Activated);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.DataGridView gridListaPedidos;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date20diasAntes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioPendiente;
        private System.Windows.Forms.RadioButton radioDespachados;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnFichaCliente;
        private System.Windows.Forms.TextBox txtTotalImportes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem transportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mediosDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioTodos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView gridStock;
        private System.Windows.Forms.RadioButton radioTodosStock;
        private System.Windows.Forms.RadioButton radioPendientesStock;
    }
}



