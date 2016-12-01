

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using InariPlaysGenNHibernate.EN.Prueba;
using InariPlaysGenNHibernate.CAD.Prueba;

namespace InariPlaysGenNHibernate.CEN.Prueba
{
public partial class VideojuegoCEN
{
private IVideojuegoCAD _IVideojuegoCAD;

public VideojuegoCEN()
{
        this._IVideojuegoCAD = new VideojuegoCAD ();
}

public VideojuegoCEN(IVideojuegoCAD _IVideojuegoCAD)
{
        this._IVideojuegoCAD = _IVideojuegoCAD;
}

public IVideojuegoCAD get_IVideojuegoCAD ()
{
        return this._IVideojuegoCAD;
}

public int New_ (string p_nombre, string p_descripcion)
{
        VideojuegoEN videojuegoEN = null;
        int oid;

        //Initialized VideojuegoEN
        videojuegoEN = new VideojuegoEN ();
        videojuegoEN.Nombre = p_nombre;

        videojuegoEN.Descripcion = p_descripcion;

        //Call to VideojuegoCAD

        oid = _IVideojuegoCAD.New_ (videojuegoEN);
        return oid;
}

public void Modify (int p_Videojuego_OID, string p_nombre, string p_descripcion)
{
        VideojuegoEN videojuegoEN = null;

        //Initialized VideojuegoEN
        videojuegoEN = new VideojuegoEN ();
        videojuegoEN.VideojuegoId = p_Videojuego_OID;
        videojuegoEN.Nombre = p_nombre;
        videojuegoEN.Descripcion = p_descripcion;
        //Call to VideojuegoCAD

        _IVideojuegoCAD.Modify (videojuegoEN);
}

public void Destroy (int videojuegoId)
{
        _IVideojuegoCAD.Destroy (videojuegoId);
}
}
}
