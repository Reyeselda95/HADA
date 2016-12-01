

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
public partial class ProductoCEN
{
private IProductoCAD _IProductoCAD;

public ProductoCEN()
{
        this._IProductoCAD = new ProductoCAD ();
}

public ProductoCEN(IProductoCAD _IProductoCAD)
{
        this._IProductoCAD = _IProductoCAD;
}

public IProductoCAD get_IProductoCAD ()
{
        return this._IProductoCAD;
}

public int Crear (int p_productoId, string p_nombre, string p_descripcion, string p_urlFoto, float p_precio, int p_stock)
{
        ProductoEN productoEN = null;
        int oid;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.ProductoId = p_productoId;

        productoEN.Nombre = p_nombre;

        productoEN.Descripcion = p_descripcion;

        productoEN.UrlFoto = p_urlFoto;

        productoEN.Precio = p_precio;

        productoEN.Stock = p_stock;

        //Call to ProductoCAD

        oid = _IProductoCAD.Crear (productoEN);
        return oid;
}

public void Modificar (int p_Producto_OID, string p_nombre, string p_descripcion, string p_urlFoto, float p_precio, int p_stock)
{
        ProductoEN productoEN = null;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.ProductoId = p_Producto_OID;
        productoEN.Nombre = p_nombre;
        productoEN.Descripcion = p_descripcion;
        productoEN.UrlFoto = p_urlFoto;
        productoEN.Precio = p_precio;
        productoEN.Stock = p_stock;
        //Call to ProductoCAD

        _IProductoCAD.Modificar (productoEN);
}

public void Borrar (int productoId)
{
        _IProductoCAD.Borrar (productoId);
}

public System.Collections.Generic.IList<ProductoEN> DameTodosLosProductos (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> list = null;

        list = _IProductoCAD.DameTodosLosProductos (first, size);
        return list;
}
}
}
