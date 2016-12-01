
using System;
using InariPlaysGenNHibernate.EN.Prueba;

namespace InariPlaysGenNHibernate.CAD.Prueba
{
public partial interface IMerchandisingCAD
{
MerchandisingEN ReadOIDDefault (int merchandisingId);

int New_ (MerchandisingEN merchandising);

void Modify (MerchandisingEN merchandising);


void Destroy (int merchandisingId);
}
}
