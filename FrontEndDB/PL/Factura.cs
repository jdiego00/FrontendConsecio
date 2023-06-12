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
            DepartamentosDAL objDep = new DepartamentosDAL();;
            for (int i = 0; i < objDep.MostrarDe("Repuestos").Tables[0].Rows.Count; i++)
            {
                checkedListBox1.Items.Add(objDep.MostrarDe("Repuestos").Tables[0].Rows[i][1]);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
