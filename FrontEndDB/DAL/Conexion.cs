using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace FrontEndDB
{
    public class Conexion
    {
        // string connString = "Data Source=v-w7-des;Initial Catalog=Exam2Verif;Integrated Security=True";
        private String CadenaConexion = "Data Source = JUANDIEGO; Initial Catalog = Concesionario_final1; Integrated Security = True";
        SqlConnection conn;
        public SqlConnection EstablecerConexion()
        {
            this.conn = new SqlConnection(this.CadenaConexion);
            return this.conn;
        }
        public void pruebaConectar()
        {
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = "Select * From Clientes";
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
        //insert into Clientes values('1258794', 'pepito', 'nice', 'Elpepe', 'Av Radial 26', '77796545')
        public bool EjecutarComandoSinRetornoDatos(string strComando)
        {
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;
                Comando.Connection = EstablecerConexion();
                Comando.Connection.Open();
                Comando.ExecuteNonQuery();
                Comando.Connection.Close();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool InsertarVentas(string strComando, string p1, string p2, string p3, string p4, string p5, string p6)
        {
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;
                Comando.Connection = EstablecerConexion();
                Comando.Connection.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@PNumChaciz",p1);
                Comando.Parameters.AddWithValue("@PCI", p2);
                Comando.Parameters.AddWithValue("@PModoPago", p3);
                Comando.Parameters.AddWithValue("@PFechaEntrega", p4);
                Comando.Parameters.AddWithValue("@PCIcli", p5);
                Comando.Parameters.AddWithValue("@CodEquipList", p6);
                Comando.ExecuteNonQuery();
                Comando.Connection.Close();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool InsertarTaller(string strComando, string p1, string p2, string p3)
        {
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;
                Comando.Connection = EstablecerConexion();
                Comando.Connection.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@PFechaSalida", p1);
                Comando.Parameters.AddWithValue("@PCI", p2);
                Comando.Parameters.AddWithValue("@PNumChacizExt", p3);
                Comando.ExecuteNonQuery();
                Comando.Connection.Close();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool InsertarMecanico(string strComando, string p1, string p2, string p3)
        {
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;
                Comando.Connection = EstablecerConexion();
                Comando.Connection.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@CodReparacion", p1);
                Comando.Parameters.AddWithValue("@MecanicoList", p2);
                Comando.Parameters.AddWithValue("@ManoDeObraList", p3);
                Comando.ExecuteNonQuery();
                Comando.Connection.Close();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool InsertarRepuestos(string strComando, string p1, string p2)
        {
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;
                Comando.Connection = EstablecerConexion();
                Comando.Connection.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@RCodReparacion", p1);
                Comando.Parameters.AddWithValue("@RCodRepuestoList", p2);
                Comando.ExecuteNonQuery();
                Comando.Connection.Close();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public string InsertarFactura(string strComando, string p1)
        {
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;
                Comando.Connection = EstablecerConexion();
                Comando.Connection.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@FcodReparacion", p1);
                string result = "";
                using (SqlDataReader reader = Comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Retrieve the string value returned by the stored procedure
                        result = reader.GetString(0);
                        //Console.WriteLine("Result: " + result);
                    }
                }

                return result;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return "ERROR";
            }
        }
        public string Reporte(string strComando, string p1, string p2)
        {
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;
                Comando.Connection = EstablecerConexion();
                Comando.Connection.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@RFechaI", p1);
                Comando.Parameters.AddWithValue("@RFechaF", p2);
                string result = "";
                using (SqlDataReader reader = Comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Retrieve the string value returned by the stored procedure
                        result = reader.GetString(0);
                        //Console.WriteLine("Result: " + result);
                    }
                }

                return result;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return "ERROR";
            }
        }
        public bool ModificarClientes(string strComando, string p1, string p2, string p3, string p4, string p5, string p6)
        {
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;
                Comando.Connection = EstablecerConexion();
                Comando.Connection.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@CI", p1);
                Comando.Parameters.AddWithValue("@Nombre", p2);
                Comando.Parameters.AddWithValue("@ApellidoPaterno", p3);
                Comando.Parameters.AddWithValue("@ApellidoMaterno", p4);
                Comando.Parameters.AddWithValue("@Direccion", p5);
                Comando.Parameters.AddWithValue("@Telefono", p6);
                Comando.ExecuteNonQuery();
                Comando.Connection.Close();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool EliminarMec(string strComando, string p1, string p2)
        {
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;
                Comando.Connection = EstablecerConexion();
                Comando.Connection.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@CodReparacion", p1);
                Comando.Parameters.AddWithValue("@CIMecanico", p2);
                Comando.ExecuteNonQuery();
                Comando.Connection.Close();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }

}
