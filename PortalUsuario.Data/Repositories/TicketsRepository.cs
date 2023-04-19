using PortalUsuario.Data.Interfaces;

namespace PortalUsuario.Data.Repositories;

public class TicketsRepository : ITicketsRepository
{
    private readonly string _uriLink;
    
    public TicketsRepository(string uri)
    {
        _uriLink = uri;
    }
    
    public async Task<string> BuscarTickets(string uriParams)
    {
        var uriBuilder = new UriBuilder(uri:_uriLink)
        {
            Query = uriParams
        };
        
        var client = new HttpClient();

        var movieDeskResponse = await client.GetAsync(uriBuilder.Uri);
       
        
        using var response = new StreamReader(movieDeskResponse.Content.ReadAsStreamAsync().Result);
    
        return await response.ReadToEndAsync();

   }
}