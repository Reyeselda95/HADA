using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using InariPlaysLibrary.EN;


namespace WebApplication.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
            
        }

        protected void NuevoCliente(object sender, EventArgs e)
        {
            ClienteEN cliente = new ClienteEN();
            
            cliente.Nombre = UserName.Text;
            cliente.Apellidos = apellidos.Text;
            cliente.NIF = NIF.Text;
            cliente.Direccion = Direccion.Text;
            cliente.Cp = Convert.ToInt32(cp.Text);
            cliente.Telefono = telefono.Text;
            cliente.Email = Email.Text;
            cliente.Password = Password.Text;
            
            if (!cliente.esCliente()) {
                cliente.insertarActualizarCliente();
                
            }


        }
    }
}