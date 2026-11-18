namespace SistemaERP.Modelo;

public class VendaItem
{
    public int Id { get; set; }
    public int IdVenda { get; set; }
    public int IdProduto { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public string Un { get; set; } = string.Empty;
    public decimal Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotalItem { get; set; }
}

