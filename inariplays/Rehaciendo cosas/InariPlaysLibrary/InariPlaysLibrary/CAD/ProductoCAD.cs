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
    class ProductoCAD
    {
        //Constante de la consexión de la base de datos
        private const string ConnectionString = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|InariDatos.mdf;User Instance=true";

        //Variable privada de un articulo interno en ProductoCAD para utilizarlo al insertar y actualizar producto
        private ProductoEN product;

        //Constructor de sobrecarga
           public ProductoCAD(ProductoEN producto)
		{
			product = producto;
		}

           //Función que devuelve una lista con todos los productos de la base de datos
           static public ProductoEN[] obtenerProductos()
           {
               List<ProductoEN> productos = new List<ProductoEN>();

               using (SqlConnection conexion = new SqlConnection())
               {
                   conexion.ConnectionString = ConnectionString;
                   try
                   {
                       conexion.Open();//abre la conexion

                       string consulta = "SELECT productoId, nombre, descripcion, precio, stock, FK_videojuegoIdVideojuego_idVideojuego, FK_musicaIdMusica_idMusica , FK_merchandisingIdMerchandising_idMerchandising, FK_peliculaIdPelicula_idPelicula    FROM Producto ORDER BY Nombre";
                       SqlCommand cmd = new SqlCommand(consulta, conexion);

                       SqlDataReader datos = cmd.ExecuteReader();
                       while (datos.Read())
                       {
                           ProductoEN product = new ProductoEN();

                           if (!string.IsNullOrEmpty(Convert.ToString(datos["productoId"])))
                               product.ProductoId = Convert.ToInt32(datos["productoId"]);
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["nombre"])))
                               product.Nombre = Convert.ToString(datos["nombre"]);
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["descripcion"])))
                               product.Descripcion = Convert.ToString(datos["descripcion"]);
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["precio"])))
                               product.Precio = Convert.ToInt32(datos["precio"]);
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["stock"])))
                               product.Stock = Convert.ToInt32(datos["stock"]);
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["FK_videojuegoIdVideojuego_idVideojuego"])))
                               product.Videojuego = VideojuegoCAD.videojuegoPorId(Convert.ToInt32(datos["FK_videojuegoIdVideojuego_idVideojuego"]));
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["FK_musicaIdMusica_idMusica"])))
                               product.Musica = MusicaCAD.musicaPorId(Convert.ToInt32(datos["FK_musicaIdMusica_idMusica"]));
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["FK_merchandisingIdMerchandising_idMerchandising"])))
                               product.Merchandising = MerchandisingCAD.merchanPorId(Convert.ToInt32(datos["FK_merchandisingIdMerchandising_idMerchandising"]));
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["FK_peliculaIdPelicula_idPelicula "])))
                               product.Pelicula = PeliculaCAD.peliculaPorId(Convert.ToInt32(datos["FK_peliculaIdPelicula_idPelicula"]));


                           productos.Add(product);
                       }
                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine("No conecta a la base de datos: " + ex);
                   }
                   conexion.Close();//cerrar conexion
               }
               return productos.ToArray();
           }

        //Funcion que devuelve un producto que tiene la misma id que la que le pasa por parametro
           static public ProductoEN productoPorId(int id)
           {
               ProductoEN product = new ProductoEN();

               using (SqlConnection conexion = new SqlConnection())
               {
                   conexion.ConnectionString = ConnectionString;
                   try
                   {
                       conexion.Open();//abre la conexion

                       string consulta = "SELECT * FROM Producto WHERE productoId = " + id + "ORDER BY nombre";
                       SqlCommand cmd = new SqlCommand(consulta, conexion);

                       SqlDataReader datos = cmd.ExecuteReader();
                       while (datos.Read())
                       {
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["productoId"])))
                               product.ProductoId = Convert.ToInt32(datos["productoId"]);
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["nombre"])))
                               product.Nombre = Convert.ToString(datos["nombre"]);
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["descripcion"])))
                               product.Descripcion = Convert.ToString(datos["descripcion"]);
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["precio"])))
                               product.Precio = Convert.ToInt32(datos["precio"]);
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["stock"])))
                               product.Stock = Convert.ToInt32(datos["stock"]);
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["FK_videojuegoIdVideojuego_idVideojuego"])))
                               product.Videojuego = VideojuegoCAD.videojuegoPorId(Convert.ToInt32(datos["FK_videojuegoIdVideojuego_idVideojuego"]));
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["FK_musicaIdMusica_idMusica"])))
                               product.Musica = MusicaCAD.musicaPorId(Convert.ToInt32(datos["FK_musicaIdMusica_idMusica"]));
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["FK_merchandisingIdMerchandising_idMerchandising"])))
                               product.Merchandising = MerchandisingCAD.merchanPorId(Convert.ToInt32(datos["FK_merchandisingIdMerchandising_idMerchandising"]));
                           if (!string.IsNullOrEmpty(Convert.ToString(datos["FK_peliculaIdPelicula_idPelicula "])))
                               product.Pelicula = PeliculaCAD.peliculaPorId(Convert.ToInt32(datos["FK_peliculaIdPelicula_idPelicula"]));
                       }
                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine("No conecta a la base de datos: " + ex);
                   }
                   conexion.Close();//cerrar conexion
               }
               return product;
           }

        //Funcion booleana que devuelve true si el producto se ha podido insertar correctamente
           private bool insertarProducto()
           {
               int cantidad = 0;
               using (SqlConnection conexion = new SqlConnection())
               {
                   conexion.ConnectionString = ConnectionString;
                   try
                   {
                       conexion.Open();//abre la conexion

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
                       cmd.Parameters.Add("@fk_videojuego", product.Videojuego.VideojuegoId);
                       cmd.Parameters.Add("@fk_musica", product.Musica.MusicaId);
                       cmd.Parameters.Add("@fk_merchandising", product.Merchandising.MerchandisingId);
                       cmd.Parameters.Add("@fk_pelicula", product.Pelicula.PeliculaId);

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

        //Funcion booleana que devuelve true si el producto se ha podido actualizar correctamente
           private bool actualizarProducto()
           {
               int cantidad = 0;
               using (SqlConnection conexion = new SqlConnection())
               {
                   conexion.ConnectionString = ConnectionString;
                   try
                   {
                       conexion.Open();//abre la conexion

                       string consulta = "UPDATE Producto SET nombre ='" + product.Nombre + "', descripcion='" + product.Descripcion + "', precio=" + product.Precio + "', FK_videojuegoIdVideojuego_idVideojuego=" + product.Videojuego.VideojuegoId + "', FK_musicaIdMusica_idMusica=" + product.Musica.MusicaId + "', FK_merchandisingIdMerchandising_idMerchandising=" + product.Merchandising.MerchandisingId + "' FK_peliculaIdPelicula_idPelicula=" + product.Pelicula.PeliculaId + "' WHERE productoId = " + product.ProductoId;
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

        //Funcion booleana que devuelve true si el producto si se pude insertar o actualizar el producto correctamente
           public bool insertarActualizarProducto()
           {
               using (SqlConnection conexion = new SqlConnection(ConnectionString))
               {
                   int cantidad = 0;
                   try
                   {
                       
                       conexion.Open();//abre la conexion
                       
                       string consulta = "SELECT count(*) FROM Producto WHERE productoId = " + product.ProductoId;
                       SqlCommand cmd = new SqlCommand(consulta, conexion);
                       cantidad = (Int32)cmd.ExecuteScalar();
                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine("No conecta a la base de datos: " + ex);
                   }
                   conexion.Close();//cerrar conexion
                  
                   if (cantidad > 0)
                       return actualizarProducto();
                   else
                       return insertarProducto();
               }
           }

        //Funcion booleana que devuelve true si el producto se puede borrar correctamente
           public bool borrarProducto()
           {
               bool aR = false;

               SqlConnection conexion = new SqlConnection(ConnectionString);
               try
               {
                   conexion.Open();//abre la conexion

                   string consulta = "DELETE from Producto WHERE nombre='" + product.Nombre + "'";

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

        //Funcion que introduce un nuevo producto
           static public int nuevoProducto() { 
            int cantidad = 0;
            using (SqlConnection conexion = new SqlConnection())
            {
                conexion.ConnectionString = ConnectionString;
                try
                {
                    conexion.Open();//abre la conexion

                    string consulta = "SELECT count(*) num FROM Producto";
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
