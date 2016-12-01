
using System;

namespace InariPlaysGenNHibernate.EN.Prueba
{
public partial class ClienteEN
{
/**
 *
 */

private string nIF;

/**
 *
 */

private string nombre;

/**
 *
 */

private string email;

/**
 *
 */

private string password;

/**
 *
 */

private string apellidos;

/**
 *
 */

private string direccion;

/**
 *
 */

private string telefono;

/**
 *
 */

private int cp;

/**
 *
 */

private System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.PedidoEN> pedido;

/**
 *
 */

private System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.CestaEN> cesta;





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


public virtual System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}


public virtual System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.CestaEN> Cesta {
        get { return cesta; } set { cesta = value;  }
}





public ClienteEN()
{
        pedido = new System.Collections.Generic.List<InariPlaysGenNHibernate.EN.Prueba.PedidoEN>();
        cesta = new System.Collections.Generic.List<InariPlaysGenNHibernate.EN.Prueba.CestaEN>();
}



public ClienteEN(string nIF, string nombre, string email, string password, string apellidos, string direccion, string telefono, int cp, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.PedidoEN> pedido, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.CestaEN> cesta)
{
        this.init (nIF, nombre, email, password, apellidos, direccion, telefono, cp, pedido, cesta);
}


public ClienteEN(ClienteEN cliente)
{
        this.init (cliente.NIF, cliente.Nombre, cliente.Email, cliente.Password, cliente.Apellidos, cliente.Direccion, cliente.Telefono, cliente.Cp, cliente.Pedido, cliente.Cesta);
}

private void init (string nIF, string nombre, string email, string password, string apellidos, string direccion, string telefono, int cp, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.PedidoEN> pedido, System.Collections.Generic.IList<InariPlaysGenNHibernate.EN.Prueba.CestaEN> cesta)
{
        this.NIF = NIF;


        this.Nombre = nombre;

        this.Email = email;

        this.Password = password;

        this.Apellidos = apellidos;

        this.Direccion = direccion;

        this.Telefono = telefono;

        this.Cp = cp;

        this.Pedido = pedido;

        this.Cesta = cesta;
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
