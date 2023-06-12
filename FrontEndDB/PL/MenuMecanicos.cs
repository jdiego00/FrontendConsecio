using FrontEndDB.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEndDB.PL
{
    public partial class MenuMecanicos : Form
    {
        public MenuMecanicos()
        {
            
            InitializeComponent();
            DepartamentosDAL oConsecionaria = new DepartamentosDAL();
            dataGridView1.DataSource = oConsecionaria.MostrarDe("Mecanicos").Tables[0];
            DataGridViewTextBoxColumn inputColumn = new DataGridViewTextBoxColumn();
            inputColumn.HeaderText = "Mano De Obra";
            inputColumn.Name = "input";
            dataGridView1.Columns.Add(inputColumn);
            dataGridView2.DataSource = oConsecionaria.MostrarReg().Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["input"].Index && e.RowIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Retrieve the entered value
                string inputValue = cell.Value?.ToString();

                // Process the entered value as needed
                if (!string.IsNullOrEmpty(inputValue))
                {
                    MessageBox.Show(inputValue);
                }
                else
                {
                    // Ignore the empty value
                }
            }
        }
        private void MenuMecanicos_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion conn= new Conexion();
            string manodeobra = "";
            string listCIMec = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Skip the last row if it is the new row
                if (!row.IsNewRow)
                {
                    // Retrieve the entered value from the inputColumn
                    string Mecanico = row.Cells["CIMecanico"].Value?.ToString();
                    string inputValue = row.Cells["input"].Value?.ToString();

                    // Process the entered value as needed
                    if (!string.IsNullOrEmpty(inputValue))
                    {
                        // Do something with the entered value
                        manodeobra+=inputValue+',';
                        listCIMec+=Mecanico+',';
                    }
                }
            }
            manodeobra=manodeobra.Remove(manodeobra.Length-1);
            listCIMec = listCIMec.Remove(listCIMec.Length - 1);
            conn.InsertarMecanico("InsertarMecanicos",textCI.Text,listCIMec,manodeobra);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
