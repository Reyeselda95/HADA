
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
public partial class MusicaCAD : BasicCAD, IMusicaCAD
{
public MusicaCAD() : base ()
{
}

public MusicaCAD(ISession sessionAux) : base (sessionAux)
{
}



public MusicaEN ReadOIDDefault (int musicaId)
{
        MusicaEN musicaEN = null;

        try
        {
                SessionInitializeTransaction ();
                musicaEN = (MusicaEN)session.Get (typeof(MusicaEN), musicaId);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in MusicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return musicaEN;
}


public int New_ (MusicaEN musica)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (musica);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in MusicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return musica.MusicaId;
}

public void Modify (MusicaEN musica)
{
        try
        {
                SessionInitializeTransaction ();
                MusicaEN musicaEN = (MusicaEN)session.Load (typeof(MusicaEN), musica.MusicaId);

                musicaEN.Nombre = musica.Nombre;


                musicaEN.Descripcion = musica.Descripcion;

                session.Update (musicaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in MusicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int musicaId)
{
        try
        {
                SessionInitializeTransaction ();
                MusicaEN musicaEN = (MusicaEN)session.Load (typeof(MusicaEN), musicaId);
                session.Delete (musicaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in MusicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
