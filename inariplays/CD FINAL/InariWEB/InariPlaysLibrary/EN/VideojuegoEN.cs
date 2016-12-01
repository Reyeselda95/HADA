using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InariPlaysLibrary.CAD;

namespace InariPlaysLibrary.EN
{
        public class VideojuegoEN
        {
            //atributos de la clase videojuego

                private int videojuegoId;

                private string nombre;

                private string descripcion;

                private string companyia;

                private float precio;

                private string urlFoto;

            //getters y setters
                public virtual int VideojuegoId {
                        get { return videojuegoId; } set { videojuegoId = value;  }
                }


                public virtual string Nombre {
                        get { return nombre; } set { nombre = value;  }
                }


                public virtual string Descripcion {
                        get { return descripcion; } set { descripcion = value;  }
                }


                public virtual string Companyia {
                        get { return companyia; } set { companyia = value;  }
                }


                public virtual float Precio {
                        get { return precio; } set { precio = value;  }
                }


                public virtual string UrlFoto {
                        get { return urlFoto; } set { urlFoto = value;  }
                }

            //constructores
                public VideojuegoEN()
                {}


                public VideojuegoEN(int videojuegoId, string nombre, string descripcion, string companyia, float precio, string urlFoto)
                {
                        this.init (videojuegoId, nombre, descripcion, companyia, precio, urlFoto);
                }

            //constructor de copia
                public VideojuegoEN(VideojuegoEN videojuego)
                {
                        this.init (videojuego.VideojuegoId, videojuego.Nombre, videojuego.Descripcion, videojuego.Companyia, videojuego.Precio, videojuego.UrlFoto);
                }

                private void init (int videojuegoId, string nombre, string descripcion, string companyia, float precio, string urlFoto)
                {
                        this.VideojuegoId = videojuegoId;

                        this.Nombre = nombre;

                        this.Descripcion = descripcion;

                        this.Companyia = companyia;

                        this.Precio = precio;

                        this.UrlFoto = urlFoto;
                }

            //metodo que devuelve si dos objetos del mismo tipo son iguales
                public override bool Equals (object obj)
                {
                        if (obj == null)
                                return false;
                        VideojuegoEN t = obj as VideojuegoEN;
                        if (t == null)
                                return false;
                        if (VideojuegoId.Equals (t.VideojuegoId))
                                return true;
                        else
                                return false;
                }

            //metodo que devuelve el hashcode
                public override int GetHashCode ()
                {
                        int hash = 13;

                        hash += this.VideojuegoId.GetHashCode ();
                        return hash;
                }
            //metodo que inserta un nuevo videojuego
                public int nuevoVideojuego()
                {
                    return VideojuegoCAD.nuevoVideojuego();
                }
            //metodo que inserta e actualiza un nuevo videojuego
                public bool insertarActualizarVideojuego() {
                    VideojuegoCAD video = new VideojuegoCAD(this);
                    return video.insertarActualizarVideojuego();
                }
            //metodo que borra un videojuego
                public bool borrarVideojuego()
                {
                    VideojuegoCAD video = new VideojuegoCAD(this);
                    return video.borrarVideojuego();
                }
            //metodo que devuleve todos los videojuegos
                public VideojuegoEN[] dameTodosVideojuegos(){
                    return VideojuegoCAD.obtenerVideojuegos();
                }
            //metodo que devuelve un videojuego pasandole un nombre
                public VideojuegoEN[] videojuegoPorNombre(){
                    return VideojuegoCAD.videojuegoPorNombre(this.Nombre);
                }                
            //metodo que devuelve un videojuego pasandole una id
                public VideojuegoEN videojuegoPorId(int id){
                    return VideojuegoCAD.videojuegoPorId(id);
                }
        }
}
