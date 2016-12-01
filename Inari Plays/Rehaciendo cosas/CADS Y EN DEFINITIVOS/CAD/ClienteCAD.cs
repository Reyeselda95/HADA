using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InariPlaysLibrary.EN;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace InariPlaysLibrary.CAD
{
    public class ClienteCAD
    {
        private const string ConnectionString = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\InariDatos.mdf;User Instance=true";

        // Representa la entidad de negocio relacionada con el CAD
        private ClienteEN cliente;

        //Constructor
        public ClienteCAD(ClienteEN cliente) {
            try
            {
                // Se asigna al atributo ConnectionString la posicion de la base de datos
                // En c de guarda la conexion con la base
                SqlConnection c = new SqlConnection(ConnectionString);
                this.cliente = cliente;
            }
            catch (Exception e)
            {
                // Si se produce un error salta la exception con un mensaje

                Console.WriteLine(e.ToString());
            }
        }

        public static ClienteEN[] obtenerTodosClientes()
        {
            List<ClienteEN> clientes = new List<ClienteEN>();

            SqlConnection c = new SqlConnection(ConnectionString);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Cliente", c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    clientes.Add(new ClienteEN(dr["NIF"].ToString(), dr["nombre"].ToString(), dr["email"].ToString(), dr["password"].ToString(), dr["apellidos"].ToString(), dr["direccion"].ToString(), dr["telefono"].ToString(), Convert.ToInt32(dr["cp"].ToString())));
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No conecta a la base de datos: " + ex);
            }
            c.Close();

            return clientes.ToArray();
        }

        //Comprueba si existe el cliente en la base de datos
        public static bool esCliente(string dni, string password)
        {
            bool existe = false;

            SqlConnection c = new SqlConnection(ConnectionString);
            try
            {
                c.Open();

                SqlCommand com = new SqlCommand("Select * from cliente where NIF='" + dni + "' and password='" + password + "'", c);
                SqlDataReader dr = com.ExecuteReader();

                existe = dr.HasRows;

                dr.Close();
            }
            catch (Exception ex) {
                Console.WriteLine("No abre la conexion: "+ex);
            }
            c.Close();

            return existe;
        }

        public bool insertarActualizarCliente()
        {
            bool aR = false;

            SqlConnection conexion = new SqlConnection(ConnectionString);
            try
            {
                conexion.Open();

                string consulta = "UPDATE Cliente " +
                                 " SET password = '" + cliente.Password +
                                   "', email = '" + cliente.Email +
                                   "', nombre = '" + cliente.Nombre +
                                   "', apellidos = '" + cliente.Apellidos +
                                   "', direccion = '" + cliente.Direccion +
                                   "', telefono = '" + cliente.Telefono +
                                   "', cp= " + cliente.Cp + "WHERE NIF='" + cliente.NIF + "'";

                SqlCommand com = new SqlCommand(consulta, conexion);

                if (com.ExecuteNonQuery() > 0)
                    aR = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No abre la conexion: " + ex);
            }
            conexion.Close();


            if (!aR)
            {
                SqlConnection conexion2 = new SqlConnection(ConnectionString);
                try
                {
                    conexion2.Open();
                    
                    string consulta2 = "INSERT into Cliente VALUES ('"
                        + cliente.NIF + "', '"
                        + cliente.Nombre + "', '"
                        + cliente.Email + "', '"
                        + cliente.Password + "', '"
                        + cliente.Apellidos + "', '"
                        + cliente.Direccion + "', '"
                        + cliente.Telefono + "',"
                        + cliente.Cp + ")";

                    SqlCommand com2 = new SqlCommand(consulta2, conexion2);

                    if (com2.ExecuteNonQuery() > 0)
                        aR = true;
                }
                catch (Exception ex) {
                    Console.WriteLine("No abre la conexion: "+ex);
                }
                conexion2.Close();
            }


            return aR;
        }

        public bool borrarCliente() 
        {
            bool aR = false;


            SqlConnection conexion = new SqlConnection(ConnectionString);

            try
            {
                conexion.Open();

                string consulta = "DELETE from Cliente WHERE NIF='" + cliente.NIF + "'";

                SqlCommand com2 = new SqlCommand(consulta, conexion);

                if (com2.ExecuteNonQuery() > 0)
                    aR = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No abre la conexion: "+ex);
            }
            conexion.Close();

            return aR;
        }

        public static ClienteEN clientePorNif(string nif) {
            ClienteEN cliente= null;

            SqlConnection c = new SqlConnection(ConnectionString);

            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Cliente WHERE NIF ='" + nif + "'", c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cliente = new ClienteEN(dr["NIF"].ToString(), dr["nombre"].ToString(), dr["email"].ToString(), dr["password"].ToString(), dr["apellidos"].ToString(), dr["direccion"].ToString(), dr["telefono"].ToString(), Convert.ToInt32(dr["cp"].ToString()));
                }
                dr.Close();
            }
            catch (Exception ex) {
                Console.WriteLine("No abre la conexión: "+ex);
            }
            c.Close();
            return cliente;
        }

    }
}
