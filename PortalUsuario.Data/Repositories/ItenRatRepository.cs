using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Repositories;

public class ItenRatRepository : IItenRatRepository
{
    private IDbConnection _connection;
    public ItenRatRepository(IDbConnection connection)
    {
        _connection = connection;
    }


    public async Task AdicionarItem(RatItensModel model)
    {
        const string query =
            @"INSERT INTO RCITMRAT (CODCOLIGADA, IDRAT, NSEQITMRAT, DATA , TIPO, DESCRICAO, QTDEHORAS, CODTB3FLX)
        VALUES (1, @IDRefRAT,@NSEQ, @DATA, F',@DESCRICAO, @QTDHORAS, @TIPO)";

        await using var conn = new SqlConnection(_connection.ConnectionString);
        await conn.ExecuteAsync(query, model);

    }

    public async Task EditarItem(RatItensModel model)
    {
        const string query =
            $@"UPDATE RCITMRAT SET DESCRICAO = @DESCRICAO, QTDEHORAS = @QTDHORAS," 
            + $@"CODTB3FLX = @TIPO  WHERE CODCOLIGADA = 1 AND IDRAT = @IDRefRAT AND NSEQITMRAT = @NSEQ";

        await using var conn = new SqlConnection(_connection.ConnectionString);
        await conn.ExecuteAsync(query, model);
    }

    public async Task RemoverItem(int idRat, int sequencial)
    {
       const string query = "DELETE FROM RCITMRAT WHERE CODCOLIGADA = 1 AND IDRAT = @IDRAT AND NSEQITMRAT = @SEQUENCIAL";
       
       await using var conn = new SqlConnection(_connection.ConnectionString);
       await conn.ExecuteAsync(query, new {IDRAT = idRat, SEQUENCIAL = sequencial});
    }

    public async Task<IEnumerable<RatItensModel>> BuscarItens(int idRat)
    {
        const string query = @"SELECT NSEQITMRAT AS SEQUENCIAL,
                                          TIPO AS STATUS,
                                          QTDEHORAS AS HORAS,
                                          CODTB3FLX AS TIPO,
                                          DESCRICAO,
                                          IDRAT AS ID_REFRAT,
                                          A.CODSISTEMA AS MODULO,
										  NOMESISTEMA,
                                          CODCOLIGADA,
                                          TIPO,
                                          DATA,
                                          IDSERVICO AS SERVICO

                                    FROM RCITMRAT A 
									inner join RCSISTEMAS B on A.CODSISTEMA = B.CODSISTEMA
                                        WHERE IDRAT = @IDRAT";
        
        await using var conn = new SqlConnection(_connection.ConnectionString);
        var response = await conn.QueryAsync<RatItensModel>(query, new{ IDRAT = idRat });

        return response;
    }

    public async Task<RatItensModel> BuscarItemUnicoRat(int idRat, int sequencial)
    {
        const string query = @"SELECT NSEQITMRAT AS SEQUENCIAL,
                                          TIPO AS STATUS,
                                          QTDEHORAS AS HORAS,
                                          CODTB3FLX AS TIPO,
                                          DESCRICAO,
                                          IDRAT AS ID_REFRAT,
                                          A.CODSISTEMA AS MODULO,
										  NOMESISTEMA,
                                          CODCOLIGADA,
                                          TIPO,
                                          DATA,
                                          IDSERVICO AS SERVICO
                                    FROM RCITMRAT A 
									INNER JOIN RCSISTEMAS B on A.CODSISTEMA = B.CODSISTEMA
                                        WHERE IDRAT = @IDRAT
                                        AND NSEQITMRAT = @SEQUENCIAL";
        
        await using var conn = new SqlConnection(_connection.ConnectionString);
        var response = await conn.QueryFirstOrDefaultAsync<RatItensModel>(query, new{ IDRAT = idRat , SEQUENCIAL = sequencial });

        return response;
    }

   
  
    

    public async Task<IEnumerable<TipoRatModel>> BuscarOpcoesTipoRat()
    {
        const string query = @"SELECT CODCLASSIFICA3, DESCRICAO
	                                FROM CLASSIFICA3
		                                WHERE CODEMPRESA = 1
		                                ORDER BY DESCRICAO";
        
        await using var conn = new SqlConnection(_connection.ConnectionString);
        var response = await conn.QueryAsync<TipoRatModel>(query);

        return response;
    }

    public async Task AtualizarHorarioItemRat(int idRat, decimal horas)
    {
        const string query = "UPDATE RCITMRAT SET QTDEHORAS = @QTDEHORAS WHERE IDRAT = @IDRAT;";

        await using var conn = new SqlConnection(_connection.ConnectionString);
        await conn.ExecuteAsync(query, new { QTDEHORAS= horas, IDRAT = idRat });
    }
}