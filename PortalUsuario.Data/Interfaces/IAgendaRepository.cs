using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Interfaces;

public interface IAgendaRepository
{
    Task<IEnumerable<AgendaModel>> BuscarDados(ParametrosAgendaDTO parametrosAgendaDto);
    Task<IEnumerable<AgendaModel>> BuscarEventoDoDia(DateTime data);
    Task<IEnumerable<ConsultorModel>> BuscarConsultores();
    Task<IEnumerable<ClienteModel>> BuscarListaDeClientes(short codColigada);
    Task BuscarListaContratos(short codColigada);
    Task BuscarListaDeTipos(string codContrato, short codColigada);
    Task<IEnumerable<ListaRatModel>> BuscarListaRaTs(DateTime data, short codcoligada);
    Task<RatModel> BuscarRat(int id, DateTime data);
    Task<bool> CadastrarRat(RatModel rat, int lote);
    Task<int> BuscarNSeqRatAgenda(string codUsuario, short codColigada);
    Task<IEnumerable<string>> BuscarEntreDatas();
    
}