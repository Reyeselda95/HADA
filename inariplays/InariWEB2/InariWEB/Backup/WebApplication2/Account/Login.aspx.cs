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
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Si le das a registrarte con esto va a 
            RegisterHyperLink.NavigateUrl = "Register.aspx";
   

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void cambiainicio(object sender, EventArgs e)
        {
            string nom = logon.UserName;
            string pass = logon.Password;
            ClienteEN cli = new ClienteEN();
            cli.Email = nom;
            cli.Password = pass;
            Labelerror.Visible = false;
            if (cli.esCliente())
            {
                Session["username"] = cli.Email;
                Response.Redirect("../Inicio.aspx");
            }
            else
            {
                Labelerror.Visible = true;   
            }
        }
    }
}