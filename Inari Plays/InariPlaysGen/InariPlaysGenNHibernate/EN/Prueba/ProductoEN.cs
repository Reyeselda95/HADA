
using System;

namespace InariPlaysGenNHibernate.EN.Prueba
{
public partial class ProductoEN
{
/**
 *
 */

private int productoId;

/**
 *
 */

private string nombre;

/**
 *
 */

private string descripcion;

/**
 *
 */

private string urlFoto;

/**
 *
 */

private float precio;

/**
 *
 */

private int stock;

/**
 *
 */

private System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN> liniaPedido;

/**
 *
 */

private System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.CestaEN> cesta;

/**
 *
 */

private InariPlaysGenNHibernate.EN.Prueba.VideojuegoEN videojuego;

/**
 *
 */

private InariPlaysGenNHibernate.EN.Prueba.MusicaEN musica;

/**
 *
 */

private InariPlaysGenNHibernate.EN.Prueba.MerchandisingEN merchandising;

/**
 *
 */

private InariPlaysGenNHibernate.EN.Prueba.PeliculaEN pelicula;





public virtual int ProductoId {
        get { return productoId; } set { productoId = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


public virtual string UrlFoto {
        get { return urlFoto; } set { urlFoto = value;  }
}


public virtual float Precio {
        get { return precio; } set { precio = value;  }
}


public virtual int Stock {
        get { return stock; } set { stock = value;  }
}


public virtual System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN> LiniaPedido {
        get { return liniaPedido; } set { liniaPedido = value;  }
}


public virtual System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.CestaEN> Cesta {
        get { return cesta; } set { cesta = value;  }
}


public virtual InariPlaysGenNHibernate.EN.Prueba.VideojuegoEN Videojuego {
        get { return videojuego; } set { videojuego = value;  }
}


public virtual InariPlaysGenNHibernate.EN.Prueba.MusicaEN Musica {
        get { return musica; } set { musica = value;  }
}


public virtual InariPlaysGenNHibernate.EN.Prueba.MerchandisingEN Merchandising {
        get { return merchandising; } set { merchandising = value;  }
}


public virtual InariPlaysGenNHibernate.EN.Prueba.PeliculaEN Pelicula {
        get { return pelicula; } set { pelicula = value;  }
}





public ProductoEN()
{
        liniaPedido = new System.Collections.Generic.List<InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN>();
        cesta = new System.Collections.Generic.List<InariPlaysGenNHibernate.EN.Prueba.CestaEN>();
}



public ProductoEN(int productoId, string nombre, string descripcion, string urlFoto, float precio, int stock, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN> liniaPedido, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.CestaEN> cesta, InariPlaysGenNHibernate.EN.Prueba.VideojuegoEN videojuego, InariPlaysGenNHibernate.EN.Prueba.MusicaEN musica, InariPlaysGenNHibernate.EN.Prueba.MerchandisingEN merchandising, InariPlaysGenNHibernate.EN.Prueba.PeliculaEN pelicula)
{
        this.init (productoId, nombre, descripcion, urlFoto, precio, stock, liniaPedido, cesta, videojuego, musica, merchandising, pelicula);
}


public ProductoEN(ProductoEN producto)
{
        this.init (producto.ProductoId, producto.Nombre, producto.Descripcion, producto.UrlFoto, producto.Precio, producto.Stock, producto.LiniaPedido, producto.Cesta, producto.Videojuego, producto.Musica, producto.Merchandising, producto.Pelicula);
}

private void init (int productoId, string nombre, string descripcion, string urlFoto, float precio, int stock, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN> liniaPedido, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.CestaEN> cesta, InariPlaysGenNHibernate.EN.Prueba.VideojuegoEN videojuego, InariPlaysGenNHibernate.EN.Prueba.MusicaEN musica, InariPlaysGenNHibernate.EN.Prueba.MerchandisingEN merchandising, InariPlaysGenNHibernate.EN.Prueba.PeliculaEN pelicula)
{
        this.ProductoId = productoId;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.UrlFoto = urlFoto;

        this.Precio = precio;

        this.Stock = stock;

        this.LiniaPedido = liniaPedido;

        this.Cesta = cesta;

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
}
}
