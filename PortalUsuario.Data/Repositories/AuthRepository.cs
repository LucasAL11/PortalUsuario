using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly IDbConnection _connection;

    public AuthRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<UsuarioModel> GetUserData(LoginDto login)
    {
        const string query =
            $@"SELECT CODUSUARIO, NOME, DATAANIVERSARIO, EMAIL, TIPOUSUARIO AS ROLE
                FROM RCUSUARIO WHERE CODUSUARIO = @CodUsuario AND SENHAWEB = @Senha AND ATIVO = 1";

        await using var conn = new SqlConnection(_connection.ConnectionString);
        return await conn.QueryFirstOrDefaultAsync<UsuarioModel>(query, login);
    }

    public async Task AtualizarCookies(string cookies)
    {
        const string query = @"UPDATE COOKIESALPR SET COOKIES = @COOKIES";
        await using var conn = new SqlConnection(_connection.ConnectionString);
        await conn.ExecuteAsync(query);

    }
}