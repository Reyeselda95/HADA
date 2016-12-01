using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using InariPlaysLibrary.CAD;
using InariPlaysLibrary.EN;

namespace WebApplication
{
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
                if (!(Session["username"].ToString() == "alex" || Session["username"].ToString() == "gema" || Session["username"].ToString() == "admin" || Session["username"].ToString() == "ximo" || Session["username"].ToString() == "barbara" || Session["username"].ToString() == "raquel"))
                {
                    Response.Redirect("Account/LoginAdmin.aspx");
                }

        }

        public void MostrarNuevoProducto(object sender, EventArgs e) {
            try {
                GridView1.Visible = false;
                Label0.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
                Label6.Visible = true;
                URL.Visible = true;
                DropDownList1.Visible = true;
                Button5.Visible = true;
                nomproduc.Visible = true;
                produdesc.Visible = true;
                produprecio.Visible = true;
                produproc.Visible = true;
                RequiredFieldValidator2.Enabled = true;
                RequiredFieldValidator3.Enabled = true;
                RequiredFieldValidator4.Enabled = true;
                RequiredFieldValidator5.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido una excepción de tipo: " + ex);
            }
            
        }

        public void Mostrarusuarios(object sender, EventArgs e)
        {
            try{
                GridView1.Visible = true;
                Label0.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Visible = false;
                URL.Visible = false;
                DropDownList1.Visible = false;
                Button5.Visible = false;
                nomproduc.Visible = false;
                produdesc.Visible = false;
                produprecio.Visible = false;
                produproc.Visible = false;
                RequiredFieldValidator2.Enabled = false;
                RequiredFieldValidator3.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
                RequiredFieldValidator5.Enabled = false;
                GridView1.DataSourceID = "SqlDataSource1";
             }
            catch (Exception ex) {
                Console.WriteLine("Se ha producido una excepción de tipo: " + ex);
            }
        }

        public void mostrarproductos(object sender, EventArgs e)
        {
            try{
                GridView1.Visible = true;
                Label0.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Visible = false;
                URL.Visible = false;
                DropDownList1.Visible = false;
                Button5.Visible = false;
                nomproduc.Visible = false;
                produdesc.Visible = false;
                produprecio.Visible = false;
                produproc.Visible = false;
                RequiredFieldValidator2.Enabled = false;
                RequiredFieldValidator3.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
                RequiredFieldValidator5.Enabled = false;
                GridView1.DataSourceID = "SqlDataSource2";
             }
            catch (Exception ex) {
                Console.WriteLine("Se ha producido una excepción de tipo: " + ex);
            }
           
        }

        public void mostrarpedidos(object sender, EventArgs e)
        {
            try
            {
                GridView1.Visible = true;
                Label0.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Visible = false;
                URL.Visible = false;
                DropDownList1.Visible = false;
                Button5.Visible = false;
                nomproduc.Visible = false;
                produdesc.Visible = false;
                produprecio.Visible = false;
                produproc.Visible = false;
                RequiredFieldValidator2.Enabled = false;
                RequiredFieldValidator3.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
                RequiredFieldValidator5.Enabled = false;
                GridView1.DataSourceID = "SqlDataSource3";
            }
            catch (Exception ex) {
                Console.WriteLine("Se ha producido una excepción de tipo: " + ex);
            }
        }

        public void insertarproducto(object sender, EventArgs e)
        {
                try
                {
                    ProductoEN produc = new ProductoEN();
                    switch (DropDownList1.Text) { 
                        case "Merchandising":
                            MerchandisingEN merchan = new MerchandisingEN();
                            merchan.Precio = Convert.ToSingle(produprecio.Text);
                            merchan.UrlFoto = URL.Text;
                            merchan.MerchandisingId = merchan.nuevoMerchan();
                            merchan.Nombre = nomproduc.Text;
                            merchan.Descripcion = produdesc.Text;
                            if (merchan.MerchanPorNombre() == null) {
                                merchan.insertarActualizarMerchan();
                            }
                            else {
                                merchan.insertarActualizarMerchan();
                                merchan.MerchandisingId--;
                            }
                            produc.Merchandising = merchan;
                            break;
                        case "Musica":
                            MusicaEN music = new MusicaEN();
                            music.Precio = Convert.ToSingle(produprecio.Text);
                            music.UrlFoto = URL.Text;
                            music.MusicaId = music.nuevaMusica();
                            music.Nombre = nomproduc.Text;
                            music.Descripcion = produdesc.Text;
                            if (music.musicaPorNombre() == null) {
                                music.insertarActualizarMusica();
                            }
                            else {
                                music.insertarActualizarMusica();
                                music.MusicaId--;
                            }
                            produc.Musica = music;
                            break;
                        case "Pelicula":
                            PeliculaEN peli = new PeliculaEN();
                            peli.Precio = Convert.ToSingle(produprecio.Text);
                            peli.UrlFoto = URL.Text;
                            peli.PeliculaId = peli.nuevaPelicula();
                            peli.Nombre = nomproduc.Text;
                            peli.Descripcion = produdesc.Text;
                            if (peli.peliculaPorNombre() == null) {
                                peli.insertarActualizarPelicula();
                            }
                            else {
                                peli.insertarActualizarPelicula();
                                peli.PeliculaId--;
                            }
                            produc.Pelicula = peli;
                            break;
                        case "Videojuego":
                            VideojuegoEN video = new VideojuegoEN();
                            video.Precio = Convert.ToSingle(produprecio.Text);
                            video.UrlFoto = URL.Text;
                            video.VideojuegoId = video.nuevoVideojuego();
                            video.Nombre = nomproduc.Text;
                            video.Descripcion = produdesc.Text;
                            if (video.videojuegoPorNombre() == null) {
                                video.insertarActualizarVideojuego();
                            }
                            else{
                                video.insertarActualizarVideojuego();
                                video.VideojuegoId--;
                            }
                            produc.Videojuego = video;
                            break;
                    }
                    
                    produc.ProductoId = produc.nuevoProducto();
                    produc.Nombre = nomproduc.Text;
                    produc.Descripcion = produdesc.Text;
                    produc.Precio = Convert.ToSingle(produprecio.Text);
                    produc.Stock = Convert.ToInt32(produproc.Text);
                    produc.insertarActualizarProducto();
                }
             catch (Exception ex) {
                Console.WriteLine("Se ha producido una excepción de tipo: " + ex);
            }
        }       
    }
}