using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InariPlaysLibrary.CAD;

namespace InariPlaysLibrary.EN
{
        public class PeliculaEN
        {
            //atributos de pelicula

                private int peliculaId;

                private string nombre;

                private string descripcion;

                private float precio;

                private string urlFoto;

            //getters y setters
                public virtual int PeliculaId {
                        get { return peliculaId; } set { peliculaId = value;  }
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

            //constructores
                public PeliculaEN()
                {}


                public PeliculaEN(int peliculaId, string nombre, string descripcion, float precio, string urlFoto)
                {
                        this.init (peliculaId, nombre, descripcion, precio, urlFoto);
                }

            //constructor de copia
                public PeliculaEN(PeliculaEN pelicula)
                {
                        this.init (pelicula.PeliculaId, pelicula.Nombre, pelicula.Descripcion, pelicula.Precio, pelicula.UrlFoto);
                }

                private void init (int peliculaId, string nombre, string descripcion, float precio, string urlFoto)
                {
                        this.PeliculaId = peliculaId;


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
                        PeliculaEN t = obj as PeliculaEN;
                        if (t == null)
                                return false;
                        if (PeliculaId.Equals (t.PeliculaId))
                                return true;
                        else
                                return false;
                }
            //metodo que devuelve el hashcode
                public override int GetHashCode ()
                {
                        int hash = 13;

                        hash += this.PeliculaId.GetHashCode ();
                        return hash;
                }
            //metodo que inserta e actualiza  con una nueva pelicula
                public bool insertarActualizarPelicula() {
                    PeliculaCAD peli = new PeliculaCAD(this);
                    return peli.insertarActualizarPelicula();
                }
            //metodo que borra una pelicula
                public bool borrarPelicula()
                {
                    PeliculaCAD peli = new PeliculaCAD(this);
                    return peli.borrarPelicula();
                }
            //metodo que devuelve una pelicula pasandole un nombre
                public PeliculaEN[] peliculaPorNombre(){
                    return PeliculaCAD.peliculaPorNombre(this.Nombre);
                }
            //metodo que devuelve todas las peliculas
                public PeliculaEN[] damePeliculas(){
                    return PeliculaCAD.obtenerPelicula();
                }
            //metodo que devuelve una pelicula pasandole por id
                public PeliculaEN peliculaPorId(){
                    return PeliculaCAD.peliculaPorId(this.PeliculaId);
                }
            //metodo que inserta una nueva pelicula
                public int nuevaPelicula()
                {
                    return PeliculaCAD.nuevaPelicula();
                }
                
        }
}
