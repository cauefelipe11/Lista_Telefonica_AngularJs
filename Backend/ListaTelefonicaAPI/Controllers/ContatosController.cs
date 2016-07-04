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
    public class ContatosController : ApiController
    {
        private static string source   = "(local)";
        private static string user     = "sa";
        private static string pass     = "123456";
        private static string dataBase = "ListaTelefonicaAngular";
        private string connectionString = String.Format("Data Source={0};User Id={1};Password={2};Initial Catalog={3}",
                                                        source, user, pass, dataBase
                                                        );
        [HttpGet] [HttpPost]
        [Route("getContatos")]
        public HttpResponseMessage getContatos()
        {
            try
            {
                List<Contato> lstContatos = new List<Contato>();
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        
                        command.Connection = connection;
                        command.CommandText =
                            "SELECT " + Environment.NewLine +
                            "    id, " + Environment.NewLine +
                            "    Contatos.nome, " + Environment.NewLine +
                            "    Contatos.data, " + Environment.NewLine +
                            "    Contatos.telefone, " + Environment.NewLine +
                            "    Operadoras.codigo opCodigo, " + Environment.NewLine +
                            "    Operadoras.nome opNome, " + Environment.NewLine +
                            "    Operadoras.categoria opCategoria" + Environment.NewLine +
                            "FROM " + Environment.NewLine +
                            "    Contatos " + Environment.NewLine +
                            "    INNER JOIN Operadoras ON(Contatos.codigoOperadora = Operadoras.codigo)";

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Operadora operadora = new Operadora()
                            {
                                codigo    = Convert.ToInt32( reader["opCodigo"]),
                                nome      = reader["opNome"].ToString(),
                                categoria = reader["opCategoria"].ToString()
                            };
                            Contato contato = new Contato()
                            {
                                id        = Convert.ToInt32(reader["id"]),
                                nome      = reader["nome"].ToString(),
                                data      = Convert.ToDateTime(reader["data"]),
                                telefone  = reader["telefone"].ToString(),
                                operadora = operadora
                            };
                            lstContatos.Add(contato);

                        }
                
                    }
                    connection.Close();
                }

                return Request.CreateResponse(HttpStatusCode.OK, lstContatos.ToArray());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, String.Format("Erro Inesperado: {0}", ex.Message));
            }
        }

        [HttpGet]
        [HttpPost]
        [Route("saveContato")]
        public HttpResponseMessage saveContatos(Contato contato)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {

                        command.Connection = connection;
                        command.CommandText =
                            "INSERT INTO Contatos (id, nome, data, telefone, codigoOperadora) values " +
                            "((SELECT MAX(id) + 1 FROM Contatos), @nome, @data, @telefone, @codigoOperadora)";

                        command.Parameters.Add(new SqlParameter("@nome", contato.nome));
                        command.Parameters.Add(new SqlParameter("@data", DateTime.Now));
                        command.Parameters.Add(new SqlParameter("@telefone", contato.telefone));
                        command.Parameters.Add(new SqlParameter("@codigoOperadora", contato.operadora.codigo));


                        command.ExecuteNonQuery();

                    }
                    connection.Close();
                }

                return Request.CreateResponse(HttpStatusCode.OK,"Contato salvo com sucesso.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, String.Format("Erro Inesperado: {0}", ex.Message));
            }


        }

    }
}
