using System;
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
        private const string ConnectionString = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|InariDatos.mdf;User Instance=true";

        private PeliculaEN peli;

        public PeliculaCAD(PeliculaEN pelicula)
		{
			peli = pelicula;
		}

        static public PeliculaEN[] obtenerPelicula()
        {
            List<PeliculaEN> peliculas = new List<PeliculaEN>();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();//abre la conexion

                    string consulta = "SELECT peliculaId, nombre, descripcion, precio, urlFoto  FROM Pelicula ORDER BY Nombre";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        PeliculaEN peli = new PeliculaEN();

                        if (!string.IsNullOrEmpty(Convert.ToString(datos["peliculaId"])))
                            peli.PeliculaId = Convert.ToInt32(datos["peliculaId"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["nombre"])))
                            peli.Nombre = Convert.ToString(datos["nombre"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["descripcion"])))
                            peli.Descripcion = Convert.ToString(datos["descripcion"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["precio"])))
                            peli.Precio = Convert.ToInt32(datos["precio"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["urlFoto"])))
                            peli.UrlFoto = Convert.ToString(datos["urlFoto"]);



                        peliculas.Add(peli);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();//cerrar conexion
            }
            return peliculas.ToArray();
        }

        static public PeliculaEN peliculaPorId(int id)
        {
            PeliculaEN peli = new PeliculaEN();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();//abre la conexion

                    string consulta = "SELECT * FROM Pelicula WHERE peliculaId = " + id + "ORDER BY nombre";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["peliculaId"])))
                            peli.PeliculaId = Convert.ToInt32(datos["peliculaId"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["nombre"])))
                            peli.Nombre = Convert.ToString(datos["nombre"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["descripcion"])))
                            peli.Descripcion = Convert.ToString(datos["descripcion"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["precio"])))
                            peli.Precio = Convert.ToInt32(datos["precio"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["urlFoto"])))
                            peli.UrlFoto = Convert.ToString(datos["urlFoto"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();//cerrar conexion
            }
            return peli; 
        }

        static public PeliculaEN[] peliculaPorNombre(string nombre)
        {
            List<PeliculaEN> peliculas = new List<PeliculaEN>();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();//abre la conexion
                    string consulta = "";


                    consulta = "SELECT * FROM Pelicula WHERE nombre like '%" + nombre + "%' ORDER BY Nombre";

                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        PeliculaEN peli = new PeliculaEN();

                        if (!string.IsNullOrEmpty(Convert.ToString(datos["peliculaId"])))
                            peli.PeliculaId = Convert.ToInt32(datos["peliculaId"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["nombre"])))
                            peli.Nombre = Convert.ToString(datos["nombre"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["descripcion"])))
                            peli.Descripcion = Convert.ToString(datos["descripcion"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["precio"])))
                            peli.Precio = Convert.ToInt32(datos["precio"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["urlFoto"])))
                            peli.UrlFoto = Convert.ToString(datos["urlFoto"]);

                        peliculas.Add(peli);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();//cerrar conexion
            }
            return peliculas.ToArray();
        }

        private bool insertarPelicula()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();//abre la conexion

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
                conexion.Close();//cerrar conexion
            }
            return (cantidad > 0);
        }

        private bool actualizarPelicula()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();//abre la conexion

                    string consulta = "UPDATE Pelicula SET nombre ='" + peli.Nombre + "', descripcion='" + peli.Descripcion + "', precio=" + peli.Precio + ", urlFoto='" + peli.UrlFoto + "' WHERE peliculaId = " + peli.PeliculaId;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    cantidad = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();//cerrar conexion
            }
            return (cantidad > 0);
        }

        public bool insertarActualizarPelicula()
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                int cantidad = 0;
                try
                {
                    conexion.Open();//abre la conexion
                    
                    string consulta = "SELECT count(*) FROM Pelicula WHERE peliculaId = " + peli.PeliculaId;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    cantidad = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();//cerrar conexion

                if (cantidad > 0)
                    return actualizarPelicula();
                else
                    return insertarPelicula();
            }
        }

        public bool borrarPelicula()
        {
            bool aR = false;

            SqlConnection conexion = new SqlConnection(ConnectionString);
            try
            {
                conexion.Open();//abre la conexion

                string consulta = "DELETE from Pelicula WHERE nombre='" + peli.Nombre + "'";

                SqlCommand com2 = new SqlCommand(consulta, conexion);

                if (com2.ExecuteNonQuery() > 0)
                    aR = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No conecta a la base de datos: " + ex);
            }
            conexion.Close();//cerrar conexion

            return aR;
        }
        static public int nuevaPelicula()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();//abre la conexion

                    string consulta = "SELECT count(*) num FROM pelicula";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    cantidad = (Int32)cmd.ExecuteScalar();
                    cantidad++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();//cerrar conexion
            }
            return cantidad;
        }
    }
}
