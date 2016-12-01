using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication2
{
   
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ServiceReference1 : System.Web.Services.WebService
    {

     
        public string HelloWorld()
        {
            return "Hello World";
        }


     
        public string MetodoEjemplo(string edad)
        {
            return "la edad es:" + edad;

        }
    }
}
 