using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using PortalUsuario.Data.Interfaces;
using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Enum;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Data.Repositories;

public class AgendaRepository : IAgendaRepository
{
    private readonly IDbConnection _connection;
    public AgendaRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<AgendaModel>> BuscarDados(ParametrosAgendaDTO parametrosAgendaDto)
    {
        var query = @"SELECT
                    RCAGENDA.NSEQ as Id,
                    RCCONTRATO.DESCAGENDA AS Subject,
                    RCAGENDA.DATA StartTime,
                    RCAGENDA.DATA EndTime,
                    ISNULL(RCRAT.IDRAT, 0) IDRAT,
                    RCAGENDA.STATUS,
                    RCAGENDA.CODUSUARIO,
                    FCFO.NOME NOMECLIENTE,
                    CASE WHEN RCAGENDA.CODCONTRATO = '000976' THEN 1
                    ELSE CASE WHEN FCFO.CODCLIENTE = 'C00169' THEN 6
                    ELSE CASE WHEN CODCLIENTE = 'S00002'
                        OR FCFO.CODCLIENTE = 'S00004'
                        OR FCFO.CODCLIENTE = 'S00003'
                        OR FCFO.CODCLIENTE = 'S00005'
                        OR FCFO.CODCLIENTE = 'S00006' THEN 4
                    ELSE CASE WHEN FCFO.CODCLIENTE = 'C00168' THEN 5 ELSE CASE WHEN RCAGENDA.CODTDO = 'RAT03' THEN 2 ELSE 3 
                        END END END END 
                        END COR,
                    ISNULL(RCAGENDA.HOMEOFFICE, 0) HOMEOFFICE,
                    RCUSUARIO.IMAGEPROFILE,
                    RCUSUARIO.NOME
                FROM
                    CLIENTE AS FCFO 
                    INNER JOIN RCAGENDA ON FCFO.CODCLIENTE = RCAGENDA.CODCFO
                    AND FCFO.CODEMPRESA = RCAGENDA.CODCOLCFO
                    LEFT OUTER JOIN RCRAT ON RCAGENDA.CODCOLIGADA = RCRAT.CODCOLIGADA
                    AND RCAGENDA.IDRAT = RCRAT.IDRAT
                    INNER JOIN RCUSUARIO ON RCAGENDA.CODUSUARIO = RCUSUARIO.CODUSUARIO
                    INNER JOIN RCVEICULO ON RCVEICULO.CODCOLIGADA = RCAGENDA.CODCOLIGADA
                    AND RCVEICULO.PLACA = RCAGENDA.PLACA
                    INNER JOIN RCCONTRATO ON RCCONTRATO.CODCOLIGADA = RCAGENDA.CODCOLIGADA
                    AND RCCONTRATO.CODCFO = RCAGENDA.CODCFO
                    AND RCCONTRATO.CODCONTRATO = RCAGENDA.CODCONTRATO
                WHERE
                    RCAGENDA.CODTDO != 'RAT51'
                    AND RCAGENDA.DATA >= @DATAINICIAL
                    AND RCAGENDA.DATA <= @DATAFIM";

        var buscarPor = parametrosAgendaDto.TipoDeBusca switch
        {
            ETipoDeBusca.USUARIO => "RCUSUARIO.NOME",
            ETipoDeBusca.CLIENTE => "FCFO.NOME",
            ETipoDeBusca.CONTRATO => "RCUSUARIO.NOME",
            ETipoDeBusca.OBSERVACAO => "RCCONTRATO.DESCRICAO",
            ETipoDeBusca.TODOS => "",
            _ => ""
        };

        if (!string.IsNullOrWhiteSpace(parametrosAgendaDto.ValorBusca))
        {
            if (parametrosAgendaDto.TipoDeBusca is not ETipoDeBusca.CLIENTE)
            {
                query = $"{query} AND {buscarPor} LIKE '{parametrosAgendaDto.ValorBusca}' " +
                        $" OR RCCONTRATO.DESCAGENDA AND '{parametrosAgendaDto.ValorBusca}' ";
            }
        }
        
        if (parametrosAgendaDto.HomeOffice) query = $"{query}{" AND RCAGENDA.HOMEOFFICE = 1  "}";

        if (parametrosAgendaDto.Externo) query = $"{query}{" AND RCAGENDA.CODTDO = 'RAT03' "}";

        if (parametrosAgendaDto.Interno)
            query = $"{query}" +
                    $"{"  AND RCAGENDA.CODCONTRATO != '000976' "}" +
                    $"{"  AND FCFO.CODCLIENTE "}" +
                    $"{" NOT IN('S00002', 'S00004', 'S00003', 'S00005','S00006', 'C00168', 'C00169') "}";
        //+ @" AND RCAGENDA.CODTDO != 'RAT03' ");
        if (parametrosAgendaDto.Externo) query.Replace(" 'C00168', ", "");

        if (parametrosAgendaDto.Ausente)
            query = $"{query}{" AND CODCLIENTE IN('S00002', 'S00004', 'S00003, 'S00005','S00006' "}";

        query = $"{query}{" ORDER BY DATAINICIAL OFFSET 5 ROWS FETCH NEXT 5 ROWS ONLY "}";
        
        await using var conn = new SqlConnection(_connection.ConnectionString);
        var response = await conn.QueryAsync<AgendaModel>(query, parametrosAgendaDto);
        return response;
    }


    public Task<IEnumerable<AgendaModel>> BuscarEventoDoDia(DateTime data)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ConsultorModel>> BuscarConsultores()
    {
        const string query = "SELECT CODUSUARIO,NOME,ISNULL(ULTIMACOLIGADA, 1) AS CODCOLIGADA FROM RCUSUARIO WHERE ATIVO = 1";
        
        await using var conn = new SqlConnection(_connection.ConnectionString);
        var response = await conn.QueryAsync<ConsultorModel>(query);

        return response;
    }

    public Task<IEnumerable<ClienteModel>> BuscarListaDeClientes(short codColigada)
    {
        throw new NotImplementedException();
    }
    
    public Task BuscarListaContratos(short codColigada)
    {
        throw new NotImplementedException();
    }

    public Task BuscarListaDeTipos(string codContrato, short codColigada)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ListaRatModel>> BuscarListaRaTs(DateTime data, short codcoligada)
    {
        throw new NotImplementedException();
    }

    public Task<RatModel> BuscarRat(int id, DateTime data)
    {
        throw new NotImplementedException();
    }
    
    public Task<bool> CadastrarRat(RatModel rat, int lote)
    {
        throw new NotImplementedException();
    }

    public Task<int> BuscarNSeqRatAgenda(string codUsuario, short codColigada)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<string>> BuscarEntreDatas()
    {
        throw new NotImplementedException();
    }
}