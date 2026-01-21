using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeInventarios
{
    public partial class Form1 : Form
    {
        bool bSidebarExpand = true, bWare = false;
        FormProduct product;
        FormExit sales;
        FormAddWarehouse addWarehouse;
        FormBuy buy;
        FormSearch search;
        FormSales venta;

        public Form1()
        {
            InitializeComponent();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMaximize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pnlMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if (product == null)
            {
                product = new FormProduct();
                product.FormClosed += product_FormClosed;
                product.MdiParent = this;
                product.Dock = DockStyle.Fill;
                product.Show();
            }
            else
            {
                product.Activate();
            }
        }

        private void product_FormClosed(object sender, FormClosedEventArgs e)
        {
            product = null;
        }

        private void pbMenu_Click(object sender, EventArgs e)
        {
            tSidebarTransition.Start();
        }

        private void sales_FormClosed(object sender, FormClosedEventArgs e)
        {
            sales = null;
        }

        private void btnWarehouses_Click(object sender, EventArgs e)
        {
            if (addWarehouse == null)
            {
                addWarehouse = new FormAddWarehouse();
                addWarehouse.FormClosed += addWarehouse_FormClosed;
                addWarehouse.MdiParent = this;
                addWarehouse.Dock = DockStyle.Fill;
                addWarehouse.Show();
            }
            else
            {
                addWarehouse.Activate();
            }
        }

        private void addWarehouse_FormClosed(object sender, FormClosedEventArgs e)
        {
            addWarehouse = null;
        }

        private void pbProducts_Click(object sender, EventArgs e)
        {
            btnProducts_Click(sender, e);
        }

        private void pbWarehouse_Click(object sender, EventArgs e)
        {
            btnWarehouses_Click(sender, e);
        }

        private void tSidebarTransition_Tick(object sender, EventArgs e)
        {
            if (!bSidebarExpand)
            {
                if(flpnlMenu.Width >= 156)
                {
                    tSidebarTransition.Stop();
                    bSidebarExpand = true;
                }else 
                    flpnlMenu.Width += 10;
            }
            else
            {
                flpnlMenu.Width -= 10;
                if (flpnlMenu.Width <= 35)
                {
                    tSidebarTransition.Stop();
                    bSidebarExpand = false;
                }
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (buy == null)
            {
                buy = new FormBuy();
                buy.FormClosed += buy_FormClosed;
                buy.MdiParent = this;
                buy.Dock = DockStyle.Fill;
                buy.Show();
            }
            else
            {
                buy.Activate();
            }
        }

        private void buy_FormClosed(object sender, FormClosedEventArgs e)
        {
            buy = null;
        }

        private void pbBuy_Click(object sender, EventArgs e)
        {
            btnBuy_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (search == null)
            {
                search = new FormSearch();
                search.FormClosed += search_FormClosed;
                search.MdiParent = this;
                search.Dock = DockStyle.Fill;
                search.Show();
            }
            else
            {
                search.Activate();
            }
        }

        private void search_FormClosed(object sender, FormClosedEventArgs e)
        {
            search = null;
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            if (sales == null)
            {
                sales = new FormExit();
                sales.FormClosed += sales_FormClosed;
                sales.MdiParent = this;
                sales.Dock = DockStyle.Fill;
                sales.Show();
            }
            else
            {
                sales.Activate();
            }
        }

        private void pbSalida_Click(object sender, EventArgs e)
        {
            btnSalida_Click(sender, e);
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            if (venta == null)
            {
                venta = new FormSales();
                venta.FormClosed += ventas_FormClosed;
                venta.MdiParent = this;
                venta.Dock = DockStyle.Fill;
                venta.Show();
            }
            else
            {
                venta.Activate();
            }
        }

        private void ventas_FormClosed(object sender, FormClosedEventArgs e)
        {
            venta = null;
        }

        private void pbSale_Click(object sender, EventArgs e)
        {
            btnSale_Click(sender, e);
        }

        private void pbWareMenu_Click(object sender, EventArgs e)
        {
            tWare.Start();
        }

        private void tWare_Tick(object sender, EventArgs e)
        {
            if (!bWare)
            {
                flpnlWare.Height += 10;
                if (flpnlWare.Height >= 105)
                {
                    tWare.Stop();
                    bWare = true;
                    pbWareMenu.Image = Properties.Resources.arrow_up;
                }
            }
            else
            {
                flpnlWare.Height -= 10;
                if (flpnlWare.Height <= 40)
                {
                    tWare.Stop();
                    bWare = false;
                    pbWareMenu.Image = Properties.Resources.arrow_down;
                }
            }
        }
    }
}
