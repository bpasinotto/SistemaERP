namespace SistemaERP.Negocio;

/// <summary>
/// Configurações de licença do sistema
/// </summary>
internal static class ConfiguracaoLicenca
{
    /// <summary>
    /// Se true, desabilita a verificação de licença (apenas para desenvolvimento/testes)
    /// </summary>
    public static bool DesabilitarVerificacao { get; set; } = false;

    /// <summary>
    /// Timeout em segundos para verificação de licença
    /// </summary>
    public static int TimeoutSegundos { get; set; } = 60;

    /// <summary>
    /// URL da API de Controle de Licença
    /// </summary>
    public static string UrlApi { get; set; } = "https://controlelicencaapi-hvfcfvdyfecpdyfy.centralus-01.azurewebsites.net";
}
