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
    class PeliculaCAD
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        // Representa la entidad de negocio relacionada con el CAD
        private PeliculaEN peli;
        //Constructor 
        public PeliculaCAD(PeliculaEN pelicula)
		{
			peli = pelicula;
		}
        //Método para obtener los datos de las peliculas
        static public PeliculaEN[] obtenerPelicula()
        {
            List<PeliculaEN> peliculas = new List<PeliculaEN>();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "SELECT peliculaId, nombre, descripcion, precio, urlFoto  FROM Pelicula ORDER BY Nombre";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        PeliculaEN peli = new PeliculaEN();

                        peli.PeliculaId = Convert.ToInt32(datos["peliculaId"]);
                        peli.Nombre = Convert.ToString(datos["nombre"]);
                        peli.Descripcion = Convert.ToString(datos["descripcion"]);
                        peli.Precio = Convert.ToSingle(datos["precio"]);
                        peli.UrlFoto = Convert.ToString(datos["urlFoto"]);

                        peliculas.Add(peli);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return peliculas.ToArray();
        }
        //Método para obterner los datos a través del id
        static public PeliculaEN peliculaPorId(int id)
        {
            PeliculaEN peli = new PeliculaEN();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "SELECT * FROM Pelicula WHERE peliculaId like " + id + " ORDER BY nombre";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                            peli.PeliculaId = Convert.ToInt32(datos["peliculaId"]);
                            peli.Nombre = Convert.ToString(datos["nombre"]);
                            peli.Descripcion = Convert.ToString(datos["descripcion"]);
                            peli.Precio = Convert.ToSingle(datos["precio"]);
                            peli.UrlFoto = Convert.ToString(datos["urlFoto"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return peli; 
        }
        //Método para obterner los datos a través del nombre
        static public PeliculaEN[] peliculaPorNombre(string nombre)
        {
            List<PeliculaEN> peliculas = new List<PeliculaEN>();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();
                    string consulta = "";


                    consulta = "SELECT * FROM Pelicula WHERE nombre like '%" + nombre + "%' ORDER BY Nombre";

                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        PeliculaEN peli = new PeliculaEN();

                        peli.PeliculaId = Convert.ToInt32(datos["peliculaId"]);
                        peli.Nombre = Convert.ToString(datos["nombre"]);
                        peli.Descripcion = Convert.ToString(datos["descripcion"]);
                        peli.Precio = Convert.ToSingle(datos["precio"]);
                        peli.UrlFoto = Convert.ToString(datos["urlFoto"]);

                        peliculas.Add(peli);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return peliculas.ToArray();
        }
        //Método para insertar los datos
        private bool insertarPelicula()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "SELECT count(*) num FROM Pelicula";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    cantidad = (Int32)cmd.ExecuteScalar();


                    consulta = "INSERT INTO Pelicula VALUES (@peliculaId, @nombre, @descripcion, @precio, @urlFoto)";

                    cmd = new SqlCommand(consulta, conexion);

                    cmd.Parameters.Add("@peliculaId", peli.PeliculaId);
                    cmd.Parameters.Add("@nombre", peli.Nombre);
                    cmd.Parameters.Add("@descripcion", peli.Descripcion);
                    cmd.Parameters.Add("@precio", peli.Precio);
                    cmd.Parameters.Add("@urlFoto", peli.UrlFoto);

                    cantidad = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd = null;
                    cantidad++;


                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return (cantidad > 0);
        }
        //Método para actualizar los datos de la base de datos
        private bool actualizarPelicula()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "UPDATE Pelicula SET descripcion='" + peli.Descripcion + "', precio=" + Convert.ToSingle(peli.Precio) + ", urlFoto='" + peli.UrlFoto + "' WHERE nombre like '%" + peli.Nombre +"%'";
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
        //Método que como dice el nombre inserta y actualiza el producto en la base de datos
        public bool insertarActualizarPelicula()
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                int cantidad = 0;
                try
                {
                    conexion.Open();
                    
                    string consulta = "SELECT count(*) FROM Pelicula WHERE nombre like '%" + peli.Nombre+"%'";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    cantidad = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();

                if (cantidad > 0)
                    return actualizarPelicula();
                else
                    return insertarPelicula();
            }
        }
        //Método para borrar el producto de la base de datos
        public bool borrarPelicula()
        {
            bool aR = false;

            SqlConnection conexion = new SqlConnection(ConnectionString);
            try
            {
                conexion.Open();

                string consulta = "DELETE from Pelicula WHERE nombre like'%" + peli.Nombre + "%'";

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
        //Funcion para crear una pelicula nueva
        static public int nuevaPelicula()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "SELECT count(*) num FROM pelicula";
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
