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
        private string ArrayToString(List<string> array)
        {
            string hola = "";
            if (array.Count > 0)
            {
                hola = array[0];
            }
            for (int i = 1; i < array.Count(); i++)
            {
                hola += "," + array[i];
            }
            return hola;
        }
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
            for (int i = 0; i < oConsecionaria.MostrarDe("Repuestos").Tables[0].Rows.Count; i++)
            {
                checkedListBox1.Items.Add(oConsecionaria.MostrarDe("Repuestos").Tables[0].Rows[i][1]);
            }
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
        List<string> pkRepuesto = new List<string>();
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
            pkRepuesto = new List<string>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                DepartamentosDAL objDep = new DepartamentosDAL();
                if (checkedListBox1.GetItemChecked(i))
                {
                    pkRepuesto.Add(objDep.MostrarDe("Repuestos").Tables[0].Rows[i][0].ToString());
                }
            }
            string pkR = ArrayToString(pkRepuesto);
            conn.InsertarMecanico("InsertarMecanicos",textCI.Text,listCIMec,manodeobra);
            conn.InsertarRepuestos("InsertarRepuestos",textCI.Text, pkR);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            con.EliminarMec("EliminarMecanicos",textCI.Text,textBox1.Text);
        }
    }
}
