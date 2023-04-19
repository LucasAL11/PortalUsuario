namespace PortalUsuario.Data.Interfaces;

public interface ITicketsRepository
{
    Task<string> BuscarTickets(string uriParams);
}