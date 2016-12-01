using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using InariPlaysLibrary.EN;


namespace WebApplication.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null) {
                Session.Clear();
                Response.Redirect("../Inicio.aspx");
            }
            
        }

        protected void NuevoCliente(object sender, EventArgs e)
        {
            ClienteEN cliente = new ClienteEN();
            try
            {
                    cliente.Nombre = UserName.Text;
                    cliente.Apellidos = apellidos.Text;
                    cliente.NIF = NIF.Text;
                    cliente.Direccion = Direccion.Text;
                    cliente.Cp = Convert.ToInt32(cp.Text);
                    cliente.Telefono = telefono.Text;
                    cliente.Email = Email.Text;
                    cliente.Password = Password.Text;
            
                if (!cliente.dameTodosClientes().Contains(cliente)) {
                    cliente.insertarActualizarCliente();
                    Response.Redirect("../Inicio.aspx");
                }

            }
            catch(Exception ex){
                Console.WriteLine("Se ha producido una Excepcion: " + ex);
            }
            

        }
    }
}