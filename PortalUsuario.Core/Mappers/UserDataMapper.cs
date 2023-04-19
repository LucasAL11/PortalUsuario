using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Core.Mappers;

internal static class UserDataMapper
{
    internal static UsuarioModel ToModel(this UserDataDto dto)
    {
        return new UsuarioModel
        {
            CodUsuario = dto.CodUsuario,
            Nome = dto.Nome,
            DataAniversario = dto.DataAniversario,
            Email = dto.Email,
            Role = dto.Role
        };
    }

    internal static UserDataDto ToDto(this UsuarioModel model)
    {
        return new UserDataDto
        {
            CodUsuario = model.CodUsuario,
            Nome = model.Nome,
            DataAniversario = model.DataAniversario,
            Email = model.Email,
            Role = model.Role
        };
    }
}

