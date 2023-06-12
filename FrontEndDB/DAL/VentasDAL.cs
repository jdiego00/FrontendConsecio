using FrontEndDB.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEndDB.DAL
{
   
    internal class VentasDAL
    {
        Conexion conexion;

        public VentasDAL()
        {
            conexion = new Conexion();
        }
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
        public bool Agregar(VentasBLL oVentasBLL)
        {
            MessageBox.Show(ArrayToString(oVentasBLL.Equipamiento));
            return conexion.InsertarVentas("InsercionVentas",oVentasBLL.NumChaciz, oVentasBLL.CIVendedor, oVentasBLL.ModoPago, oVentasBLL.FechaEntrega,oVentasBLL.CICliente, ArrayToString(oVentasBLL.Equipamiento));
        }
    }
}
