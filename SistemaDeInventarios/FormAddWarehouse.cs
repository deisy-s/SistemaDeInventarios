using DevExpress.XtraEditors.Filtering;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaDeInventarios
{
    public partial class FormAddWarehouse : Form
    {
        bool bNew = true;
        public FormAddWarehouse()
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

            if (!string.IsNullOrEmpty(tbID.Text) && tbID.Text.Length > 9)
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbID.Text) && !string.IsNullOrEmpty(tbDescripcion.Text))
                {
                    warehouse ware = new warehouse()
                    {
                        sWID = tbID.Text,
                        sDescripcion = tbDescripcion.Text
                    };

                    ClassWarehouse cWare = new ClassWarehouse();

                    bool bOK = bNew ? cWare.CreateWarehouse(ware) : cWare.UpdateWarehouse(ware);

                    if (bOK)
                    {
                        Clear();
                        MessageBox.Show("Almacen Creado");
                    }
                    else
                    {
                        MessageBox.Show($"Ocurrió un error: {cWare.sError}");
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

        private void tbID_Leave(object sender, EventArgs e)
        {
            warehouse ware = new warehouse();
            ClassWarehouse cWare = new ClassWarehouse();

            try
            {
                if (cWare.ReadWarehouse(tbID.Text, ref ware))
                {
                    if (ware.sDescripcion != null)
                    {
                        btnDelete.Enabled = true;
                        tbDescripcion.Text = ware.sDescripcion;
                        bNew = false;
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void Clear()
        {
            btnDelete.Enabled = false;
            tbID.Text = string.Empty;
            tbDescripcion.Text = string.Empty;
            tbID.Focus();
            dgvWarehouse.Rows.Clear();
            FillDGV();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void tbDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbDescripcion.Text) && tbDescripcion.Text.Length > 99)
            {
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbID.Text))
                {
                    ClassWarehouse cWare = new ClassWarehouse();

                    if (cWare.DeleteWarehouse(tbID.Text))
                    {
                        Clear();
                        MessageBox.Show("Almacen Eliminado");
                    }
                    else
                    {
                        MessageBox.Show($"Ocurrió un error: {cWare.sError}");
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

        private void FormAddWarehouse_Load(object sender, EventArgs e)
        {
            dgvWarehouse.Columns[0].Width = 100;
            dgvWarehouse.Columns[1].Width = 250;
            FillDGV();
        }

        private void FillDGV()
        {
            DataTable dt = new DataTable();
            ClassWarehouse cWare = new ClassWarehouse();

            try
            {
                cWare.FindWarehouses(ref dt);
                foreach (DataRow row in dt.Rows)
                {
                    dgvWarehouse.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }
    }
}
