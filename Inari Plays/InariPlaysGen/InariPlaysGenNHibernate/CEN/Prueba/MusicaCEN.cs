

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
public partial class MusicaCEN
{
private IMusicaCAD _IMusicaCAD;

public MusicaCEN()
{
        this._IMusicaCAD = new MusicaCAD ();
}

public MusicaCEN(IMusicaCAD _IMusicaCAD)
{
        this._IMusicaCAD = _IMusicaCAD;
}

public IMusicaCAD get_IMusicaCAD ()
{
        return this._IMusicaCAD;
}

public int New_ (string p_nombre, string p_descripcion)
{
        MusicaEN musicaEN = null;
        int oid;

        //Initialized MusicaEN
        musicaEN = new MusicaEN ();
        musicaEN.Nombre = p_nombre;

        musicaEN.Descripcion = p_descripcion;

        //Call to MusicaCAD

        oid = _IMusicaCAD.New_ (musicaEN);
        return oid;
}

public void Modify (int p_musica_OID, string p_nombre, string p_descripcion)
{
        MusicaEN musicaEN = null;

        //Initialized MusicaEN
        musicaEN = new MusicaEN ();
        musicaEN.MusicaId = p_musica_OID;
        musicaEN.Nombre = p_nombre;
        musicaEN.Descripcion = p_descripcion;
        //Call to MusicaCAD

        _IMusicaCAD.Modify (musicaEN);
}

public void Destroy (int musicaId)
{
        _IMusicaCAD.Destroy (musicaId);
}
}
}
