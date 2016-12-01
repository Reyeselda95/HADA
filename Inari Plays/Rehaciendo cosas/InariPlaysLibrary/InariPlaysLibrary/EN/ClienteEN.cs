using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InariPlaysLibrary.EN
{
            public class ClienteEN
            {

                private string nIF;

                private string nombre;

                private string email;

                private string password;

                private string apellidos;

                private string direccion;

                private string telefono;

                private int cp;

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


                public ClienteEN()
                {
                }



                public ClienteEN(string nIF, string nombre, string email, string password, string apellidos, string direccion, string telefono, int cp)
                {
                        this.init (nIF, nombre, email, password, apellidos, direccion, telefono, cp);
                }


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

                public override int GetHashCode ()
                {
                        int hash = 13;

                        hash += this.NIF.GetHashCode ();
                        return hash;
                }
            }
}
