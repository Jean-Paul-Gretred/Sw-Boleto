using Azure;
using Newtonsoft.Json;
using SwBoleto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SwBoleto.API
{
    internal class BoletoAPI_INTER
    {
        public static string client_id_h = Properties.Settings.Default.client_id_h;
 
        public static string client_secret_h = Properties.Settings.Default.client_secret_h;
      
        public static string permissoes = "boleto-cobranca.write boleto-cobranca.read";
        public static X509Certificate2 certificate;

        public static async Task<Token> GerarToken()
        {
            string responsebody;
            using (HttpClient client = new HttpClient())
            {
                try
                {

                    string url = "";
                    if(Program.Ambiente == "PRODUÇÃO")
                    {
                         url = "https://cdpj.partners.bancointer.com.br/oauth/v2/token";
                    }
                    else
                    {
                         url = "https://cdpj-sandbox.partners.uatinter.co/oauth/v2/token";
                    }
                    
                    var handler = new HttpClientHandler();
                    //handler.ClientCertificateOptions = ClientCertificateOption.Manual;                    
                    String certPem = File.ReadAllText(Program.certificadoCaminho);
                    String keyPem = File.ReadAllText(Program.certificadoSenha);
                    byte[] pfxBytes;
                    X509Certificate2 cert = X509Certificate2.CreateFromPem(certPem, keyPem);
                    pfxBytes = cert.Export(X509ContentType.Pkcs12);
                    certificate = new X509Certificate2(pfxBytes);
                    handler.ClientCertificates.Add(certificate);
                    handler.UseProxy = false;
                    handler.SslProtocols = SslProtocols.Tls12;
                    // Configurar o cliente HTTP com o handler personalizado
                    using (HttpClient certClient = new HttpClient(handler))
                    {
                        var parametros = new[]
                            {
                                new KeyValuePair<string, string>("client_id", client_id_h),
                                new KeyValuePair<string, string>("client_secret", client_secret_h),
                                new KeyValuePair<string, string>("scope", permissoes),
                                new KeyValuePair<string, string>("grant_type", "client_credentials")
                                };
                        // Converter os parâmetros para o formato x-www-form-urlencoded
                        var conteudo = new FormUrlEncodedContent(parametros);

                        // Enviar a requisição POST
                        var response = await certClient.PostAsync(url, conteudo);

                        // Processar a resposta
                        if (response.IsSuccessStatusCode)
                        {
                            responsebody = await response.Content.ReadAsStringAsync();

                            Token token = new Token();
                            token = JsonConvert.DeserializeObject<Token>(responsebody);
                            return token;
                        }
                        else
                        {
                            MessageBox.Show("erro ao gerar token Código: " + response.StatusCode.ToString());
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("erro ao gerar token Erro:" + ex.Message);
                    return null;
                }
            }

        }


        public static async Task<CodsolicitacaoInter> CadastrarBoleto(ReqBoleto_Inter reqboleto, Token token, string cc_num)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var handler = new HttpClientHandler();
                //handler.ClientCertificateOptions = ClientCertificateOption.Manual;                    
                String certPem = File.ReadAllText(Program.certificadoCaminho);
                String keyPem = File.ReadAllText(Program.certificadoSenha);
                byte[] pfxBytes;
                X509Certificate2 cert = X509Certificate2.CreateFromPem(certPem, keyPem);
                pfxBytes = cert.Export(X509ContentType.Pkcs12);
                certificate = new X509Certificate2(pfxBytes);
                handler.ClientCertificates.Add(certificate);
                handler.UseProxy = false;
                handler.SslProtocols = SslProtocols.Tls12;
                    using (HttpClient certClient = new HttpClient(handler))
                    {

                        HttpRequestMessage request;
                        HttpResponseMessage response;
                        string responsebody;

                        string url = "";
                        string AuthAux = "";


                        if (Program.Ambiente == "PRODUÇÃO")
                        {
                            url = "https://cdpj.partners.bancointer.com.br/cobranca/v3/cobrancas";
                        }
                        else
                        {
                            url = "https://cdpj-sandbox.partners.uatinter.co/cobranca/v3/cobrancas";
                        }
                        AuthAux = "Bearer " + token.access_token;







                        request = new HttpRequestMessage(HttpMethod.Post, url);
                        var stringdata = JsonConvert.SerializeObject(reqboleto);
                        
                        var stringcontent = new StringContent(stringdata, Encoding.UTF8, "application/json");
                        request.Content = stringcontent;

                        request.Headers.Add("Authorization", AuthAux);
                        //request.Headers.Add("x-conta-corrente", cc_num);

                        response = await certClient.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            responsebody = await response.Content.ReadAsStringAsync();

                            CodsolicitacaoInter cod_boleto = new CodsolicitacaoInter();
                            cod_boleto = JsonConvert.DeserializeObject<CodsolicitacaoInter>(responsebody);
                            return cod_boleto;

                        }
                        else
                        {
                            MessageBox.Show("erro ao enviar Boleto");
                            return null;
                        }
                    }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("erro ao enviar Boleto");
                    
                    return null;
                }
                
            }
        }


        public static async Task<bool> CancelarBoleto(ReqCancelarInter cancelarInter, CodsolicitacaoInter codsolicitacao, Token token, string cc_num)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var handler = new HttpClientHandler();
                    //handler.ClientCertificateOptions = ClientCertificateOption.Manual;                    
                    String certPem = File.ReadAllText(Program.certificadoCaminho);
                    String keyPem = File.ReadAllText(Program.certificadoSenha);
                    byte[] pfxBytes;
                    X509Certificate2 cert = X509Certificate2.CreateFromPem(certPem, keyPem);
                    pfxBytes = cert.Export(X509ContentType.Pkcs12);
                    certificate = new X509Certificate2(pfxBytes);
                    handler.ClientCertificates.Add(certificate);
                    handler.UseProxy = false;
                    handler.SslProtocols = SslProtocols.Tls12;
                    using (HttpClient certClient = new HttpClient(handler))
                    {
                        HttpRequestMessage request;
                        HttpResponseMessage response;
                        string responsebody;

                        string url = "";
                        string AuthAux = "";


                        if (Program.Ambiente == "PRODUÇÃO")
                        {
                            url = "https://cdpj.partners.bancointer.com.br/cobranca/v3/cobrancas/" + codsolicitacao.codigoSolicitacao + "/cancelar";
                        }
                        else
                        {
                            url = "https://cdpj-sandbox.partners.uatinter.co/cobranca/v3/cobrancas/" + codsolicitacao.codigoSolicitacao + "/cancelar";
                        }
                        AuthAux = "Bearer " + token.access_token.ToString();







                        request = new HttpRequestMessage(HttpMethod.Post, url);
                        var stringdata = JsonConvert.SerializeObject(cancelarInter);
                        var stringcontent = new StringContent(stringdata, Encoding.UTF8, "application/json");
                        request.Content = stringcontent;

                        request.Headers.Add("Authorization", AuthAux);
                        //request.Headers.Add("x-conta-corrente", cc_num);

                        response = await certClient.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {

                            return true;

                        }
                        else
                        {
                            MessageBox.Show("erro ao cancelar Boleto");
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("erro ao cancelar Boleto");
                    return false;
                }

            }
        }
        public static async Task<RespConsulta_Inter> consultarBoleto(CodsolicitacaoInter codsolicitacao, Token token, string cc_num)
        {

            using (var client = new HttpClient())
            {
                try
                {
                    var handler = new HttpClientHandler();
                    //handler.ClientCertificateOptions = ClientCertificateOption.Manual;                    
                    String certPem = File.ReadAllText(Program.certificadoCaminho);
                    String keyPem = File.ReadAllText(Program.certificadoSenha);
                    byte[] pfxBytes;
                    X509Certificate2 cert = X509Certificate2.CreateFromPem(certPem, keyPem);
                    pfxBytes = cert.Export(X509ContentType.Pkcs12);
                    certificate = new X509Certificate2(pfxBytes);
                    handler.ClientCertificates.Add(certificate);
                    handler.UseProxy = false;
                    handler.SslProtocols = SslProtocols.Tls12;
                    using (HttpClient certClient = new HttpClient(handler))
                    {
                        HttpRequestMessage request;
                        HttpResponseMessage response;
                        string responsebody;

                        string url = "";
                        string AuthAux = "";


                        if (Program.Ambiente == "PRODUÇÃO")
                        {
                            url = "https://cdpj.partners.bancointer.com.br/cobranca/v3/cobrancas/" + codsolicitacao.codigoSolicitacao;
                        }
                        else
                        {
                            url = "https://cdpj-sandbox.partners.uatinter.co/cobranca/v3/cobrancas/" + codsolicitacao.codigoSolicitacao;
                        }
                        AuthAux = "Bearer " + token.access_token.ToString();







                        request = new HttpRequestMessage(HttpMethod.Get, url);


                        request.Headers.Add("Authorization", AuthAux);
                        //request.Headers.Add("x-conta-corrente", cc_num);

                        response = await certClient.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            responsebody = await response.Content.ReadAsStringAsync();

                            RespConsulta_Inter boleto = new RespConsulta_Inter();
                            boleto = JsonConvert.DeserializeObject<RespConsulta_Inter>(responsebody);
                            return boleto;

                        }
                        else
                        {
                            
                            MessageBox.Show("erro ao consultar Boleto");
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("erro ao consultar Boleto");
                    return null;
                }

            }
        }

    }
   
}
