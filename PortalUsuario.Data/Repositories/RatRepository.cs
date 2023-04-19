using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Repositories;

public class RatRepository : IRatRepository
{
    private readonly IDbConnection _connection;

    public RatRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<RatModel>> Selecionar(ParametrosRatDTO parametros)
    {
        var status = parametros.status switch
        {
            0 => " 'A' ",
            1 => " !A ",
            2 => " 'A', 'F' ",
            _ => throw new ArgumentOutOfRangeException()
        };

        const string query = @"
                SELECT A.IDRAT, A.STATUS, ISNULL(A.DATA, GETDATE()) DATA, ISNULL(A.TOTAL, 0) TOTALHORAS, ISNULL(B.NOME, '') CLIENTE,
                ISNULL((SELECT X.CODTDO + ' - ' + X.DESCRICAO FROM TIPODOCUMENTO X WHERE X.CODEMPRESA = A.CODCOLIGADA AND X.CODTDO = A.TIPO), '') TIPO,
                ISNULL((SELECT DESCRICAO FROM RCCONTRATO X WHERE X.CODCOLIGADA = A.CODCOLIGADA AND X.CODCONTRATO = A.CODCONTRATO AND A.CODCFO=X.CODCFO AND X.CODCOLCFO=A.CODCOLCFO), '') CONTRATO,
                ISNULL(A.CODCOLCFO, '') CODCOLCFO,
                ISNULL(A.CODCFO, '') CODCFO,
                ISNULL(A.REFEICAO, 0) REFEICAO
                FROM RCRAT A
                JOIN CLIENTE B ON A.CODCOLCFO = B.CODEMPRESA AND A.CODCFO = B.CODCLIENTE
                WHERE A.CODCOLIGADA = @codColigada
                AND A.CODUSUARIO = @codUsuario
                AND A.STATUS IN (@status)
                AND A.DATA >= @dataInicial
                AND A.DATA <= @dataFinal
                ORDER BY A.DATA";

        await using var conn = new SqlConnection(_connection.ConnectionString);
        return await conn.QueryAsync<RatModel>(query);;
    }

    public async Task Atualizar(RatModel model)
    {
        const string query =
            @"UPDATE RCRAT SET USUARIOS = @Usuario, HMCHEGADA = @HmChegada, HMSAIDA = @HmSaida, HTCHEGADA = @HtChegada, 
                            HTSAIDA = @HtSaida, KM = @Km, VALORHOTEL = @ValorHotel, REFEICAO = @Refeicao, VALORPEDAGIO = @ValorPedagio, 
                            TIPO = @Tipo, TOTAL = @Total, CODCONTRATO = @CodContrato, DATAULTIMAALTERACAO = @DtUltimaAlteracao, PLACA = @Placa, 
                            USUARIOALTERACAO = @UsuarioUltimaAlteracao, VALORALMOCO = @ValorAlmoco, VALORJANTA = @ValorJanta, 
                            VALORESTACIONAMENTO = @ValorEstacionamento 
	                            
                                WHERE CODCOLIGADA = @Codcoligada 
			                        AND IDRAT = @IdRat ";

        await using var conn = new SqlConnection(_connection.ConnectionString);
        await conn.ExecuteAsync(query);
    }

    public async Task FinalizarRat(int idRat)
    {
        const string query = @"UPDATE RCRAT SET STATUS = 'F', 
                 DATAULTIMAALTERACAO = GETDATE(), 
                 DATAENTREGA = GETDATE(),
                 HORAENTREGA = CONVERT(CHAR(5),GETDATE(),108) 
             WHERE 
                 CODCOLIGADA = 1 
               AND IDRAT = @IdRat";

        await using var conn = new SqlConnection(_connection.ConnectionString);
        await conn.ExecuteAsync(query, new { idRat });
    }

    public async Task Inserir(RatModel model)
    {
        const string query = @"EXEC ZRC_CRIARAT @TIPOOPERACAO, @CODCOLIGADA, @CODUSUARIO, @DATA, @CODCFO, @CODCOLCFO, 
                                @CODCONTRATO, @CODTDO, @OBSERVACAO, @PLACA, null, null, @LOTE, @GERARAT, @HOMEOFFICE";

        using var conn = new SqlConnection(_connection.ConnectionString);
        await conn.ExecuteAsync(query, model);
    }

    public async Task<IEnumerable<RatModel>> BuscarCamposDesabilitados(int idRat, string usuario)
    {
        const string query = @"SELECT A.DATA, B.NOME CLIENTE
        FROM RCRAT A, CLIENTE B
            WHERE A.CODCOLIGADA = 1
        AND A.CODUSUARIO = @CODUSUARIO
        AND A.CODCOLCFO = B.CODEMPRESA 
        AND A.CODCFO = B.CODCLIENTE
        AND A.IDRAT = @IRAT";

        await using var conn = new SqlConnection(_connection.ConnectionString);
        return await conn.QueryAsync<RatModel>(query, new { CODUSUARIO = usuario, IRAT = idRat });
       
    }

    public async Task<IEnumerable<DespesaModel>> BuscarDespesa()
    {
        throw new NotImplementedException();
    }

    public async Task<int> ContarQuantidadeRat(string codUsuario, int codColigada)
    {
        const string query =
            @"SELECT COUNT(*) ABERTOS FROM RCRAT WHERE CODCOLIGADA = @CODCOLIGADA AND CODUSUARIO = @CODUSUARIO
                                    AND DATA > '2019/01/01'
                                    AND DATA <= GETDATE()
                                    AND STATUS = 'A'";

        await using var conn = new SqlConnection(_connection.ConnectionString);
        var response =
            await conn.QueryFirstOrDefaultAsync<int>(query, new { CODCOLIGADA = codColigada, CODUSUARIO = codUsuario });

        return response;
    }
    
    public async Task ReabriRat(int idRat)
    {
        throw new NotImplementedException();
    }

    public async Task SelecionarPorIdFaturamento(int idRat)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RatModel>> SelecionarRatPorId(int idRat)
    {
        throw new NotImplementedException();
    }
    
    public async Task<IEnumerable<RelatorioPowerBiModel>> BuscarRelatoriosPbi()
    {
        throw new NotImplementedException();
    }
    
}