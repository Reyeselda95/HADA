
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
public partial class CestaCAD : BasicCAD, ICestaCAD
{
public CestaCAD() : base ()
{
}

public CestaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CestaEN ReadOIDDefault (int Iden)
{
        CestaEN cestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cestaEN = (CestaEN)session.Get (typeof(CestaEN), Iden);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cestaEN;
}


public int Crear (CestaEN cesta)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (cesta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cesta.Iden;
}

public void Borrar (int Iden)
{
        try
        {
                SessionInitializeTransaction ();
                CestaEN cestaEN = (CestaEN)session.Load (typeof(CestaEN), Iden);
                session.Delete (cestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in CestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
