namespace PortalUsuario.Data.Repositories;

public abstract class BaseRepository
{
    protected readonly string ConnectionString;

    protected BaseRepository(string connectionString)
    {
        ConnectionString = connectionString;
    } 
}