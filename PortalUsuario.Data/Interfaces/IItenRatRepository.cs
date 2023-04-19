
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Interfaces;

public interface IItenRatRepository
{
    Task AdicionarItem(RatItensModel model);
    Task EditarItem(RatItensModel model);
    Task RemoverItem(int idRat, int sequencial);
    Task<IEnumerable<RatItensModel>> BuscarItens(int idRat);
    Task<RatItensModel> BuscarItemUnicoRat(int idRat, int sequencial);
    Task<IEnumerable<TipoRatModel>> BuscarOpcoesTipoRat();
    Task AtualizarHorarioItemRat(int idRat, decimal horas);



}