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
            DepartamentosDAL odep = new DepartamentosDAL();
            InitializeComponent();
            dataGridView1.DataSource = odep.MostrarDe("Clientes").Tables[0];
        }   

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (oClientesDAL.Agregar(RecuperarInformacion()))
            {
                MessageBox.Show("Cliente Agregado Correctamente");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            if(con.ModificarClientes("EditarCliente", textCI.Text, textNombre.Text, textApaterno.Text, textAmaterno.Text, textDireccion.Text, textTelefono.Text))
            {
                MessageBox.Show("Cliente Modificado Correctamente");
            }
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

        private void textDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
