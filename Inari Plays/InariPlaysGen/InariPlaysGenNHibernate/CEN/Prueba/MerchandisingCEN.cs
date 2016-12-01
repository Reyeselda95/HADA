

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
public partial class MerchandisingCEN
{
private IMerchandisingCAD _IMerchandisingCAD;

public MerchandisingCEN()
{
        this._IMerchandisingCAD = new MerchandisingCAD ();
}

public MerchandisingCEN(IMerchandisingCAD _IMerchandisingCAD)
{
        this._IMerchandisingCAD = _IMerchandisingCAD;
}

public IMerchandisingCAD get_IMerchandisingCAD ()
{
        return this._IMerchandisingCAD;
}

public int New_ (string p_nombre, string p_descripcion)
{
        MerchandisingEN merchandisingEN = null;
        int oid;

        //Initialized MerchandisingEN
        merchandisingEN = new MerchandisingEN ();
        merchandisingEN.Nombre = p_nombre;

        merchandisingEN.Descripcion = p_descripcion;

        //Call to MerchandisingCAD

        oid = _IMerchandisingCAD.New_ (merchandisingEN);
        return oid;
}

public void Modify (int p_merchandising_OID, string p_nombre, string p_descripcion)
{
        MerchandisingEN merchandisingEN = null;

        //Initialized MerchandisingEN
        merchandisingEN = new MerchandisingEN ();
        merchandisingEN.MerchandisingId = p_merchandising_OID;
        merchandisingEN.Nombre = p_nombre;
        merchandisingEN.Descripcion = p_descripcion;
        //Call to MerchandisingCAD

        _IMerchandisingCAD.Modify (merchandisingEN);
}

public void Destroy (int merchandisingId)
{
        _IMerchandisingCAD.Destroy (merchandisingId);
}
}
}
