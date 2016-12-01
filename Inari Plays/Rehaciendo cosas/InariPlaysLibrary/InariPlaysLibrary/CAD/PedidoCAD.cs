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
    class PedidoCAD
    {
        private const string ConnectionString = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\InariDatos.mdf;User Instance=true";

        private ClienteEN cliente;
        private CestaEN cesta;

        public PedidoCAD(ClienteEN cliente, CestaEN cesta) {
            this.cliente = cliente;
            this.cesta = cesta;
        }

        public static PedidoEN[] dameTodosPedidos()
        {
            List<PedidoEN> pedidos = new List<PedidoEN>();

            SqlConnection c = new SqlConnection(ConnectionString);
            c.Open();
            SqlCommand com = new SqlCommand("Select * from Pedido", c);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                pedidos.Add(new PedidoEN(Convert.ToInt32(dr["pedidoId"].ToString()), Convert.ToDateTime(dr["fecha"].ToString()), dr["direccion"].ToString(), Convert.ToInt32(dr["codigoPostal"].ToString()), "Contra Reembolso", ClienteCAD.clientePorNif(dr["FK_NIF_idCliente"].ToString())));
            }
            dr.Close();
            c.Close();
            return pedidos.ToArray();
        }

        public bool insertarActualizarAdmin()
        {
            bool aR = false;
            int cuenta = 0;
            SqlConnection conexion = new SqlConnection(ConnectionString);
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

            conexion.Close();
            return aR;
        }

        public static PedidoEN pedidoPorId(int id) {
            PedidoEN pedido = null;

            SqlConnection c = new SqlConnection(ConnectionString);
            c.Open();
            SqlCommand com = new SqlCommand("Select * from Pedido WHERE pedidoId ='" + id + "'", c);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                pedido = new PedidoEN(Convert.ToInt32(dr["pedidoId"].ToString()), Convert.ToDateTime(dr["fecha"].ToString()), dr["direccion"].ToString(), Convert.ToInt32(dr["codigoPostal"].ToString()), dr["tipoPago"].ToString(), ClienteCAD.clientePorNif(dr["FK_NIF_idCliente"].ToString()));
            }
            dr.Close();
            c.Close();
            return pedido;
        
        }
    }
}
