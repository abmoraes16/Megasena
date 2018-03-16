using System;
using System.Collections.Generic;
using System.Net;
using MegaSena.Model;
using MegaSena.RegrasDeNegocio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MegaSena.bin.Controllers
{
    [Route("api/Megasena")]
    public class JogoController : Controller
    {
        List<String> Jogos = new List<String>();
        GeracaoJogos geracao = new GeracaoJogos();

        [HttpPost]
        public JsonResult CadastrarJogo([FromBody]JogoDomain Jogo)
        {
            try{
                if(!ModelState.IsValid){
                    Response.StatusCode = (int)HttpStatusCode.BadRequest; 
                    return Json(new { success = false, responseText=""});
                }
                
                Response.StatusCode = (int)HttpStatusCode.OK; 
                return Json(JsonConvert.SerializeObject(new { success = geracao.GeraJogos(Jogo) }));

            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest; 
                    return Json(new { success = false, responseText=""});
            }
            
        }

        [HttpGet]
        public List<String> HttpGet()
        {
            return geracao.GetJogos();
        }
    }
}