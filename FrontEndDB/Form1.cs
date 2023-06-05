using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrontEndDB.DAL;
using FrontEndDB.PL;

namespace FrontEndDB
{
    public partial class Form1 : Form
    {
        DepartamentosDAL oConsecionaria;
        public Form1()
        {
            oConsecionaria = new DepartamentosDAL();
            InitializeComponent();
            dataGridView1.DataSource = oConsecionaria.MostrarConsecio().Tables[0];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Conexion hola = new Conexion();
            hola.pruebaConectar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormularioConsecio formularioconsecio = new FormularioConsecio();
            formularioconsecio.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AbrirFormHijo(object fromHijo)
        {
            if(this.panelcontenedor.Controls.Count > 0)
                this.panelcontenedor.Controls.RemoveAt(0);
            Form fh = fromHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelcontenedor.Controls.Add(fh);
            this.panelcontenedor.Tag = fh;
            fh.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new SinBorde());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
