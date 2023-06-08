using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace FrontEndDB
{
    public class Conexion
    {
        // string connString = "Data Source=v-w7-des;Initial Catalog=Exam2Verif;Integrated Security=True";
        private String CadenaConexion = "Data Source = JUANDIEGO; Initial Catalog = Concesionario_final1; Integrated Security = True";
        SqlConnection conn;
            public SqlConnection EstablecerConexion()
        {
            this.conn= new SqlConnection(this.CadenaConexion);
            return this.conn;
        }
            public void pruebaConectar()
        {
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = "SELECT * from Concesionario";
                Comando.Connection = EstablecerConexion();
                Comando.Connection.Open();
                Comando.ExecuteNonQuery();
                Comando.Connection.Close();
                
                MessageBox.Show("Conexion Exitosa");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                Environment.Exit(0);
            }
        }
        public DataSet EjecutarSentencia(SqlCommand sqlComando)
        {

            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Comando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = Comando;
                conn.Open();
                Adaptador.Fill(DS);
                conn.Close();
                return DS;
            }
            catch
            {
                return DS;
            }
        }



    }
}
