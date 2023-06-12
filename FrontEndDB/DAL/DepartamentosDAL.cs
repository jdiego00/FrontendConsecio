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

        public DataSet MostrarDe(string DeDonde)
        {
            DeDonde = "SELECT * from " + DeDonde;
            SqlCommand sentencia = new SqlCommand(DeDonde);
            return conn.EjecutarSentencia(sentencia);
        }
        public DataSet MostrarDeAutoExt()
        {
            SqlCommand sentencia = new SqlCommand("SELECT C.CI, C.Nombre, AE.NumChacizExt, AE.Color, AE.Modelo FROM AutoExterno AE JOIN Clientes C ON AE.CI = C.CI;");
            return conn.EjecutarSentencia(sentencia);
        }
        public DataSet MostrarReg()
        {
            SqlCommand sentencia = new SqlCommand("SELECT RT.CodReparacion, C.Nombre, AE.NumChacizExt, AE.Modelo FROM RegistroTaller RT JOIN Clientes C ON RT.CI = C.CI JOIN AutoExterno AE ON RT.NumChacizExt = AE.NumChacizExt;");
            return conn.EjecutarSentencia(sentencia);
        }


    }
}
