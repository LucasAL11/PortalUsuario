using LanguageExt;
using PortalUsuario.Core.Interfaces;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Data.Repositories;
using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Core.Services;

public class PesquisaDeSatisfacaoService : IPesquisaDeSatisfacaoService
{
    private readonly IPesquisaDeSatisfacaoRepository _repository;

    public PesquisaDeSatisfacaoService(string connectionString)
    {
        _repository = new PesquisaDeSatisfacaoRepository(connectionString);
    }
    public async Task<IEnumerable<PesquisaSatisfacaoDTO>> BuscarListaDePesquisaDeSatisfacao()
    {
        var response = await _repository.BuscarListaDePesquisaDeSatisfacao();

        var ListaDePesquisa = new List<PesquisaSatisfacaoDTO>();

        foreach (var pesquisa in response)
        {
            var dto = new PesquisaSatisfacaoDTO
            {
                Id = pesquisa.Id,
                DescricaoNota = pesquisa.DescricaoNota,
                Nota = pesquisa.Nota,
                Observacoes = pesquisa.Observacoes,
                NomeConsultor = pesquisa.NomeUsuario
            };
            
            ListaDePesquisa.Add(dto);
        }

        return ListaDePesquisa;
    }
    
    
    public async Task<IEnumerable<PesquisaSatisfacaoDTO>> BuscarPesquisaDeSatisfacao(string consultor)
    {

        var response = await _repository.BuscarPesquisaDeSatisfacao(consultor);
        
        var ListaDePesquisa = new List<PesquisaSatisfacaoDTO>();

        foreach (var pesquisa in response)
        {
            var dto = new PesquisaSatisfacaoDTO
            {
                Id = pesquisa.Id,
                DescricaoNota = pesquisa.DescricaoNota,
                Nota = pesquisa.Nota,
                Observacoes = pesquisa.Observacoes,
                NomeConsultor = pesquisa.NomeUsuario
            };
            
            ListaDePesquisa.Add(dto);
        }
        
        return ListaDePesquisa;

    }
    
    public async Task<IndiceSatisfacaoDTO> BuscarResultadoPesquisaDeSatisfacao()
    {
        var response = await _repository.BuscarResultadoPesquisaDeSatisfacao();

        var dto = new IndiceSatisfacaoDTO
        {
            Ruim = response.Ruim,
            Horrivel = response.Horrivel,
            Aceitavel = response.Aceitavel,
            Bom = response.Bom,
            Otimo = response.Otimo
        };
        
        return dto;
    }

    
    public async Task ReiniciarPesquisa()
    {
        await _repository.ReiniciarPesquisa();
    }
    
    public async Task EnviarPesquisaDeSatisfacao(PesquisaSatisfacaoDTO dto)
    {
        
        var model = new PesquisaSatisfacaoModel
        {
            Id = dto.Id,
            DescricaoNota = dto.DescricaoNota,
            Nota = dto.Nota,
            Observacoes = dto.Observacoes,
            NomeUsuario = dto.NomeConsultor,
            CodUsuario_RcUsuario = dto.NomeConsultor,
            Enviou = 1 //wtf is that 
        };

        await _repository.EnviarPesquisaDeSatisfacao(model);
    }
}