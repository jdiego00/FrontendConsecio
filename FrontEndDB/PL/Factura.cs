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
    public partial class Factura : Form
    {
        public Factura()
        {
            InitializeComponent();
            DepartamentosDAL oConcesionaria = new DepartamentosDAL();
            dataGridView2.DataSource = oConcesionaria.MostrarReg().Tables[0];
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Factura_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion conn = new Conexion();
            MessageBox.Show(conn.InsertarFactura("Factura",textCI.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion conn = new Conexion();
            MessageBox.Show(conn.Reporte("RepTaller", textBox1.Text, textBox2.Text));
        }
    }
}
