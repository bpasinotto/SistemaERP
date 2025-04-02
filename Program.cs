using SistemaERP.Apresentacao;

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

            // Fechar a tela de carregamento
            formCarregamento.Close();
        }

        // Executar o formulário de login
        Application.Run(new FormLogin());
    }
}
