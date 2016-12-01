using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Videoclub;

public partial class _Default : System.Web.UI.Page
{
    protected UsuarioEN[] usuariosDB = UsuarioEN.getUsuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        UsuarioEN usuarioActual = (UsuarioEN)Session["Usuario"];

        if (usuarioActual == null)
            Response.Redirect("inicio.aspx");


        string op = Request.QueryString["op"];

        if (op != null && op == "delok") // Operacion correcta
        {
            PanelCorrectoBorr.Visible = true;
        }

        if (op != null && op == "modok") // Operacion correcta
        {
            PanelCorrectoMod.Visible = true;
        }

        if(op != null && op == "mod") // Modificar id
        {
            UsuarioEN usuarioMod = UsuarioEN.getUsuario(Convert.ToInt32(Request.QueryString["id"]));
            if (((UsuarioEN)Session["Usuario"]).getDni() == usuarioMod.getDni())
            {
                PanelErrorModSession.Visible = true;
            }
            else
            {
                modificarPanel.Visible = true;
            }
        }

        if (op != null && op == "bor") // Borrar id
        {
            UsuarioEN borrar = UsuarioEN.getUsuario(Convert.ToInt32(Request.QueryString["id"]));
            if(borrar.getDni() == ((UsuarioEN)Session["Usuario"]).getDni())
                PanelError.Visible = true;
            else
            {
                borrar.borrarDB();
                Response.Redirect("usuarios.aspx?op=delok");
            }
        }
    }
    protected void aceptarCambios_Click(object sender, EventArgs e)
    {
        if (nuevoApellidosTextBox.Text == "" || nuevoNombreTextBox.Text == "" || nuevoPassTextBox.Text == "")
        {
            PanelErrorMod.Visible = true;
            return;
        }
        else
        {
                UsuarioEN mod = UsuarioEN.getUsuario(Convert.ToInt32(Request.QueryString["id"]));
                mod.setNombre(nuevoNombreTextBox.Text);
                mod.setApellidos(nuevoApellidosTextBox.Text);
                mod.setPassword(nuevoPassTextBox.Text);
                mod.setRol(nuevoRolDropDownList.SelectedValue);
                mod.commitDB();
                Response.Redirect("usuarios.aspx?op=modok");
        }
    }
}