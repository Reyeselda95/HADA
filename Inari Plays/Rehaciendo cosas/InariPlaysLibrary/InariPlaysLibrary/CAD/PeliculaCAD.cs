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
        private const string ConnectionString = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\InariDatos.mdf;User Instance=true";

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
                conexion.Open();

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
            return peliculas.ToArray();
        }

        static public PeliculaEN peliculaPorId(int id)
        {
            PeliculaEN peli = new PeliculaEN();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                conexion.Open();

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
            return peli; 
        }

        static public PeliculaEN[] peliculaPorNombre(string nombre)
        {
            List<PeliculaEN> peliculas = new List<PeliculaEN>();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                conexion.Open();
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
            return peliculas.ToArray();
        }

        private bool insertarPelicula()
        {
            int cantidad = 0;
                using (SqlConnection conexion = new SqlConnection())
                {
                    conexion.ConnectionString = ConnectionString;
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
                
            return (cantidad > 0);
        }

        private bool actualizarPelicula()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                conexion.Open();

                string consulta = "UPDATE Pelicula SET nombre ='" + peli.Nombre + "', descripcion='" + peli.Descripcion + "', precio=" + peli.Precio + ", urlFoto='" + peli.UrlFoto + "' WHERE peliculaId = " + peli.PeliculaId;
                SqlCommand cmd = new SqlCommand(consulta, conexion);

                cantidad = cmd.ExecuteNonQuery();
            }
            return (cantidad > 0);
        }

        public bool insertarActualizarPelicula()
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                int cantidad = 0;
                string consulta = "SELECT count(*) FROM Pelicula WHERE peliculaId = " + peli.PeliculaId;
                SqlCommand cmd = new SqlCommand(consulta, conexion);

                cantidad = (Int32)cmd.ExecuteScalar();
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
            conexion.Open();

            string consulta = "DELETE from Pelicula WHERE nombre='" + peli.Nombre + "'";

            SqlCommand com2 = new SqlCommand(consulta, conexion);

            if (com2.ExecuteNonQuery() > 0)
                aR = true;

            conexion.Close();

            return aR;
        }
    }
}
