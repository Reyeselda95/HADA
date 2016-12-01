

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
public partial class AdministradorCEN
{
private IAdministradorCAD _IAdministradorCAD;

public AdministradorCEN()
{
        this._IAdministradorCAD = new AdministradorCAD ();
}

public AdministradorCEN(IAdministradorCAD _IAdministradorCAD)
{
        this._IAdministradorCAD = _IAdministradorCAD;
}

public IAdministradorCAD get_IAdministradorCAD ()
{
        return this._IAdministradorCAD;
}

public int NewAdmin (string p_nombre, string p_apellidos, string p_password)
{
        AdministradorEN administradorEN = null;
        int oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Nombre = p_nombre;

        administradorEN.Apellidos = p_apellidos;

        administradorEN.Password = p_password;

        //Call to AdministradorCAD

        oid = _IAdministradorCAD.NewAdmin (administradorEN);
        return oid;
}

public void ModificarAdmin (int p_Administrador_OID, string p_nombre, string p_apellidos, string p_password)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Id = p_Administrador_OID;
        administradorEN.Nombre = p_nombre;
        administradorEN.Apellidos = p_apellidos;
        administradorEN.Password = p_password;
        //Call to AdministradorCAD

        _IAdministradorCAD.ModificarAdmin (administradorEN);
}

public void EliminarAdmin (int id)
{
        _IAdministradorCAD.EliminarAdmin (id);
}
}
}
