﻿using System;
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
        private const string ConnectionString = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\InariDatos.mdf;User Instance=true";

        private CestaEN cesta;

        public CestaCAD(CestaEN cesta) {
            this.cesta = cesta;
        }

         public bool insertarActualizarCesta()
        {
            bool aR = false;

            SqlConnection conexion = new SqlConnection(ConnectionString);
            conexion.Open();

            string consulta = "UPDATE Cesta " +
                             " SET fecha = " + cesta.Fecha +
                               ", FK_NIF_idCLiente = '" + cesta.Cliente +
                        "' WHERE Iden=" + cesta.Iden ;

            SqlCommand com = new SqlCommand(consulta, conexion);

            if (com.ExecuteNonQuery() > 0)
                aR = true;

            conexion.Close();


            if (!aR)
            {
                SqlConnection conexion2 = new SqlConnection(ConnectionString);
                conexion2.Open();


                string consulta2 = "INSERT into Cesta VALUES (" 
                    + cesta.Iden + ", " 
                    + cesta.Fecha + ", '" 
                    + cesta.Cliente + "')";

                SqlCommand com2 = new SqlCommand(consulta2, conexion2);

                if (com2.ExecuteNonQuery() > 0)
                    aR = true;

                conexion2.Close();
            }

            return aR;
        }

         public bool borrarCesta()
         {
             bool aR = false;


             SqlConnection conexion = new SqlConnection(ConnectionString);
             conexion.Open();

             string consulta = "DELETE from Cesta WHERE Iden='" + cesta.Iden + "'";

             SqlCommand com2 = new SqlCommand(consulta, conexion);

             if (com2.ExecuteNonQuery() > 0)
                 aR = true;

             conexion.Close();

             return aR;
         }

         
    }
}
