
using System;

namespace InariPlaysGenNHibernate.EN.Prueba
{
public partial class MerchandisingEN
{
/**
 *
 */

private int merchandisingId;

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





public virtual int MerchandisingId {
        get { return merchandisingId; } set { merchandisingId = value;  }
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





public MerchandisingEN()
{
        producto = new System.Collections.Generic.List<InariPlaysGenNHibernate.EN.Prueba.ProductoEN>();
}



public MerchandisingEN(int merchandisingId, string nombre, string descripcion, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.ProductoEN> producto)
{
        this.init (merchandisingId, nombre, descripcion, producto);
}


public MerchandisingEN(MerchandisingEN merchandising)
{
        this.init (merchandising.MerchandisingId, merchandising.Nombre, merchandising.Descripcion, merchandising.Producto);
}

private void init (int merchandisingId, string nombre, string descripcion, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.ProductoEN> producto)
{
        this.MerchandisingId = merchandisingId;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MerchandisingEN t = obj as MerchandisingEN;
        if (t == null)
                return false;
        if (MerchandisingId.Equals (t.MerchandisingId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.MerchandisingId.GetHashCode ();
        return hash;
}
}
}
