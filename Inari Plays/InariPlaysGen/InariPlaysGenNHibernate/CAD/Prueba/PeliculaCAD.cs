
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
public partial class PeliculaCAD : BasicCAD, IPeliculaCAD
{
public PeliculaCAD() : base ()
{
}

public PeliculaCAD(ISession sessionAux) : base (sessionAux)
{
}



public PeliculaEN ReadOIDDefault (int peliculaId)
{
        PeliculaEN peliculaEN = null;

        try
        {
                SessionInitializeTransaction ();
                peliculaEN = (PeliculaEN)session.Get (typeof(PeliculaEN), peliculaId);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return peliculaEN;
}


public int New_ (PeliculaEN pelicula)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (pelicula);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pelicula.PeliculaId;
}

public void Modify (PeliculaEN pelicula)
{
        try
        {
                SessionInitializeTransaction ();
                PeliculaEN peliculaEN = (PeliculaEN)session.Load (typeof(PeliculaEN), pelicula.PeliculaId);

                peliculaEN.Nombre = pelicula.Nombre;


                peliculaEN.Descripcion = pelicula.Descripcion;

                session.Update (peliculaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int peliculaId)
{
        try
        {
                SessionInitializeTransaction ();
                PeliculaEN peliculaEN = (PeliculaEN)session.Load (typeof(PeliculaEN), peliculaId);
                session.Delete (peliculaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in PeliculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
