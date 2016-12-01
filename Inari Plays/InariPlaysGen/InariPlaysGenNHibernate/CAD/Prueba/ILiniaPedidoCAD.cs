
using System;
using InariPlaysGenNHibernate.EN.Prueba;

namespace InariPlaysGenNHibernate.CAD.Prueba
{
public partial interface ILiniaPedidoCAD
{
LiniaPedidoEN ReadOIDDefault (int numero);

int CrearLiniaPedido (LiniaPedidoEN liniaPedido);

void ModificarLinia (LiniaPedidoEN liniaPedido);
}
}
