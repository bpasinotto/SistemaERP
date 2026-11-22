using SistemaERP.Apresentacao;
using SistemaERP.Dados;
using SistemaERP.Negocio;

namespace SistemaERP;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWH1ccHVUR2RfWEVxXkQ=");

        // Mostrar a tela de carregamento
        using (var formCarregamento = new FormCarregamento())
        {
            formCarregamento.Show();
            formCarregamento.Refresh();

            // Inicializar o banco
            Banco.Inicializa();

            // Verificar licença da empresa (em desenvolvimento local a validação remota é ignorada sem requisições HTTP)
            if (ConfiguracaoLicenca.DesabilitarVerificacao)
            {
                System.Diagnostics.Debug.WriteLine($"[AMBIENTE: {ConfiguracaoLicenca.Ambiente}] Validação remota de licença desabilitada.");
            }
            else if (!Task.Run(() => VerificarLicenca()).GetAwaiter().GetResult())
            {
                // Fechar a tela de carregamento
                formCarregamento.Close();

                // Mostrar mensagem de bloqueio
                FormMensagem mensagem = new FormMensagem("Sistema Bloqueado", "Sistema Bloqueado");
                mensagem.ShowDialog();

                // Fechar a aplicação
                Application.Exit();
                return;
            }

            // Fechar a tela de carregamento
            formCarregamento.Close();
        }

        int login = 0; // Ativar a tela de login
        if (login == 1)
        {
            // Executar o formulário de login
            Application.Run(new FormLogin());
        }
        else
        {
            // Executar o formulário principal
            Application.Run(new FormPrincipal());
        }
    }

    /// <summary>
    /// Verifica se a licença da empresa está ativa
    /// </summary>
    private static async Task<bool> VerificarLicenca()
    {
        // Desabilitar verificação se configurado (apenas desenvolvimento)
        if (ConfiguracaoLicenca.DesabilitarVerificacao)
        {
            System.Diagnostics.Debug.WriteLine("Verificação de licença DESABILITADA");
            return true;
        }

        try
        {
            var empresaRepositorio = new EmpresaRepositorio();
            var clienteId = empresaRepositorio.ObterClienteId();

            if (!clienteId.HasValue)
            {
                // Se não existir ClienteId, bloqueia o sistema
                System.Diagnostics.Debug.WriteLine("ClienteId não encontrado");
                return false;
            }

            System.Diagnostics.Debug.WriteLine($"ClienteId obtido: {clienteId}");

            var licencaServico = new LicencaServico();
            var tarefa = await licencaServico.VerificarLicencaAsync(clienteId.Value).ConfigureAwait(false);

            // Aguardar com timeout configurado
            if (!tarefa)
            {
                System.Diagnostics.Debug.WriteLine("Timeout ao verificar licença");
                return false;
            }

            System.Diagnostics.Debug.WriteLine($"Resultado da verificação: {tarefa}");
            return tarefa;
        }
        catch (AggregateException aex)
        {
            System.Diagnostics.Debug.WriteLine($"Erro ao verificar licença (AggregateException): {aex.InnerException?.Message}");
            return false;
        }
        catch (Exception ex)
        {
            // Em caso de erro, bloqueia o sistema por segurança
            System.Diagnostics.Debug.WriteLine($"Erro ao verificar licença: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
            return false;
        }
    }
}