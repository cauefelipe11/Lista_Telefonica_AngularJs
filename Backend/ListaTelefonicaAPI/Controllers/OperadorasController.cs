using ListaTelefonicaAPI.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ListaTelefonicaAPI.Controllers
{
    [RoutePrefix("api/listaTelefonica")]
    public class OperadorasController : ApiController
    {
        private static string source = "(local)";
        private static string user = "sa";
        private static string pass = "123456";
        private static string dataBase = "ListaTelefonicaAngular";
        private string connectionString = String.Format("Data Source={0};User Id={1};Password={2};Initial Catalog={3}",
                                                        source, user, pass, dataBase
                                                        );
        [HttpGet]
        [HttpPost]
        [Route("getOperadoras")]
        public HttpResponseMessage getContatos()
        {
            try
            {
                List<Operadora> lstOperadora = new List<Operadora>();
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {

                        command.Connection = connection;
                        command.CommandText =
                            "SELECT " + Environment.NewLine +
                            "    codigo, " + Environment.NewLine +
                            "    nome, " + Environment.NewLine +
                            "    categoria, " + Environment.NewLine +
                            "    preco " + Environment.NewLine +
                            "FROM " + Environment.NewLine +
                            "    Operadoras ";

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Operadora operadora = new Operadora()
                            {
                                codigo = Convert.ToInt32(reader["codigo"]),
                                nome = reader["nome"].ToString(),
                                categoria = reader["categoria"].ToString(),
                                preco = Convert.ToDouble(reader["preco"])
                            };
                           
                            lstOperadora.Add(operadora);

                        }

                    }
                    connection.Close();
                }

                return Request.CreateResponse(HttpStatusCode.OK, lstOperadora.ToArray());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, String.Format("Erro Inesperado: {0}", ex.Message));
            }


        }
    }
}
