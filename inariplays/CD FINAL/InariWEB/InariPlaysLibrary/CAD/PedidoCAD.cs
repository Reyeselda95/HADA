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
    
    class PedidoCAD
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        // Representa la entidad de negocio relacionada con el CAD
        private ClienteEN cliente;
        private CestaEN cesta;
        //Constructor de Pedido
        public PedidoCAD(ClienteEN cliente, CestaEN cesta) {
            this.cliente = cliente;
            this.cesta = cesta;
        }
        //Método para obterner todos los pedido realizados 
        public static PedidoEN[] dameTodosPedidos()
        {
            List<PedidoEN> pedidos = new List<PedidoEN>();

            SqlConnection c = new SqlConnection(ConnectionString);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Pedido", c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    pedidos.Add(new PedidoEN(Convert.ToInt32(dr["pedidoId"].ToString()), Convert.ToDateTime(dr["fecha"].ToString()), dr["direccion"].ToString(), Convert.ToInt32(dr["codigoPostal"].ToString()), "Contra Reembolso", ClienteCAD.clientePorNif(dr["FK_NIF_idCliente"].ToString())));
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No conecta a la base de datos: " + ex);
            }
            c.Close();
            return pedidos.ToArray();
        }
        //Método para insertar y actualizar un pedido y que se actualice la base de datos
        public bool insertarActualizarPedido()
        {
            bool aR = false;
            int cuenta = 0;
            SqlConnection conexion = new SqlConnection(ConnectionString);
            try
            {
                conexion.Open();

                string consulta = "SELECT COUNT(*) numero FROM LiniaPedido";
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cuenta = (Int32)cmd.ExecuteScalar();
                cuenta++;

                string consulta2 = "INSERT into Pedido VALUES ('"
                    + cuenta + "', '"
                    + cesta.Fecha + "', '"
                    + cliente.Direccion + "', '"
                    + cliente.Cp + "', 'Contra Reembolso', '"
                    + cliente.NIF + "')";

                SqlCommand com2 = new SqlCommand(consulta2, conexion);

                if (com2.ExecuteNonQuery() > 0)
                    aR = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No conecta a la base de datos: " + ex);
            }
            conexion.Close();
            return aR;
        }
        //Obterner un pedido a través del id
        public static PedidoEN pedidoPorId(int id) {
            PedidoEN pedido = null;

            SqlConnection c = new SqlConnection(ConnectionString);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("Select * from Pedido WHERE pedidoId like " + id , c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    pedido = new PedidoEN(Convert.ToInt32(dr["pedidoId"].ToString()), Convert.ToDateTime(dr["fecha"].ToString()), dr["direccion"].ToString(), Convert.ToInt32(dr["codigoPostal"].ToString()), dr["tipoPago"].ToString(), ClienteCAD.clientePorNif(dr["FK_NIF_idCliente"].ToString()));
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No conecta a la base de datos: " + ex);
            }
            c.Close();
            return pedido;
        
        }
    }
}
