

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
public partial class PeliculaCEN
{
private IPeliculaCAD _IPeliculaCAD;

public PeliculaCEN()
{
        this._IPeliculaCAD = new PeliculaCAD ();
}

public PeliculaCEN(IPeliculaCAD _IPeliculaCAD)
{
        this._IPeliculaCAD = _IPeliculaCAD;
}

public IPeliculaCAD get_IPeliculaCAD ()
{
        return this._IPeliculaCAD;
}

public int New_ (string p_nombre, string p_descripcion)
{
        PeliculaEN peliculaEN = null;
        int oid;

        //Initialized PeliculaEN
        peliculaEN = new PeliculaEN ();
        peliculaEN.Nombre = p_nombre;

        peliculaEN.Descripcion = p_descripcion;

        //Call to PeliculaCAD

        oid = _IPeliculaCAD.New_ (peliculaEN);
        return oid;
}

public void Modify (int p_pelicula_OID, string p_nombre, string p_descripcion)
{
        PeliculaEN peliculaEN = null;

        //Initialized PeliculaEN
        peliculaEN = new PeliculaEN ();
        peliculaEN.PeliculaId = p_pelicula_OID;
        peliculaEN.Nombre = p_nombre;
        peliculaEN.Descripcion = p_descripcion;
        //Call to PeliculaCAD

        _IPeliculaCAD.Modify (peliculaEN);
}

public void Destroy (int peliculaId)
{
        _IPeliculaCAD.Destroy (peliculaId);
}
}
}
