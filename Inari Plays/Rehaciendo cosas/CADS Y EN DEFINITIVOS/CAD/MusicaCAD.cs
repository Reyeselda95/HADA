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
    class MusicaCAD
    {
        private const string ConnectionString = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\InariDatos.mdf;User Instance=true";

         private MusicaEN mus;

        public MusicaCAD(MusicaEN musica)
		{
			mus = musica;
		}

        static public MusicaEN[] obtenerMusica()
        {
            List<MusicaEN> musica = new List<MusicaEN>();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try { 
                    conexion.Open();

                    string consulta = "SELECT merchandisingId, nombre, descripcion, precio, urlFoto   FROM Musica ORDER BY Nombre";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        MusicaEN music = new MusicaEN();

                        if (!string.IsNullOrEmpty(Convert.ToString(datos["musicaId"])))
                            music.MusicaId = Convert.ToInt32(datos["musicaId"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["nombre"])))
                            music.Nombre = Convert.ToString(datos["nombre"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["descripcion"])))
                            music.Descripcion = Convert.ToString(datos["descripcion"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["precio"])))
                            music.Precio = Convert.ToInt32(datos["precio"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["urlFoto"])))
                            music.UrlFoto = Convert.ToString(datos["urlFoto"]);
                        
                         musica.Add(music);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return musica.ToArray();
        }

        static public MusicaEN musicaPorId(int id)
        {
            MusicaEN music = new MusicaEN();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "SELECT * FROM Musica WHERE musicaId = " + id + "ORDER BY nombre";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["musicaId"])))
                            music.MusicaId = Convert.ToInt32(datos["musicaId"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["nombre"])))
                            music.Nombre = Convert.ToString(datos["nombre"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["descripcion"])))
                            music.Descripcion = Convert.ToString(datos["descripcion"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["precio"])))
                            music.Precio = Convert.ToInt32(datos["precio"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["urlFoto"])))
                            music.UrlFoto = Convert.ToString(datos["urlFoto"]);
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return music; 
        }

        static public MusicaEN[] musicaPorNombre(string nombre)
        {
            List<MusicaEN> musica = new List<MusicaEN>();

            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();
                    string consulta = "";


                    consulta = "SELECT * FROM Musica WHERE nombre like '%" + nombre + "%' ORDER BY Nombre";

                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    SqlDataReader datos = cmd.ExecuteReader();
                    while (datos.Read())
                    {
                        MusicaEN music = new MusicaEN();

                        if (!string.IsNullOrEmpty(Convert.ToString(datos["musicaId"])))
                            music.MusicaId = Convert.ToInt32(datos["musicaId"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["nombre"])))
                            music.Nombre = Convert.ToString(datos["nombre"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["descripcion"])))
                            music.Descripcion = Convert.ToString(datos["descripcion"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["precio"])))
                            music.Precio = Convert.ToInt32(datos["precio"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(datos["urlFoto"])))
                            music.UrlFoto = Convert.ToString(datos["urlFoto"]);

                        musica.Add(music);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();
            }
            return musica.ToArray();
        }

        private bool insertarMusica()
        {
            int cantidad = 0;
                using (SqlConnection conexion = new SqlConnection())
                {
                    conexion.ConnectionString = ConnectionString;
                    try
                    {
                        conexion.Open();

                        string consulta = "SELECT count(*) num FROM Musica";
                        SqlCommand cmd = new SqlCommand(consulta, conexion);

                        cantidad = (Int32)cmd.ExecuteScalar();

                        consulta = "INSERT INTO Musica VALUES (@musicaId, @nombre, @descripcion, @precio, @urlFoto)";

                        cmd = new SqlCommand(consulta, conexion);

                        cmd.Parameters.Add("@musicaId", mus.MusicaId);
                        cmd.Parameters.Add("@nombre", mus.Nombre);
                        cmd.Parameters.Add("@descripcion", mus.Descripcion);
                        cmd.Parameters.Add("@precio", mus.Precio);
                        cmd.Parameters.Add("@urlFoto", mus.UrlFoto);

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

        private bool actualizarMusica()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "UPDATE Musica SET nombre ='" + mus.Nombre + "', descripcion='" + mus.Descripcion + "', precio=" + mus.Precio + ", urlFoto='" + mus.UrlFoto + "' WHERE musicaId = " + mus.MusicaId;
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

        public bool insertarActualizarMusica()
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                int cantidad = 0;
                try
                {
                    conexion.Open();
                    string consulta = "SELECT count(*) FROM Musica WHERE musicaId = " + mus.MusicaId;
                    SqlCommand cmd = new SqlCommand(consulta, conexion);

                    cantidad = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }
                conexion.Close();

                if (cantidad > 0)
                    return actualizarMusica();
                else
                    return insertarMusica();
            }
        }

        public bool borrarMusica()
        {
            bool aR = false;

            SqlConnection conexion = new SqlConnection(ConnectionString);
            try
            {
                conexion.Open();

                string consulta = "DELETE from Musica WHERE nombre='" + mus.Nombre + "'";

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
        static public int nuevaMusica()
        {
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "SELECT count(*) num FROM musica";
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
