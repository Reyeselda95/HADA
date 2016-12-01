
using System;
using InariPlaysGenNHibernate.EN.Prueba;

namespace InariPlaysGenNHibernate.CAD.Prueba
{
public partial interface IProductoCAD
{
ProductoEN ReadOIDDefault (int productoId);

int Crear (ProductoEN producto);

void Modificar (ProductoEN producto);


void Borrar (int productoId);




System.Collections.Generic.IList<ProductoEN> DameTodosLosProductos (int first, int size);
}
}
