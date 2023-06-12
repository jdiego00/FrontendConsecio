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
using Org.BouncyCastle.Utilities.IO;

namespace FrontEndDB.PL
{  
    public partial class RegistroVenta : Form
    {
        VentasDAL oVentasDAL;
        public RegistroVenta()
        {
            oVentasDAL= new VentasDAL();
            DepartamentosDAL oDep = new DepartamentosDAL();
            InitializeComponent();
            dataGridView1.DataSource= oDep.MostrarCli().Tables[0];
            dataGridView2.DataSource = oDep.MostrarVEND().Tables[0];


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void RegistroVenta_Load(object sender, EventArgs e)
        {
            DepartamentosDAL objDep = new DepartamentosDAL();
            //comboBox1.DataSource = objDep.MostrarDe("Modelos").Tables[0];
            //comboBox1.ValueMember = "CodModelo";
            for (int i = 0; i < objDep.MostrarDe("Equipamiento").Tables[0].Rows.Count; i++)
            {
                checkedListBox1.Items.Add(objDep.MostrarDe("Equipamiento").Tables[0].Rows[i][2]);
            }
        }



        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DepartamentosDAL objDep = new DepartamentosDAL();
            //int indice = checkedListBox1.SelectedIndex;
            //string PK = objDep.MostrarDe("Equipamiento").Tables[0].Rows[indice][0].ToString();
            //checkedListBox1.GetItemChecked(0).ToString();
            //MessageBox.Show(PK);
        }
        
            List<string> pkEquipo = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            pkEquipo = new List<string>();
            for ( int i = 0; i<checkedListBox1.Items.Count; i++ )
            {
                DepartamentosDAL objDep = new DepartamentosDAL();
                if (checkedListBox1.GetItemChecked(i))
                {
                    pkEquipo.Add(objDep.MostrarDe("Equipamiento").Tables[0].Rows[i][0].ToString());
                }
            }
            oVentasDAL.Agregar(RecuperarInformacion());
            
        }

        private void textCI_TextChanged(object sender, EventArgs e)
        {

        }
        private VentasBLL RecuperarInformacion()
        {
            VentasBLL oVentasBLL = new VentasBLL();
            oVentasBLL.NumChaciz = textNumChazis.Text;
            oVentasBLL.CIVendedor = textCI.Text;
            oVentasBLL.CICliente = textCIcliente.Text;
            oVentasBLL.ModoPago = groupBox2.Text;
            oVentasBLL.Equipamiento = pkEquipo;
            oVentasBLL.FechaEntrega = textBox1.Text;
            return oVentasBLL;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
