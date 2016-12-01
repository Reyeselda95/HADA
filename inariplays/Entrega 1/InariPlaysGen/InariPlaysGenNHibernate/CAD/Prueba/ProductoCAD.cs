
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
public partial class ProductoCAD : BasicCAD, IProductoCAD
{
public ProductoCAD() : base ()
{
}

public ProductoCAD(ISession sessionAux) : base (sessionAux)
{
}



public ProductoEN ReadOIDDefault (int productoId)
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoEN), productoId);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}


public int Crear (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (producto);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return producto.ProductoId;
}

public void Modificar (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoEN productoEN = (ProductoEN)session.Load (typeof(ProductoEN), producto.ProductoId);

                productoEN.Nombre = producto.Nombre;


                productoEN.Descripcion = producto.Descripcion;


                productoEN.UrlFoto = producto.UrlFoto;


                productoEN.Precio = producto.Precio;


                productoEN.Stock = producto.Stock;

                session.Update (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int productoId)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoEN productoEN = (ProductoEN)session.Load (typeof(ProductoEN), productoId);
                session.Delete (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ProductoEN> DameTodosLosProductos (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProductoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                else
                        result = session.CreateCriteria (typeof(ProductoEN)).List<ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is InariPlaysGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new InariPlaysGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
