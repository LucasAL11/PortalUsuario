using PortalUsuario.Core.Interfaces;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.DTO;

namespace PortalUsuario.Core.Services;

public class ConsultoresService : IConsultoresServices
{
    private readonly IConsultorRespository _repository;

    public ConsultoresService(IConsultorRespository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ConsultorDTO>> GetAll()
    {
        var consultorModel = await _repository.Select();
        return consultorModel
            .Select(consultor => new ConsultorDTO
            {
                Nome = consultor.Nome,
                idade = DateTime.Now.Year - consultor.DataDeNascimento.Year,
                DataDeNascimento = consultor.DataDeNascimento
            })
            .ToList();
    }
}