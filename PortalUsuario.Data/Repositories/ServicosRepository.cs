using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Repositories;

public class ServicosRepository : IServicosRepository
{
    private readonly IDbConnection _connection;

    public ServicosRepository(IDbConnection connection)
    {
        _connection = connection;
    }


    public async Task<IEnumerable<ServicosModel>> Select(int codColigada)
    {
        const string query = @"SELECT NSEQ, CODIGOPROCESSO AS CODPROCESSO, DESCRICAO  DESCRICAO " +
                              "FROM RCSERVICOS " +
                              "WHERE CODCOLIGADA = @CODCOLIGADA " +
                              "ORDER BY CODIGOPROCESSO";

        await using var conn = new SqlConnection(_connection.ConnectionString);
        return await conn.QueryAsync<ServicosModel>(query, new { codColigada });
    }
}