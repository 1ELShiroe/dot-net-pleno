using StallosDotnetPleno.Infrastructure.Services.Entities.Roster;
using StallosDotnetPleno.Application.Interfaces.Services;
using Newtonsoft.Json;
using RestSharp;

namespace StallosDotnetPleno.Infrastructure.Services
{
    public class RosterService : IRosterService
    {
        private readonly string API_URL = Environment.GetEnvironmentVariable("API_URL")!;
        private readonly string ClientId = Environment.GetEnvironmentVariable("CLIENT_ID")!;
        private readonly string ClientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET")!;
        private readonly string GrantType = Environment.GetEnvironmentVariable("GRANT_TYPE")!;
        private readonly string ContentType = Environment.GetEnvironmentVariable("CONTENT_TYPE") ?? "application/x-www-form-urlencoded";
        private readonly string CacheControl = Environment.GetEnvironmentVariable("CACHE_CONTROL") ?? "no-cache";
        private readonly string ApiKey = Environment.GetEnvironmentVariable("API_KEY")!;

        /// <summary>
        /// Obtém um token de acesso do serviço OAuth2.
        /// </summary>
        /// <returns>Token de acesso como string.</returns>
        /// <exception cref="Exception">Lançada se o token de acesso não for encontrado ou se a requisição falhar.</exception>
        public string GetToken()
        {
            var client = new RestClient(API_URL);
            var request = new RestRequest("/oauth2/token", Method.Post);

            request.AddHeader("cache-control", CacheControl);
            request.AddHeader("content-type", ContentType);
            request.AddParameter(ContentType, $"grant_type={GrantType}&client_id={ClientId}&client_secret={ClientSecret}", ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var tokenResponse = JsonConvert.DeserializeObject<RosterToken>(response.Content!);
                return tokenResponse?.AccessToken ?? throw new Exception("Access token not found in the response");
            }

            throw new Exception($"Error obtaining token: {response.StatusCode} - {response.Content}");
        }

        /// <summary>
        /// Obtém o protocolo do serviço Roster usando o token de acesso.
        /// </summary>
        /// <param name="name">Nome da consulta.</param>
        /// <param name="document">Documento da consulta.</param>
        /// <param name="responsible">Responsável pela consulta.</param>
        /// <param name="origin">Origem da consulta.</param>
        /// <param name="histories">Lista de históricos.</param>
        /// <returns>Protocolo como string.</returns>
        /// <exception cref="Exception">Lançada se o protocolo não for encontrado ou se a requisição falhar.</exception>
        public string GetProtocol(string name, string document, string responsible, int origin, string[] histories)
        {
            var client = new RestClient(API_URL);
            var request = new RestRequest("/prd/roster/v2/protocolo", Method.Post);

            request.AddHeader("cache-control", CacheControl);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/json");
            request.AddHeader("x-api-key", ApiKey);

            var token = GetToken();
            request.AddHeader("Authorization", $"Bearer {token}");

            var body = new
            {
                Responsavel = responsible,
                Origem = origin,
                Consulta = new
                {
                    Nome = name,
                    Documento = document
                },
                Listas = histories
            };

            request.AddJsonBody(body);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var protocolResponse = JsonConvert.DeserializeObject<RosterProtocolo>(response.Content!);
                return protocolResponse?.Protocol ?? throw new Exception("Protocol not found in the response");
            }

            throw new Exception($"Error obtaining protocol: {response.StatusCode} - {response.Content}");
        }

