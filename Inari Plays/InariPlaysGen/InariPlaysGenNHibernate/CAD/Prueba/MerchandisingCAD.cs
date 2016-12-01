
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
public partial class MerchandisingCAD : BasicCAD, IMerchandisingCAD
{
public MerchandisingCAD() : base ()
{
}

public MerchandisingCAD(ISession sessionAux) : base (sessionAux)
{
}



public MerchandisingEN ReadOIDDefault (int merchandisingId)
{
        MerchandisingEN merchandisingEN = null;

        try
        {
                SessionInitializeTransaction ();
                merchandisingEN = (MerchandisingEN)session.Get (typeof(MerchandisingEN), merchandisingId);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in MerchandisingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return merchandisingEN;
}


public int New_ (MerchandisingEN merchandising)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (merchandising);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in MerchandisingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return merchandising.MerchandisingId;
}

public void Modify (MerchandisingEN merchandising)
{
        try
        {
                SessionInitializeTransaction ();
                MerchandisingEN merchandisingEN = (MerchandisingEN)session.Load (typeof(MerchandisingEN), merchandising.MerchandisingId);

                merchandisingEN.Nombre = merchandising.Nombre;


                merchandisingEN.Descripcion = merchandising.Descripcion;

                session.Update (merchandisingEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in MerchandisingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int merchandisingId)
{
        try
        {
                SessionInitializeTransaction ();
                MerchandisingEN merchandisingEN = (MerchandisingEN)session.Load (typeof(MerchandisingEN), merchandisingId);
                session.Delete (merchandisingEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in MerchandisingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
