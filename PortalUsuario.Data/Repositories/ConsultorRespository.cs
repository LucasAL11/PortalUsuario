using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Repositories;

public class ConsultorRespository : IConsultorRespository
{
    private readonly IDbConnection _connection;

    public ConsultorRespository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<ConsultorModel>> Select()
    {
        const string query = @"
                SELECT NOME, DATAANIVERSARIO AS DATADENASCIMENTO
                FROM RCUSUARIO
                WHERE DATAANIVERSARIO IS NOT NULL
                    AND ATIVO = 1
                    AND NOME NOT LIKE 'MESTRE'
                ORDER BY DATAANIVERSARIO";

        using var conn = new SqlConnection(_connection.ConnectionString);
        return await conn.QueryAsync<ConsultorModel>(query);
    }
}