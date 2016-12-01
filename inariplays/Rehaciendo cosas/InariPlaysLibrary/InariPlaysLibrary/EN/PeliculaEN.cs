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

                private int peliculaId;

                private string nombre;

                private string descripcion;

                private int precio;

                private string urlFoto;

                public virtual int PeliculaId {
                        get { return peliculaId; } set { peliculaId = value;  }
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

                public PeliculaEN()
                {}


                public PeliculaEN(int peliculaId, string nombre, string descripcion, int precio, string urlFoto)
                {
                        this.init (peliculaId, nombre, descripcion, precio, urlFoto);
                }


                public PeliculaEN(PeliculaEN pelicula)
                {
                        this.init (pelicula.PeliculaId, pelicula.Nombre, pelicula.Descripcion, pelicula.Precio, pelicula.UrlFoto);
                }

                private void init (int peliculaId, string nombre, string descripcion, int precio, string urlFoto)
                {
                        this.PeliculaId = peliculaId;


                        this.Nombre = nombre;

                        this.Descripcion = descripcion;

                        this.Precio = precio;

                        this.UrlFoto = urlFoto;
                }

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

                public override int GetHashCode ()
                {
                        int hash = 13;

                        hash += this.PeliculaId.GetHashCode ();
                        return hash;
                }
                public bool insertarActualizarPelicula() {
                    PeliculaCAD peli = new PeliculaCAD(this);
                    return peli.insertarActualizarPelicula();
                }
                public bool borrarPelicula()
                {
                    PeliculaCAD peli = new PeliculaCAD(this);
                    return peli.borrarPelicula();
                }

                public PeliculaEN[] peliculaPorNombre(){
                    return PeliculaCAD.peliculaPorNombre(this.Nombre);
                }
                public PeliculaEN[] damePeliculas(){
                    return PeliculaCAD.obtenerPelicula();
                }
                public PeliculaEN peliculaPorId(){
                    return PeliculaCAD.peliculaPorId(this.PeliculaId);
                }
                public int nuevaPelicula()
                {
                    return PeliculaCAD.nuevaPelicula();
                }
                
        }
}