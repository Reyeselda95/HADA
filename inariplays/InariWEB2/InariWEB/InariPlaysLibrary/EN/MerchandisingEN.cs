using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InariPlaysLibrary.CAD;

namespace InariPlaysLibrary.EN
{
        public class MerchandisingEN
        {
            //atributos de merchandising
                private int merchandisingId;

                private string nombre;

                private string descripcion;

                private float precio;

                private string urlFoto;
            //gettters y setters
                public virtual int MerchandisingId {
                        get { return merchandisingId; } set { merchandisingId = value;  }
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
                public MerchandisingEN() { }

                public MerchandisingEN(int merchandisingId, string nombre, string descripcion, float precio, string urlFoto)
                {
                        this.init (merchandisingId, nombre, descripcion, precio, urlFoto);
                }

            //constructor de copia
                public MerchandisingEN(MerchandisingEN merchandising)
                {
                        this.init (merchandising.MerchandisingId, merchandising.Nombre, merchandising.Descripcion, merchandising.Precio, merchandising.UrlFoto);
                }

                private void init (int merchandisingId, string nombre, string descripcion, float precio, string urlFoto)
                {
                        this.MerchandisingId = merchandisingId;

                        this.Nombre = nombre;

                        this.Descripcion = descripcion;

                        this.Precio = precio;

                        this.UrlFoto = urlFoto;
                }
            //metodo equals para la comprobacion de objetos del mismo tipo
                public override bool Equals (object obj)
                {
                        if (obj == null)
                                return false;
                        MerchandisingEN t = obj as MerchandisingEN;
                        if (t == null)
                                return false;
                        if (MerchandisingId.Equals (t.MerchandisingId))
                                return true;
                        else
                                return false;
                }
            //metodo que devuelve el hashcode
                public override int GetHashCode ()
                {
                        int hash = 13;

                        hash += this.MerchandisingId.GetHashCode ();
                        return hash;
                }
            //metodo que devuelve un articulo merchan pasandole su identificador
                public static MerchandisingEN merchanPorId(int id)
                {
                    return MerchandisingCAD.merchanPorId(id);
                }
            //metodo que devuelve todos los pruductos merchandising
                public MerchandisingEN[] dameTodoMerchan() {
                    return MerchandisingCAD.obtenerMerchan();
                }
            //metodo que devuelve un articulo merchan pasandole el nombre
                public MerchandisingEN[] MerchanPorNombre()
                {
                    return MerchandisingCAD.merchanPorNombre(this.Nombre);
                }
            //metodo que inserta e actualiza un nuevo objeto merchan
                public bool insertarActualizarMerchan() {
                    MerchandisingCAD merchan = new MerchandisingCAD(this);
                    return merchan.insertarActualizarMerchan();
                }
            //metodo que borra un objeto merchan
                public bool borrarMerchan()
                {
                    MerchandisingCAD merchan = new MerchandisingCAD(this);
                    return merchan.borrarMerchan();
                }
            //metodo que inserta un nuevo merchan
                public int nuevoMerchan()
                {
                    return MerchandisingCAD.nuevoMerchan();
                }
        }
}
