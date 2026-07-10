using Newtonsoft.Json;
using SwBoleto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SwBoleto.API
{
    internal class BoletoAPIBB
    {
        // Chaves Homologação
        public static string client_id_h = Properties.Settings.Default.client_id_h;
        //"eyJpZCI6IjFhNTVlM2ItYjZhZS00ZDBhLWFjOTIiLCJjb2RpZ29QdWJsaWNhZG9yIjowLCJjb2RpZ29Tb2Z0d2FyZSI6NTM5NzksInNlcXVlbmNpYWxJbnN0YWxhY2FvIjoxfQ";
        public static string client_secret_h = Properties.Settings.Default.client_secret_h;
        //"eyJpZCI6IjNkNDUiLCJjb2RpZ29QdWJsaWNhZG9yIjowLCJjb2RpZ29Tb2Z0d2FyZSI6NTM5NzksInNlcXVlbmNpYWxJbnN0YWxhY2FvIjoxLCJzZXF1ZW5jaWFsQ3JlZGVuY2lhbCI6MSwiYW1iaWVudGUiOiJob21vbG9nYWNhbyIsImlhdCI6MTY3NDg0NDE2NDEyOX0";
        public static string developer_application_key_h = Properties.Settings.Default.developer_application_key_h;
        //"051f42a12b828ab5a0fb82876b2ba990";
        public static string client_basic = Properties.Settings.Default.client_basic;
        //"Basic ZXlKcFpDSTZJakZoTlRWbE0ySXRZalpoWlMwMFpEQmhMV0ZqT1RJaUxDSmpiMlJwWjI5UWRXSnNhV05oWkc5eUlqb3dMQ0pqYjJScFoyOVRiMlowZDJGeVpTSTZOVE01Tnprc0luTmxjWFZsYm1OcFlXeEpibk4wWVd4aFkyRnZJam94ZlE6ZXlKcFpDSTZJak5rTkRVaUxDSmpiMlJwWjI5UWRXSnNhV05oWkc5eUlqb3dMQ0pqYjJScFoyOVRiMlowZDJGeVpTSTZOVE01Tnprc0luTmxjWFZsYm1OcFlXeEpibk4wWVd4aFkyRnZJam94TENKelpYRjFaVzVqYVdGc1EzSmxaR1Z1WTJsaGJDSTZNU3dpWVcxaWFXVnVkR1VpT2lKb2IyMXZiRzluWVdOaGJ5SXNJbWxoZENJNk1UWTNORGcwTkRFMk5ERXlPWDA=";


        public static async Task<Token> GerarToken()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpRequestMessage request;
                    HttpResponseMessage response;
                    string responsebody;
                    string URIaux = "";
                    if (Program.Ambiente == "Homologação")
                    {
                        URIaux = "https://oauth.hm.bb.com.br/oauth/token?grant_type=client_credentials&Scope=cobrancas.boletos-requisicao cobrancas.boletos-info";
                    }
                    else
                    {
                         URIaux = "https://oauth.bb.com.br/oauth/token?grant_type=client_credentials&Scope=cobrancas.boletos-requisicao cobrancas.boletos-info";

                    }
                    request = new HttpRequestMessage(HttpMethod.Post, URIaux);
                    //string AuthAux = "Basic ZXlKcFpDSTZJakZoTlRWbE0ySXRZalpoWlMwMFpEQmhMV0ZqT1RJaUxDSmpiMlJwWjI5UWRXSnNhV05oWkc5eUlqb3dMQ0pqYjJScFoyOVRiMlowZDJGeVpTSTZOVE01Tnprc0luTmxjWFZsYm1OcFlXeEpibk4wWVd4aFkyRnZJam94ZlE6ZXlKcFpDSTZJak5rTkRVaUxDSmpiMlJwWjI5UWRXSnNhV05oWkc5eUlqb3dMQ0pqYjJScFoyOVRiMlowZDJGeVpTSTZOVE01Tnprc0luTmxjWFZsYm1OcFlXeEpibk4wWVd4aFkyRnZJam94TENKelpYRjFaVzVqYVdGc1EzSmxaR1Z1WTJsaGJDSTZNU3dpWVcxaWFXVnVkR1VpT2lKb2IyMXZiRzluWVdOaGJ5SXNJbWxoZENJNk1UWTNORGcwTkRFMk5ERXlPWDA=";
                    request.Headers.Add("Authorization", client_basic);

                    response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        responsebody = await response.Content.ReadAsStringAsync();

                        Token token = new Token();
                        token = JsonConvert.DeserializeObject<Token>(responsebody);
                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        public static async Task<RespBoleto> CadastrarBoleto(ReqBoleto reqboleto, Token token)
        {
            using (var client = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response;
                    string responsebody;
                    string AuthAux = "Bearer " + token.access_token;
                    string URIaux = "";
                    if (Program.Ambiente == "Homologação")
                    {
                         URIaux = "https://api.hm.bb.com.br/cobrancas/v2/boletos?gw-dev-app-key=" + developer_application_key_h;
                    }
                    else
                    {
                         URIaux = "https://api.bb.com.br/cobrancas/v2/boletos?gw-dev-app-key=" + developer_application_key_h;

                    }
                    client.DefaultRequestHeaders.Add("Authorization", AuthAux);
                    
                    var stringdata = JsonConvert.SerializeObject(reqboleto);
                    

                    var jsonContent = new StringContent(stringdata, Encoding.UTF8, "application/json");
                    jsonContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(URIaux, jsonContent);


                    
                    
                    if (response.IsSuccessStatusCode)
                    {
                        responsebody = await response.Content.ReadAsStringAsync();

                        RespBoleto dadosboleto = new RespBoleto();
                        dadosboleto = JsonConvert.DeserializeObject<RespBoleto>(responsebody);
                        return dadosboleto;
                    }
                    else
                    {
                        // A solicitação falhou, trate o erro
                        Console.WriteLine("A solicitação falhou com o código de status: " + (int)response.StatusCode);
                        
                        if (response.Content != null)
                        {
                            var errorResponse = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Resposta de erro: " + errorResponse);
                            MessageBox.Show("Erro ao enviar boleto:" + reqboleto.numeroTituloCliente);
                        }
                        return null;
                    }                

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        
        public static async Task<RespCancelar> CancelarBoleto(string nossoNumero,ReqCancelar reqcancelar, Token token)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response;
                    string responsebody;
                    string AuthAux = "Bearer " + token.access_token;
                    string URIaux = "";
                    if (Program.Ambiente == "Homologação")
                    {
                        URIaux = "https://api.hm.bb.com.br/cobrancas/v2/boletos/"+nossoNumero+"/baixar?gw-dev-app-key="+developer_application_key_h;

                    }
                    else
                    {
                        URIaux = "https://api.bb.com.br/cobrancas/v2/boletos/"+nossoNumero+"/baixar?gw-dev-app-key="+developer_application_key_h;


                    }
                    client.DefaultRequestHeaders.Add("Authorization", AuthAux);

                    var stringdata = JsonConvert.SerializeObject(reqcancelar);


                    var jsonContent = new StringContent(stringdata, Encoding.UTF8, "application/json");
                    jsonContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(URIaux, jsonContent);

                    
                    if (response.IsSuccessStatusCode)
                    {
                        responsebody = await response.Content.ReadAsStringAsync();

                        RespCancelar listBoleto = new RespCancelar();
                        listBoleto = JsonConvert.DeserializeObject<RespCancelar>(responsebody);
                        return listBoleto;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public static async Task<RespConsultaBoleto> consultarBoleto(string nossoNumero,string numeroConvenio,Token token)
        {            
            
                using (var handler = new HttpClientHandler())
                {
                    

                    using (var client = new HttpClient(handler))
                    {
                        try
                        {
                            HttpRequestMessage request;
                            HttpResponseMessage response;
                            string responsebody;

                            string URIaux = "https://api.bb.com.br/cobrancas/v2/boletos/"+nossoNumero+"?gw-dev-app-key="+ developer_application_key_h + "&numeroConvenio="+numeroConvenio;
                            string AuthAux = "Bearer " + token.access_token;

                        request = new HttpRequestMessage(HttpMethod.Get, URIaux);
                            
                            

                            request.Headers.Add("Authorization", AuthAux);

                            

                            response = await client.SendAsync(request);

                            if (response.IsSuccessStatusCode)
                            {
                                responsebody = await response.Content.ReadAsStringAsync();

                                RespConsultaBoleto cod_boleto = new RespConsultaBoleto();
                                cod_boleto = JsonConvert.DeserializeObject<RespConsultaBoleto>(responsebody);
                                return cod_boleto;
                            
                            }
                            else
                            {
                                

                                return null;
                            }
                        }
                        catch (Exception ex)
                        {
                            

                            return null;
                        }

                    }
                }
            
        }
    }
}
