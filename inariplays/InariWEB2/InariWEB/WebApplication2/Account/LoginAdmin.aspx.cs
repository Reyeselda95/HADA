using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InariPlaysLibrary.CAD;
using InariPlaysLibrary.EN;

namespace WebApplication.Account
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void cambiainicio(object sender, EventArgs e)
        {
            string nom = Login2.UserName;
            string pass = Login2.Password;
            AdministradorEN admin = new AdministradorEN();
            admin.Nombre=nom;
            admin.Password=pass;
            Labelerror.Visible = false;
            if (admin.esAdmin())
            {
                Session["username"] = admin.Nombre;
                Response.Redirect("../Administrador.aspx");
            }
            else
            {
                Labelerror.Visible = true;
            }
        }
    }
}