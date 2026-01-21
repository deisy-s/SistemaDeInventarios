using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
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
using System.Xml.Linq;

namespace SistemaDeInventarios
{
    public partial class FormExit : Form
    {
        double dTotal = 0;
        public FormExit()
        {
            InitializeComponent();
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
                            cbWarehouse.Text = "Nombre";
                            VerifySaldo();
                        } else
                        {
                            MessageBox.Show("No existe ese producto");
                        }
                    }

                    cbWarehouse.Items.Clear();
                    DataTable dt2 = new DataTable();
                    ClassWarehouse cWare = new ClassWarehouse();

                    cWare.FindWarehouses(tbProductID.Text, ref dt2);
                    foreach (DataRow row in dt2.Rows)
                    {
                        cbWarehouse.Items.Add(row[1].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FindFolio()
        {
            DataTable dt1 = new DataTable();
            ClassMovement cMove = new ClassMovement();

            cMove.VistaInv(ref dt1);
            foreach (DataRow row in dt1.Rows)
            {
                string s = row[0].ToString();
                Int32 i = Int32.Parse(s) + 1;
                tbFolio.Text = i.ToString();
            }

        }

        private void FormSales_Load(object sender, EventArgs e)
        {
            tbAmount.Text = "0.0";
            tbAmount.SelectionStart = tbAmount.Text.Length;

            dgvSales.Columns[0].Width = 60;
            dgvSales.Columns[1].Width = 120;
            dgvSales.Columns[2].Width = 60;
            dgvSales.Columns[3].Width = 60;
            dgvSales.Columns[4].Width = 60;
            dgvSales.Columns[5].Width = 120;

            tbDate.Text = DateTime.Today.ToString();

            DataTable dt = new DataTable();
            ClassWarehouse cWare = new ClassWarehouse();

            try
            {
                cWare.FindWarehouses(ref dt);
                foreach (DataRow row in dt.Rows)
                {
                    cbWarehouse.Items.Add(row[1].ToString());
                }

                FindFolio();
            } catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            dgvSales.Rows.Clear();
            tbTotal.Text = "$0.00";
        }

        private void Clear()
        {
            tbProductID.Text = "ID";
            tbProduct.Text = "Nombre";
            cbWarehouse.Text = "Nombre";
            tbAmount.Text = "0.0";
            tbSalePrice.Text = "0.00";
            FindFolio();
        }

        private void tbAmount_Enter(object sender, EventArgs e)
        {
            if(tbAmount.Text == "0.0")
            {
                tbAmount.Text = string.Empty;
            }
        }

        private void cbProduct_Leave(object sender, EventArgs e)
        {
            productos prod = new productos();
            ClassProducts cProd = new ClassProducts();

            try
            {
                if(tbProduct.Text == "")
                {
                    tbProduct.Text = "Nombre";
                } else
                {
                    if (cProd.SearchName(tbProduct.Text, ref prod))
                    {
                        if (prod.sProductID != null)
                        {
                            tbProductID.Text = prod.sProductID.ToString();
                            cbWarehouse.Text = "Nombre";
                            VerifySaldo();
                        } else
                        {
                            MessageBox.Show("No existe ese producto");
                        }
                    } else
                    {
                        MessageBox.Show("No existe ese producto");
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void VerifySaldo()
        {
            try
            {
                cbWarehouse.Items.Clear();
                ClassWarehouse cWare = new ClassWarehouse();
                DataTable dt = new DataTable();
                cWare.FindWarehouses(tbProductID.Text, ref dt);

                foreach (DataRow row in dt.Rows)
                {
                    cbWarehouse.Items.Add(row[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void tbProductID_Enter(object sender, EventArgs e)
        {
            if( tbProductID.Text == "ID")
            {
                tbProductID.Text = string.Empty;
            }
        }

        private void cbWarehouse_Enter(object sender, EventArgs e)
        {
            if(cbWarehouse.Text == "Nombre")
            {
                cbWarehouse.Text = string.Empty;
            }
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
                            double price = Convert.ToDouble(dt2.Rows[0][3]);
                            double amount = Convert.ToDouble(tbAmount.Text);
                            dgvSales.Rows.Add(tbProductID.Text, tbProduct.Text, tbAmount.Text, dt2.Rows[0][3].ToString(), (price * amount), dt.Rows[0][1].ToString());
                            Clear();
                            UpdateTotal(price, amount);
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
            } catch(Exception ex)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime today = DateTime.Now;

                if (dgvSales.Rows.Count > 0)
                {
                    List<string> lProdID = new List<string>();
                    List<string> lQuantity = new List<string>();
                    List<string> lPrice = new List<string>();
                    List<string> lWareID = new List<string>();

                    foreach (DataGridViewRow row in dgvSales.Rows)
                    {
                        // No guardar los datos de la línea en blanco del datagridview
                        if (row.IsNewRow) continue;

                        string prodID = row.Cells[0].Value?.ToString();
                        string quantity = row.Cells[2].Value?.ToString();
                        string price = row.Cells[3].Value?.ToString();
                        string wareID = row.Cells[5].Value?.ToString();

                        DataTable dt = new DataTable();
                        ClassWarehouse cWare = new ClassWarehouse();
                        cWare.FindID(wareID, ref dt);
                        if (dt.Rows.Count > 0)
                        {
                            wareID = dt.Rows[0][0].ToString();
                        }

                        lProdID.Add(prodID);
                        lQuantity.Add(quantity);
                        lPrice.Add(price);
                        lWareID.Add(wareID);
                    }

                    ClassMovement move = new ClassMovement();
                    if (move.SellProduct(lProdID, lQuantity, lPrice, lWareID, today))
                    {
                        MessageBox.Show("Salida guardada");
                        Clear();
                        dgvSales.Rows.Clear();
                    }
                    else
                        MessageBox.Show($"Ocurrió un error: {move.sError}");
                }
                else
                {
                    MessageBox.Show("Por favor agregue un dato a la salida");
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
        }

        private void tbAmount_Leave(object sender, EventArgs e)
        {
            if (tbAmount.Text == "")
                tbAmount.Text = "0.0";
        }

        private void cbWarehouse_Leave(object sender, EventArgs e)
        {
            if (cbWarehouse.Text == "")
                cbWarehouse.Text = "Nombre";
        }
    }
}
