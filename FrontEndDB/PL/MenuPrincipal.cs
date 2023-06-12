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
    public partial class MenuPrincipal : Form
    {
    
        public MenuPrincipal()
        {
            
            InitializeComponent();
            
        }
        private void AbrirFormHija(object fromHijo)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form fh = fromHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fh);
            this.panel1.Tag = fh;
            fh.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new MenuInicio());
            pictureBox1.BringToFront();
        }



        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new MenuVenta());
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            AbrirFormHija(new MenuVenta());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new RegistroVenta());
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new MenuTaller());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new MenuMecanicos());
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            AbrirFormHija(new Factura());
        }
    }
}
