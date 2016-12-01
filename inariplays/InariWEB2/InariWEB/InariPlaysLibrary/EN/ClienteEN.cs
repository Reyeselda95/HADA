using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InariPlaysLibrary.CAD;


namespace InariPlaysLibrary.EN
{
            public class ClienteEN
            {
                //atributos de cliente

                private string nIF;

                private string nombre;

                private string email;

                private string password;

                private string apellidos;

                private string direccion;

                private string telefono;

                private int cp;

                ClienteCAD CAD_Cliente;


                //getters y setters
                public virtual string NIF {
                        get { return nIF; } set { nIF = value;  }
                }


                public virtual string Nombre {
                        get { return nombre; } set { nombre = value;  }
                }


                public virtual string Email {
                        get { return email; } set { email = value;  }
                }


                public virtual string Password {
                        get { return password; } set { password = value;  }
                }


                public virtual string Apellidos {
                        get { return apellidos; } set { apellidos = value;  }
                }


                public virtual string Direccion {
                        get { return direccion; } set { direccion = value;  }
                }


                public virtual string Telefono {
                        get { return telefono; } set { telefono = value;  }
                }


                public virtual int Cp {
                        get { return cp; } set { cp = value;  }
                }

                //constructores
                public ClienteEN()
                {
                }



                public ClienteEN(string nIF, string nombre, string email, string password, string apellidos, string direccion, string telefono, int cp)
                {
                        this.init (nIF, nombre, email, password, apellidos, direccion, telefono, cp);
                }

                //constructor de copia
                public ClienteEN(ClienteEN cliente)
                {
                        this.init (cliente.NIF, cliente.Nombre, cliente.Email, cliente.Password, cliente.Apellidos, cliente.Direccion, cliente.Telefono, cliente.Cp);
                }

                private void init (string nIF, string nombre, string email, string password, string apellidos, string direccion, string telefono, int cp)
                {
                        this.NIF = nIF;


                        this.Nombre = nombre;

                        this.Email = email;

                        this.Password = password;

                        this.Apellidos = apellidos;

                        this.Direccion = direccion;

                        this.Telefono = telefono;

                        this.Cp = cp;

                }
                //metodo equals para comprobacion de objetos del mismo tipo
                public override bool Equals (object obj)
                {
                        if (obj == null)
                                return false;
                        ClienteEN t = obj as ClienteEN;
                        if (t == null)
                                return false;
                        if (NIF.Equals (t.NIF))
                                return true;
                        else
                                return false;
                }
                //metodo para obtener hashcode
                public override int GetHashCode ()
                {
                        int hash = 13;

                        hash += this.NIF.GetHashCode ();
                        return hash;
                }
                //inserta un nuevo cliente
                public bool insertarActualizarCliente(){
                
                  ClienteCAD cliente = new ClienteCAD(this);
                  return cliente.insertarActualizarCliente();
                }
                //borra un cliente
                public bool borrarCliente()
                {

                    ClienteCAD cliente = new ClienteCAD(this);
                    return cliente.borrarCliente();
                }
                //comprueba si un usuario es cliente
                public bool esCliente()
                {
                    return ClienteCAD.esCliente(this.Email, this.Password);
                }
                //funcion que da todos los clientes
                public ClienteEN[] dameTodosClientes() {
                    return ClienteCAD.obtenerTodosClientes();
                }
                //funcion que devuelve un cliente que coincida con el nif introducido
                public ClienteEN clientePorNif() {
                    return ClienteCAD.clientePorNif(this.NIF);
                }

            }
}
