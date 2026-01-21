namespace SistemaDeInventarios
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlMinimize = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flpnlMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnProducts = new System.Windows.Forms.Button();
            this.flpnlWare = new System.Windows.Forms.FlowLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnWarehouses = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSalida = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSale = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tSidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.tWare = new System.Windows.Forms.Timer(this.components);
            this.pbProducts = new System.Windows.Forms.PictureBox();
            this.pbWareMenu = new System.Windows.Forms.PictureBox();
            this.pbWarehouse = new System.Windows.Forms.PictureBox();
            this.pbBuy = new System.Windows.Forms.PictureBox();
            this.pbSalida = new System.Windows.Forms.PictureBox();
            this.pbSale = new System.Windows.Forms.PictureBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.pbMinimize = new System.Windows.Forms.PictureBox();
            this.pbMenu = new System.Windows.Forms.PictureBox();
            this.pbMaximize = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.pnlMinimize.SuspendLayout();
            this.flpnlMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flpnlWare.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWareMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pbClose);
            this.panel1.Controls.Add(this.pnlMinimize);
            this.panel1.Controls.Add(this.pbMenu);
            this.panel1.Controls.Add(this.pbMaximize);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 41);
            this.panel1.TabIndex = 0;
            // 
            // pnlMinimize
            // 
            this.pnlMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMinimize.BackColor = System.Drawing.Color.White;
            this.pnlMinimize.Controls.Add(this.pbMinimize);
            this.pnlMinimize.Location = new System.Drawing.Point(832, 6);
            this.pnlMinimize.Name = "pnlMinimize";
            this.pnlMinimize.Size = new System.Drawing.Size(30, 30);
            this.pnlMinimize.TabIndex = 4;
            this.pnlMinimize.Click += new System.EventHandler(this.pnlMinimize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(15)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(40, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "SISTEMA DE INVENTARIOS";
            // 
            // flpnlMenu
            // 
            this.flpnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(56)))));
            this.flpnlMenu.Controls.Add(this.panel2);
            this.flpnlMenu.Controls.Add(this.flpnlWare);
            this.flpnlMenu.Controls.Add(this.panel6);
            this.flpnlMenu.Controls.Add(this.panel3);
            this.flpnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpnlMenu.Location = new System.Drawing.Point(0, 41);
            this.flpnlMenu.Name = "flpnlMenu";
            this.flpnlMenu.Size = new System.Drawing.Size(247, 668);
            this.flpnlMenu.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.pbProducts);
            this.panel2.Controls.Add(this.btnProducts);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 52);
            this.panel2.TabIndex = 2;
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(56)))));
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Location = new System.Drawing.Point(0, 0);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(240, 52);
            this.btnProducts.TabIndex = 3;
            this.btnProducts.Text = "Productos";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // flpnlWare
            // 
            this.flpnlWare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(20)))), ((int)(((byte)(92)))));
            this.flpnlWare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flpnlWare.Controls.Add(this.panel7);
            this.flpnlWare.Controls.Add(this.panel4);
            this.flpnlWare.Controls.Add(this.panel5);
            this.flpnlWare.Location = new System.Drawing.Point(0, 58);
            this.flpnlWare.Margin = new System.Windows.Forms.Padding(0);
            this.flpnlWare.Name = "flpnlWare";
            this.flpnlWare.Size = new System.Drawing.Size(247, 53);
            this.flpnlWare.TabIndex = 10;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pbWareMenu);
            this.panel7.Controls.Add(this.pbWarehouse);
            this.panel7.Controls.Add(this.btnWarehouses);
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(241, 50);
            this.panel7.TabIndex = 9;
            // 
            // btnWarehouses
            // 
            this.btnWarehouses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(56)))));
            this.btnWarehouses.FlatAppearance.BorderSize = 0;
            this.btnWarehouses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarehouses.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWarehouses.ForeColor = System.Drawing.Color.White;
            this.btnWarehouses.Location = new System.Drawing.Point(0, 0);
            this.btnWarehouses.Name = "btnWarehouses";
            this.btnWarehouses.Size = new System.Drawing.Size(241, 50);
            this.btnWarehouses.TabIndex = 3;
            this.btnWarehouses.Text = "Almacenes";
            this.btnWarehouses.UseVisualStyleBackColor = false;
            this.btnWarehouses.Click += new System.EventHandler(this.btnWarehouses_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pbBuy);
            this.panel4.Controls.Add(this.btnEnter);
            this.panel4.Location = new System.Drawing.Point(3, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 50);
            this.panel4.TabIndex = 5;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(20)))), ((int)(((byte)(92)))));
            this.btnEnter.FlatAppearance.BorderSize = 0;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.ForeColor = System.Drawing.Color.White;
            this.btnEnter.Location = new System.Drawing.Point(0, 0);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(241, 50);
            this.btnEnter.TabIndex = 3;
            this.btnEnter.Text = "Entradas";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pbSalida);
            this.panel5.Controls.Add(this.btnSalida);
            this.panel5.Location = new System.Drawing.Point(3, 115);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(241, 50);
            this.panel5.TabIndex = 7;
            // 
            // btnSalida
            // 
            this.btnSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(20)))), ((int)(((byte)(92)))));
            this.btnSalida.FlatAppearance.BorderSize = 0;
            this.btnSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalida.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalida.ForeColor = System.Drawing.Color.White;
            this.btnSalida.Location = new System.Drawing.Point(0, 0);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(241, 50);
            this.btnSalida.TabIndex = 3;
            this.btnSalida.Text = "Salidas";
            this.btnSalida.UseVisualStyleBackColor = false;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.pbSale);
            this.panel6.Controls.Add(this.btnSale);
            this.panel6.Location = new System.Drawing.Point(3, 114);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(241, 50);
            this.panel6.TabIndex = 9;
            // 
            // btnSale
            // 
            this.btnSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(56)))));
            this.btnSale.FlatAppearance.BorderSize = 0;
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.ForeColor = System.Drawing.Color.White;
            this.btnSale.Location = new System.Drawing.Point(0, 0);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(241, 50);
            this.btnSale.TabIndex = 3;
            this.btnSale.Text = "Ventas";
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pbSearch);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Location = new System.Drawing.Point(3, 170);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 50);
            this.panel3.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(56)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(241, 50);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Consultar";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tSidebarTransition
            // 
            this.tSidebarTransition.Interval = 10;
            this.tSidebarTransition.Tick += new System.EventHandler(this.tSidebarTransition_Tick);
            // 
            // tWare
            // 
            this.tWare.Interval = 10;
            this.tWare.Tick += new System.EventHandler(this.tWare_Tick);
            // 
            // pbProducts
            // 
            this.pbProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(56)))));
            this.pbProducts.Image = global::SistemaDeInventarios.Properties.Resources.product;
            this.pbProducts.Location = new System.Drawing.Point(6, 10);
            this.pbProducts.Name = "pbProducts";
            this.pbProducts.Size = new System.Drawing.Size(32, 32);
            this.pbProducts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProducts.TabIndex = 4;
            this.pbProducts.TabStop = false;
            this.pbProducts.Click += new System.EventHandler(this.pbProducts_Click);
            // 
            // pbWareMenu
            // 
            this.pbWareMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(56)))));
            this.pbWareMenu.Image = global::SistemaDeInventarios.Properties.Resources.arrow_down;
            this.pbWareMenu.Location = new System.Drawing.Point(206, 10);
            this.pbWareMenu.Name = "pbWareMenu";
            this.pbWareMenu.Size = new System.Drawing.Size(32, 32);
            this.pbWareMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWareMenu.TabIndex = 11;
            this.pbWareMenu.TabStop = false;
            this.pbWareMenu.Click += new System.EventHandler(this.pbWareMenu_Click);
            // 
            // pbWarehouse
            // 
            this.pbWarehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(12)))), ((int)(((byte)(56)))));
            this.pbWarehouse.Image = global::SistemaDeInventarios.Properties.Resources.warehouse;
            this.pbWarehouse.Location = new System.Drawing.Point(6, 10);
            this.pbWarehouse.Name = "pbWarehouse";
            this.pbWarehouse.Size = new System.Drawing.Size(32, 32);
            this.pbWarehouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWarehouse.TabIndex = 3;
            this.pbWarehouse.TabStop = false;
            this.pbWarehouse.Click += new System.EventHandler(this.pbWarehouse_Click);
            // 
            // pbBuy
            // 
            this.pbBuy.Image = global::SistemaDeInventarios.Properties.Resources.more;
            this.pbBuy.Location = new System.Drawing.Point(6, 11);
            this.pbBuy.Name = "pbBuy";
            this.pbBuy.Size = new System.Drawing.Size(30, 30);
            this.pbBuy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBuy.TabIndex = 4;
            this.pbBuy.TabStop = false;
            this.pbBuy.Click += new System.EventHandler(this.pbBuy_Click);
            // 
            // pbSalida
            // 
            this.pbSalida.Image = global::SistemaDeInventarios.Properties.Resources.minus;
            this.pbSalida.Location = new System.Drawing.Point(6, 13);
            this.pbSalida.Name = "pbSalida";
            this.pbSalida.Size = new System.Drawing.Size(30, 30);
            this.pbSalida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSalida.TabIndex = 2;
            this.pbSalida.TabStop = false;
            this.pbSalida.Click += new System.EventHandler(this.pbSalida_Click);
            // 
            // pbSale
            // 
            this.pbSale.Image = global::SistemaDeInventarios.Properties.Resources.cart;
            this.pbSale.Location = new System.Drawing.Point(6, 10);
            this.pbSale.Name = "pbSale";
            this.pbSale.Size = new System.Drawing.Size(32, 32);
            this.pbSale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSale.TabIndex = 2;
            this.pbSale.TabStop = false;
            this.pbSale.Click += new System.EventHandler(this.pbSale_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.Image = global::SistemaDeInventarios.Properties.Resources.search;
            this.pbSearch.Location = new System.Drawing.Point(6, 10);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(32, 32);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 2;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.Image = global::SistemaDeInventarios.Properties.Resources.close;
            this.pbClose.Location = new System.Drawing.Point(931, 8);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(26, 26);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClose.TabIndex = 3;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // pbMinimize
            // 
            this.pbMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMinimize.Image = global::SistemaDeInventarios.Properties.Resources.window_minimize;
            this.pbMinimize.Location = new System.Drawing.Point(0, 0);
            this.pbMinimize.Name = "pbMinimize";
            this.pbMinimize.Size = new System.Drawing.Size(30, 18);
            this.pbMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMinimize.TabIndex = 1;
            this.pbMinimize.TabStop = false;
            this.pbMinimize.Click += new System.EventHandler(this.pbMinimize_Click);
            // 
            // pbMenu
            // 
            this.pbMenu.Image = global::SistemaDeInventarios.Properties.Resources.menu;
            this.pbMenu.Location = new System.Drawing.Point(8, 6);
            this.pbMenu.Name = "pbMenu";
            this.pbMenu.Size = new System.Drawing.Size(30, 30);
            this.pbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMenu.TabIndex = 1;
            this.pbMenu.TabStop = false;
            this.pbMenu.Click += new System.EventHandler(this.pbMenu_Click);
            // 
            // pbMaximize
            // 
            this.pbMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMaximize.Image = global::SistemaDeInventarios.Properties.Resources.maximize;
            this.pbMaximize.Location = new System.Drawing.Point(883, 6);
            this.pbMaximize.Name = "pbMaximize";
            this.pbMaximize.Size = new System.Drawing.Size(30, 30);
            this.pbMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMaximize.TabIndex = 2;
            this.pbMaximize.TabStop = false;
            this.pbMaximize.Click += new System.EventHandler(this.pbMaximize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(964, 709);
            this.Controls.Add(this.flpnlMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlMinimize.ResumeLayout(false);
            this.flpnlMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flpnlWare.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWareMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaximize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbMenu;
        private System.Windows.Forms.PictureBox pbMinimize;
        private System.Windows.Forms.PictureBox pbMaximize;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Panel pnlMinimize;
        private System.Windows.Forms.FlowLayoutPanel flpnlMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnWarehouses;
        private System.Windows.Forms.Timer tSidebarTransition;
        private System.Windows.Forms.PictureBox pbSalida;
        private System.Windows.Forms.PictureBox pbProducts;
        private System.Windows.Forms.PictureBox pbWarehouse;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pbBuy;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel flpnlWare;
        private System.Windows.Forms.Timer tWare;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pbSale;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.PictureBox pbWareMenu;
    }
}

