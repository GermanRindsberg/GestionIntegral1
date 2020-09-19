﻿namespace GestionIntegral.CapaPresentacion
{
    partial class OrdenDeTrabajo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtFechaEnvio = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNuevosTaller = new System.Windows.Forms.Button();
            this.cbTaller = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMenosCantidad = new System.Windows.Forms.Button();
            this.btnMasCantidad = new System.Windows.Forms.Button();
            this.btnQuitarProducto = new System.Windows.Forms.Button();
            this.btnAgregarProductoNuevo = new System.Windows.Forms.Button();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.btnSumarProducto = new System.Windows.Forms.Button();
            this.gridOT = new System.Windows.Forms.DataGridView();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFechaRetiroEstimada = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.dtFechaRetirado = new System.Windows.Forms.DateTimePicker();
            this.checkRetirado = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridOT)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtFechaEnvio
            // 
            this.dtFechaEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtFechaEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEnvio.Location = new System.Drawing.Point(196, 12);
            this.dtFechaEnvio.Name = "dtFechaEnvio";
            this.dtFechaEnvio.Size = new System.Drawing.Size(161, 26);
            this.dtFechaEnvio.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 16);
            this.label7.TabIndex = 80;
            this.label7.Text = "Fecha de envio a taller";
            // 
            // btnNuevosTaller
            // 
            this.btnNuevosTaller.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevosTaller.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNuevosTaller.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.btnNuevosTaller.ForeColor = System.Drawing.Color.Black;
            this.btnNuevosTaller.Location = new System.Drawing.Point(324, 95);
            this.btnNuevosTaller.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnNuevosTaller.Name = "btnNuevosTaller";
            this.btnNuevosTaller.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNuevosTaller.Size = new System.Drawing.Size(33, 27);
            this.btnNuevosTaller.TabIndex = 84;
            this.btnNuevosTaller.Text = "+";
            this.btnNuevosTaller.UseVisualStyleBackColor = true;
            this.btnNuevosTaller.Click += new System.EventHandler(this.btnNuevosTaller_Click);
            // 
            // cbTaller
            // 
            this.cbTaller.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbTaller.FormattingEnabled = true;
            this.cbTaller.Location = new System.Drawing.Point(9, 98);
            this.cbTaller.Name = "cbTaller";
            this.cbTaller.Size = new System.Drawing.Size(310, 24);
            this.cbTaller.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 82;
            this.label1.Text = "Taller";
            // 
            // btnMenosCantidad
            // 
            this.btnMenosCantidad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMenosCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.btnMenosCantidad.ForeColor = System.Drawing.Color.Lime;
            this.btnMenosCantidad.Location = new System.Drawing.Point(100, 207);
            this.btnMenosCantidad.Name = "btnMenosCantidad";
            this.btnMenosCantidad.Size = new System.Drawing.Size(36, 20);
            this.btnMenosCantidad.TabIndex = 96;
            this.btnMenosCantidad.Text = "-";
            this.btnMenosCantidad.UseVisualStyleBackColor = true;
            this.btnMenosCantidad.Click += new System.EventHandler(this.btnMenosCantidad_Click);
            // 
            // btnMasCantidad
            // 
            this.btnMasCantidad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMasCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.btnMasCantidad.ForeColor = System.Drawing.Color.Lime;
            this.btnMasCantidad.Location = new System.Drawing.Point(100, 184);
            this.btnMasCantidad.Name = "btnMasCantidad";
            this.btnMasCantidad.Size = new System.Drawing.Size(36, 20);
            this.btnMasCantidad.TabIndex = 95;
            this.btnMasCantidad.Text = "+";
            this.btnMasCantidad.UseVisualStyleBackColor = true;
            this.btnMasCantidad.Click += new System.EventHandler(this.btnMasCantidad_Click);
            // 
            // btnQuitarProducto
            // 
            this.btnQuitarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuitarProducto.ForeColor = System.Drawing.Color.Black;
            this.btnQuitarProducto.Location = new System.Drawing.Point(266, 199);
            this.btnQuitarProducto.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnQuitarProducto.Name = "btnQuitarProducto";
            this.btnQuitarProducto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnQuitarProducto.Size = new System.Drawing.Size(91, 30);
            this.btnQuitarProducto.TabIndex = 94;
            this.btnQuitarProducto.Text = "Borrar";
            this.btnQuitarProducto.UseVisualStyleBackColor = true;
            // 
            // btnAgregarProductoNuevo
            // 
            this.btnAgregarProductoNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarProductoNuevo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAgregarProductoNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.btnAgregarProductoNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarProductoNuevo.Location = new System.Drawing.Point(324, 139);
            this.btnAgregarProductoNuevo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnAgregarProductoNuevo.Name = "btnAgregarProductoNuevo";
            this.btnAgregarProductoNuevo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAgregarProductoNuevo.Size = new System.Drawing.Size(33, 27);
            this.btnAgregarProductoNuevo.TabIndex = 93;
            this.btnAgregarProductoNuevo.Text = "+";
            this.btnAgregarProductoNuevo.UseVisualStyleBackColor = true;
            this.btnAgregarProductoNuevo.Click += new System.EventHandler(this.btnAgregarProductoNuevo_Click);
            // 
            // cbProducto
            // 
            this.cbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbProducto.FormattingEnabled = true;
            this.cbProducto.Location = new System.Drawing.Point(10, 140);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(308, 24);
            this.cbProducto.TabIndex = 90;
            // 
            // btnSumarProducto
            // 
            this.btnSumarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSumarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSumarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSumarProducto.ForeColor = System.Drawing.Color.Black;
            this.btnSumarProducto.Location = new System.Drawing.Point(169, 199);
            this.btnSumarProducto.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnSumarProducto.Name = "btnSumarProducto";
            this.btnSumarProducto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSumarProducto.Size = new System.Drawing.Size(91, 30);
            this.btnSumarProducto.TabIndex = 89;
            this.btnSumarProducto.Text = "Agregar ";
            this.btnSumarProducto.UseVisualStyleBackColor = true;
            this.btnSumarProducto.Click += new System.EventHandler(this.btnSumarProducto_Click);
            // 
            // gridOT
            // 
            this.gridOT.AllowUserToAddRows = false;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.gridOT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridOT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridOT.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridOT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridOT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOT.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridOT.Location = new System.Drawing.Point(9, 233);
            this.gridOT.Name = "gridOT";
            this.gridOT.RowHeadersVisible = false;
            this.gridOT.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridOT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOT.ShowCellErrors = false;
            this.gridOT.ShowCellToolTips = false;
            this.gridOT.ShowEditingIcon = false;
            this.gridOT.ShowRowErrors = false;
            this.gridOT.Size = new System.Drawing.Size(348, 259);
            this.gridOT.TabIndex = 88;
            // 
            // txtCant
            // 
            this.txtCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txtCant.Location = new System.Drawing.Point(9, 184);
            this.txtCant.Multiline = true;
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(85, 43);
            this.txtCant.TabIndex = 86;
            this.txtCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(9, 167);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 15);
            this.label19.TabIndex = 87;
            this.label19.Text = "Cantidad";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(12, 123);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 15);
            this.label17.TabIndex = 85;
            this.label17.Text = "Producto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 16);
            this.label2.TabIndex = 98;
            this.label2.Text = "Fecha de retiro estimada";
            // 
            // dtFechaRetiroEstimada
            // 
            this.dtFechaRetiroEstimada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtFechaRetiroEstimada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaRetiroEstimada.Location = new System.Drawing.Point(196, 44);
            this.dtFechaRetiroEstimada.Name = "dtFechaRetiroEstimada";
            this.dtFechaRetiroEstimada.Size = new System.Drawing.Size(161, 26);
            this.dtFechaRetiroEstimada.TabIndex = 97;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(131, 562);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancelar.Size = new System.Drawing.Size(91, 30);
            this.btnCancelar.TabIndex = 100;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInsertar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnInsertar.ForeColor = System.Drawing.Color.Black;
            this.btnInsertar.Location = new System.Drawing.Point(9, 553);
            this.btnInsertar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnInsertar.Size = new System.Drawing.Size(120, 39);
            this.btnInsertar.TabIndex = 99;
            this.btnInsertar.Text = "Insertar/editar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // dtFechaRetirado
            // 
            this.dtFechaRetirado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtFechaRetirado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaRetirado.Location = new System.Drawing.Point(214, 15);
            this.dtFechaRetirado.Name = "dtFechaRetirado";
            this.dtFechaRetirado.Size = new System.Drawing.Size(129, 26);
            this.dtFechaRetirado.TabIndex = 102;
            // 
            // checkRetirado
            // 
            this.checkRetirado.AutoSize = true;
            this.checkRetirado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRetirado.Location = new System.Drawing.Point(3, 16);
            this.checkRetirado.Name = "checkRetirado";
            this.checkRetirado.Size = new System.Drawing.Size(97, 24);
            this.checkRetirado.TabIndex = 101;
            this.checkRetirado.Text = "Retirado";
            this.checkRetirado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 103;
            this.label3.Text = "Fecha de retiro";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtFechaRetirado);
            this.groupBox1.Controls.Add(this.checkRetirado);
            this.groupBox1.Location = new System.Drawing.Point(9, 498);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 52);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            // 
            // OrdenDeTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(367, 602);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFechaRetiroEstimada);
            this.Controls.Add(this.btnMenosCantidad);
            this.Controls.Add(this.btnMasCantidad);
            this.Controls.Add(this.btnQuitarProducto);
            this.Controls.Add(this.btnAgregarProductoNuevo);
            this.Controls.Add(this.cbProducto);
            this.Controls.Add(this.btnSumarProducto);
            this.Controls.Add(this.gridOT);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnNuevosTaller);
            this.Controls.Add(this.cbTaller);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtFechaEnvio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OrdenDeTrabajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrdenDeTrabajo";
            this.Load += new System.EventHandler(this.OrdenDeTrabajo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridOT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFechaEnvio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNuevosTaller;
        private System.Windows.Forms.ComboBox cbTaller;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMenosCantidad;
        private System.Windows.Forms.Button btnMasCantidad;
        private System.Windows.Forms.Button btnQuitarProducto;
        private System.Windows.Forms.Button btnAgregarProductoNuevo;
        private System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Button btnSumarProducto;
        private System.Windows.Forms.DataGridView gridOT;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFechaRetiroEstimada;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.DateTimePicker dtFechaRetirado;
        private System.Windows.Forms.CheckBox checkRetirado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}