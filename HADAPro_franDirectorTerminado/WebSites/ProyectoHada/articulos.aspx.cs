using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Videoclub;

public partial class _Default : System.Web.UI.Page
{
    protected ArticuloEN[] articulos = ArticuloCAD.getArticulo();
	protected ArticuloEN[] articulos_on = ArticuloCAD.getArticulo("", 123414);
	public int id = -1;

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
			}

			if (Request.QueryString["mode"] == "borrar")
			{
				id = Convert.ToInt32(Request.QueryString["id"]);

				ArticuloEN art = new ArticuloEN();
				art.artById(id);
				art.Id = id;

				art.borrarDB(0);

				Response.Redirect("articulos.aspx");
			}

			if (Request.QueryString["mode"] == "activar")
			{
				id = Convert.ToInt32(Request.QueryString["id"]);

				ArticuloEN art = new ArticuloEN();
				art.artById(id);
				art.Id = id;

				art.borrarDB(1);

				Response.Redirect("articulos.aspx");
			}
		}
	}
	
	protected void Insertar_Click(object sender, EventArgs e)
	{
		id = Convert.ToInt32(Request.QueryString["id"]);
		if (nuevoArtNombre.Text != "" && nuevoArtDescripcion.Text != "" && nuevoArtStock.Text != "" && nuevoArtPrecio.Text != "" && nuevoArtFoto.Text != "")
		{
			ArticuloEN articulo = new ArticuloEN(id, nuevoArtNombre.Text, nuevoArtDescripcion.Text, int.Parse(nuevoArtStock.Text), float.Parse(nuevoArtPrecio.Text), nuevoArtFoto.Text, 0);
			articulo.commitBD();
		}

		Response.Redirect("articulos.aspx");
	}

	protected void busquedaButton_Click(object sender, EventArgs e)
	{
		UsuarioEN usuarioActual = (UsuarioEN)Session["Usuario"];
		
		if (usuarioActual.getRol().ToString() == "gerente")
			articulos = ArticuloCAD.getArticulo(busquedaArticuloTextBox.Text, 534523);
		if (usuarioActual.getRol().ToString() == "registrado")
			articulos_on = ArticuloCAD.getArticulo(busquedaArticuloTextBox.Text, 123414);
	}
}