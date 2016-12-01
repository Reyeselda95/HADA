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
using System.Configuration;


namespace InariPlaysLibrary.CAD
{
    class MerchandisingCAD
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        // Representa la entidad de negocio relacionada con el CAD
         private MerchandisingEN merch;
        //Constructor de Merchandising 
        public MerchandisingCAD(MerchandisingEN merchan)
		{
			merch = merchan;
		}
        // Método que como el mismo nombre dice sirve para obterner un Merchandising
        static public MerchandisingEN[] obtenerMerchan()
        {
            List<MerchandisingEN> merchan = new List<MerchandisingEN>();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();


                    string consulta = "SELECT merchandisingId, nombre, descripcion, precio, urlFoto   FROM Merchandising ORDER BY Nombre";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        MerchandisingEN mer = new MerchandisingEN();

                        mer.MerchandisingId = Convert.ToInt32(datos["merchandisingId"]);
                        mer.Nombre = Convert.ToString(datos["nombre"]);
                        mer.Descripcion = Convert.ToString(datos["descripcion"]);
                        mer.Precio = Convert.ToSingle(datos["precio"]);
                        mer.UrlFoto = Convert.ToString(datos["urlFoto"]);
                        merchan.Add(mer);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
                
            }
            return merchan.ToArray();
        }
        //Obtener un Merchandising a partir de un id
         static public MerchandisingEN merchanPorId(int id)
        {
            MerchandisingEN mer = new MerchandisingEN();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM merchandising WHERE merchandisingId like @id");
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                            mer.MerchandisingId = Convert.ToInt32(datos["merchandisingId"]);
                            mer.Nombre = Convert.ToString(datos["nombre"]);
                            mer.Descripcion = Convert.ToString(datos["descripcion"]);
                            mer.Precio = Convert.ToSingle(datos["precio"]);
                            mer.UrlFoto = Convert.ToString(datos["urlFoto"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
      
            }
            return mer; 
        }
        //Obtiene el merchandising a través del nombre que pasa por referencia
        static public MerchandisingEN[] merchanPorNombre(string nombre)
        {
            List<MerchandisingEN> merchan = new List<MerchandisingEN>();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();
                    string consulta = "";


                    consulta = "SELECT * FROM Merchandising WHERE nombre like '%" + nombre + "%' ORDER BY Nombre";

                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        MerchandisingEN mer = new MerchandisingEN();

                        mer.MerchandisingId = Convert.ToInt32(datos["merchandisingIdMerchandising"]);
                        mer.Nombre = Convert.ToString(datos["nombre"]);
                        mer.Descripcion = Convert.ToString(datos["descripcion"]);
                        mer.Precio = Convert.ToSingle(datos["precio"]);
                        mer.UrlFoto = Convert.ToString(datos["urlFoto"]);

                        merchan.Add(mer);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return merchan.ToArray();
        }
        //Método para insrtar un merchandising 
        private bool insertarMerchan()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "SELECT count(*) num FROM Merchandising";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    cantidad = (Int32)cmd.ExecuteScalar();


                    consulta = "INSERT INTO Merchandising VALUES (@merchandisingId, @nombre, @descripcion, @precio, @urlFoto)";

                    cmd = new SqlCommand(consulta, conexion);

                    cmd.Parameters.Add("@merchandisingId", merch.MerchandisingId);
                    cmd.Parameters.Add("@nombre", merch.Nombre);
                    cmd.Parameters.Add("@descripcion", merch.Descripcion);
                    cmd.Parameters.Add("@precio", merch.Precio);
                    cmd.Parameters.Add("@urlFoto", merch.UrlFoto);

                    cantidad = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd = null;
                    cantidad++;

                }
                catch (Exception ex) {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return (cantidad > 0);
        }
        //Método que actualiza
        private bool actualizarMerchan()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "UPDATE Merchandising SET descripcion='" + merch.Descripcion + "', precio=" + Convert.ToSingle(merch.Precio) + ", urlFoto='" + merch.UrlFoto + "' WHERE nombre like '%" + merch.Nombre+"%'";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    cantidad = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                } 
                conexion.Close();
            }
            return (cantidad > 0);
        }

        public bool insertarActualizarMerchan()
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                int cantidad = 0;
                try
                {
                    //Abrimos la conexión
                    conexion.Open();

                    string consulta = "SELECT count(*) FROM Merchandising WHERE nombre like '%" + merch.Nombre+"%'";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cantidad = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                if (cantidad > 0)
                    return actualizarMerchan();
                else
                    return insertarMerchan();
            }
        }
        //Método para borrar un merchandising
        public bool borrarMerchan()
        {
            bool aR = false;

            SqlConnection conexion = new SqlConnection(ConnectionString);
            try
            {
                conexion.Open();

                string consulta = "DELETE from Merchandising WHERE nombre like '%" + merch.Nombre + "%'";

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
        //Metodo para crear un nuevo merchandising
        static public int nuevoMerchan()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "SELECT count(*) num FROM merchandising";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    cantidad = (Int32)cmd.ExecuteScalar();
                    cantidad++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return cantidad;
        }
    }
}
