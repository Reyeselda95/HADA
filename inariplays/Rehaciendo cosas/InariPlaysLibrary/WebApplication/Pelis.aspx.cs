using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Pelis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*InariPlaysGenNHibernate.EN.Prueba.PeliculaEN fen = new InariPlaysGenNHibernate.EN.Prueba.PeliculaEN();
            InariPlaysGenNHibernate.CEN.Prueba.PeliculaCEN f= new InariPlaysGenNHibernate.CEN.Prueba.PeliculaCEN();
            fen=f.get_IPeliculaCAD();

            a.Text =fen.Descripcion;*/

        }
        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}