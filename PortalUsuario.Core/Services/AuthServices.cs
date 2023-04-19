using System.IdentityModel.Tokens.Jwt;
using PortalUsuario.Core.Mappers;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PortalUsuario.Core.Interfaces;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Core.Services;

public class AuthServices : IAuthServices
{
    private readonly IAuthRepository _repository;

    public AuthServices(IAuthRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserDataDto> BuscarDadosUsuario(LoginDto login)
    {
        var userDataModel = await _repository.GetUserData(login);

        if (userDataModel == null)
            throw new ArgumentException("Usuario não encontrado");

        var userData = userDataModel.ToDto();

        var token = GenerateToken(userData);

        userData.Token = token.Result;

        return userData;
    }

    public async Task AtualizarCookies(string cookies)
    {
       await _repository.AtualizarCookies(cookies);
    }

    private Task<string> GenerateToken(UserDataDto dto)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("A3A670475B40469994AECC8610E3B4EA");
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, dto.CodUsuario),
                new Claim(ClaimTypes.Role, dto.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}