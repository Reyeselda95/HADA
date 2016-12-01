using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Videoclub;


public partial class MasterPage : System.Web.UI.MasterPage
{

    protected UsuarioEN usuarioActual = null;//UsuarioEN.getUsuario(24458998);//UsuarioEN.getUsuario(53244622);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (((UsuarioEN)Session["Usuario"]) != null)
            usuarioActual = ((UsuarioEN)Session["Usuario"]);

        if (usuarioActual != null)
        {
            if (usuarioActual.getRol().ToString() == "registrado") // carga las opciones del usuario registrado
            {
                globoInicioSesion.Visible = false; 
                menuReserva.Visible = true;
                menuPerfil.Visible = true;
                menuCerrarSesion.Visible = true;
            }
            if (usuarioActual.getRol().ToString() == "gerente") // carga las opciones del usuario gerente
            {
                globoInicioSesion.Visible = false; 
                menuReserva.Visible = false;
                menuArticulos.Visible = true;
                menuUsuarios.Visible = true;
                menuFacturar.Visible = true;
                menuPerfil.Visible = true;
                subBody.Visible = true;
                menuCerrarSesion.Visible = true;
            }
        }
    }

    public UsuarioEN getUsuarioActual()
    {
        return usuarioActual;
    }

    public void setUsuarioActual(UsuarioEN us)
    {
        this.usuarioActual = us;
    }

    protected void accederButton_Click(object sender, EventArgs e)
    {
        try
        {
            bool esUsuario = UsuarioEN.esUsuario(Convert.ToInt32(userTextBox.Text), passTextBox.Text);

            if (!esUsuario)
                throw new Exception("El usuario no existe con esa contraseña");
            else
            {
                Session["Usuario"] = UsuarioEN.getUsuario(Convert.ToInt32(userTextBox.Text));
                globoInicioSesion.Visible = false;
                Response.Redirect("inicio.aspx");
            }

        }
        catch (Exception a) { Label3.Text = a.Message/*": El usuario no existe con esa contraseña!"*/;}
        
    }
    protected void menuCerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("inicio.aspx");
    }
    protected void nuevoUsuarioButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("nuevoUsuario.aspx");
    }
}
