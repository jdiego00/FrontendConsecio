using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontEndDB.BLL;
using FrontEndDB.DAL;

namespace FrontEndDB.PL
{
    public partial class MenuVenta : Form
    {
        ClientesDAL oClientesDAL;
        public MenuVenta()
        {
            oClientesDAL = new ClientesDAL();
            InitializeComponent();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           oClientesDAL.Agregar(RecuperarInformacion());
        }
        private ClientesBLL RecuperarInformacion()
        {
            ClientesBLL oCliente = new ClientesBLL();
            oCliente.Telefono = textTelefono.Text;
            oCliente.CI = textCI.Text;
            oCliente.ApellidoMaterno = textAmaterno.Text;
            oCliente.ApellidoPaterno = textApaterno.Text;
            oCliente.Direccion = textDireccion.Text;
            oCliente.Nombre = textNombre.Text;

            return oCliente;
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
