using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculaJuros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {

        HttpClient client = new HttpClient();
        public async Task<double> GetTaxa()
        {
            string url = "http://localhost:51963/api/TaxaDeJuros";
            var response = await client.GetStringAsync(url);


            return JsonConvert.DeserializeObject<double>(response);
        }

        // GET: api/<CalculaJurosController
        [HttpGet]
            public async Task<string> Get(double v, int t)
            {
                double ValorInicial = v;
                int tempo = t;
                double juros = await GetTaxa();

                double ValorFinal = ValorInicial * Math.Pow(1 + juros, tempo);
                var numero = ValorFinal.ToString("N2");

                return numero;

            }

            // GET api/<CalculaJurosController>/5
            [HttpGet("{id}")]
            public string Get(int id)
            {
                return "value";
            }

            // PUT api/<CalculaJurosController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/<CalculaJurosController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
    }
}
