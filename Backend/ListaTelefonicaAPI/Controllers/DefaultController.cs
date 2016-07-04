using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ListaTelefonicaAPI.Controllers
{
    [RoutePrefix("api/listaTelefonica")]
    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route("getServerDateTime")]
        public HttpResponseMessage getServerDateTime()
        {
            try
            {
                string dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                return Request.CreateResponse(HttpStatusCode.OK, dataHora);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public struct Teste {
            public string teste;

        };


        [HttpPost]
        [Route("setGenValue")]
        public HttpResponseMessage setGenValue(JObject teste)
        {
            try
            {
                string dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                return Request.CreateResponse(HttpStatusCode.OK, dataHora);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
