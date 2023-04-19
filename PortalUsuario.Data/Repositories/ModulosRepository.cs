using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Repositories;

public class ModulosRepository : IModulosRepository
{
    private IModulosRepository _modulosRepositoryImplementation;

    private readonly IDbConnection _connection;

    public ModulosRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<SistemasModel>> GetFromDb()
    {
        const string query = @"SELECT CODSISTEMA, NOMESISTEMA FROM RCSISTEMAS ORDER BY NOMESISTEMA";

        await using var conn = new SqlConnection(_connection.ConnectionString);
        var response = await conn.QueryAsync<SistemasModel>(query);

        return response;
    }
}