using Dapper;
using Microsoft.Data.SqlClient;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Repositories;

public class PesquisaDeSatisfacaoRepository : BaseRepository, IPesquisaDeSatisfacaoRepository
{
    public PesquisaDeSatisfacaoRepository(string connectionString)
        : base(connectionString)
    {
    }

    public async Task EnviarPesquisaDeSatisfacao(PesquisaSatisfacaoModel model)
    {
        const string query = @"INSERT INTO RCPORTALPESQUISASATISFACAO 
	                        (NOMECONSULTOR, ENVIOU, NOTA, OBSERVACOES, CODUSUARIO_RCUSUARIO, DESCRICAONOTA, DATAENVIO) 
	                        VALUES (@NOMEUSUARIO, @ENVIOU, @NOTA, @OBSERVACOES, @CODUSUARIO_RCUSUARIO, @DESCRICAONOTA, GETDATE())";

        await using var conn = new SqlConnection(ConnectionString);
        await conn.ExecuteAsync(query, model);
    }
    
    public async Task ReiniciarPesquisa()
    {
        const string query = "TRUCATE TABLE RCPORTALPESQUISASATISFACAO";

        await using var conn = new SqlConnection(ConnectionString);
        await conn.ExecuteAsync(query);
    }

    public async Task<IndiceSatisfacaoModel> BuscarResultadoPesquisaDeSatisfacao()
    {
        const string query = $@"SELECT COUNT(*) AS BOM, 
                            (SELECT COUNT(*) AS OTIMO FROM RCPORTALPESQUISASATISFACAO WHERE DESCRICAONOTA = 'Aceitável') AS Aceitavel, 
                            (SELECT COUNT(*) AS OTIMO FROM RCPORTALPESQUISASATISFACAO WHERE DESCRICAONOTA = 'Horrível') AS Horrivel,
                            (SELECT COUNT(*) AS OTIMO FROM RCPORTALPESQUISASATISFACAO WHERE DESCRICAONOTA = 'Ruim') AS Ruim,
                            (SELECT COUNT(*) AS OTIMO FROM RCPORTALPESQUISASATISFACAO WHERE DESCRICAONOTA = 'Ótimo') AS Otimo
                        FROM RCPORTALPESQUISASATISFACAO"; 
                            

        await using var conn = new SqlConnection(ConnectionString);
        var response = await conn.QueryFirstAsync<IndiceSatisfacaoModel>(query);
        return response;
    }

    public async Task<IEnumerable<PesquisaSatisfacaoModel>> BuscarListaDePesquisaDeSatisfacao()
    {
        const string query =
            "SELECT TOP 100 ID,NOMECONSULTOR, ENVIOU, OBSERVACOES, CODUSUARIO_RCUSUARIO, DATAENVIO,DESCRICAONOTA,NOTA FROM RCPORTALPESQUISASATISFACAO";

        await using var conn = new SqlConnection(ConnectionString);
        var response = await conn.QueryAsync<PesquisaSatisfacaoModel>(query);
        return response;
    }

    public async Task<IEnumerable<PesquisaSatisfacaoModel>> BuscarPesquisaDeSatisfacao(string consultor)
    {
        const string query =
            @"SELECT TOP 100 ID,NOMECONSULTOR, ENVIOU, OBSERVACOES, CODUSUARIO_RCUSUARIO, " +
            "DATAENVIO,DESCRICAONOTA,NOTA FROM RCPORTALPESQUISASATISFACAO WHERE CODUSUARIO_RCUSUARIO = @CODUSUARIO_RCUSUARIO";

        await using var conn = new SqlConnection(ConnectionString);
        var response = await conn.QueryAsync<PesquisaSatisfacaoModel>(query, new { CODUSUARIO_RCUSUARIO = consultor });
        return response;
    }
}