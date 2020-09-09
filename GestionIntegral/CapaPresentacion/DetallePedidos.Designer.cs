namespace GestionIntegral.CapaPresentacion
{
    partial class DetallePedidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetallePedidos));
            this.dvPedido = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblObservacionesTransporte = new System.Windows.Forms.Label();
            this.lblTelTransporte = new System.Windows.Forms.Label();
            this.lblRazonTransporte = new System.Windows.Forms.Label();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.lblPiso = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblDepto = new System.Windows.Forms.Label();
            this.lblCp = new System.Windows.Forms.Label();
            this.lblNro = new System.Windows.Forms.Label();
            this.lblCalleCliente = new System.Windows.Forms.Label();
            this.lblObsCliente = new System.Windows.Forms.Label();
            this.lblFechaAlta = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTel2 = new System.Windows.Forms.Label();
            this.lblTel1 = new System.Windows.Forms.Label();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNumPedido = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dvPedido)).BeginInit();
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dvPedido
            // 
            this.dvPedido.AllowUserToAddRows = false;
            this.dvPedido.AllowUserToDeleteRows = false;
            this.dvPedido.AllowUserToResizeColumns = false;
            this.dvPedido.AllowUserToResizeRows = false;
            this.dvPedido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dvPedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvPedido.BackgroundColor = System.Drawing.Color.White;
            this.dvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvPedido.DefaultCellStyle = dataGridViewCellStyle1;
            this.dvPedido.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dvPedido.Enabled = false;
            this.dvPedido.Location = new System.Drawing.Point(12, 536);
            this.dvPedido.Name = "dvPedido";
            this.dvPedido.RowHeadersVisible = false;
            this.dvPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvPedido.Size = new System.Drawing.Size(760, 242);
            this.dvPedido.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(568, 834);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(113, 30);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblObservacionesTransporte
            // 
            this.lblObservacionesTransporte.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblObservacionesTransporte.AutoSize = true;
            this.lblObservacionesTransporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblObservacionesTransporte.Location = new System.Drawing.Point(168, 441);
            this.lblObservacionesTransporte.Name = "lblObservacionesTransporte";
            this.lblObservacionesTransporte.Size = new System.Drawing.Size(122, 20);
            this.lblObservacionesTransporte.TabIndex = 9;
            this.lblObservacionesTransporte.Text = "Observaciones: ";
            // 
            // lblTelTransporte
            // 
            this.lblTelTransporte.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTelTransporte.AutoSize = true;
            this.lblTelTransporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTelTransporte.Location = new System.Drawing.Point(487, 396);
            this.lblTelTransporte.Name = "lblTelTransporte";
            this.lblTelTransporte.Size = new System.Drawing.Size(79, 20);
            this.lblTelTransporte.TabIndex = 8;
            this.lblTelTransporte.Text = "Telefono: ";
            // 
            // lblRazonTransporte
            // 
            this.lblRazonTransporte.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRazonTransporte.AutoSize = true;
            this.lblRazonTransporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblRazonTransporte.Location = new System.Drawing.Point(132, 396);
            this.lblRazonTransporte.Name = "lblRazonTransporte";
            this.lblRazonTransporte.Size = new System.Drawing.Size(108, 20);
            this.lblRazonTransporte.TabIndex = 7;
            this.lblRazonTransporte.Text = "Razon social: ";
            // 
            // lblProvincia
            // 
            this.lblProvincia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblProvincia.Location = new System.Drawing.Point(407, 328);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(70, 20);
            this.lblProvincia.TabIndex = 6;
            this.lblProvincia.Text = "Cordoba";
            // 
            // lblPiso
            // 
            this.lblPiso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPiso.AutoSize = true;
            this.lblPiso.BackColor = System.Drawing.Color.Transparent;
            this.lblPiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPiso.Location = new System.Drawing.Point(655, 290);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(27, 20);
            this.lblPiso.TabIndex = 5;
            this.lblPiso.Text = "14";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblLocalidad.Location = new System.Drawing.Point(122, 328);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(118, 20);
            this.lblLocalidad.TabIndex = 4;
            this.lblLocalidad.Text = "Villa Carlos Paz";
            // 
            // lblDepto
            // 
            this.lblDepto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDepto.AutoSize = true;
            this.lblDepto.BackColor = System.Drawing.Color.Transparent;
            this.lblDepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDepto.Location = new System.Drawing.Point(550, 290);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(20, 20);
            this.lblDepto.TabIndex = 3;
            this.lblDepto.Text = "A";
            // 
            // lblCp
            // 
            this.lblCp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCp.AutoSize = true;
            this.lblCp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCp.Location = new System.Drawing.Point(654, 328);
            this.lblCp.Name = "lblCp";
            this.lblCp.Size = new System.Drawing.Size(45, 20);
            this.lblCp.TabIndex = 2;
            this.lblCp.Text = "5152";
            // 
            // lblNro
            // 
            this.lblNro.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNro.AutoSize = true;
            this.lblNro.BackColor = System.Drawing.Color.Transparent;
            this.lblNro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNro.Location = new System.Drawing.Point(411, 290);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(36, 20);
            this.lblNro.TabIndex = 1;
            this.lblNro.Text = "648";
            // 
            // lblCalleCliente
            // 
            this.lblCalleCliente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCalleCliente.AutoSize = true;
            this.lblCalleCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblCalleCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCalleCliente.Location = new System.Drawing.Point(86, 290);
            this.lblCalleCliente.Name = "lblCalleCliente";
            this.lblCalleCliente.Size = new System.Drawing.Size(84, 20);
            this.lblCalleCliente.TabIndex = 0;
            this.lblCalleCliente.Text = "Rio salado";
            // 
            // lblObsCliente
            // 
            this.lblObsCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblObsCliente.AutoSize = true;
            this.lblObsCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblObsCliente.Location = new System.Drawing.Point(163, 183);
            this.lblObsCliente.Name = "lblObsCliente";
            this.lblObsCliente.Size = new System.Drawing.Size(122, 20);
            this.lblObsCliente.TabIndex = 6;
            this.lblObsCliente.Text = "Observaciones: ";
            // 
            // lblFechaAlta
            // 
            this.lblFechaAlta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFechaAlta.AutoSize = true;
            this.lblFechaAlta.BackColor = System.Drawing.Color.White;
            this.lblFechaAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblFechaAlta.Location = new System.Drawing.Point(444, 20);
            this.lblFechaAlta.Name = "lblFechaAlta";
            this.lblFechaAlta.Size = new System.Drawing.Size(89, 20);
            this.lblFechaAlta.TabIndex = 5;
            this.lblFechaAlta.Text = "27/08/1980";
            // 
            // lblCuit
            // 
            this.lblCuit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCuit.AutoSize = true;
            this.lblCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCuit.Location = new System.Drawing.Point(460, 139);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(108, 20);
            this.lblCuit.TabIndex = 4;
            this.lblCuit.Text = "20282724686";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblEmail.Location = new System.Drawing.Point(89, 139);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(176, 20);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "rindsberg@hotmail.com";
            // 
            // lblTel2
            // 
            this.lblTel2.AutoSize = true;
            this.lblTel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTel2.Location = new System.Drawing.Point(475, 98);
            this.lblTel2.Name = "lblTel2";
            this.lblTel2.Size = new System.Drawing.Size(135, 20);
            this.lblTel2.TabIndex = 2;
            this.lblTel2.Text = "03541215626772";
            // 
            // lblTel1
            // 
            this.lblTel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTel1.AutoSize = true;
            this.lblTel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTel1.Location = new System.Drawing.Point(107, 96);
            this.lblTel1.Name = "lblTel1";
            this.lblTel1.Size = new System.Drawing.Size(126, 20);
            this.lblTel1.TabIndex = 1;
            this.lblTel1.Text = "0354115626772";
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblRazonSocial.Location = new System.Drawing.Point(141, 59);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(144, 20);
            this.lblRazonSocial.TabIndex = 0;
            this.lblRazonSocial.Text = "German Rindsberg";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(637, 777);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(85, 25);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Total $ ";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(687, 834);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(113, 30);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.dvPedido);
            this.panel.Controls.Add(this.lblTotal);
            this.panel.Controls.Add(this.panel1);
            this.panel.Location = new System.Drawing.Point(12, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(785, 808);
            this.panel.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::GestionIntegral.Properties.Resources.gestionIntegral5;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblNumPedido);
            this.panel1.Controls.Add(this.lblObservacionesTransporte);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblCp);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lblRazonSocial);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.lblTelTransporte);
            this.panel1.Controls.Add(this.lblRazonTransporte);
            this.panel1.Controls.Add(this.lblCuit);
            this.panel1.Controls.Add(this.lblFechaAlta);
            this.panel1.Controls.Add(this.lblCalleCliente);
            this.panel1.Controls.Add(this.lblDepto);
            this.panel1.Controls.Add(this.lblLocalidad);
            this.panel1.Controls.Add(this.lblTel1);
            this.panel1.Controls.Add(this.lblTel2);
            this.panel1.Controls.Add(this.lblNro);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.lblObsCliente);
            this.panel1.Controls.Add(this.lblProvincia);
            this.panel1.Controls.Add(this.lblPiso);
            this.panel1.Location = new System.Drawing.Point(12, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 522);
            this.panel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(521, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 25);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // lblNumPedido
            // 
            this.lblNumPedido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNumPedido.AutoSize = true;
            this.lblNumPedido.BackColor = System.Drawing.Color.White;
            this.lblNumPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNumPedido.Location = new System.Drawing.Point(33, 20);
            this.lblNumPedido.Name = "lblNumPedido";
            this.lblNumPedido.Size = new System.Drawing.Size(87, 20);
            this.lblNumPedido.TabIndex = 11;
            this.lblNumPedido.Text = "Pedido Nº: ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(144, -73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "German Rindsberg";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label16.Location = new System.Drawing.Point(564, -128);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 20);
            this.label16.TabIndex = 5;
            this.label16.Text = "27/08/1980";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(637, 634);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 25);
            this.label18.TabIndex = 10;
            this.label18.Text = "Total $ ";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // DetallePedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(808, 870);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DetallePedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetallePedido";
            this.Load += new System.EventHandler(this.DetallePedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvPedido)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvPedido;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblTel1;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTel2;
        private System.Windows.Forms.Label lblFechaAlta;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblObsCliente;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.Label lblCp;
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.Label lblCalleCliente;
        private System.Windows.Forms.Label lblObservacionesTransporte;
        private System.Windows.Forms.Label lblTelTransporte;
        private System.Windows.Forms.Label lblRazonTransporte;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Panel panel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblNumPedido;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}