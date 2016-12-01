using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Videoclub;

public partial class directores : System.Web.UI.Page
{
    public int id = -1;
    public string desc, lugar, nom = "";
    public DateTime fecha = DateTime.Now;
    protected DirectorEN[] todosdirectores = DirectorCAD.getDirector();
    protected DirectorEN directorPorId = DirectorCAD.getDirector(1);
    protected DirectorEN[] directorPorNombre = DirectorCAD.getDirector("");
   
    protected void Page_Load(object sender, EventArgs e)
    {
        UsuarioEN usuarioActual = (UsuarioEN)Session["Usuario"];

        if (usuarioActual == null)
            Response.Redirect("inicio.aspx");

        if (usuarioActual.getRol().ToString() == "gerente")
        {
            if (Request.QueryString["mode"] == "modificar")
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                //nom = nuevoDirNombre.Text = Request.QueryString["nombre"];
               //string feca =  nuevoDirFecha.Text = Request.QueryString["fecha"];
               //fecha = Convert.ToDateTime(feca);
               //lugar = nuevoDirLugar.Text = Request.QueryString["lugar"];
               //desc = nuevoDirDesc.Text = Request.QueryString["desc"]; 
            }

            if (Request.QueryString["mode"] == "borrar")
            {
                id = Convert.ToInt32(Request.QueryString["id"]);

                DirectorEN dire = DirectorEN.getDirector(id);
                dire.borrarDB();

                Response.Redirect("directores.aspx");
            }
        }
    }
    
    protected void busquedaButton_Click(object sender, EventArgs e)
    {
        UsuarioEN usuarioActual = (UsuarioEN)Session["Usuario"];


        if (usuarioActual.getRol().ToString() == "gerente")
            todosdirectores = DirectorCAD.getDirector(busquedaDirectorTextBox.Text);

        if (usuarioActual.getRol().ToString() == "registrado")
            directorPorNombre = DirectorCAD.getDirector(busquedaDirectorTextBox.Text);
    }
    protected void Insertar_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["id"]);
       
        if (nuevoDirNombre.Text != "" && nuevoDirLugar.Text != "" && nuevoDirFecha.Text != "" && nuevoDirDesc.Text != "")
        {
            //nuevoDirNombre.Text = Request.QueryString["nombre"] + "pp";
            //nuevoDirFecha.Text = Request.QueryString["fecha"];
            //nuevoDirLugar.Text = Request.QueryString["lugar"] + "pp";
            //nuevoDirDesc.Text = Request.QueryString["desc"] + "pp";

            DirectorEN nuevo = new DirectorEN(id, nuevoDirNombre.Text, Convert.ToDateTime(nuevoDirFecha.Text), nuevoDirLugar.Text, nuevoDirDesc.Text);
            nuevo.commitBD();
            //DirectorEN nuevodir = new DirectorEN(id,nuevoDirNombre.Text, Convert.ToDateTime(nuevoDirFecha.Text), nuevoDirLugar.Text, nuevoDirDesc.Text);
            //nuevodir.commitBD();

        }

        Response.Redirect("directores.aspx");
    }

    protected void Modificar_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["id"]);

        if (nuevoDirNombre.Text != "" && nuevoDirLugar.Text != "" && nuevoDirFecha.Text != "" && nuevoDirDesc.Text != "")
        {
            DirectorEN nuevo = new DirectorEN(id, nuevoDirNombre.Text, Convert.ToDateTime(nuevoDirFecha.Text), nuevoDirLugar.Text, nuevoDirDesc.Text);
            nuevo.commitBD();
        }
        Response.Redirect("directores.aspx");
    }
}