namespace PortalUsuario.Shared.DTO;

public class UserDataDto
{
    public string CodUsuario { get; set; }
    public string Nome { get; set; }
    public DateTime? DataAniversario { get; set; }
    public string Email { get; set; }
    public short Role { get; set; }
    public string Token { get; set; }
    
}

