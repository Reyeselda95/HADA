using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InariPlaysLibrary.CAD;

namespace InariPlaysLibrary.EN
{
        public class MusicaEN
        {

                private int musicaId;

                private string nombre;

                private string descripcion;

                private int precio;

                private string urlFoto;

                public virtual int MusicaId {
                        get { return musicaId; } set { musicaId = value;  }
                }


                public virtual string Nombre {
                        get { return nombre; } set { nombre = value;  }
                }


                public virtual string Descripcion {
                        get { return descripcion; } set { descripcion = value;  }
                }


                public virtual int Precio {
                        get { return precio; } set { precio = value;  }
                }


                public virtual string UrlFoto {
                        get { return urlFoto; } set { urlFoto = value;  }
                }

                public MusicaEN(){}

                public MusicaEN(int musicaId, string nombre, string descripcion, int precio, string urlFoto)
                {
                        this.init (musicaId, nombre, descripcion, precio, urlFoto);
                }


                public MusicaEN(MusicaEN musica)
                {
                        this.init (musica.MusicaId, musica.Nombre, musica.Descripcion, musica.Precio, musica.UrlFoto);
                }

                private void init (int musicaId, string nombre, string descripcion, int precio, string urlFoto)
                {
                        this.MusicaId = musicaId;


                        this.Nombre = nombre;

                        this.Descripcion = descripcion;

                        this.Precio = precio;

                        this.UrlFoto = urlFoto;
                }

                public override bool Equals (object obj)
                {
                        if (obj == null)
                                return false;
                        MusicaEN t = obj as MusicaEN;
                        if (t == null)
                                return false;
                        if (MusicaId.Equals (t.MusicaId))
                                return true;
                        else
                                return false;
                }

                public override int GetHashCode ()
                {
                        int hash = 13;

                        hash += this.MusicaId.GetHashCode ();
                        return hash;
                }

                public bool borrarMusica() {
                    MusicaCAD musica = new MusicaCAD(this);
                    return musica.borrarMusica();
                }
                public bool insertarActualizarMusica()
                {
                    MusicaCAD musica = new MusicaCAD(this);
                    return musica.insertarActualizarMusica();
                }
                public MusicaEN[] dameTodaMusica() {
                    return MusicaCAD.obtenerMusica();
                }
                public MusicaEN[] musicaPorNombre()
                {
                    return MusicaCAD.musicaPorNombre(this.Nombre);
                }
                public MusicaEN musicaPorId()
                {
                    return MusicaCAD.musicaPorId(this.MusicaId);
                }
                public int nuevaMusica()
                {
                    return MusicaCAD.nuevaMusica();
                }
        }
}
