using PortalUsuario.Core.Interfaces;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Data.Repositories;

namespace PortalUsuario.Core.Services;

public class TicketsServices : ITicketsServices
{
    private const string UriLink = "https://api.movidesk.com/public/v1/tickets";

    private readonly ITicketsRepository _repository;

    public TicketsServices()
    {
        _repository = new TicketsRepository(UriLink);
    }

    public async Task<string> BuscarQuantidadeDeTicket(string usuario)
    {
        try
        {
            var uriParams =
                $"?token=8afc5d15-d5da-4e53-8fda-3f75c355ff2a&" +
                $"$select=id,type,origin,status,createdBy&$expand=owner&" +
                $"$filter=owner/businessName eq '{usuario}'";

            var response = await _repository.BuscarTickets(uriParams);


            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<string> BuscarQuantidadeDeTicketAbertos(string usuario)
    {
        try
        {
            var uriParams =
                $"?token=8afc5d15-d5da-4e53-8fda-3f75c355ff2a&" +
                $"$select=id,type,origin,status,createdBy,resolvedIn,closedIn,reopenedIn&$expand=owner&" +
                $"$filter=owner/businessName eq '{usuario}' and (baseStatus eq 'InAttendance' or baseStatus eq 'New')";

            var response = await _repository.BuscarTickets(uriParams);


            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<string> BuscarQuantidadeTicketsResolvidos(string usuario)
    {
        try
        {
            var uriParams =
                $"?token=8afc5d15-d5da-4e53-8fda-3f75c355ff2a&" +
                $"$select=id,type,origin,status,createdBy,resolvedIn,closedIn,reopenedIn&" +
                $"$expand=owner&$filter=owner/businessName eq '{usuario}' and resolvedIn ne null";

            var response = await _repository.BuscarTickets(uriParams);


            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}