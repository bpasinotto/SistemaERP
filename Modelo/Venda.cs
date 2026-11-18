namespace SistemaERP.Modelo;

public class Venda
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public int IdUsuario { get; set; }
    public string NomeUsuario { get; set; } = string.Empty;
    public DateTime DataVenda { get; set; } = DateTime.Now;
    public decimal ValorTotal { get; set; }
    public string Situacao { get; set; } = "Concluída";
    public string? Observacao { get; set; }
    public List<VendaItem> Itens { get; set; } = new();
}

