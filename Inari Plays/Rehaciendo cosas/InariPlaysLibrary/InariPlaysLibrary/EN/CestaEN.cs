using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InariPlaysLibrary.EN
{
    public class CestaEN
    {

            private int iden;

            private Nullable<DateTime> fecha;

            private ClienteEN cliente;

            private List<ProductoEN> productos;

            public virtual int Iden {
                    get { return iden; } 
                    set { iden = value; }
            }

            public virtual Nullable<DateTime> Fecha {
                    get { return fecha; } set { fecha = value;  }
            }


            public virtual ClienteEN Cliente {
                    get { return cliente; } set { cliente = value;  }
            }


            public virtual List<ProductoEN> Productos {
                    get { return productos; } set { productos = value;  }
            }

            public CestaEN()
            {
                    productos = new List<ProductoEN>();
            }

            public CestaEN(int iden, Nullable<DateTime> fecha, ClienteEN cliente,List<ProductoEN> productos)
            {
                    this.init (iden, fecha, cliente, productos);
            }


            public CestaEN(CestaEN cesta)
            {
                    this.init (cesta.Iden, cesta.Fecha, cesta.Cliente, cesta.Productos);
            }

            private void init (int iden, Nullable<DateTime> fecha, ClienteEN cliente, List<ProductoEN> productos)
            {
                    this.Iden = Iden;


                    this.Fecha = fecha;

                    this.Cliente = cliente;

                    this.Productos = productos;
            }

            public override bool Equals (object obj)
            {
                    if (obj == null)
                            return false;
                    CestaEN t = obj as CestaEN;
                    if (t == null)
                            return false;
                    if (Iden.Equals (t.Iden))
                            return true;
                    else
                            return false;
            }
            public override int GetHashCode ()
            {
                    int hash = 13;

                    hash += this.Iden.GetHashCode ();
                    return hash;
            }

            //El método añade un producto a la cesta
            public void insertaProductoCesta(ProductoEN producto)
            {
                Productos.Add(producto);
            }


            //El método eliminia un producto a la cesta
            public void eliminaProductoCesta(ProductoEN producto)
            {
                Productos.Remove(producto);
            }

            public int cantidad(ProductoEN producto) {
                int cantidad=0;
                foreach (ProductoEN p in productos) {
                    if (p.Equals(producto)) {
                        cantidad++;
                    }
                }
                return cantidad;
            }
        }
}
