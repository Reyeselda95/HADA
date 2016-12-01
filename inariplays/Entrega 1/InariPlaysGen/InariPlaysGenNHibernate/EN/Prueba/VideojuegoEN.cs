
using System;

namespace InariPlaysGenNHibernate.EN.Prueba
{
public partial class VideojuegoEN
{
/**
 *
 */

private int videojuegoId;

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





public virtual int VideojuegoId {
        get { return videojuegoId; } set { videojuegoId = value;  }
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





public VideojuegoEN()
{
        producto = new System.Collections.Generic.List<InariPlaysGenNHibernate.EN.Prueba.ProductoEN>();
}



public VideojuegoEN(int videojuegoId, string nombre, string descripcion, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.ProductoEN> producto)
{
        this.init (videojuegoId, nombre, descripcion, producto);
}


public VideojuegoEN(VideojuegoEN videojuego)
{
        this.init (videojuego.VideojuegoId, videojuego.Nombre, videojuego.Descripcion, videojuego.Producto);
}

private void init (int videojuegoId, string nombre, string descripcion, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.ProductoEN> producto)
{
        this.VideojuegoId = videojuegoId;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        VideojuegoEN t = obj as VideojuegoEN;
        if (t == null)
                return false;
        if (VideojuegoId.Equals (t.VideojuegoId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.VideojuegoId.GetHashCode ();
        return hash;
}
}
}
