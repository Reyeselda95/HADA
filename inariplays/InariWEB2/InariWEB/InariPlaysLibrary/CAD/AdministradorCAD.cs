using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InariPlaysLibrary.EN;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace InariPlaysLibrary.CAD
{
    class AdministradorCAD
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

        // Representa la entidad de negocio relacionada con el CAD
        private AdministradorEN admin;

        public AdministradorCAD(AdministradorEN admin) {
            this.admin = admin;
        }

        public static AdministradorEN[] dameTodosAdmin() { 
            List<AdministradorEN> admins =new List<AdministradorEN>();

            SqlConnection c = new SqlConnection(ConnectionString);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Administrador", c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    admins.Add(new AdministradorEN(Convert.ToInt32(dr["idAdministrador"].ToString()), dr["nombre"].ToString(), dr["apellidos"].ToString(), dr["password"].ToString()));
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No conecta a la base de datos: " + ex);
            }
            c.Close();
            return admins.ToArray();
        }

        //Comprueba si existe el admin en la base de datos
        public static bool esAdmin(string admin, string password)
        {
            bool existe = false;

            SqlConnection c = new SqlConnection(ConnectionString);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Administrador where nombre like '%" + admin + "%' and password like  '%" + password + "%'", c);
                SqlDataReader dr = com.ExecuteReader();

                existe = dr.HasRows;

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No conecta a la base de datos: " + ex);
            }
            c.Close();

            return existe;
        }

        public bool insertarActualizarAdmin()
        {
            bool aR = false;

            SqlConnection conexion = new SqlConnection(ConnectionString);
            try
            {
                conexion.Open();

                string consulta = "UPDATE Administrador " +
                                 " SET password = '" + admin.Password +
                                   "', apellidos = '" + admin.Apellidos +
                                   "' WHERE nombre like '%" + admin.Id + "%'";

                SqlCommand com = new SqlCommand(consulta, conexion);

                if (com.ExecuteNonQuery() > 0)
                    aR = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No conecta a la base de datos: " + ex);
            }

            conexion.Close();


            if (!aR)
            {
                SqlConnection conexion2 = new SqlConnection(ConnectionString);
                try
                {
                    conexion2.Open();


                    string consulta2 = "INSERT into Administrador VALUES ('"
                        + admin.Id + "', '"
                        + admin.Nombre + "', '"
                        + admin.Apellidos + "', '"
                        + admin.Password + "')";

                    SqlCommand com2 = new SqlCommand(consulta2, conexion2);

                    if (com2.ExecuteNonQuery() > 0)
                        aR = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion2.Close();
            }


            return aR;
        }

        public bool borrarAdmin()
        {
            bool aR = false;


            SqlConnection conexion = new SqlConnection(ConnectionString);
            try
            {
                conexion.Open();

                string consulta = "DELETE from Administrador WHERE idAdministrador like'%" + admin.Id + "%'";

                SqlCommand com2 = new SqlCommand(consulta, conexion);

                if (com2.ExecuteNonQuery() > 0)
                    aR = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No conecta a la base de datos: " + ex);
            }
            conexion.Close();

            return aR;
        }

    }
}
