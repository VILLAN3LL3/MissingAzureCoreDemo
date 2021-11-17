using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestMessage req, TraceWriter log)
        {
            CryptographyClient result = AzureKeyVaultClient.CreateCryptographyClient();

            return result == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "")
                : req.CreateResponse(HttpStatusCode.OK, "");
        }
    }
}
