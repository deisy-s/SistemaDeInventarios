using DevExpress.Data.Helpers;
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
    public partial class FormSales : Form
    {
        double dTotal = 0;
        string wareID = string.Empty;

        public FormSales()
        {
            InitializeComponent();
        }

        private void FormSales_Load(object sender, EventArgs e)
        {
            tbAmount.Text = "0.0";
            tbAmount.SelectionStart = tbAmount.Text.Length;

            dgvSale.Columns[0].Width = 60;
            dgvSale.Columns[1].Width = 120;
            dgvSale.Columns[2].Width = 60;
            dgvSale.Columns[3].Width = 60;
            dgvSale.Columns[4].Width = 60;
            dgvSale.Columns[5].Width = 120;

            tbDate.Text = DateTime.Today.ToString();

            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            ClassWarehouse cWare = new ClassWarehouse();

            try
            {
                cWare.FindWarehouses(ref dt2);
                foreach (DataRow row in dt2.Rows)
                {
                    cbWarehouse.Items.Add(row[1].ToString());
                }

                FindFolio();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void FindFolio()
        {
            DataTable dt1 = new DataTable();
            ClassMovement cMove = new ClassMovement();

            cMove.VistaSale(ref dt1);
            foreach (DataRow row in dt1.Rows)
            {
                string s = row[0].ToString();
                Int32 i = Int32.Parse(s) + 1;
                tbFolio.Text = i.ToString();
            }

        }

        private void cbWarehouse_Enter(object sender, EventArgs e)
        {
            if (cbWarehouse.Text == "Nombre")
            {
                cbWarehouse.Text = string.Empty;
            }
        }

        private void tbProductID_Enter(object sender, EventArgs e)
        {
            if (tbProductID.Text == "ID")
            {
                tbProductID.Text = string.Empty;
            }
        }

        private void tbAmount_Enter(object sender, EventArgs e)
        {
            if (tbAmount.Text == "0.0")
            {
                tbAmount.Text = string.Empty;
            }
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un número ni la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != 46 && e.KeyChar != 13 && e.KeyChar != 11)
            {
                // Si no es un número ni la tecla de retroceso, cancela el evento de pulsación de tecla
                e.Handled = true;
            }

            // Verifica si ya hay un punto en el texto y si el caracter es un punto
            if (tbAmount.Text != null && e.KeyChar == 46 && tbAmount.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void tbProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Verifica si la tecla presionada no es un número ni la tecla de retroceso(backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != 13 && e.KeyChar != 11)
            {
                // Si no es un número ni la tecla de retroceso, cancela el evento de pulsación de tecla
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }

            if (!string.IsNullOrEmpty(tbProductID.Text) && tbProductID.Text.Length > 9 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void Clear()
        {
            tbProductID.Text = "ID";
            tbProduct.Text = "Nombre";
            tbAmount.Text = "0.0";
            FindFolio();
        }

        private void ClearAll()
        {
            tbProductID.Text = "ID";
            tbProduct.Text = "Nombre";
            cbWarehouse.Text = "Nombre";
            tbAmount.Text = "0.0";
            tbSalePrice.Text = "0.00";
            tbTotal.Text = "$0.00";
            dgvSale.Rows.Clear();
            FindFolio();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbProductID.Text != "ID" && tbProduct.Text != "Nombre" && tbAmount.Text != "0.0" && cbWarehouse.Text != "Nombre")
                {
                    DataTable dt = new DataTable();
                    ClassWarehouse cWare = new ClassWarehouse();
                    cWare.FindID(cbWarehouse.Text, ref dt);

                    DataTable dt2 = new DataTable();
                    ClassProducts cProd = new ClassProducts();
                    cProd.FindProducts(tbProductID.Text, ref dt2);

                    ClassMovement cMove = new ClassMovement();
                    double saldo = cMove.CheckSaldo(tbProductID.Text, dt.Rows[0][0].ToString());

                    if (saldo > double.Parse(tbAmount.Text))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            double price = Convert.ToDouble(dt2.Rows[0][2]);
                            double amount = Convert.ToDouble(tbAmount.Text);

                            if (dgvSale.Rows.Count == 1)
                            {
                                wareID = dt.Rows[0][1].ToString();
                            }

                            if (wareID == dt.Rows[0][1].ToString())
                            {
                                dgvSale.Rows.Add(tbProductID.Text, tbProduct.Text, tbAmount.Text, dt2.Rows[0][2].ToString(), (price * amount), dt.Rows[0][1].ToString());
                                Clear();
                                UpdateTotal(price, amount);
                            }
                            else
                            {
                                Clear();

                                DataTable dt3 = new DataTable();
                                cWare.FindID(wareID, ref dt3);
                                if (dt3.Rows.Count > 0)
                                {
                                    cbWarehouse.Text = dt3.Rows[0][1].ToString();
                                }

                                MessageBox.Show("El almacen seleccionado no es el mismo que el resto de la venta");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido encontrar el almacen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se cuenta con suficiente producto en el almacen");
                        Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese todos los campos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        public void UpdateTotal(double price, double amount)
        {
            try
            {
                dTotal += (price * amount);
                tbTotal.Text = "$" + dTotal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void tbProductID_Leave(object sender, EventArgs e)
        {
            productos prod = new productos();
            ClassProducts cProd = new ClassProducts();

            try
            {
                if(tbProductID.Text == "")
                {
                    tbProductID.Text = "ID";
                } else
                {
                    if (cProd.ReadProduct(tbProductID.Text, ref prod))
                    {
                        if (prod.sProductName != null)
                        {
                            tbProduct.Text = prod.sProductName.ToString();
                            tbSalePrice.Text = prod.dSalePrice.ToString();
                            CheckExists();
                        }
                        else
                        {
                            MessageBox.Show("Ese producto no existe");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void CheckExists()
        {
            try
            {
                string sWareID = "";
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();

                ClassWarehouse cWare = new ClassWarehouse();
                cWare.FindID(cbWarehouse.Text, ref dt);
                ClassProducts cProd = new ClassProducts();

                if (dt.Rows.Count > 0)
                {
                    sWareID = dt.Rows[0][0].ToString();
                }

                cProd.FindProdDisp(sWareID, ref dt2);

                if(dt2.Rows.Count == 0)
                {
                    MessageBox.Show("El almacen no cuenta con ese producto");
                    tbProductID.Text = "ID";
                    tbProduct.Text = "Nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvSale.Rows.Count > 1)
                {
                    ClassMovement cMove = new ClassMovement();
                    List<string> lProdID = new List<string>();
                    List<double> lPrice = new List<double>();
                    List<double> lAmount = new List<double>();

                    string total = tbTotal.Text.Substring(1);
                    int quantity = dgvSale.Rows.Count - 1;
                    foreach (DataGridViewRow row in dgvSale.Rows)
                    {
                        // No guardar los datos de la línea en blanco del datagridview
                        if (row.IsNewRow) continue;

                        string prodID = row.Cells[0].Value?.ToString();
                        string price = row.Cells[3].Value?.ToString();
                        string amount = row.Cells[2].Value?.ToString();

                        lProdID.Add(prodID);
                        lPrice.Add(double.Parse(price));
                        lAmount.Add(double.Parse(amount));
                    }

                    DataTable dt = new DataTable();
                    ClassWarehouse cWare = new ClassWarehouse();
                    cWare.FindID(wareID, ref dt);
                    if (dt.Rows.Count > 0)
                    {
                        wareID = dt.Rows[0][0].ToString();
                    }

                    if (cMove.Sale(DateTime.Now, wareID, double.Parse(total), quantity, lProdID, lAmount, lPrice))
                    {
                        MessageBox.Show("Venta registrada");
                        ClearAll();
                    } else
                        MessageBox.Show($"Ocurrió un error: {cMove.sError}");
                }
                else
                    MessageBox.Show("Por favor agregue un producto a la lista");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void tbAmount_Leave(object sender, EventArgs e)
        {
            if(tbAmount.Text == "")
            {
                tbAmount.Text = "0.0";
            }
        }
    }
}
