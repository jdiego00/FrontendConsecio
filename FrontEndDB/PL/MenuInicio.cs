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
    public partial class MenuInicio : Form
    {
        DepartamentosDAL oConsecionaria;
       
        public MenuInicio()
        {
            oConsecionaria = new DepartamentosDAL();
           
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = oConsecionaria.MostrarDe("Venta").Tables[0];
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = oConsecionaria.MostrarDe("Mecanicos").Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = oConsecionaria.MostrarDe("Automoviles").Tables[0];
        }
    }
}
