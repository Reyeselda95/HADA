
using System;
using InariPlaysGenNHibernate.EN.Prueba;

namespace InariPlaysGenNHibernate.CAD.Prueba
{
public partial interface IClienteCAD
{
ClienteEN ReadOIDDefault (string NIF);

string CrearCliente (ClienteEN cliente);

ClienteEN DameClientePorID (string NIF);


void ModificarCliente (ClienteEN cliente);


void BorrarCliente (string NIF);
}
}
