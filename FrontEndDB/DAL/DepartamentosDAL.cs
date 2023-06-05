using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndDB.DAL
{   
    public class DepartamentosDAL
    {
        Conexion conn;
        public DepartamentosDAL() { conn = new Conexion(); }

        public DataSet MostrarConsecio()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * from Concesionario");
            return conn.EjecutarSentencia(sentencia);
        }

    }
}
