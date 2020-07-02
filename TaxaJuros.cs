using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros
{
    public class TaxaJuros
    {
        HttpClient client = new HttpClient();
        public async Task<HttpResponseMessage> GetTaxa()
        {
            try
            {
                string url = "http://localhost:51963/api/TaxaDeJuros";
                var response = await client.GetAsync(url);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
