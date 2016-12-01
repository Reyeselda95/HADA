using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InariPlaysLibrary.EN;
using InariPlaysLibrary.CAD;

namespace WebApplication

{
    public partial class descvideo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           int id = Convert.ToInt32(Request.QueryString["Id"]);
           MerchandisingEN merchanen = new MerchandisingEN();
           merchanen.merchById(id);
           
           tit.Text = merchanen.Nombre;
                    
            
        }
        
    }
}