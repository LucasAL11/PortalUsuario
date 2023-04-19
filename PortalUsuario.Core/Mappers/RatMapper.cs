using PortalUsuario.Shared.DTO;
using PortalUsuario.Shared.Models;

namespace PortalUsuario.Core.Mappers;

internal static class RatMapper
{
    internal static IEnumerable<RatDto> ToDTO(this IEnumerable<RatModel> model)
    {
        IEnumerable<RatDto> ratDtos = new List<RatDto>();

        foreach (var rat in model)
        {
            var ratDto = new RatDto
            {
                IDRAT = rat.IDRAT,
                NSEQ = rat.NSEQ,
                STATUS = rat.STATUS,
                USUARIOS = rat.USUARIOS,
                CODUSUARIO = rat.CODUSUARIO,
                USUARIOALTERACAO = rat.USUARIOALTERACAO,
                DATA = rat.DATA,
                DATAULTIMAALTERACAO = rat.DATAULTIMAALTERACAO,
                DATAINICIAL = rat.DATAINICIAL,
                DATAFIM = rat.DATAFIM,
                HMCHEGADA = rat.HMCHEGADA,
                HMSAIDA = rat.HMSAIDA,
                HTCHEGADA = rat.HTCHEGADA,
                HTSAIDA = rat.HTSAIDA,
                TOTAL = rat.TOTAL,
                KM = rat.KM,
                TIPO = rat.TIPO,
                TIPOAGENDA = rat.TIPOAGENDA,
                VALORESTACIONAMENTO = rat.VALORESTACIONAMENTO,
                VALORJANTA = rat.VALORJANTA,
                VALORALMOCO = rat.VALORALMOCO,
                VALORPEDAGIO = rat.VALORPEDAGIO,
                VALORHOTEL = rat.VALORHOTEL,
                REFEICAO = rat.REFEICAO,
                CODTDO = rat.CODTDO,
                CODCOLIGADA = rat.CODCOLIGADA,
                CODCFO = rat.CODCFO,
                CODCOLCFO = rat.CODCOLCFO,
                CODCOLCFOVISUALIZACAO = rat.CODCOLCFOVISUALIZACAO,
                CLIENTE = rat.CLIENTE,
                CODCONTRATO = rat.CODCONTRATO,
                PLACA = rat.PLACA,
                ATENDIMENTO = rat.ATENDIMENTO,
                TIPOOPERACAO = rat.TIPOOPERACAO,
                OBSERVACAO = rat.OBSERVACAO,
                CONTRATO = rat.CONTRATO,
                GeraRAT = rat.GeraRAT,
                HomeOffice = rat.HomeOffice,
                IDFATURAMENTORC = rat.IDFATURAMENTORC,
            };
            IEnumerable<RatDto> enumerable = ratDtos.Append(ratDto);



            

            foreach (var item in ratDto.Itens.Select(item => new RatItensDto
                     {
                         CodColigada = item.CodColigada,
                         Id = item.Id,
                         Status = item.Status,
                         Horas = item.Horas,
                         Modulo = item.Modulo,
                         Servico = item.Servico,
                         Tipo = item.Tipo,
                         GetTipo = item.GetTipo,
                         Descricao = item.Descricao,
                         Id_RefRat = item.Id_RefRat,
                         Data = item.Data,
                         NomeSistema = item.NomeSistema,
                         Operacao = item.Operacao
                     }))
            {
                
            }
            
            
        }

        return ratDtos;
    }
}