using PortalUsuario.Core.Interfaces;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Data.Repositories;
using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Core.Services;

public class ItenRatServiceses : IItenRatServices
{
    private readonly IItenRatRepository _repository;

    public ItenRatServiceses(IItenRatRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RatItensDto>> BuscarItensRat(int id)
    {
        var models = await _repository.BuscarItens(id);

        var dto = new RatItensDto();
        var listaDto = new List<RatItensDto>();

        foreach (var item in models)
        {
            dto.CodColigada = item.CodColigada;
            dto.Data = item.Data;
            dto.Descricao = item.Descricao;
            dto.Id = item.Id;
            dto.Horas = item.Horas;
            dto.Modulo = item.Modulo;
            dto.Operacao = item.Operacao;
            dto.Servico = item.Servico;
            dto.Status = item.Status;
            dto.Tipo = item.Tipo;
            dto.GetTipo = item.GetTipo;
            dto.NomeSistema = item.NomeSistema;
            dto.Id_RefRat = item.Id_RefRat;

            listaDto.Add(dto);
        }

        return listaDto;
    }

    public async Task<RatItensDto> BucarItemRatUnico(int idRat, int sequencia)
    {
        var item = await _repository.BuscarItemUnicoRat(idRat, sequencia);

        var dto = new RatItensDto
        {
            CodColigada = item.CodColigada,
            Data = item.Data,
            Descricao = item.Descricao,
            Id = item.Id,
            Horas = item.Horas,
            Modulo = item.Modulo,
            Operacao = item.Operacao,
            Servico = item.Servico,
            Status = item.Status,
            Tipo = item.Tipo,
            GetTipo = item.GetTipo,
            NomeSistema = item.NomeSistema,
            Id_RefRat = item.Id_RefRat
        };

        return dto;
    }
    
    public async Task<IEnumerable<TipoRatDTO>> BucarListaTiposRat()
    {
        var response = await _repository.BuscarOpcoesTipoRat();
        var key = 0;

        return response.Select(servico => new TipoRatDTO { Tipo = servico.Tipo, Descricao = servico.Descricao }).ToList();
    }

    public async Task AdicionarItem(RatItensDto dto)
    {
        var model = new RatItensModel()
        {
            CodColigada = dto.CodColigada,
            Id = dto.Id,
            Status = dto.Status,
            Horas = dto.Horas,
            Modulo = dto.Modulo,
            Servico = dto.Servico,
            Tipo = dto.Tipo,
            GetTipo = dto.GetTipo,
            Descricao = dto.Descricao,
            Id_RefRat = dto.Id_RefRat,
            Data = dto.Data,
            NomeSistema = dto.NomeSistema,
            Operacao = dto.Operacao
        };

        await _repository.AdicionarItem(model);
    }

    public async Task EditarItemRat(RatItensDto dto)
    {
        var model = new RatItensModel
        {
            CodColigada = dto.CodColigada,
            Id = dto.Id,
            Status = dto.Status,
            Horas = dto.Horas,
            Modulo = dto.Modulo,
            Servico = dto.Servico,
            Tipo = dto.Tipo,
            GetTipo = dto.GetTipo,
            Descricao = dto.Descricao,
            Id_RefRat = dto.Id_RefRat,
            Data = dto.Data,
            NomeSistema = dto.NomeSistema,
            Operacao = dto.Operacao
        };

        await _repository.EditarItem(model);
    }

    public async Task<bool> RemoverItemRat(int idRat, int sequencial)
    {
        
        await _repository.RemoverItem(idRat, sequencial);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }

    public async Task<bool> AtualizarHorarioItemRat(int idRat, decimal horario)
    {
        try
        {
            await _repository.AtualizarHorarioItemRat(idRat, horario);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}