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
            //atributos de la clase musica
                private int musicaId;

                private string nombre;

                private string descripcion;

                private float precio;

                private string urlFoto;

            //getters y setters 
                public virtual int MusicaId {
                        get { return musicaId; } set { musicaId = value;  }
                }


                public virtual string Nombre {
                        get { return nombre; } set { nombre = value;  }
                }


                public virtual string Descripcion {
                        get { return descripcion; } set { descripcion = value;  }
                }


                public virtual float Precio {
                        get { return precio; } set { precio = value;  }
                }


                public virtual string UrlFoto {
                        get { return urlFoto; } set { urlFoto = value;  }
                }

            //contructores
                public MusicaEN(){}

                public MusicaEN(int musicaId, string nombre, string descripcion, float precio, string urlFoto)
                {
                        this.init (musicaId, nombre, descripcion, precio, urlFoto);
                }

            //constructores de copia
                public MusicaEN(MusicaEN musica)
                {
                        this.init (musica.MusicaId, musica.Nombre, musica.Descripcion, musica.Precio, musica.UrlFoto);
                }

                private void init (int musicaId, string nombre, string descripcion, float precio, string urlFoto)
                {
                        this.MusicaId = musicaId;


                        this.Nombre = nombre;

                        this.Descripcion = descripcion;

                        this.Precio = precio;

                        this.UrlFoto = urlFoto;
                }

            //metodo que comprueba si dos objetos de la misma instancia son iguales
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
            //metodo que devuelve el hashcode
                public override int GetHashCode ()
                {
                        int hash = 13;

                        hash += this.MusicaId.GetHashCode ();
                        return hash;
                }
            //metodo que borra un objeto musica
                public bool borrarMusica() {
                    MusicaCAD musica = new MusicaCAD(this);
                    return musica.borrarMusica();
                }
            //metodo que inserta e actualiza un nuevo objeto musica
                public bool insertarActualizarMusica()
                {
                    MusicaCAD musica = new MusicaCAD(this);
                    return musica.insertarActualizarMusica();
                }
            //metodo que devuelve toda la musica almacenada
                public MusicaEN[] dameTodaMusica() {
                    return MusicaCAD.obtenerMusica();
                }
            //metodo que devuelve un objeto musica por nombre
                public MusicaEN[] musicaPorNombre()
                {
                    return MusicaCAD.musicaPorNombre(this.Nombre);
                }
            //metodo que devuelve un objeto musica pasandole la identificacion
                public MusicaEN musicaPorId()
                {
                    return MusicaCAD.musicaPorId(this.MusicaId);
                }
            //metodo que devuelve la musica insertada recientemente
                public int nuevaMusica()
                {
                    return MusicaCAD.nuevaMusica();
                }
        }
}
