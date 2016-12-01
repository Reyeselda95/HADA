
using System;
using InariPlaysGenNHibernate.EN.Prueba;

namespace InariPlaysGenNHibernate.CAD.Prueba
{
public partial interface IMusicaCAD
{
MusicaEN ReadOIDDefault (int musicaId);

int New_ (MusicaEN musica);

void Modify (MusicaEN musica);


void Destroy (int musicaId);
}
}
