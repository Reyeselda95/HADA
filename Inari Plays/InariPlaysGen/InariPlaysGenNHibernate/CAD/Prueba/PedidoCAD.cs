
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
public partial class PedidoCAD : BasicCAD, IPedidoCAD
{
public PedidoCAD() : base ()
{
}

public PedidoCAD(ISession sessionAux) : base (sessionAux)
{
}



public PedidoEN ReadOIDDefault (int pedidoId)
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoEN), pedidoId);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}


public int CrearPedido (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (pedido);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedido.PedidoId;
}

public void ModificarPedido (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), pedido.PedidoId);

                pedidoEN.Fecha = pedido.Fecha;


                pedidoEN.Direccion = pedido.Direccion;


                pedidoEN.Localidad = pedido.Localidad;


                pedidoEN.Provincia = pedido.Provincia;


                pedidoEN.CodigoPostal = pedido.CodigoPostal;


                pedidoEN.TipoPago = pedido.TipoPago;

                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarPedido (int pedidoId)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), pedidoId);
                session.Delete (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PedidoEN> DameTodosLosPedidos (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PedidoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                else
                        result = session.CreateCriteria (typeof(PedidoEN)).List<PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public PedidoEN BuscarPedidoPorID (int pedidoId)
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoEN), pedidoId);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public void BorrarLiniaPedido (int p_Pedido_OID, System.Collections.Generic.IList<int> p_liniaPedido_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                InariPlaysGenNHibernate.EN.Prueba.PedidoEN pedidoEN = null;
                pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), p_Pedido_OID);

                InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN liniaPedidoENAux = null;
                if (pedidoEN.LiniaPedido != null) {
                        foreach (int item in p_liniaPedido_OIDs) {
                                liniaPedidoENAux = (InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN)session.Load (typeof(InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN), item);
                                if (pedidoEN.LiniaPedido.Contains (liniaPedidoENAux) == true) {
                                        pedidoEN.LiniaPedido.Remove (liniaPedidoENAux);
                                        liniaPedidoENAux.Pedido = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_liniaPedido_OIDs you are trying to unrelationer, doesn't exist in PedidoEN");
                        }
                }

                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AnyadirLiniaPedido (int p_Pedido_OID, System.Collections.Generic.IList<int> p_liniaPedido_OIDs)
{
        InariPlaysGenNHibernate.EN.Prueba.PedidoEN pedidoEN = null;
        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), p_Pedido_OID);
                InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN liniaPedidoENAux = null;
                if (pedidoEN.LiniaPedido == null) {
                        pedidoEN.LiniaPedido = new System.Collections.Generic.List<InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN>();
                }

                foreach (int item in p_liniaPedido_OIDs) {
                        liniaPedidoENAux = new InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN ();
                        liniaPedidoENAux = (InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN)session.Load (typeof(InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN), item);
                        liniaPedidoENAux.Pedido = pedidoEN;

                        pedidoEN.LiniaPedido.Add (liniaPedidoENAux);
                }


                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
