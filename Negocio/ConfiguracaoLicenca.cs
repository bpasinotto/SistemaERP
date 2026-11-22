using System.Configuration;

namespace SistemaERP.Negocio;

/// <summary>
/// Configurações de ambiente e controle de licença do sistema.
/// Em compilações Release (Produção), a verificação de licença é sempre obrigatória
/// e não pode ser desabilitada por arquivo de configuração.
/// </summary>
internal static class ConfiguracaoLicenca
{
    private const string UrlApiPadrao = "https://controlelicencaapi-hvfcfvdyfecpdyfy.centralus-01.azurewebsites.net";
    private const int TimeoutPadraoSegundos = 60;

    /// <summary>
    /// Retorna o ambiente atual da aplicação ("Desenvolvimento" ou "Producao").
    /// Em Release, retorna sempre "Producao".
    /// </summary>
    public static string Ambiente
    {
        get
        {
#if DEBUG
            var ambienteConfig = ConfigurationManager.AppSettings["Ambiente"];
            return string.IsNullOrWhiteSpace(ambienteConfig) ? "Desenvolvimento" : ambienteConfig.Trim();
#else
            return "Producao";
#endif
        }
    }

    /// <summary>
    /// Indica se o sistema está executando em ambiente de desenvolvimento local.
    /// </summary>
    public static bool EhDesenvolvimento =>
        string.Equals(Ambiente, "Desenvolvimento", StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Se true, desabilita a verificação remota de licença.
    /// Só pode retornar true em compilações DEBUG e ambiente de Desenvolvimento.
    /// Em compilações RELEASE (Produção), retorna SEMPRE false.
    /// </summary>
    public static bool DesabilitarVerificacao
    {
        get
        {
#if DEBUG
            if (!EhDesenvolvimento)
            {
                return false;
            }

            var config = ConfigurationManager.AppSettings["DesabilitarVerificacaoLicenca"];
            if (bool.TryParse(config, out bool desabilitar))
            {
                return desabilitar;
            }

            return true;
#else
            return false;
#endif
        }
    }

    /// <summary>
    /// Timeout em segundos para verificação de licença.
    /// </summary>
    public static int TimeoutSegundos
    {
        get
        {
            var config = ConfigurationManager.AppSettings["TimeoutLicencaSegundos"];
            if (int.TryParse(config, out int timeout) && timeout > 0)
            {
                return timeout;
            }

            return TimeoutPadraoSegundos;
        }
    }

    /// <summary>
    /// URL da API de Controle de Licença.
    /// </summary>
    public static string UrlApi
    {
        get
        {
            var config = ConfigurationManager.AppSettings["UrlApiLicenca"];
            return string.IsNullOrWhiteSpace(config) ? UrlApiPadrao : config.Trim();
        }
    }
}
