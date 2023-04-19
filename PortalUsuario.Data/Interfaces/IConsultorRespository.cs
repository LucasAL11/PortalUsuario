using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Interfaces;

/// <summary>
/// Interface para o repositório de consultores.
/// </summary>
public interface IConsultorRespository
{
    /// <summary>
    /// Seleciona todos os consultores ativos com data de aniversário.
    /// </summary>
    /// <returns>Uma lista de objetos ConsultorModel.</returns>
    Task<IEnumerable<ConsultorModel>> Select();
}