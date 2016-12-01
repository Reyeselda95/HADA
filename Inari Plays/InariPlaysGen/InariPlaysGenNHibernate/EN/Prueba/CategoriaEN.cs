
using System;

namespace InariPlaysGenNHibernate.EN.Prueba
{
public partial class CategoriaEN
{
/**
 *
 */

private int categoriaID;

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





public virtual int CategoriaID {
        get { return categoriaID; } set { categoriaID = value;  }
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





public CategoriaEN()
{
        producto = new System.Collections.Generic.List<InariPlaysGenNHibernate.EN.Prueba.ProductoEN>();
}



public CategoriaEN(int categoriaID, string nombre, string descripcion, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.ProductoEN> producto)
{
        this.init (categoriaID, nombre, descripcion, producto);
}


public CategoriaEN(CategoriaEN categoria)
{
        this.init (categoria.CategoriaID, categoria.Nombre, categoria.Descripcion, categoria.Producto);
}

private void init (int categoriaID, string nombre, string descripcion, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.ProductoEN> producto)
{
        this.CategoriaID = categoriaID;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CategoriaEN t = obj as CategoriaEN;
        if (t == null)
                return false;
        if (CategoriaID.Equals (t.CategoriaID))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.CategoriaID.GetHashCode ();
        return hash;
}
}
}
