using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTienda.DBconf
{
    class Conexion
    {
        SqlConnection con;

        public Conexion()
        {
            con = new SqlConnection("Server=localhost;Database=Tienda; Integrated Security=True");
        }
        public SqlConnection conectar()
        {
            try
            {
                con.Open();
                Console.WriteLine("Conexion Exitosa");
                return con;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fallo la conexion");
                return null;
            }
        }
        public bool desconectar()
        {
            try
            {
                con.Close();
                Console.WriteLine("Cerrado");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fallo en cerrar la conexion" + e);
                return false;
            }
        }
    }
}
