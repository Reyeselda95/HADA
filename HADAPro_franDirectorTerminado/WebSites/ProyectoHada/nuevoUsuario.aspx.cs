using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Videoclub;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] != null)
            Response.Redirect("inicio.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int d = 0;

        if (nuevoApellidos.Text == "" || nuevoDNI.Text == "" ||nuevoNombre.Text == "" || nuevoPass.Text == "" || nuevoDNI.Text.Length != 8)
        {
            PanelError.Visible = true;
        }
        else
        {
            try
            {
                UsuarioEN nuevo = new UsuarioEN(Convert.ToInt32(nuevoDNI.Text), nuevoPass.Text, nuevoNombre.Text,nuevoApellidos.Text,"registrado");
                Response.Write(nuevo.getDni() + " " + nuevo.getNombre() + " " + nuevo.getApellidos() + " " + nuevo.getPassword() + " " + nuevo.getRol().ToString() + nuevo.getFechaAlta());
                nuevo.commitDB();

                Response.Redirect("inicio.aspx?nuevo=ok");
            }
            catch (Exception a) { PanelError.Visible = true;}
        }

    }
}