        /// <summary>
        /// Obtém informações do Bolsa Família com base nos parâmetros fornecidos.
        /// </summary>
        /// <param name="comparison">Comparação opcional para o filtro.</param>
        /// <param name="name">Nome da pessoa.</param>
        /// <param name="cpf">CPF da pessoa.</param>
        /// <param name="pageNumber">Número da página (padrão: 1).</param>
        /// <param name="pageSize">Tamanho da página (padrão: 10).</param>
        /// <returns>Um objeto <see cref="RosterBolsaFamilia"/> contendo os resultados da busca.</returns>
        /// <exception cref="Exception">Lançada se a requisição falhar ou se a resposta estiver vazia.</exception>
        public RosterDefault<RosterBolsaFamilia> BolsaFamilia(string protocol, string? comparison, string name, string cpf, int? pageNumber, int? pageSize)
        {
            var client = new RestClient(API_URL);
            var request = new RestRequest("/prd/roster/v2/bolsa-familia", Method.Get);

            request.AddHeader("cache-control", CacheControl);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("protocolo", protocol);

            request.AddParameter("nome", name);
            request.AddParameter("cpf", cpf);
            request.AddParameter("pagina", pageNumber ?? 1);
            request.AddParameter("tamanho", pageSize ?? 10);

            if (!string.IsNullOrEmpty(comparison))
            {
                request.AddParameter("comparacao", comparison);
            }

            var token = GetToken();
            request.AddHeader("Authorization", $"Bearer {token}");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var tokenResponse = JsonConvert.DeserializeObject<RosterDefault<RosterBolsaFamilia>>(response.Content!);
                return tokenResponse ?? throw new Exception("Bolsa Familia information not found in the response");
            }
            else
            {
                throw new Exception($"Error obtaining Bolsa Familia information: {response.StatusCode} - {response.Content}");
            }
        }

        /// <summary>
        /// Obtém informações sobre pessoas expostas politicamente (PEP) com base nos parâmetros fornecidos.
        /// </summary>
        /// <param name="comparison">Comparação opcional para o filtro.</param>
        /// <param name="name">Nome da pessoa.</param>
        /// <param name="cpf">CPF da pessoa.</param>
        /// <param name="pageNumber">Número da página (padrão: 1).</param>
        /// <param name="pageSize">Tamanho da página (padrão: 10).</param>
        /// <returns>Um objeto <see cref="RosterDefault{RosterPep}"/> contendo os resultados da busca.</returns>
        /// <exception cref="Exception">Lançada se a requisição falhar ou se a resposta estiver vazia.</exception>
        public RosterDefault<RosterPep> Pep(string protocol, string? comparison, string name, string cpf, int? pageNumber, int? pageSize)
        {
            var client = new RestClient(API_URL);
            var request = new RestRequest("/prd/roster/v2/pep", Method.Get);

            request.AddHeader("cache-control", CacheControl);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("protocolo", protocol);

            request.AddParameter("nome", name);
            request.AddParameter("cpf", cpf);
            request.AddParameter("pagina", pageNumber ?? 1);
            request.AddParameter("tamanho", pageSize ?? 10);

            if (!string.IsNullOrEmpty(comparison))
            {
                request.AddParameter("comparacao", comparison);
            }

            var token = GetToken();
            request.AddHeader("Authorization", $"Bearer {token}");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var tokenResponse = JsonConvert.DeserializeObject<RosterDefault<RosterPep>>(response.Content!);
                return tokenResponse ?? throw new Exception("PEP information not found in the response");
            }

            throw new Exception($"Error obtaining PEP information: {response.StatusCode} - {response.Content}");
        }

        /// <summary>
        /// Obtém informações do protocolo Interpol do serviço Roster usando o token de acesso.
        /// </summary>
        /// <param name="protocol">O protocolo para a solicitação.</param>
        /// <param name="comparison">O tipo de comparação (opcional).</param>
        /// <param name="name">O nome para a solicitação.</param>
        /// <param name="pageNumber">O número da página (opcional, padrão é 1).</param>
        /// <param name="pageSize">O tamanho da página (opcional, padrão é 10).</param>
        /// <returns>Objeto RosterDefault contendo informações do RosterInterpol.</returns>
        /// <exception cref="Exception">Lançada se a informação do Interpol não for encontrada ou se a requisição falhar.</exception>
        public RosterDefault<RosterInterpol> Interpol(string protocol, string? comparison, string name, int? pageNumber, int? pageSize)
        {
            var client = new RestClient(API_URL);
            var request = new RestRequest("/prd/roster/v2/interpol", Method.Get);

            request.AddHeader("cache-control", CacheControl);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("protocolo", protocol);

            request.AddParameter("nome", name);
            request.AddParameter("pagina", pageNumber ?? 1);
            request.AddParameter("tamanho", pageSize ?? 10);

            if (!string.IsNullOrEmpty(comparison))
            {
                request.AddParameter("comparacao", comparison);
            }

            var token = GetToken();
            request.AddHeader("Authorization", $"Bearer {token}");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var tokenResponse = JsonConvert.DeserializeObject<RosterDefault<RosterInterpol>>(response.Content!);
                return tokenResponse ?? throw new Exception("Interpol information not found in the response");
            }

            throw new Exception($"Error obtaining Interpol information: {response.StatusCode} - {response.Content}");
        }

        /// <summary>
        /// Recupera os dados do cadastro OFAC a partir do endpoint da API especificado.
        /// </summary>
        /// <param name="protocol">O protocolo usado para a solicitação.</param>
        /// <param name="comparison">O tipo de comparação para a solicitação (opcional).</param>
        /// <param name="name">O nome a ser pesquisado no cadastro OFAC.</param>
        /// <param name="pageNumber">O número da página para paginação (opcional).</param>
        /// <param name="pageSize">O tamanho da página para paginação (opcional).</param>
        /// <returns>Retorna um objeto <see cref="RosterDefault{RosterInterpol}"/> contendo os dados do cadastro OFAC.</returns>
        /// <exception cref="Exception">Lançada quando a resposta não for bem-sucedida ou as informações do OFAC não forem encontradas na resposta.</exception>
        public RosterDefault<RosterOFac> OFac(string protocol, string? comparison, string name, int? pageNumber, int? pageSize)
        {
            var client = new RestClient(API_URL);
            var request = new RestRequest("/prd/roster/v2/ofac", Method.Get);

            request.AddHeader("cache-control", CacheControl);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("protocolo", protocol);

            request.AddParameter("nome", name);
            request.AddParameter("pagina", pageNumber ?? 1);
            request.AddParameter("tamanho", pageSize ?? 10);

            if (!string.IsNullOrEmpty(comparison))
            {
                request.AddParameter("comparacao", comparison);
            }

            var token = GetToken();
            request.AddHeader("Authorization", $"Bearer {token}");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var tokenResponse = JsonConvert.DeserializeObject<RosterDefault<RosterOFac>>(response.Content!);
                return tokenResponse ?? throw new Exception("OFAC information not found in the response");
            }

            throw new Exception($"Error obtaining OFAC information: {response.StatusCode} - {response.Content}");
        }

        /// <summary>
        /// Recupera os dados do cadastro CEPIM a partir do endpoint da API especificado.
        /// </summary>
        /// <param name="protocol">O protocolo usado para a solicitação.</param>
        /// <param name="comparison">O tipo de comparação para a solicitação (opcional).</param>
        /// <param name="name">O nome a ser pesquisado no cadastro CEPIM.</param>
        /// <param name="pageNumber">O número da página para paginação (opcional).</param>
        /// <param name="pageSize">O tamanho da página para paginação (opcional).</param>
        /// <returns>Retorna um objeto <see cref="RosterDefault{RosterCepim}"/> contendo os dados do cadastro CEPIM.</returns>
        /// <exception cref="Exception">Lançada quando a resposta não for bem-sucedida ou as informações do CEPIM não forem encontradas na resposta.</exception>
        public RosterDefault<RosterCepim> Cepim(string protocol, string? comparison, string name, int? pageNumber, int? pageSize)
        {
            var client = new RestClient(API_URL);
            var request = new RestRequest("/prd/roster/v2/ofac", Method.Get);

            request.AddHeader("cache-control", CacheControl);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("protocolo", protocol);

            request.AddParameter("nome", name);
            request.AddParameter("pagina", pageNumber ?? 1);
            request.AddParameter("tamanho", pageSize ?? 10);

            if (!string.IsNullOrEmpty(comparison))
            {
                request.AddParameter("comparacao", comparison);
            }

            var token = GetToken();
            request.AddHeader("Authorization", $"Bearer {token}");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var tokenResponse = JsonConvert.DeserializeObject<RosterDefault<RosterCepim>>(response.Content!);
                return tokenResponse ?? throw new Exception("CEPIM information not found in the response");
            }

            throw new Exception($"Error obtaining information from CEPIM: {response.StatusCode} - {response.Content}");
        }
    }
}
