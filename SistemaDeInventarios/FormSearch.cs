using ReglasNegocio;
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
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSearch.Text != null)
                {
                    if (cbSearch.Text == "Saldos")
                    {
                        DataTable dt = new DataTable();
                        ClassMovement cMove = new ClassMovement();
                        cMove.VistaSaldo(ref dt);
                        dgvSearch.Columns.Add("Column1", "AlmacenID");
                        dgvSearch.Columns.Add("Column2", "Almacen");
                        dgvSearch.Columns.Add("Column3", "ProductoID");
                        dgvSearch.Columns.Add("Column4", "Producto");
                        dgvSearch.Columns.Add("Column5", "Saldo");
                        dgvSearch.Columns[0].Width = 70;
                        dgvSearch.Columns[1].Width = 90;
                        dgvSearch.Columns[2].Width = 70;
                        dgvSearch.Columns[3].Width = 90;
                        dgvSearch.Columns[4].Width = 60;

                        foreach (DataRow dr in dt.Rows)
                        {
                            dgvSearch.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                        }
                    }
                    else if (cbSearch.Text == "Inventarios Detalles")
                    {
                        DataTable dt = new DataTable();
                        ClassMovement cMove = new ClassMovement();
                        cMove.VistaInvD(ref dt);
                        dgvSearch.Columns.Add("Column1", "Folio");
                        dgvSearch.Columns.Add("Column2", "KeyX");
                        dgvSearch.Columns.Add("Column3", "ProductoID");
                        dgvSearch.Columns.Add("Column4", "Cantidad");
                        dgvSearch.Columns.Add("Column5", "Precio de compra");
                        dgvSearch.Columns.Add("Column6", "AlmacenID");
                        dgvSearch.Columns.Add("Column7", "Tipo de movimiento");
                        dgvSearch.Columns[0].Width = 50;
                        dgvSearch.Columns[1].Width = 50;
                        dgvSearch.Columns[2].Width = 70;
                        dgvSearch.Columns[3].Width = 60;
                        dgvSearch.Columns[4].Width = 60;
                        dgvSearch.Columns[5].Width = 60;
                        dgvSearch.Columns[6].Width = 80;

                        foreach (DataRow dr in dt.Rows)
                        {
                            dgvSearch.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                        }
                    }
                    else if (cbSearch.Text == "Almacenes")
                    {
                        DataTable dt = new DataTable();
                        ClassWarehouse cWare = new ClassWarehouse();
                        cWare.FindWarehouses(ref dt);
                        dgvSearch.Columns.Add("Column1", "AlmacenID");
                        dgvSearch.Columns.Add("Column2", "Descripción");
                        dgvSearch.Columns[0].Width = 100;
                        dgvSearch.Columns[1].Width = 150;

                        foreach (DataRow dr in dt.Rows)
                        {
                            dgvSearch.Rows.Add(dr[0].ToString(), dr[1].ToString());
                        }
                    }
                    else if (cbSearch.Text == "Productos")
                    {
                        DataTable dt = new DataTable();
                        ClassProducts cProd = new ClassProducts();
                        cProd.FindProducts(ref dt);
                        dgvSearch.Columns.Add("Column1", "ProductoID");
                        dgvSearch.Columns.Add("Column2", "Nombre");
                        dgvSearch.Columns.Add("Column3", "Precio de venta");
                        dgvSearch.Columns.Add("Column4", "Precio de compra");
                        dgvSearch.Columns[0].Width = 100;
                        dgvSearch.Columns[1].Width = 150;
                        dgvSearch.Columns[2].Width = 80;
                        dgvSearch.Columns[3].Width = 80;

                        foreach (DataRow dr in dt.Rows)
                        {
                            dgvSearch.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                        }
                    }
                    else if (cbSearch.Text == "Inventarios")
                    {
                        DataTable dt = new DataTable();
                        ClassMovement cMove = new ClassMovement();
                        cMove.VistaInv(ref dt);
                        dgvSearch.Columns.Add("Column1", "Folio");
                        dgvSearch.Columns.Add("Column2", "Fecha");
                        dgvSearch.Columns.Add("Column3", "Tipo de movimiento");
                        dgvSearch.Columns[0].Width = 80;
                        dgvSearch.Columns[1].Width = 150;
                        dgvSearch.Columns[2].Width = 100;

                        foreach (DataRow dr in dt.Rows)
                        {
                            dgvSearch.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                        }
                    }
                    else if (cbSearch.Text == "Ventas")
                    {
                        DataTable dt = new DataTable();
                        ClassMovement cMove = new ClassMovement();
                        cMove.VistaSale(ref dt);
                        dgvSearch.Columns.Add("Column1", "VentaID");
                        dgvSearch.Columns.Add("Column2", "Fecha");
                        dgvSearch.Columns.Add("Column3", "AlmacenID");
                        dgvSearch.Columns.Add("Column4", "Nombre");
                        dgvSearch.Columns.Add("Column5", "Total de venta");
                        dgvSearch.Columns.Add("Column6", "Cantidad de artículos");
                        dgvSearch.Columns[0].Width = 70;
                        dgvSearch.Columns[1].Width = 120;
                        dgvSearch.Columns[2].Width = 70;
                        dgvSearch.Columns[3].Width = 100;
                        dgvSearch.Columns[4].Width = 80;
                        dgvSearch.Columns[5].Width = 80;

                        foreach (DataRow dr in dt.Rows)
                        {
                            dgvSearch.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                        }
                    }
                    else if (cbSearch.Text == "Ventas Detalles")
                    {
                        DataTable dt = new DataTable();
                        ClassMovement cMove = new ClassMovement();
                        cMove.VistaSaleD(ref dt);
                        dgvSearch.Columns.Add("Column1", "VentaID");
                        dgvSearch.Columns.Add("Column2", "KeyX");
                        dgvSearch.Columns.Add("Column3", "ProductoID");
                        dgvSearch.Columns.Add("Column4", "Nombre");
                        dgvSearch.Columns.Add("Column5", "Cantidad");
                        dgvSearch.Columns.Add("Column6", "Precio de venta");
                        dgvSearch.Columns.Add("Column7", "AlmacenID");
                        dgvSearch.Columns.Add("Column8", "Nombre");
                        dgvSearch.Columns[0].Width = 70;
                        dgvSearch.Columns[1].Width = 60;
                        dgvSearch.Columns[2].Width = 70;
                        dgvSearch.Columns[3].Width = 100;
                        dgvSearch.Columns[4].Width = 70;
                        dgvSearch.Columns[5].Width = 70;
                        dgvSearch.Columns[6].Width = 70;
                        dgvSearch.Columns[7].Width = 100;

                        foreach (DataRow dr in dt.Rows)
                        {
                            dgvSearch.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione una tabla para consultar");
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            cbSearch.Text = string.Empty;
            dgvSearch.Rows.Clear();
            dgvSearch.Columns.Clear();
        }

        private void cbSearch_Enter(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
