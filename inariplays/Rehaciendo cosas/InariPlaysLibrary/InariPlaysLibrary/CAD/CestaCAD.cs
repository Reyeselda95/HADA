using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InariPlaysLibrary.EN;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace InariPlaysLibrary.CAD
{
    class CestaCAD
    {
        //Constante de la consexión de la base de datos
        private const string ConnectionString = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|InariDatos.mdf;User Instance=true";

        //Variable privada de un articulo interno en CestaCAD para utilizarlo al insertar y actualizar cesta
        private CestaEN cesta;

        //Constructor
        public CestaCAD(CestaEN cesta) {
            this.cesta = cesta;
        }

        //Funcion booleana que devuelve true si deja Actualizar la cesta correctamente
        public bool insertarActualizarCesta()
        {
            bool aR = false;

            SqlConnection conexion = new SqlConnection(ConnectionString);
            try
            {
                conexion.Open();//abre la conexion

                string consulta = "UPDATE Cesta " +
                                 " SET fecha = " + cesta.Fecha +
                                   ", FK_NIF_idCLiente = '" + cesta.Cliente +
                            "' WHERE Iden=" + cesta.Iden;

                SqlCommand com = new SqlCommand(consulta, conexion);

                if (com.ExecuteNonQuery() > 0)
                    aR = true;
            }
            catch (Exception ex) {
                Console.WriteLine("No conecta a la base de datos: " + ex);
            }

            conexion.Close();//cerrar conexion


            if (!aR)
            {
                SqlConnection conexion2 = new SqlConnection(ConnectionString);
                try
                {
                    conexion2.Open();//abre la conexion


                    string consulta2 = "INSERT into Cesta VALUES ("
                        + cesta.Iden + ", "
                        + cesta.Fecha + ", '"
                        + cesta.Cliente + "')";

                    SqlCommand com2 = new SqlCommand(consulta2, conexion2);

                    if (com2.ExecuteNonQuery() > 0)
                        aR = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }

                conexion2.Close();//cerrar conexion
            }

            return aR;
        }

        //Funcion booleana que devuelve true si deja borrar la cesta correctamente
        public bool borrarCesta()
         {
             bool aR = false;


             SqlConnection conexion = new SqlConnection(ConnectionString);
             try
             {
                 conexion.Open();//abre la conexion

                 string consulta = "DELETE from Cesta WHERE Iden='" + cesta.Iden + "'";

                 SqlCommand com2 = new SqlCommand(consulta, conexion);

                 if (com2.ExecuteNonQuery() > 0)
                     aR = true;
             }
             catch (Exception ex)
             {
                 Console.WriteLine("No conecta a la base de datos: " + ex);
             }

             conexion.Close();//cerrar conexion

             return aR;
         }

         
    }
}
