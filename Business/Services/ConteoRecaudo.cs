using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Nodes;
using Domain.Entities;
using System.Net.Http.Headers;
using Domain.Dto;

namespace Application.Services
{
    public class ConteoRecaudo: IConteoRecaudo
    {
        public ConteoRecaudo(IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public async Task<Token> GetToken()
        {
            Token token = new Token();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var requestBody = new
                    {
                        userName = "user",
                        password = "1234"
                    };
                    var jsonBody = JsonSerializer.Serialize(requestBody);
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("http://23.102.103.53:5200/Api/Login",content  );

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        token = JsonSerializer.Deserialize<Token>(responseBody);
                      
                    }

                    return token;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return token;
                    
                }
            }
        }

        public async Task<List<RecaudoDTO>> GetRecaudos(string Date, string token)
        {
            List<RecaudoDTO> Recaudos = new List<RecaudoDTO>();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage response = await client.GetAsync("http://23.102.103.53:5200/Api/RecaudoVehiculos/" + Date);             
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena
                        string responseBody = await response.Content.ReadAsStringAsync();
                        if (responseBody.Any())
                        {
                            Recaudos = JsonSerializer.Deserialize<List<RecaudoDTO>>(responseBody);
                        }
                    }

                    return Recaudos;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return Recaudos;

                }
            }
        }

    }
}
