namespace RCPortalConsultor.Shared.Models;

public class RatViewModel
{
    public string Status { get; set; }
    public int RefRAT { get; set; }
    public DateTime? Data { get; set; }
    public string Cliente { get; set; }
    public string Descricao { get; set; }
    public decimal TotalHoras { get; set; }
    public string Tipo { get; set; }
    public string DescTipo { get; set; }
    public int CODCOLCFO { get; set; }
    public string CODCFO { get; set; }
    public decimal REFEICAO { get; set; }
}