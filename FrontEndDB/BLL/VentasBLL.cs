using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndDB.BLL
{
    internal class VentasBLL
    {
        public string CICliente{ get; set; }
        public string CIVendedor { get; set; }
        public string NumChaciz { get; set; }
        public string ModoPago { get; set; }

        public string FechaEntrega { get; set; }
        public List<String> Equipamiento { get; set; }
    }
}
