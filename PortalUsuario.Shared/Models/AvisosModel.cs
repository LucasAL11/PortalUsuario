namespace PortalUsuario.Shared.Models;

public class AvisosModel
{
    public int CodColigada { get; set; }
    public int Nseq { get; set; }
    public string Titulo { get; set; }
    public string Corpo { get; set; }
    public DateTime Data { get; set; }
    public int Ativo { get; set; }
    public string UsuarioUltimaAlteracao { get; set; }
    public DateTime DataUltimaAlteracao { get; set; }
    public byte[] Arquivos { get; set; }
}