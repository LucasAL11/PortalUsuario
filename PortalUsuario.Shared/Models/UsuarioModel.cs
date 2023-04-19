namespace PortalUsuario.Shared.Models;

public class UsuarioModel
{
    public string CodUsuario { get; set; }
    public string Nome { get; set; }
    public DateTime? DataAniversario { get; set; }
    public string Email { get; set; }
    public short Role { get; set; }

   
}