using System;
using System.Configuration;
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
    class LineaPedidoCAD
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

        private CestaEN cesta;
        private PedidoEN pedido;

        public LineaPedidoCAD(CestaEN cesta, PedidoEN pedido) {
            this.cesta = cesta;
            this.pedido = pedido;
        }

        public static LiniaPedidoEN[] dameTodosLiniaPedido()
        {
            List<LiniaPedidoEN> linpeds = new List<LiniaPedidoEN>();

            SqlConnection c = new SqlConnection(ConnectionString);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from LiniaPedido", c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    linpeds.Add(new LiniaPedidoEN(Convert.ToInt32(dr["numero"].ToString()), Convert.ToInt32(dr["cantidad"].ToString()), PedidoCAD.pedidoPorId(Convert.ToInt32(dr["FK_pedidoId_idPedido"].ToString())), ProductoCAD.productoPorId(Convert.ToInt32(dr["FK_productoId_idProducto"].ToString()))));
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No conecta a la base de datos: " + ex);
            }
            c.Close();
            return linpeds.ToArray();
        }

        public bool insertarLiniaPedido()
        {
            bool aR = false;
            int cuenta = 0;
            foreach (ProductoEN p in cesta.Productos) {
                SqlConnection conexion = new SqlConnection(ConnectionString);
                try
                {
                    conexion.Open();

                    string consulta = "SELECT COUNT(*) numero FROM LiniaPedido";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cuenta = (Int32)cmd.ExecuteScalar();
                    cuenta++;

                    string consulta2 = "INSERT into LiniaPedido VALUES ("
                        + cuenta + ", '"
                        + cesta.cantidad(p) + ", "
                        + pedido.PedidoId + ", "
                        + p.ProductoId + ")";

                    SqlCommand com2 = new SqlCommand(consulta2, conexion);

                    if (com2.ExecuteNonQuery() > 0)
                        aR = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No conecta a la base de datos: " + ex);
                }

                conexion.Close();
            }
            return aR;
        }
            
    }
}
