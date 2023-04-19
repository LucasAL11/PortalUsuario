namespace PortalUsuario.Core.Interfaces;

public interface ITicketsServices
{
    Task<string> BuscarQuantidadeDeTicket(string usuario);
    Task<string> BuscarQuantidadeDeTicketAbertos(string usuario);
    Task<string> BuscarQuantidadeTicketsResolvidos(string usuario);
}