
using System;
using InariPlaysGenNHibernate.EN.Prueba;

namespace InariPlaysGenNHibernate.CAD.Prueba
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (int id);

int NewAdmin (AdministradorEN administrador);

void ModificarAdmin (AdministradorEN administrador);


void EliminarAdmin (int id);
}
}
