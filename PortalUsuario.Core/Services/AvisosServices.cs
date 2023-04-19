using PortalUsuario.Core.Interfaces;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Core.Services;

public class AvisosServices : IAvisosServices
{

    private readonly IAvisosRepository _repository;

    public AvisosServices(IAvisosRepository services)
    {
        _repository = services;
    }
    
    
    public async Task<IEnumerable<AvisoDto>> BuscarAvisos(bool isAdm)
    {
        var avisosModel = await _repository.BuscarAvisos(isAdm);

        var avisosDto = new List<AvisoDto>();

        foreach (var avisoModel in avisosModel)
        {
            var aviso = new AvisoDto
            {
                CodColigada = avisoModel.CodColigada,
                Nseq = avisoModel.Nseq,
                Titulo = avisoModel.Titulo,
                Corpo = avisoModel.Corpo,
                Data = avisoModel.Data,
                Ativo = avisoModel.Ativo,
                UsuarioUltimaAlteracao = avisoModel.UsuarioUltimaAlteracao,
                DataUltimaAlteracao = avisoModel.DataUltimaAlteracao,
                Arquivos = avisoModel.Arquivos
            };

            avisosDto.Add(aviso);
        }

        return avisosDto;
    }

    public async Task CadastrarAviso(AvisoDto dto)
    {
        var model = new AvisosModel
        {
            CodColigada = dto.CodColigada,
            Titulo = dto.Titulo,
            Corpo = dto.Corpo,
            Data = dto.Data,
            Ativo = dto.Ativo,
            UsuarioUltimaAlteracao = dto.UsuarioUltimaAlteracao,
            Arquivos = dto.Arquivos
        };


        await _repository.CadastrarAviso(model);
    }

    public async Task EditarAviso()
    {
        throw new NotImplementedException();
    }

    public async Task EnviarArquivosAviso()
    {
        throw new NotImplementedException();
    }

    public async Task<AvisoDto> BuscarAvisoPorId(int nSeq)
    {
        var avisoModel = await _repository.BuscarAvisoPorNSeq(nSeq);

        var aviso = new AvisoDto
        {
            CodColigada = avisoModel.CodColigada,
            Nseq = avisoModel.Nseq,
            Titulo = avisoModel.Titulo,
            Corpo = avisoModel.Corpo,
            Data = avisoModel.Data,
            Ativo = avisoModel.Ativo,
            UsuarioUltimaAlteracao = avisoModel.UsuarioUltimaAlteracao,
            DataUltimaAlteracao = avisoModel.Data,
            Arquivos = avisoModel.Arquivos
        };
        return aviso;
    }

    public async Task<AvisoDto> BuscarArquivos(int nSeq)
    {
        var model = await _repository.BuscarArquivos(nSeq);

        var dto = new AvisoDto();
        
        dto.Arquivos = model.Arquivos;

        return dto;
    }
}