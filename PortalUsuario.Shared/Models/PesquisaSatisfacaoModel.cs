namespace PortalUsuario.Shared.Models;

public class PesquisaSatisfacaoModel
{
    public string CodUsuario_RcUsuario { get; set; }
    public int Id { get; set; }
    public string NomeUsuario { get; set; }
    public int Nota { get; set; }
    public string Observacoes { get; set; }
    public string DescricaoNota { get; set; }
    public int Enviou { get; set; }
}