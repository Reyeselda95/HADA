
using System;

namespace InariPlaysGenNHibernate.EN.Prueba
{
public partial class PedidoEN
{
/**
 *
 */

private int pedidoId;

/**
 *
 */

private Nullable<DateTime> fecha;

/**
 *
 */

private string direccion;

/**
 *
 */

private string localidad;

/**
 *
 */

private string provincia;

/**
 *
 */

private int codigoPostal;

/**
 *
 */

private string tipoPago;

/**
 *
 */

private InariPlaysGenNHibernate.EN.Prueba.ClienteEN cliente;

/**
 *
 */

private System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN> liniaPedido;





public virtual int PedidoId {
        get { return pedidoId; } set { pedidoId = value;  }
}


public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}


public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}


public virtual string Localidad {
        get { return localidad; } set { localidad = value;  }
}


public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}


public virtual int CodigoPostal {
        get { return codigoPostal; } set { codigoPostal = value;  }
}


public virtual string TipoPago {
        get { return tipoPago; } set { tipoPago = value;  }
}


public virtual InariPlaysGenNHibernate.EN.Prueba.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}


public virtual System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN> LiniaPedido {
        get { return liniaPedido; } set { liniaPedido = value;  }
}





public PedidoEN()
{
        liniaPedido = new System.Collections.Generic.List<InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN>();
}



public PedidoEN(int pedidoId, Nullable<DateTime> fecha, string direccion, string localidad, string provincia, int codigoPostal, string tipoPago, InariPlaysGenNHibernate.EN.Prueba.ClienteEN cliente, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN> liniaPedido)
{
        this.init (pedidoId, fecha, direccion, localidad, provincia, codigoPostal, tipoPago, cliente, liniaPedido);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (pedido.PedidoId, pedido.Fecha, pedido.Direccion, pedido.Localidad, pedido.Provincia, pedido.CodigoPostal, pedido.TipoPago, pedido.Cliente, pedido.LiniaPedido);
}

private void init (int pedidoId, Nullable<DateTime> fecha, string direccion, string localidad, string provincia, int codigoPostal, string tipoPago, InariPlaysGenNHibernate.EN.Prueba.ClienteEN cliente, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.LiniaPedidoEN> liniaPedido)
{
        this.PedidoId = pedidoId;


        this.Fecha = fecha;

        this.Direccion = direccion;

        this.Localidad = localidad;

        this.Provincia = provincia;

        this.CodigoPostal = codigoPostal;

        this.TipoPago = tipoPago;

        this.Cliente = cliente;

        this.LiniaPedido = liniaPedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
        if (t == null)
                return false;
        if (PedidoId.Equals (t.PedidoId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.PedidoId.GetHashCode ();
        return hash;
}
}
}
