using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InariPlaysLibrary.EN
{
        public class MerchandisingEN
        {

                private int merchandisingId;

                private string nombre;

                private string descripcion;

                private int precio;

                private string urlFoto;

                public virtual int MerchandisingId {
                        get { return merchandisingId; } set { merchandisingId = value;  }
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

                public MerchandisingEN() { }

                public MerchandisingEN(int merchandisingId, string nombre, string descripcion, int precio, string urlFoto)
                {
                        this.init (merchandisingId, nombre, descripcion, precio, urlFoto);
                }


                public MerchandisingEN(MerchandisingEN merchandising)
                {
                        this.init (merchandising.MerchandisingId, merchandising.Nombre, merchandising.Descripcion, merchandising.Precio, merchandising.UrlFoto);
                }

                private void init (int merchandisingId, string nombre, string descripcion, int precio, string urlFoto)
                {
                        this.MerchandisingId = merchandisingId;


                        this.Nombre = nombre;

                        this.Descripcion = descripcion;

                        this.Precio = precio;

                        this.UrlFoto = urlFoto;
                }

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

                public override int GetHashCode ()
                {
                        int hash = 13;

                        hash += this.MerchandisingId.GetHashCode ();
                        return hash;
                }
        }
}
