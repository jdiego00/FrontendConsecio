using FrontEndDB.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndDB.DAL
{
    internal class ClientesDAL
    {
        Conexion conexion;
        public ClientesDAL()
        {
            conexion = new Conexion();
        }
        public bool Agregar(ClientesBLL oClientesBLL)
        {
            return conexion.EjecutarComandoSinRetornoDatos("insert into Clientes values('"+oClientesBLL.CI+"', '"+oClientesBLL.Nombre+"', '"+oClientesBLL.ApellidoPaterno+"', '"+oClientesBLL.ApellidoMaterno+"', '"+oClientesBLL.Direccion+"', '"+oClientesBLL.Telefono+"')");
        }
    }
}
