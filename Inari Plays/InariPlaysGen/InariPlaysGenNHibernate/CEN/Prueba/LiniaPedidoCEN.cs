

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
public partial class LiniaPedidoCEN
{
private ILiniaPedidoCAD _ILiniaPedidoCAD;

public LiniaPedidoCEN()
{
        this._ILiniaPedidoCAD = new LiniaPedidoCAD ();
}

public LiniaPedidoCEN(ILiniaPedidoCAD _ILiniaPedidoCAD)
{
        this._ILiniaPedidoCAD = _ILiniaPedidoCAD;
}

public ILiniaPedidoCAD get_ILiniaPedidoCAD ()
{
        return this._ILiniaPedidoCAD;
}

public int CrearLiniaPedido (int p_cantidad, int p_numero)
{
        LiniaPedidoEN liniaPedidoEN = null;
        int oid;

        //Initialized LiniaPedidoEN
        liniaPedidoEN = new LiniaPedidoEN ();
        liniaPedidoEN.Cantidad = p_cantidad;

        liniaPedidoEN.Numero = p_numero;

        //Call to LiniaPedidoCAD

        oid = _ILiniaPedidoCAD.CrearLiniaPedido (liniaPedidoEN);
        return oid;
}

public void ModificarLinia (int p_LiniaPedido_OID, int p_cantidad)
{
        LiniaPedidoEN liniaPedidoEN = null;

        //Initialized LiniaPedidoEN
        liniaPedidoEN = new LiniaPedidoEN ();
        liniaPedidoEN.Numero = p_LiniaPedido_OID;
        liniaPedidoEN.Cantidad = p_cantidad;
        //Call to LiniaPedidoCAD

        _ILiniaPedidoCAD.ModificarLinia (liniaPedidoEN);
}
}
}
