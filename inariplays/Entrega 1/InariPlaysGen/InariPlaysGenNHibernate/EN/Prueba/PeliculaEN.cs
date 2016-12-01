
using System;

namespace InariPlaysGenNHibernate.EN.Prueba
{
public partial class PeliculaEN
{
/**
 *
 */

private int peliculaId;

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

private System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.ProductoEN> producto;





public virtual int PeliculaId {
        get { return peliculaId; } set { peliculaId = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


public virtual System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.ProductoEN> Producto {
        get { return producto; } set { producto = value;  }
}





public PeliculaEN()
{
        producto = new System.Collections.Generic.List<InariPlaysGenNHibernate.EN.Prueba.ProductoEN>();
}



public PeliculaEN(int peliculaId, string nombre, string descripcion, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.ProductoEN> producto)
{
        this.init (peliculaId, nombre, descripcion, producto);
}


public PeliculaEN(PeliculaEN pelicula)
{
        this.init (pelicula.PeliculaId, pelicula.Nombre, pelicula.Descripcion, pelicula.Producto);
}

private void init (int peliculaId, string nombre, string descripcion, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.ProductoEN> producto)
{
        this.PeliculaId = peliculaId;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PeliculaEN t = obj as PeliculaEN;
        if (t == null)
                return false;
        if (PeliculaId.Equals (t.PeliculaId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.PeliculaId.GetHashCode ();
        return hash;
}
}
}
