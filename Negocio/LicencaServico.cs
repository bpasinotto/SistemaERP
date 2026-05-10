using System.Net.Http;
using System.Text.Json;

namespace SistemaERP.Negocio;

internal class LicencaServico
{
    private readonly string _apiBaseUrl;
    private readonly HttpClient _httpClient;

    public LicencaServico()
    {
        _apiBaseUrl = ConfiguracaoLicenca.UrlApi;
        var handler = new HttpClientHandler();
        // Ignorar certificados inválidos em desenvolvimento
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
        _httpClient = new HttpClient(handler);
        _httpClient.Timeout = TimeSpan.FromSeconds(ConfiguracaoLicenca.TimeoutSegundos);
    }

    /// <summary>
    /// Verifica se a empresa está liberada ou bloqueada na API de controle de licença
    /// </summary>
    /// <param name="empresaId">ID da empresa (ClienteId)</param>
    /// <returns>true se liberada, false se bloqueada</returns>
    public async Task<bool> VerificarLicencaAsync(Guid empresaId)
    {
        try
        {            
            var url = $"{_apiBaseUrl}/api/licencas/{empresaId}/status";

            System.Diagnostics.Debug.WriteLine($"[LICENÇA] URL: {url}");
            System.Diagnostics.Debug.WriteLine($"[LICENÇA] EmpresaId: {empresaId}");

            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            System.Diagnostics.Debug.WriteLine($"[LICENÇA] Status Code: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                System.Diagnostics.Debug.WriteLine($"[LICENÇA] Resposta: {jsonContent}");

                var jsonDocument = JsonDocument.Parse(jsonContent);
                var root = jsonDocument.RootElement;

                // Verifica se o campo "bloqueado" existe e obtém seu valor
                if (root.TryGetProperty("bloqueado", out var blockedProperty))
                {
                    System.Diagnostics.Debug.WriteLine($"[LICENÇA] blockedProperty.ValueKind: {blockedProperty.ValueKind}");
                    System.Diagnostics.Debug.WriteLine($"[LICENÇA] blockedProperty raw: {blockedProperty}");

                    bool bloqueado = blockedProperty.GetBoolean();

                    System.Diagnostics.Debug.WriteLine($"[LICENÇA] GetBoolean() retornou: {blockedProperty.GetBoolean()}");
                    System.Diagnostics.Debug.WriteLine($"[LICENÇA] bloqueado = {bloqueado}");
                    System.Diagnostics.Debug.WriteLine($"[LICENÇA] !bloqueado = {!bloqueado}");

                    return !bloqueado; // Retorna true se NÃO está bloqueado (liberado)
                }

                // Se não conseguir determinar o status, assume como liberado
                System.Diagnostics.Debug.WriteLine($"[LICENÇA] Campo bloqueado não encontrado");
                return true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Se a empresa não existe na API, assume como bloqueada
                System.Diagnostics.Debug.WriteLine($"[LICENÇA] 404 - ClienteId não existe");
                return false;
            }
            else
            {
                // Em caso de erro na API, assume como bloqueada por segurança
                System.Diagnostics.Debug.WriteLine($"[LICENÇA] Erro: {response.StatusCode}");
                throw new Exception($"Erro ao verificar licença: {response.StatusCode}");
            }
        }
        catch (HttpRequestException ex)
        {
            // Se não conseguir conectar à API (offline), assume como bloqueada
            System.Diagnostics.Debug.WriteLine($"[LICENÇA] HttpRequestException: {ex.Message}");
            throw new Exception($"Erro ao conectar com a API de licença: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[LICENÇA] Exception: {ex.Message}");
            throw new Exception($"Erro ao verificar licença: {ex.Message}", ex);
        }
    }
}
