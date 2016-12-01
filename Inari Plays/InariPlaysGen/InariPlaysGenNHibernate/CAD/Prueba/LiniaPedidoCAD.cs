
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
public partial class LiniaPedidoCAD : BasicCAD, ILiniaPedidoCAD
{
public LiniaPedidoCAD() : base ()
{
}

public LiniaPedidoCAD(ISession sessionAux) : base (sessionAux)
{
}



public LiniaPedidoEN ReadOIDDefault (int numero)
{
        LiniaPedidoEN liniaPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                liniaPedidoEN = (LiniaPedidoEN)session.Get (typeof(LiniaPedidoEN), numero);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in LiniaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return liniaPedidoEN;
}


public int CrearLiniaPedido (LiniaPedidoEN liniaPedido)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (liniaPedido);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in LiniaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return liniaPedido.Numero;
}

public void ModificarLinia (LiniaPedidoEN liniaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LiniaPedidoEN liniaPedidoEN = (LiniaPedidoEN)session.Load (typeof(LiniaPedidoEN), liniaPedido.Numero);

                liniaPedidoEN.Cantidad = liniaPedido.Cantidad;

                session.Update (liniaPedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in LiniaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
