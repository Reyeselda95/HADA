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
    class VideojuegoCAD
    {
        private const string ConnectionString = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\InariDatos.mdf;User Instance=true";

        private VideojuegoEN videojuego;

        public VideojuegoCAD(VideojuegoEN video)
		{
			videojuego = video;
		}

        static public VideojuegoEN[] obtenerVideojuegos()
        {
            List<VideojuegoEN> videojuegos = new List<VideojuegoEN>();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "SELECT videojuegoId, nombre, descripcion,companyia, precio, urlFoto   FROM Videojuego ORDER BY Nombre";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        VideojuegoEN videojuego = new VideojuegoEN();

                        if (!string.IsNullOrEmpty(Convert.ToString(datos["videojuegoId"])))
                            videojuego.VideojuegoId = Convert.ToInt32(datos["videojuegoId"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["nombre"])))
                            videojuego.Nombre = Convert.ToString(datos["nombre"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["descripcion"])))
                            videojuego.Descripcion = Convert.ToString(datos["descripcion"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["companyia"])))
                            videojuego.Companyia = Convert.ToString(datos["companyia"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["precio"])))
                            videojuego.Precio = Convert.ToInt32(datos["precio"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["urlFoto"])))
                            videojuego.UrlFoto = Convert.ToString(datos["urlFoto"]);



                        videojuegos.Add(videojuego);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return videojuegos.ToArray();
        }

        static public VideojuegoEN videojuegoPorId(int id)
        {
            VideojuegoEN videojuego = new VideojuegoEN();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "SELECT * FROM Videojuego WHERE videojuegoId = " + id + "ORDER BY nombre";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["videojuegoId"])))
                            videojuego.VideojuegoId = Convert.ToInt32(datos["videojuegoId"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["nombre"])))
                            videojuego.Nombre = Convert.ToString(datos["nombre"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["descripcion"])))
                            videojuego.Descripcion = Convert.ToString(datos["descripcion"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["companyia"])))
                            videojuego.Companyia = Convert.ToString(datos["companyia"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["precio"])))
                            videojuego.Precio = Convert.ToInt32(datos["precio"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["urlFoto"])))
                            videojuego.UrlFoto = Convert.ToString(datos["urlFoto"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return videojuego; 
        }

        static public VideojuegoEN[] videojuegoPorNombre(string nombre)
        {
            List<VideojuegoEN> videojuegos = new List<VideojuegoEN>();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();
                    string consulta = "";


                    consulta = "SELECT * FROM Videojugo WHERE nombre like '%" + nombre + "%' ORDER BY Nombre";

                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        VideojuegoEN videojuego = new VideojuegoEN();

                        if (!string.IsNullOrEmpty(Convert.ToString(datos["videojuegoId"])))
                            videojuego.VideojuegoId = Convert.ToInt32(datos["videojuegoId"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["nombre"])))
                            videojuego.Nombre = Convert.ToString(datos["nombre"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["descripcion"])))
                            videojuego.Descripcion = Convert.ToString(datos["descripcion"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["companyia"])))
                            videojuego.Companyia = Convert.ToString(datos["companyia"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["precio"])))
                            videojuego.Precio = Convert.ToInt32(datos["precio"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["urlFoto"])))
                            videojuego.UrlFoto = Convert.ToString(datos["urlFoto"]);

                        videojuegos.Add(videojuego);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return videojuegos.ToArray();
        }

        private bool insertarVideojuego()
        {
            int cantidad = 0;
                using (SqlConnection conexion = new SqlConnection())
                {
                    conexion.ConnectionString = ConnectionString;
                    try
                    {
                        conexion.Open();

                        string consulta = "SELECT count(*) num FROM Videojuego";
                        SqlCommand cmd = new SqlCommand(consulta, conexion);

                        cantidad = (Int32)cmd.ExecuteScalar();

                        consulta = "INSERT INTO Videojuego VALUES (@videojuegoId, @nombre, @descripcion, @precio, @urlFoto, @companyia)";

                        cmd = new SqlCommand(consulta, conexion);

                        cmd.Parameters.Add("@videojuegoId", videojuego.VideojuegoId);
                        cmd.Parameters.Add("@nombre", videojuego.Nombre);
                        cmd.Parameters.Add("@descripcion", videojuego.Descripcion);
                        cmd.Parameters.Add("@precio", videojuego.Precio);
                        cmd.Parameters.Add("@urlFoto", videojuego.UrlFoto);
                        cmd.Parameters.Add("@companyia", videojuego.Companyia);

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

        private bool actualizarVideojuego()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "UPDATE Videojuego SET nombre ='" + videojuego.Nombre + "', descripcion='" + videojuego.Descripcion + "', precio=" + videojuego.Precio + ", urlFoto='" + videojuego.UrlFoto + ", companyia='" + videojuego.Companyia + "' WHERE videojuegoId = " + videojuego.VideojuegoId;
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

        public bool insertarActualizarVideojuego()
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                int cantidad = 0;
                try
                {
                    conexion.Open();
                    
                    string consulta = "SELECT count(*) FROM Videojuego WHERE videojuegoId = " + videojuego.VideojuegoId;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    cantidad = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
                if (cantidad > 0)
                    return actualizarVideojuego();
                else
                    return insertarVideojuego();
            }
        }

        public bool borrarVideojuego()
        {
            bool aR = false;

            SqlConnection conexion = new SqlConnection(ConnectionString);
            try
            {
                conexion.Open();

                string consulta = "DELETE from Videojuego WHERE nombre='" + videojuego.Nombre + "'";

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

        static public int nuevoVideojuego()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "SELECT count(*) num FROM Videojuego";
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
