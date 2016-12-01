
using System;
using InariPlaysGenNHibernate.EN.Prueba;

namespace InariPlaysGenNHibernate.CAD.Prueba
{
public partial interface IPedidoCAD
{
PedidoEN ReadOIDDefault (int pedidoId);

int CrearPedido (PedidoEN pedido);

void ModificarPedido (PedidoEN pedido);


void BorrarPedido (int pedidoId);


System.Collections.Generic.IList<PedidoEN> DameTodosLosPedidos (int first, int size);


PedidoEN BuscarPedidoPorID (int pedidoId);


void BorrarLiniaPedido (int p_Pedido_OID, System.Collections.Generic.IList<int> p_liniaPedido_OIDs);

void AnyadirLiniaPedido (int p_Pedido_OID, System.Collections.Generic.IList<int> p_liniaPedido_OIDs);
}
}
