
using System;
using InariPlaysGenNHibernate.EN.Prueba;

namespace InariPlaysGenNHibernate.CAD.Prueba
{
public partial interface ICestaCAD
{
CestaEN ReadOIDDefault (int Iden);

int Crear (CestaEN cesta);

void Borrar (int Iden);
}
}
