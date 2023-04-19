using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Repositories;

public class AvisosRepository :  IAvisosRepository
{

    private readonly IDbConnection _connection;
    public AvisosRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<AvisosModel>> BuscarAvisos(bool isAdm)
    {
        var query = $@"SELECT NSEQ, CODCOLIGADA, TITULO, CORPO, DATA, ATIVO 
	                            FROM RCAVISO
                                {(isAdm ? " WHERE " : " WHERE ATIVO = 1 AND " )}
                                   DATA >= '{DateTime.Today.AddDays(-7):yyyy-MM-d}' AND
	                               DATA <= DATEADD(wk, DATEDIFF(wk, 6, CURRENT_TIMESTAMP), 6 + 7) 
                             ORDER BY DATA DESC";
        
        await using var conn = new SqlConnection(_connection.ConnectionString);
        var response = await conn.QueryAsync<AvisosModel>(query);
        return response;
    }

    public async Task<AvisosModel> BuscarAvisoPorNSeq(int nSeq)
    {
        const string query = @"SELECT NSEQ, CODCOLIGADA, TITULO, CORPO, DATA, ATIVO 
	                            FROM RCAVISO WHERE NSEQ = @NSEQ";
        
        await using var conn = new SqlConnection(_connection.ConnectionString);
        var response = await conn.QuerySingleAsync<AvisosModel>(query, new { NSEQ = nSeq });
        return response;
    }

    public async Task<AvisosModel> BuscarArquivos(int nSeq)
    {
        const string query = @"SELECT ARQUIVOS
	                            FROM RCAVISO WHERE NSEQ = @NSEQ";

        await using var conn = new SqlConnection(_connection.ConnectionString);
        var response = await conn.QuerySingleOrDefaultAsync<AvisosModel>(query, new { NSEQ = nSeq });
        return response;
    }

    public async Task CadastrarAviso(AvisosModel model)
    {
        const string query =
            @"INSERT INTO RCAVISO (CODCOLIGADA,TITULO,CORPO,DATA,ATIVO, USUARIOULTIMAALTERACAO, DATAULTIMAALTERACAO)
	                            VALUES (@CODCOLIGADA, @TITULO, @CORPO, @DATA, @ATIVO, @USUARIOULTIMAALTERACAO, GETDATE());";
        
        await using var conn = new SqlConnection(_connection.ConnectionString);
        await conn.ExecuteAsync(query, model);
    }
}