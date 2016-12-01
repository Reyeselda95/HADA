using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Videoclub;

public partial class _Default : System.Web.UI.Page
{
    protected UsuarioEN usuarioActual;

    protected void Page_Load(object sender, EventArgs e)
    {
        usuarioActual = (UsuarioEN)Session["Usuario"];

        if (usuarioActual == null)
            Response.Redirect("inicio.aspx");


        if(usuarioActual.getRol() != Rol.gerente)
            nuevoRolDropDownList.Enabled = false;

        string op = Request.QueryString["op"];
        if (op != null && op.Equals("0"))
            PanelCorrecto.Visible = true;

    }

    protected void aceptarCambios_Click(object sender, EventArgs e)
    {
        if (nuevoNombreTextBox.Text == "" || nuevoApelidoTextBox.Text == "")
        {
            PanelError.Visible = true;
            return;
        }

        usuarioActual.setNombre(nuevoNombreTextBox.Text);
        usuarioActual.setApellidos(nuevoApelidoTextBox.Text);
        usuarioActual.setRol(nuevoRolDropDownList.SelectedValue);
        usuarioActual.commitDB();

        Response.Redirect("perfil.aspx?op=0");
    }
}