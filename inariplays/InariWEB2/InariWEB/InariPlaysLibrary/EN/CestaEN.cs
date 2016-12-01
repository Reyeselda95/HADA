using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InariPlaysLibrary.CAD;

namespace InariPlaysLibrary.EN
{
    public class CestaEN
    {
        // propiedades de la cesta
            private int iden;

            private Nullable<DateTime> fecha;

            private ClienteEN cliente;

            private ProductoEN[] productos;

            private int[] cantidades;

            int numprods = 0;

        //getters y setters
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


            public virtual ProductoEN[] Productos {
                    get { return productos; } set { productos = value;  }
            }
            
            public virtual int[] Cantidades{
                get { return cantidades; } set { cantidades = value; }
            }
        //constructores
            public CestaEN()
            {
            }

            public CestaEN(int iden, Nullable<DateTime> fecha, ClienteEN cliente,ProductoEN[] productos, int[] cantidades)
            {
                    this.init (iden, fecha, cliente, productos, cantidades);
            }

        //constructor de copia
            public CestaEN(CestaEN cesta)
            {
                    this.init (cesta.Iden, cesta.Fecha, cesta.Cliente, cesta.Productos, cesta.cantidades);
            }

            private void init (int iden, Nullable<DateTime> fecha, ClienteEN cliente, ProductoEN[] productos, int[] cantidades)
            {
                    this.Iden = Iden;

                    this.Fecha = fecha;

                    this.Cliente = cliente;

                    this.Productos = productos;

                    this.Cantidades = cantidades;
            }

        //funcion equals para la comprobacion de objetos del mismo tipo
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

        //funcion para obtener el hash
            public override int GetHashCode ()
            {
                    int hash = 13;

                    hash += this.Iden.GetHashCode ();
                    return hash;
            }

            //El método añade un producto a la cesta
            public void insertaProductoCesta(ProductoEN producto)
            {
                Productos[numprods]=producto;
                if (productos.Contains(producto))
                {
                    cantidades[numprods]++;
                }
                else {
                    cantidades[numprods] = 1;
                    numprods++;
                }
            }

            public int buscaIndexProdudcto(ProductoEN producto) {
                bool found=false;
                int i = 0;
                while (!found) {
                    if (Productos[i].Equals(producto)) {
                        found = true;
                    }
                    else {
                        i++;
                    }
                }
                return i;
            }
            //El método eliminia un producto a la cesta
            public void eliminaProductoCesta(ProductoEN producto)
            {
                int newpos=buscaIndexProdudcto(producto);
                while (newpos + 1 <= numprods)
                {
                    Productos[newpos] = Productos[newpos + 1];
                }
            }
        // devuelve la cantidad de un porducto
            public int cantidad(ProductoEN producto) {
                int cantidad=0;
                foreach (ProductoEN p in productos) {
                    if (p.Equals(producto)) {
                        cantidad++;
                    }
                }
                return cantidad;
            }
        //borra un elemento de la cesta
            public bool borrarCesta() { 
                CestaCAD cesta=new CestaCAD(this);
                return cesta.borrarCesta();
            }

        //inserta un elemento en la cesta y la actualiza
            public bool insertarActualizarCesta()
            {
                CestaCAD cesta = new CestaCAD(this);
                return cesta.insertarActualizarCesta();
            }
        }
}
