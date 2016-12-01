

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
public partial class PedidoCEN
{
private IPedidoCAD _IPedidoCAD;

public PedidoCEN()
{
        this._IPedidoCAD = new PedidoCAD ();
}

public PedidoCEN(IPedidoCAD _IPedidoCAD)
{
        this._IPedidoCAD = _IPedidoCAD;
}

public IPedidoCAD get_IPedidoCAD ()
{
        return this._IPedidoCAD;
}

public int CrearPedido (int p_pedidoId, Nullable<DateTime> p_fecha, string p_direccion, string p_localidad, string p_provincia, int p_codigoPostal, string p_tipoPago)
{
        PedidoEN pedidoEN = null;
        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.PedidoId = p_pedidoId;

        pedidoEN.Fecha = p_fecha;

        pedidoEN.Direccion = p_direccion;

        pedidoEN.Localidad = p_localidad;

        pedidoEN.Provincia = p_provincia;

        pedidoEN.CodigoPostal = p_codigoPostal;

        pedidoEN.TipoPago = p_tipoPago;

        //Call to PedidoCAD

        oid = _IPedidoCAD.CrearPedido (pedidoEN);
        return oid;
}

public void ModificarPedido (int p_Pedido_OID, Nullable<DateTime> p_fecha, string p_direccion, string p_localidad, string p_provincia, int p_codigoPostal, string p_tipoPago)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.PedidoId = p_Pedido_OID;
        pedidoEN.Fecha = p_fecha;
        pedidoEN.Direccion = p_direccion;
        pedidoEN.Localidad = p_localidad;
        pedidoEN.Provincia = p_provincia;
        pedidoEN.CodigoPostal = p_codigoPostal;
        pedidoEN.TipoPago = p_tipoPago;
        //Call to PedidoCAD

        _IPedidoCAD.ModificarPedido (pedidoEN);
}

public void BorrarPedido (int pedidoId)
{
        _IPedidoCAD.BorrarPedido (pedidoId);
}

public System.Collections.Generic.IList<PedidoEN> DameTodosLosPedidos (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoCAD.DameTodosLosPedidos (first, size);
        return list;
}
public PedidoEN BuscarPedidoPorID (int pedidoId)
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoCAD.BuscarPedidoPorID (pedidoId);
        return pedidoEN;
}

public void BorrarLiniaPedido (int p_Pedido_OID, System.Collections.Generic.IList<int> p_liniaPedido_OIDs)
{
        //Call to PedidoCAD

        _IPedidoCAD.BorrarLiniaPedido (p_Pedido_OID, p_liniaPedido_OIDs);
}
public void AnyadirLiniaPedido (int p_Pedido_OID, System.Collections.Generic.IList<int> p_liniaPedido_OIDs)
{
        //Call to PedidoCAD

        _IPedidoCAD.AnyadirLiniaPedido (p_Pedido_OID, p_liniaPedido_OIDs);
}
}
}
