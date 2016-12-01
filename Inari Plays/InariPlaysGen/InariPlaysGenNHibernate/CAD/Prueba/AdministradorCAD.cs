
using System;
using System.Text;
using InariPlaysGenNHibernate.CEN.Prueba;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using InariPlaysGenNHibernate.EN.Prueba;
using InariPlaysGenNHibernate.Exceptions;

namespace InariPlaysGenNHibernate.CAD.Prueba
{
public partial class AdministradorCAD : BasicCAD, IAdministradorCAD
{
public AdministradorCAD() : base ()
{
}

public AdministradorCAD(ISession sessionAux) : base (sessionAux)
{
}



public AdministradorEN ReadOIDDefault (int id)
{
        AdministradorEN administradorEN = null;

        try
        {
                SessionInitializeTransaction ();
                administradorEN = (AdministradorEN)session.Get (typeof(AdministradorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in AdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return administradorEN;
}


public int NewAdmin (AdministradorEN administrador)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (administrador);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in AdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return administrador.Id;
}

public void ModificarAdmin (AdministradorEN administrador)
{
        try
        {
                SessionInitializeTransaction ();
                AdministradorEN administradorEN = (AdministradorEN)session.Load (typeof(AdministradorEN), administrador.Id);

                administradorEN.Nombre = administrador.Nombre;


                administradorEN.Apellidos = administrador.Apellidos;


                administradorEN.Password = administrador.Password;

                session.Update (administradorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in AdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarAdmin (int id)
{
        try
        {
                SessionInitializeTransaction ();
                AdministradorEN administradorEN = (AdministradorEN)session.Load (typeof(AdministradorEN), id);
                session.Delete (administradorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in AdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
