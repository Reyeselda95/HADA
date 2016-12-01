using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InariPlaysLibrary.CAD;

namespace InariPlaysLibrary.EN
{
        public class ProductoEN
        {

                private int productoId;

                private string nombre;

                private string descripcion;

                private float precio;

                private int stock;

                private VideojuegoEN videojuego;

                private MusicaEN musica;

                private MerchandisingEN merchandising;

                private PeliculaEN pelicula;

                public virtual int ProductoId {
                        get { return productoId; } set { productoId = value;  }
                }

                public virtual string Nombre {
                        get { return nombre; } set { nombre = value;  }
                }


                public virtual string Descripcion {
                        get { return descripcion; } set { descripcion = value;  }
                }


                public virtual float Precio {
                        get { return precio; } set { precio = value;  }
                }


                public virtual int Stock {
                        get { return stock; } set { stock = value;  }
                }

                public virtual VideojuegoEN Videojuego {
                        get { return videojuego; } set { videojuego = value;  }
                }

                public virtual MusicaEN Musica {
                        get { return musica; } set { musica = value;  }
                }

                public virtual MerchandisingEN Merchandising {
                        get { return merchandising; } set { merchandising = value;  }
                }

                public virtual PeliculaEN Pelicula {
                        get { return pelicula; } set { pelicula = value;  }
                }

                public ProductoEN(){}
            
                public ProductoEN(int productoId, string nombre, string descripcion, float precio, int stock, VideojuegoEN videojuego, MusicaEN musica, MerchandisingEN merchandising, PeliculaEN pelicula)
                {
                        this.init (productoId, nombre, descripcion, precio, stock, videojuego, musica, merchandising, pelicula);
                }


                public ProductoEN(ProductoEN producto)
                {
                        this.init (producto.ProductoId, producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock, producto.Videojuego, producto.Musica, producto.Merchandising, producto.Pelicula);
                }

                private void init (int productoId, string nombre, string descripcion, float precio, int stock, VideojuegoEN videojuego, MusicaEN musica, MerchandisingEN merchandising, PeliculaEN pelicula)
                {
                        this.ProductoId = productoId;


                        this.Nombre = nombre;

                        this.Descripcion = descripcion;

                        this.Precio = precio;

                        this.Stock = stock;

                        this.Videojuego = videojuego;

                        this.Musica = musica;

                        this.Merchandising = merchandising;

                        this.Pelicula = pelicula;
                }

                public override bool Equals (object obj)
                {
                        if (obj == null)
                                return false;
                        ProductoEN t = obj as ProductoEN;
                        if (t == null)
                                return false;
                        if (ProductoId.Equals (t.ProductoId))
                                return true;
                        else
                                return false;
                }

                public override int GetHashCode ()
                {
                        int hash = 13;

                        hash += this.ProductoId.GetHashCode ();
                        return hash;
                }

                public ProductoEN[] dameTodosProductos() {
                    return ProductoCAD.obtenerProductos();
                }

                public ProductoEN productoPorId() {
                    return ProductoCAD.productoPorId(this.ProductoId);
                }

                public bool borrarProducto() {
                    ProductoCAD producto = new ProductoCAD(this);
                    return producto.borrarProducto();
                }

                public int nuevoProducto() { 
                    return ProductoCAD.nuevoProducto();
                }
                public bool insertarActualizarProducto()
                {
                    ProductoCAD producto = new ProductoCAD(this);
                    return producto.insertarActualizarProducto();
                }
        }
}