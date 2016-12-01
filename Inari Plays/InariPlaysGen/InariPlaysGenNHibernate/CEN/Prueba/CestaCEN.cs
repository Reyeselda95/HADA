

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
public partial class CestaCEN
{
private ICestaCAD _ICestaCAD;

public CestaCEN()
{
        this._ICestaCAD = new CestaCAD ();
}

public CestaCEN(ICestaCAD _ICestaCAD)
{
        this._ICestaCAD = _ICestaCAD;
}

public ICestaCAD get_ICestaCAD ()
{
        return this._ICestaCAD;
}

public int Crear (int p_Iden, Nullable<DateTime> p_fecha)
{
        CestaEN cestaEN = null;
        int oid;

        //Initialized CestaEN
        cestaEN = new CestaEN ();
        cestaEN.Iden = p_Iden;

        cestaEN.Fecha = p_fecha;

        //Call to CestaCAD

        oid = _ICestaCAD.Crear (cestaEN);
        return oid;
}

public void Borrar (int Iden)
{
        _ICestaCAD.Borrar (Iden);
}
}
}
