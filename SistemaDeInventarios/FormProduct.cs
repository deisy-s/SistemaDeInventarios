using DevExpress.XtraEditors;
using ReglasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaDeInventarios
{
    public partial class FormProduct : Form
    {
        bool bNew = true;
        int iID = 0;

        public FormProduct()
        {
            InitializeComponent();
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
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

            if (!string.IsNullOrEmpty(tbID.Text) && tbID.Text.Length > 9 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tbSalePrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSalePrice.Text))
            {
                tbSalePrice.Text = "0.00";
            }
            if(tbSalePrice.Text != null && !tbSalePrice.Text.Contains("."))
            {
                tbSalePrice.Text += ".00";
            }
        }

        private void tbBuyPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbBuyPrice.Text))
            {
                tbBuyPrice.Text = "0.00";
            }
            if (tbBuyPrice.Text != null && !tbBuyPrice.Text.Contains("."))
            {
                tbBuyPrice.Text += ".00";
            }
        }

        private void tbSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un número ni la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != 46 && e.KeyChar != 13 && e.KeyChar != 11)
            {
                // Si no es un número ni la tecla de retroceso, cancela el evento de pulsación de tecla
                e.Handled = true;
            }

            // Verifica si ya hay un punto en el texto y si el caracter es un punto
            if (tbSalePrice.Text != null && e.KeyChar == 46 && tbSalePrice.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void tbBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un número ni la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != 46 && e.KeyChar != 13 && e.KeyChar != 11)
            {
                // Si no es un número ni la tecla de retroceso, cancela el evento de pulsación de tecla
                e.Handled = true;
            }

            // Verifica si ya hay un punto en el texto y si el caracter es un punto
            if (tbBuyPrice.Text != null && e.KeyChar == 46 && tbBuyPrice.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            bNew = true;
            btnDelete.Enabled = false;
            tbID.Text = string.Empty;
            tbName.Text = string.Empty;
            tbSalePrice.Text = string.Empty;
            tbBuyPrice.Text = string.Empty;
            tbID.Focus();
            dgvProducts.Rows.Clear();
            FillDGV();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbID.Text) && !string.IsNullOrEmpty(tbName.Text) && tbBuyPrice.Text != "0.00" && tbSalePrice.Text != "0.00")
                {
                    productos prod = new productos()
                    {
                        sProductID = tbID.Text,
                        sProductName = tbName.Text,
                        dSalePrice = double.Parse(tbSalePrice.Text),
                        dBuyPrice = double.Parse(tbBuyPrice.Text)
                    };

                    ClassProducts cProd = new ClassProducts();

                    bool bOk = bNew ? cProd.CreateProduct(prod) : cProd.UpdateProduct(prod);

                    if (bOk)
                    {
                        Clear();
                        MessageBox.Show("Producto Creado");
                    }
                    else
                    {
                        MessageBox.Show($"Ocurrió un error: {cProd.sError}");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor llene todos los campos");
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbID.Text))
                {
                    ClassProducts cProd = new ClassProducts();

                    if (cProd.DeleteProduct(tbID.Text))
                    {
                        Clear();
                        MessageBox.Show("Producto Eliminado");
                    }
                    else
                    {
                        MessageBox.Show($"Ocurrió un error: {cProd.sError}");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un ID");
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void tbID_Leave(object sender, EventArgs e)
        {
            productos prod = new productos();
            ClassProducts cProd = new ClassProducts();

            try
            {
                if (cProd.ReadProduct(tbID.Text, ref prod))
                {
                    if (prod.sProductName != null)
                    {
                        bNew = false;
                        btnDelete.Enabled = true;
                        tbName.Text = prod.sProductName.ToString();
                        tbSalePrice.Text = prod.dSalePrice.ToString();
                        tbBuyPrice.Text = prod.dBuyPrice.ToString();
                        if (!tbSalePrice.Text.Contains('.'))
                        {
                            tbSalePrice.Text += ".00";
                        }
                        if (!tbBuyPrice.Text.Contains('.'))
                        {
                            tbBuyPrice.Text += ".00";
                        }
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }


        private void tbSalePrice_TextChanged(object sender, EventArgs e)
        {
            string sNum = tbSalePrice.Text.Replace(",", "").Replace("$", "").Replace(".", "").TrimStart('0');
            decimal ul;
            //Check we are indeed handling a number
            if (decimal.TryParse(sNum, out ul))
            {
                ul /= 100;
                //Format the text as currency
                tbSalePrice.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C2}", ul);
                tbSalePrice.Select(tbSalePrice.Text.Length, 0);
            }
            bool goodToGo = TextisValid(tbSalePrice.Text);
            if (!goodToGo)
            {
                tbSalePrice.Text = "0.00";
                tbSalePrice.Select(tbSalePrice.Text.Length, 0);
            }

        }

        private void tbBuyPrice_TextChanged(object sender, EventArgs e)
        {
            string sNum = tbBuyPrice.Text.Replace(",", "").Replace("$", "").Replace(".", "").TrimStart('0');
            decimal ul;
            //Check we are indeed handling a number
            if (decimal.TryParse(sNum, out ul))
            {
                ul /= 100;
                //Format the text as currency
                tbBuyPrice.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C2}", ul);
                tbBuyPrice.Select(tbBuyPrice.Text.Length, 0);
            }
            bool goodToGo = TextisValid(tbBuyPrice.Text);
            if (!goodToGo)
            {
                tbBuyPrice.Text = "0.00";
                tbBuyPrice.Select(tbBuyPrice.Text.Length, 0);
            }
        }

        private bool TextisValid(string text)
        {
            Regex money = new Regex(@"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$");
            return money.IsMatch(text);
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            tbBuyPrice.Text = "0.00";
            tbBuyPrice.SelectionStart = tbBuyPrice.Text.Length;
            tbSalePrice.Text = "0.00";
            tbSalePrice.SelectionStart = tbSalePrice.Text.Length;
            dgvProducts.Columns[0].Width = 80;
            dgvProducts.Columns[1].Width = 140;
            dgvProducts.Columns[2].Width = 80;
            dgvProducts.Columns[3].Width = 80;

            //DataTable dt = new DataTable();
            //ClassProducts cProd = new ClassProducts();

            //cProd.FindProducts(ref dt);
            //foreach (DataColumn column in dt.Columns)
            //{
            //    dgvProducts.Columns.Add(column.ColumnName, column.ToString());
            //}
            FillDGV();
        }

        private void FillDGV()
        {
            DataTable dt = new DataTable();
            ClassProducts cProd = new ClassProducts();

            try
            {
                cProd.FindProducts(ref dt);
                foreach (DataRow row in dt.Rows)
                {
                    dgvProducts.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        //private void NextID()
        //{
        //    ClassProducts cProd = new ClassProducts();
        //    iID = cProd.LastID();
        //    if (iID != 0)
        //    {
        //        tbID.Text = (iID + 1).ToString();
        //    }
        //}

        private void tbSalePrice_Enter(object sender, EventArgs e)
        {
            if(tbSalePrice.Text == "0.00")
            {
                tbSalePrice.Text = string.Empty;
            }
        }

        private void tbBuyPrice_Enter(object sender, EventArgs e)
        {
            if(tbBuyPrice.Text == "0.00")
            {
                tbBuyPrice.Text = string.Empty;
            }
        }

        private void tbID_Enter(object sender, EventArgs e)
        {
            //if(string.IsNullOrEmpty(tbID.Text))
            //{
            //    NextID();
            //}
        }
    }
}
