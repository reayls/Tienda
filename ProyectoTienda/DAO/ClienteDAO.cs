using ProyectoTienda.DBconf;
using ProyectoTienda.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTienda.DAO
{
    class ClienteDAO
    {
        public static bool guardar(Cliente c)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "INSERT INTO Cliente VALUES('" + c.Dni + "','" + c.Nombres + "','" + c.Apellidos + "'," + c.Edad + ",'" + c.Ciudad + "')";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int filaAfectadas = comando.ExecuteNonQuery();
                if (filaAfectadas == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {
                    con.desconectar();
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("el error en insertar es : " + e);
                return false;
            }
        }
        public static DataTable Listar()
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "SELECT * FROM Cliente";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader lista = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lista);
                con.desconectar();
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine("El error en mostrar es: " + e);
                return null;
            }
        }
        public static Cliente consultar(String doc)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "SELECT * FROM Cliente WHERE dni='" + doc + "'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader();
                Cliente cl = new Cliente();
                if (dr.Read())
                {
                    cl.Id = Convert.ToInt32(dr["id"].ToString());
                    cl.Dni = dr["dni"].ToString();
                    cl.Nombres = dr["nombres"].ToString();
                    cl.Apellidos = dr["apellidos"].ToString();
                    cl.Edad = Convert.ToInt32(dr["edad"].ToString());
                    cl.Ciudad = dr["ciudad"].ToString();
                    con.desconectar();
                    return cl;
                }
                else
                {
                    con.desconectar();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("El error en mostrar es: " + e);
                return null;
            }
        }
        public static bool actualizar(Cliente c)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "UPDATE  Cliente SET nombres='" + c.Nombres + "',apellidos='" + c.Apellidos + "',edad='" + c.Edad + "',ciudad='" + c.Ciudad + "' WHERE dni='" + c.Dni + "'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int filaAfectadas = comando.ExecuteNonQuery();
                if (filaAfectadas == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {
                    con.desconectar();
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("el error es: " + e);
                return false;
            }
        }
        public static bool eliminar(string doc)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "DELETE FROM Cliente WHERE dni='" + doc + "'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int filaAfectadas = comando.ExecuteNonQuery();
                if (filaAfectadas == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {
                    con.desconectar();
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("el error es: " + e);
                return false;
            }
        }
    }
}
