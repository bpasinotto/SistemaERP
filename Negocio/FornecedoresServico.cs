using System.Data;
using SistemaERP.Dados;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace SistemaERP.Negocio
{
    internal class FornecedoresServico
    {
        private static readonly HttpClient client = new HttpClient();

        public DataTable RetornaTodosFornecedores(bool Inativos)
        {
            var Status = 1;
            if (Inativos)
            {
                Status = 0;
            }

            FornecedoresRepositorio fornecedores = new FornecedoresRepositorio();
            return fornecedores.BuscaTodosFornecedores(Status);
        }

        public List<string> BuscaFornecedorId(int Id)
        {
            FornecedoresRepositorio repositorio = new FornecedoresRepositorio();
            return repositorio.BuscaFornecedorId(Id);
        }

        // Insere um novo fornecedor no banco de dados
        public bool InsereFornecedor(string cnpj, string razao, string fantasia, string email, string telefone, string cep, string rua, string numero, string bairro, string complemento, string cidade, string estado, string obs)
        {
            return new FornecedoresRepositorio().InsereFornecedor(cnpj, razao, fantasia, email, telefone, cep, rua, numero, bairro, complemento, cidade, estado, obs);
        }

        // Altera um fornecedor no banco de dados
        public bool AlteraFornecedor(string id, string cnpj, string razao, string fantasia, string email, string telefone, string cep, string rua, string numero, string bairro, string complemento, string cidade, string estado, string obs)
        {
            return new FornecedoresRepositorio().AlteraFornecedor(id, cnpj, razao, fantasia, email, telefone, cep, rua, numero, bairro, complemento, cidade, estado, obs);
        }

        // Inativa ou ativa um fornecedor
        public bool InativaAtivaFornecedor(string id, bool inativar)
        {
            return new FornecedoresRepositorio().InativaAtivaFornecedor(id, inativar);
        }

        public List<Fornecedor> ObterTodosFornecedores()
        {
            return new FornecedoresRepositorio().ObterTodosFornecedores();
        }
        
        internal async Task<List<string>> ValidaDocumentoAsync(string documento)
        {
            CPFCNPJ.IMain CpfCnpj = new CPFCNPJ.Main();
            string documentoLimpo = documento.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");

            if (documentoLimpo.Length == 14)
            {
                // Validação e formatação de CNPJ
                if (CpfCnpj.IsValidCPFCNPJ(documentoLimpo))
                {
                    return await RetornaDadosEmpresaAsync(documentoLimpo);
                }
                else
                {
                    return new List<string> { "2" };
                }
            }
            else
            {
                return new List<string> { "3" };
            }
        }

        private async Task<List<string>> RetornaDadosEmpresaAsync(string cnpj)
        {
            CPFCNPJ.IMain CpfCnpj = new CPFCNPJ.Main();

            var url = $"https://open.cnpja.com/office/{cnpj}";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response;

            try
            {
                response = await client.GetAsync(url);
            }
            catch (HttpRequestException)
            {
                return new List<string> { "5" };
            }

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var empresa = JObject.Parse(responseData);

                List<string> dados = new List<string>
                {
                    CpfCnpj.FormatCPFCNPJ(cnpj, CPFCNPJ.Enum.TypeString.CNPJ), // 0
                    empresa["company"]?["name"]?.ToString() ?? "", // 1
                    empresa["alias"]?.ToString() ?? "", // 2                
                    ObterTelefone(empresa["phones"], 0), // 3
                    ObterEmail(empresa["emails"], 0), // 4
                    empresa["address"]?["zip"]?.ToString() ?? "", // 5
                    empresa["address"]?["street"]?.ToString() ?? "", // 6
                    empresa["address"]?["number"]?.ToString() ?? "", // 7
                    empresa["address"]?["district"]?.ToString() ?? "", // 8
                    empresa["address"]?["details"]?.ToString() ?? "", // 9
                    empresa["address"]?["city"]?.ToString() ?? "", // 10
                    empresa["address"]?["state"]?.ToString() ?? "", // 11
                };

                return dados;
            }
            else
            {
                return new List<string> { "4" };
            }
        }

        private string ObterTelefone(JToken phones, int index)
        {
            if (phones is JArray jArray && jArray.Count > index)
            {
                var phone = jArray[index];
                var tipo = phone["type"]?.ToString() ?? "";
                var area = phone["area"]?.ToString() ?? "";
                var numero = phone["number"]?.ToString() ?? "";

                if (tipo == "MOBILE")
                {
                    return $"({area}) 9{numero[..4]}-{numero.Substring(4)}";
                }
                else
                {
                    return $"({area}) {numero[..4]}-{numero.Substring(4)}";
                }
            }
            return "";
        }

        private string ObterEmail(JToken emails, int index)
        {
            if (emails is JArray jArray && jArray.Count > index)
            {
                return jArray[index]?["address"]?.ToString() ?? "";
            }
            return "";
        }

        internal async Task<Dictionary<string, string>> ConsultaCepAsync(string cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json/";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response;

            try
            {
                response = await client.GetAsync(url);
            }
            catch (HttpRequestException)
            {
                return new Dictionary<string, string> { { "erro", "Erro ao consultar o CEP" } };
            }

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var endereco = JObject.Parse(responseData);

                if (endereco["erro"] != null)
                {
                    return new Dictionary<string, string> { { "erro", "CEP não encontrado" } };
                }

                return new Dictionary<string, string>
                {
                    { "cep", endereco["cep"]?.ToString() ?? "" },
                    { "logradouro", endereco["logradouro"]?.ToString() ?? "" },
                    { "complemento", endereco["complemento"]?.ToString() ?? "" },
                    { "bairro", endereco["bairro"]?.ToString() ?? "" },
                    { "localidade", endereco["localidade"]?.ToString() ?? "" },
                    { "uf", endereco["uf"]?.ToString() ?? "" }
                };
            }
            else
            {
                return new Dictionary<string, string> { { "erro", "Erro ao consultar o CEP" } };
            }
        }
    }
}
