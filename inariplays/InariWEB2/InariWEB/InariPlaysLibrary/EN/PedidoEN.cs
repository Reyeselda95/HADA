using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InariPlaysLibrary.CAD;

namespace InariPlaysLibrary.EN
{
        public class PedidoEN
        {
            //atributos que tiene un pedido
                private int pedidoId;

                private Nullable<DateTime> fecha;

                private string direccion;

                private int codigoPostal;

                private string tipoPago;

                private ClienteEN cliente;

            //getters y setters
                public virtual int PedidoId {
                        get { return pedidoId; } set { pedidoId = value;  }
                }

                public virtual Nullable<DateTime> Fecha {
                        get { return fecha; } set { fecha = value;  }
                }

                public virtual string Direccion {
                        get { return direccion; } set { direccion = value;  }
                }

                public virtual int CodigoPostal {
                        get { return codigoPostal; } set { codigoPostal = value;  }
                }


                public virtual string TipoPago {
                        get { return tipoPago; } set { tipoPago = value;  }
                }


                public virtual ClienteEN Cliente {
                        get { return cliente; } set { cliente = value;  }
                }

            //constructores 
                public PedidoEN()
                {}

          
                public PedidoEN(int pedidoId, Nullable<DateTime> fecha, string direccion, int codigoPostal, string tipoPago, ClienteEN cliente)
                {
                        this.init (pedidoId, fecha, direccion, codigoPostal, tipoPago, cliente);
                }

                //constructor de copia
                public PedidoEN(PedidoEN pedido)
                {
                        this.init (pedido.PedidoId, pedido.Fecha, pedido.Direccion, pedido.CodigoPostal, pedido.TipoPago, pedido.Cliente);
                }

                private void init (int pedidoId, Nullable<DateTime> fecha, string direccion, int codigoPostal, string tipoPago, ClienteEN cliente)
                {
                        this.PedidoId = pedidoId;


                        this.Fecha = fecha;

                        this.Direccion = direccion;

                        this.CodigoPostal = codigoPostal;

                        this.TipoPago = tipoPago;

                        this.Cliente = cliente;
                }
            //metodo que comprueba si dos objetos de la misma instancia son iguales
                public override bool Equals (object obj)
                {
                        if (obj == null)
                                return false;
                        PedidoEN t = obj as PedidoEN;
                        if (t == null)
                                return false;
                        if (PedidoId.Equals (t.PedidoId))
                                return true;
                        else
                                return false;
                }
            //metodo que devuelve el hashcode
                public override int GetHashCode ()
                {
                        int hash = 13;

                        hash += this.PedidoId.GetHashCode ();
                        return hash;
                }
            //metodo que devuelve un pedido pasandole una id
                public PedidoEN pedidoPorId()
                {
                    return PedidoCAD.pedidoPorId(this.PedidoId);
                }
            //metodo que inserta e actualiza un nuevo pedido
                public bool insertarActualizarPedido(ClienteEN cliente, CestaEN cesta) { 
                    PedidoCAD pedido= new PedidoCAD(cliente, cesta);
                    return pedido.insertarActualizarPedido();
                }
            //metodo que devuelve todos los pedidos
                public PedidoEN[] dameTodosPedidos() {
                    return PedidoCAD.dameTodosPedidos();
                }
        }
}
