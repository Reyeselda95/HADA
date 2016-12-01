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
    class ProductoCAD
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

        private ProductoEN product;

           public ProductoCAD(ProductoEN producto)
		{
			product = producto;
		}

           static public ProductoEN[] obtenerProductos()
           {
               List<ProductoEN> productos = new List<ProductoEN>();

               using (SqlConnection conexion = new SqlConnection())
               {
                   conexion.ConnectionString = ConnectionString;
                   try
                   {
                       conexion.Open();

                       string consulta = "SELECT * FROM Producto ORDER BY Nombre";
                       SqlCommand cmd = new SqlCommand(consulta, conexion);

                       SqlDataReader datos = cmd.ExecuteReader();
                       while (datos.Read())
                       {
                           ProductoEN product = new ProductoEN();

                           product.ProductoId = Convert.ToInt32(datos["productoId"]);
                           product.Nombre = Convert.ToString(datos["nombre"]);
                           product.Descripcion = Convert.ToString(datos["descripcion"]);
                           product.Precio = Convert.ToSingle(datos["precio"]);
                           product.Stock = Convert.ToInt32(datos["stock"]);
                           product.Videojuego = VideojuegoCAD.videojuegoPorId(Convert.ToInt32(datos["FK_videojuegoId"]));
                           product.Musica = MusicaCAD.musicaPorId(Convert.ToInt32(datos["FK_musicaId"]));
                           product.Merchandising = MerchandisingCAD.merchanPorId(Convert.ToInt32(datos["FK_merchandisingId"]));
                           product.Pelicula = PeliculaCAD.peliculaPorId(Convert.ToInt32(datos["FK_peliculaId"]));

                           productos.Add(product);
                       }
                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine("No conecta a la base de datos: " + ex);
                   }
                   conexion.Close();
               }
               return productos.ToArray();
           }

           static public ProductoEN productoPorId(int id)
           {
               ProductoEN product = new ProductoEN();

               using (SqlConnection conexion = new SqlConnection())
               {
                   conexion.ConnectionString = ConnectionString;
                   try
                   {
                       conexion.Open();

                       string consulta = "SELECT * FROM Producto WHERE productoId like " + id + " ORDER BY nombre";
                       SqlCommand cmd = new SqlCommand(consulta, conexion);

                       SqlDataReader datos = cmd.ExecuteReader();
                       while (datos.Read())
                       {
                               product.ProductoId = Convert.ToInt32(datos["productoId"]);
                               product.Nombre = Convert.ToString(datos["nombre"]);
                               product.Descripcion = Convert.ToString(datos["descripcion"]);
                               product.Precio = Convert.ToSingle(datos["precio"]);
                               product.Stock = Convert.ToInt32(datos["stock"]);
                               product.Videojuego = VideojuegoCAD.videojuegoPorId(Convert.ToInt32(datos["FK_videojuegoId"]));
                               product.Musica = MusicaCAD.musicaPorId(Convert.ToInt32(datos["FK_musicaId"]));
                               product.Merchandising = MerchandisingCAD.merchanPorId(Convert.ToInt32(datos["FK_merchandisingId"]));
                               product.Pelicula = PeliculaCAD.peliculaPorId(Convert.ToInt32(datos["FK_peliculaId"]));
                       }
                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine("No conecta a la base de datos: " + ex);
                   }
                   conexion.Close();
               }
               return product;
           }

           private bool insertarProducto()
           {
               int cantidad = 0;
               using (SqlConnection conexion = new SqlConnection())
               {
                   conexion.ConnectionString = ConnectionString;
                   try
                   {
                       conexion.Open();

                       string consulta = "SELECT count(*) num FROM Producto";
                       SqlCommand cmd = new SqlCommand(consulta, conexion);

                       cantidad = (Int32)cmd.ExecuteScalar();

                       consulta = "INSERT INTO Producto VALUES (@productoId, @nombre, @descripcion, @precio, @stock, @fk_videojuego, @fk_musica, @fk_merchandising, @fk_pelicula)";

                       cmd = new SqlCommand(consulta, conexion);

                       cmd.Parameters.Add("@productoId", product.ProductoId);
                       cmd.Parameters.Add("@nombre", product.Nombre);
                       cmd.Parameters.Add("@descripcion", product.Descripcion);
                       cmd.Parameters.Add("@precio", product.Precio);
                       cmd.Parameters.Add("@stock", product.Stock);
                       if (product.Videojuego != null)
                       {
                           cmd.Parameters.Add("@fk_videojuego", product.Videojuego.VideojuegoId);
                       }
                       else {
                           cmd.Parameters.Add("@fk_videojuego", Convert.DBNull);
                       }
                       if (product.Musica != null)
                       {
                           cmd.Parameters.Add("@fk_musica", product.Musica.MusicaId);
                       }
                       else {
                           cmd.Parameters.Add("@fk_musica", Convert.DBNull);
                       }
                       if (product.Merchandising != null)
                       {
                           cmd.Parameters.Add("@fk_merchandising", product.Merchandising.MerchandisingId);
                       }
                       else{
                           cmd.Parameters.Add("@fk_merchandising", Convert.DBNull);
                       }
                       if (product.Pelicula != null)
                       {
                           cmd.Parameters.Add("@fk_pelicula", product.Pelicula.PeliculaId);
                       }
                       else {
                           cmd.Parameters.Add("@fk_pelicula", Convert.DBNull);
                       }
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

           private bool actualizarProducto()
           {
               int cantidad = 0;
               using (SqlConnection conexion = new SqlConnection())
               {
                   conexion.ConnectionString = ConnectionString;
                   try
                   {
                       conexion.Open();

                       string consulta = "UPDATE Producto SET  descripcion=@descripcion, precio=@precio, FK_videojuegoId=@fk_videojuego, FK_musicaId=@fk_musica, FK_merchandisingId=@fk_merchandising, FK_peliculaId=@fk_pelicula WHERE nombre like '% @nombre %'";
                       SqlCommand cmd = new SqlCommand(consulta, conexion);

                       cmd.Parameters.Add("@productoId", product.ProductoId);
                       cmd.Parameters.Add("@nombre", product.Nombre);
                       cmd.Parameters.Add("@descripcion", product.Descripcion);
                       cmd.Parameters.Add("@precio", product.Precio);
                       cmd.Parameters.Add("@stock", product.Stock);
                       if (product.Videojuego != null){
                           cmd.Parameters.Add("@fk_videojuego", product.Videojuego.VideojuegoId);
                       }
                       else{
                           cmd.Parameters.Add("@fk_videojuego", Convert.DBNull);
                       }
                       if (product.Musica != null){
                           cmd.Parameters.Add("@fk_musica", product.Musica.MusicaId);
                       }
                       else{
                           cmd.Parameters.Add("@fk_musica", Convert.DBNull);
                       }
                       if (product.Merchandising != null) {
                           cmd.Parameters.Add("@fk_merchandising", product.Merchandising.MerchandisingId);
                       }
                       else{
                           cmd.Parameters.Add("@fk_merchandising", Convert.DBNull);
                       }
                       if (product.Pelicula != null){
                           cmd.Parameters.Add("@fk_pelicula", product.Pelicula.PeliculaId);
                       }
                       else {
                           cmd.Parameters.Add("@fk_pelicula", Convert.DBNull);
                       }

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

           public bool insertarActualizarProducto()
           {
               using (SqlConnection conexion = new SqlConnection(ConnectionString))
               {
                   int cantidad = 0;
                   try
                   {
                       conexion.Open();
                       
                       string consulta = "SELECT count(*) FROM Producto WHERE nombre like '%" + product.Nombre+"%'";
                       SqlCommand cmd = new SqlCommand(consulta, conexion);
                       cantidad = (Int32)cmd.ExecuteScalar();
                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine("No conecta a la base de datos: " + ex);
                   }
                   conexion.Close();
                  
                   if (cantidad > 0)
                       return actualizarProducto();
                   else
                       return insertarProducto();
               }
           }

           public bool borrarProducto()
           {
               bool aR = false;

               SqlConnection conexion = new SqlConnection(ConnectionString);
               try
               {
                   conexion.Open();

                   string consulta = "DELETE from Producto WHERE nombre like'%" + product.Nombre + "%'";

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

           static public int nuevoProducto() { 
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();

                    string consulta = "SELECT count(*) num FROM Producto";
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
