
using System;
using InariPlaysGenNHibernate.EN.Prueba;

namespace InariPlaysGenNHibernate.CAD.Prueba
{
public partial interface ICategoriaCAD
{
CategoriaEN ReadOIDDefault (int categoriaID);

int Crear (CategoriaEN categoria);

void Borrar (int categoriaID);


void Modificar (CategoriaEN categoria);
}
}
