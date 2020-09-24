﻿namespace GestionIntegral.CapaPresentacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.gridStock = new System.Windows.Forms.DataGridView();
            this.radioTodosStock = new System.Windows.Forms.RadioButton();
            this.radioPendientesStock = new System.Windows.Forms.RadioButton();
            this.gridResumen = new System.Windows.Forms.DataGridView();
            this.radioDiseño = new System.Windows.Forms.RadioButton();
            this.radioFamilia = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOt = new System.Windows.Forms.Button();
            this.talleresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenesDeTrabajoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResumen)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.HotTrack;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.informesToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.transportesToolStripMenuItem1,
            this.productosToolStripMenuItem,
            this.talleresToolStripMenuItem,
            this.ordenesDeTrabajoToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1584, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.informesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // transportesToolStripMenuItem1
            // 
            this.transportesToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transportesToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.transportesToolStripMenuItem1.Name = "transportesToolStripMenuItem1";
            this.transportesToolStripMenuItem1.Size = new System.Drawing.Size(100, 24);
            this.transportesToolStripMenuItem1.Text = "Transportes";
            this.transportesToolStripMenuItem1.Click += new System.EventHandler(this.transportesToolStripMenuItem1_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
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
            this.gridListaPedidos.Size = new System.Drawing.Size(1031, 320);
            this.gridListaPedidos.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(485, 51);
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
            this.date20diasAntes.Location = new System.Drawing.Point(190, 51);
            this.date20diasAntes.Name = "date20diasAntes";
            this.date20diasAntes.Size = new System.Drawing.Size(200, 20);
            this.date20diasAntes.TabIndex = 8;
            this.date20diasAntes.ValueChanged += new System.EventHandler(this.date20diasAntes_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(146, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(444, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hasta";
            // 
            // radioPendiente
            // 
            this.radioPendiente.AutoSize = true;
            this.radioPendiente.BackColor = System.Drawing.Color.Transparent;
            this.radioPendiente.Location = new System.Drawing.Point(739, 53);
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
            this.radioDespachados.Location = new System.Drawing.Point(847, 53);
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
            this.btnNuevo.Location = new System.Drawing.Point(251, 416);
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
            this.btnEditar.Location = new System.Drawing.Point(449, 416);
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
            this.btnEliminar.Location = new System.Drawing.Point(647, 416);
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
            this.btnFichaCliente.Location = new System.Drawing.Point(845, 416);
            this.btnFichaCliente.Name = "btnFichaCliente";
            this.btnFichaCliente.Size = new System.Drawing.Size(188, 34);
            this.btnFichaCliente.TabIndex = 17;
            this.btnFichaCliente.Text = "Ficha Cliente";
            this.btnFichaCliente.UseVisualStyleBackColor = true;
            this.btnFichaCliente.Click += new System.EventHandler(this.btnFichaCliente_Click);
            // 
            // txtTotalImportes
            // 
            this.txtTotalImportes.Location = new System.Drawing.Point(114, 423);
            this.txtTotalImportes.Name = "txtTotalImportes";
            this.txtTotalImportes.Size = new System.Drawing.Size(131, 20);
            this.txtTotalImportes.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Total de importes";
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
            this.gridStock.Location = new System.Drawing.Point(12, 515);
            this.gridStock.Name = "gridStock";
            this.gridStock.RowHeadersVisible = false;
            this.gridStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridStock.ShowCellErrors = false;
            this.gridStock.ShowCellToolTips = false;
            this.gridStock.ShowEditingIcon = false;
            this.gridStock.ShowRowErrors = false;
            this.gridStock.Size = new System.Drawing.Size(1031, 297);
            this.gridStock.TabIndex = 20;
            this.gridStock.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStock_CellEndEdit);
            // 
            // radioTodosStock
            // 
            this.radioTodosStock.AutoSize = true;
            this.radioTodosStock.BackColor = System.Drawing.Color.Transparent;
            this.radioTodosStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioTodosStock.Location = new System.Drawing.Point(202, 13);
            this.radioTodosStock.Name = "radioTodosStock";
            this.radioTodosStock.Size = new System.Drawing.Size(66, 21);
            this.radioTodosStock.TabIndex = 24;
            this.radioTodosStock.TabStop = true;
            this.radioTodosStock.Text = "Todos";
            this.radioTodosStock.UseVisualStyleBackColor = false;
            // 
            // radioPendientesStock
            // 
            this.radioPendientesStock.AutoSize = true;
            this.radioPendientesStock.BackColor = System.Drawing.Color.Transparent;
            this.radioPendientesStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioPendientesStock.Location = new System.Drawing.Point(274, 13);
            this.radioPendientesStock.Name = "radioPendientesStock";
            this.radioPendientesStock.Size = new System.Drawing.Size(97, 21);
            this.radioPendientesStock.TabIndex = 23;
            this.radioPendientesStock.TabStop = true;
            this.radioPendientesStock.Text = "Pendientes";
            this.radioPendientesStock.UseVisualStyleBackColor = false;
            // 
            // gridResumen
            // 
            this.gridResumen.AllowUserToAddRows = false;
            this.gridResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridResumen.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridResumen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridResumen.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridResumen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridResumen.Location = new System.Drawing.Point(1067, 86);
            this.gridResumen.Name = "gridResumen";
            this.gridResumen.RowHeadersVisible = false;
            this.gridResumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridResumen.ShowCellErrors = false;
            this.gridResumen.ShowCellToolTips = false;
            this.gridResumen.ShowEditingIcon = false;
            this.gridResumen.ShowRowErrors = false;
            this.gridResumen.Size = new System.Drawing.Size(501, 760);
            this.gridResumen.TabIndex = 25;
            // 
            // radioDiseño
            // 
            this.radioDiseño.AutoSize = true;
            this.radioDiseño.BackColor = System.Drawing.Color.Transparent;
            this.radioDiseño.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioDiseño.Location = new System.Drawing.Point(172, 38);
            this.radioDiseño.Name = "radioDiseño";
            this.radioDiseño.Size = new System.Drawing.Size(92, 21);
            this.radioDiseño.TabIndex = 28;
            this.radioDiseño.TabStop = true;
            this.radioDiseño.Text = "Ver familia";
            this.radioDiseño.UseVisualStyleBackColor = false;
            this.radioDiseño.CheckedChanged += new System.EventHandler(this.radioDiseño_CheckedChanged);
            // 
            // radioFamilia
            // 
            this.radioFamilia.AutoSize = true;
            this.radioFamilia.BackColor = System.Drawing.Color.Transparent;
            this.radioFamilia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioFamilia.Location = new System.Drawing.Point(10, 38);
            this.radioFamilia.Name = "radioFamilia";
            this.radioFamilia.Size = new System.Drawing.Size(154, 21);
            this.radioFamilia.TabIndex = 27;
            this.radioFamilia.TabStop = true;
            this.radioFamilia.Text = "Ver producto/diseño";
            this.radioFamilia.UseVisualStyleBackColor = false;
            this.radioFamilia.CheckedChanged += new System.EventHandler(this.radioFamilia_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioFamilia);
            this.groupBox1.Controls.Add(this.radioDiseño);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.groupBox1.Location = new System.Drawing.Point(1067, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 60);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resumen de ventas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioTodosStock);
            this.groupBox2.Controls.Add(this.radioPendientesStock);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.groupBox2.Location = new System.Drawing.Point(12, 480);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1031, 34);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Disponibilidad";
            // 
            // btnOt
            // 
            this.btnOt.Location = new System.Drawing.Point(926, 818);
            this.btnOt.Name = "btnOt";
            this.btnOt.Size = new System.Drawing.Size(117, 40);
            this.btnOt.TabIndex = 31;
            this.btnOt.Text = "Ordenes de trabajo";
            this.btnOt.UseVisualStyleBackColor = true;
            this.btnOt.Click += new System.EventHandler(this.btnOt_Click);
            // 
            // talleresToolStripMenuItem
            // 
            this.talleresToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.talleresToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.talleresToolStripMenuItem.Name = "talleresToolStripMenuItem";
            this.talleresToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.talleresToolStripMenuItem.Text = "Talleres";
            this.talleresToolStripMenuItem.Click += new System.EventHandler(this.talleresToolStripMenuItem_Click);
            // 
            // ordenesDeTrabajoToolStripMenuItem
            // 
            this.ordenesDeTrabajoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.ordenesDeTrabajoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ordenesDeTrabajoToolStripMenuItem.Name = "ordenesDeTrabajoToolStripMenuItem";
            this.ordenesDeTrabajoToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.ordenesDeTrabajoToolStripMenuItem.Text = "Ordenes de trabajo";
            this.ordenesDeTrabajoToolStripMenuItem.Click += new System.EventHandler(this.ordenesDeTrabajoToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.btnOt);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridResumen);
            this.Controls.Add(this.gridStock);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalImportes);
            this.Controls.Add(this.btnFichaCliente);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Activated += new System.EventHandler(this.Principal_Activated);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResumen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.DataGridView gridStock;
        private System.Windows.Forms.RadioButton radioTodosStock;
        private System.Windows.Forms.RadioButton radioPendientesStock;
        private System.Windows.Forms.DataGridView gridResumen;
        private System.Windows.Forms.RadioButton radioDiseño;
        private System.Windows.Forms.RadioButton radioFamilia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOt;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem talleresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenesDeTrabajoToolStripMenuItem;
    }
}



