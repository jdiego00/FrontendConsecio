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
    public partial class MenuTaller : Form
    {
        public MenuTaller()
        {
            DepartamentosDAL oConsecionaria= new DepartamentosDAL();
            InitializeComponent();
            dataGridView1.DataSource = oConsecionaria.MostrarDeAutoExt().Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textCI_TextChanged(object sender, EventArgs e)
        {

        }

        private void MenuTaller_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion conn = new Conexion();
            if(conn.InsertarTaller("InsercionTalleres", textFecha.Text, textCiCliente.Text, textAuto.Text))
            {
                MessageBox.Show("Agregado Correctamente");
            }

        }
    }
}
