using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InariPlaysLibrary.EN
{
        public class LiniaPedidoEN
        {
            private int cantidad;

            private int numero;

            private PedidoEN pedido;

            private ProductoEN producto;


            public virtual int Cantidad {
                    get { return cantidad; } set { cantidad = value;  }
            }


            public virtual int Numero {
                    get { return numero; } set { numero = value;  }
            }


            public virtual PedidoEN Pedido {
                    get { return pedido; } set { pedido = value;  }
            }


            public virtual ProductoEN Producto {
                    get { return producto; } set { producto = value;  }
            }


            public LiniaPedidoEN()
            {
            }

            public LiniaPedidoEN(int numero,int cantidad, PedidoEN pedido,ProductoEN producto)
            {
                    this.init (numero, cantidad, pedido, producto);
            }

            public LiniaPedidoEN(LiniaPedidoEN liniaPedido)
            {
                    this.init (liniaPedido.Numero, liniaPedido.Cantidad, liniaPedido.Pedido, liniaPedido.Producto);
            }

            private void init (int numero, int cantidad, InariPlaysLibrary.EN.PedidoEN pedido, InariPlaysLibrary.EN.ProductoEN producto)
            {
                    this.Numero = numero;

                    this.Cantidad = cantidad;

                    this.Pedido = pedido;

                    this.Producto = producto;
            }

            public override bool Equals (object obj)
            {
                    if (obj == null)
                            return false;
                    LiniaPedidoEN t = obj as LiniaPedidoEN;
                    if (t == null)
                            return false;
                    if (Numero.Equals (t.Numero))
                            return true;
                    else
                            return false;
            }

            public override int GetHashCode ()
            {
                    int hash = 13;

                    hash += this.Numero.GetHashCode ();
                    return hash;
            }
        }
}
