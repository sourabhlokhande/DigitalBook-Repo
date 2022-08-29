using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PaymentGateway.Model;
using System.Data.SqlClient;

namespace PaymentGateway
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("PaymentGate")]
        public static async Task<IActionResult> PaymentGate(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "PaymentGate")] HttpRequest req, ILogger log)
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Payment input = JsonConvert.DeserializeObject<Payment>(requestBody);
 
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=tcp:digitalbookapp.database.windows.net,1433;Initial Catalog=DigitalBook;Persist Security Info=False;User ID=sourabh;Password=pass@word1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    connection.Open();

                    var query = $"INSERT INTO [PaymentTbl] (Email,CreatedDate,ModifiedDate,BookId) VALUES('{input.Email}','{input.CreatedDate}','{input.ModifiedDate}', '{input.BookId}')";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
                //return new BadRequestResult(e.Message);
                return new OkObjectResult(e.Message);
            }
            return new OkResult();
        }
    }
}
